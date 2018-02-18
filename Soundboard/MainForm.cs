using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Web;
using YoutubeExplode;
using YoutubeExplode.Models.MediaStreams;
using NAudio.Wave;
using EventHook;
using YoutubeExplode.Models;

namespace Soundboard
{
    public partial class MainForm : Form
    {

        private SoundPlayer m_remotePlayer;
        private SoundPlayer m_localPlayer;

        private YoutubeClient m_youtubeClient;

        public float RemoteVolumeValue { get { return (1f * remoteVolume.Value * masterVolume.Value) / 10000f; } }
        public float LocalVolumeValue { get { return (1f * localVolume.Value * masterVolume.Value) / 10000f; } }

        private int soundIndexWaitingForKeySetup = -1;

        public MainForm()
        {
            InitializeComponent();

            if (Preferences.Default.Filenames == null)
                Preferences.Default.Filenames = new System.Collections.Specialized.StringCollection();

            if (Preferences.Default.Keys == null)
                Preferences.Default.Keys = new System.Collections.Specialized.StringCollection();

            if (Preferences.Default.YoutubeNames == null)
                Preferences.Default.YoutubeNames = new System.Collections.Specialized.StringCollection();

            m_youtubeClient = new YoutubeClient();

            m_remotePlayer = new SoundPlayer(Preferences.Default.RemoteDevice);
            m_localPlayer = new SoundPlayer(Preferences.Default.LocalDevice);

            m_remotePlayer.SetVolume(RemoteVolumeValue);
            m_localPlayer.SetVolume(LocalVolumeValue);

            RefreshSoundList();
            LoadAndRefreshVolumesFromSettings();

            KeyboardWatcher.Start();
            KeyboardWatcher.OnKeyInput += OnKeyboardInput;
        }

        private void OnKeyboardInput(object sender, KeyInputEventArgs e)
        {
            if(e.KeyData.EventType == KeyEvent.down)
            {
                if(soundIndexWaitingForKeySetup >= 0)
                    SetupKey(soundIndexWaitingForKeySetup, e.KeyData.Keyname);
                else
                {
                    if (e.KeyData.Keyname == "NumPad0")
                        StopSound();
                    for (int i = 0; i < Preferences.Default.Keys.Count; i++)
                    {
                        if (Preferences.Default.Keys[i] == e.KeyData.Keyname)
                            PlaySound(Preferences.Default.Filenames[i]);
                    }
                }
            }
        }

        private void RefreshSoundList()
        {
            soundList.Rows.Clear();

            for (int i = 0; i < Preferences.Default.Filenames.Count; i++)
                soundList.Rows.Add(new string[] { Preferences.Default.YoutubeNames[i], "Play", Preferences.Default.Keys[i] });
        }

        private void LoadAndRefreshVolumesFromSettings()
        {
            remoteVolume.Value = Preferences.Default.RemoteVolume;
            localVolume.Value = Preferences.Default.LocalVolume;
            masterVolume.Value = Preferences.Default.MasterVolume;
        }

        private async void downloadButton_Click(object sender, EventArgs e)
        {
            string id = YoutubeClient.ParseVideoId(youtubeURL.Text);
            Video video = await m_youtubeClient.GetVideoAsync(id);
            string name = video.Title;

            string filepath = await DownloadAudio(id);

            AddSound(id, name, filepath);

            if (string.IsNullOrEmpty(filepath) == false)
                PlaySound(filepath);
        }

        public async Task<string> DownloadAudio(string id)
        {
            MediaStreamInfoSet audioStreamInfoSet = await m_youtubeClient.GetVideoMediaStreamInfosAsync(id);

            string filename = null;

            foreach (AudioStreamInfo audioStreamInfo in audioStreamInfoSet.Audio)
            {
                if (audioStreamInfo.AudioEncoding != AudioEncoding.Opus && audioStreamInfo.AudioEncoding != AudioEncoding.Vorbis)
                {
                    string extension = audioStreamInfo.Container.GetFileExtension();
                    filename = string.Format("{0}.{1}", id, extension);

                    await m_youtubeClient.DownloadMediaStreamAsync(audioStreamInfo, "Library\\" + filename);
                }
            }

            return filename;
        }

        private void AddSound(string id, string name, string filename)
        {
            soundList.Rows.Add(new object[] { name, "Play", "None" });
            Preferences.Default.Filenames.Add(filename);
            Preferences.Default.Keys.Add("None");
            Preferences.Default.YoutubeNames.Add(name);
            Preferences.Default.Save();
        }

        public void PlaySound(string filepath)
        {
            m_remotePlayer.PlaySound(filepath);
            m_localPlayer.PlaySound(filepath);
        }

        public void StopSound()
        {
            m_remotePlayer.Stop();
            m_localPlayer.Stop();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm(this);
            settingsForm.Show();
        }

        public void OnRemoteDeviceChange()
        {
            m_remotePlayer.Dispose();
            m_remotePlayer = new SoundPlayer(Preferences.Default.RemoteDevice);
        }

        public void OnLocalDeviceChange()
        {
            m_localPlayer.Dispose();
            m_localPlayer = new SoundPlayer(Preferences.Default.LocalDevice);
        }

        private void OnVolumeChanged(object sender, EventArgs e)
        {
            m_remotePlayer.SetVolume(RemoteVolumeValue);
            m_localPlayer.SetVolume(LocalVolumeValue);

            if(sender == remoteVolume)
                Preferences.Default.RemoteVolume = remoteVolume.Value;
            if(sender == localVolume)
                Preferences.Default.LocalVolume = localVolume.Value;
            if(sender == masterVolume)
                Preferences.Default.MasterVolume = masterVolume.Value;
            Preferences.Default.Save();
        }

        private void soundList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var grid = (DataGridView)sender;

            if (e.RowIndex >= 0)
            {
                if (grid.Columns[e.ColumnIndex] == playColumn)
                {
                    PlaySound(Preferences.Default.Filenames[e.RowIndex]);
                }
                else if(grid.Columns[e.ColumnIndex] == keyColumn)
                {
                    soundIndexWaitingForKeySetup = e.RowIndex;
                    grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "...";
                }
            }

        }

        public void SetupKey(int index, string key)
        {
            soundIndexWaitingForKeySetup = -1;
            Action action = () => { soundList.Rows[index].Cells[keyColumn.Index].Value = key; };
            soundList.Invoke(action);
            Preferences.Default.Keys[index] = key;
            Preferences.Default.Save();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
