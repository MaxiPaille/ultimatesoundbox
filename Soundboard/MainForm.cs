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
using NAudio.Vorbis;
using EventHook;

namespace Soundboard
{
    public partial class MainForm : Form
    {

        private SoundPlayer m_remotePlayer;
        private SoundPlayer m_localPlayer;

        private YoutubeClient m_youtubeClient;

        public float RemoteVolumeValue { get { return (1f * remoteVolume.Value * masterVolume.Value) / 10000f; } }
        public float LocalVolumeValue { get { return (1f * localVolume.Value * masterVolume.Value) / 10000f; } }

        public MainForm()
        {
            InitializeComponent();

            if (Preferences.Default.Filenames == null)
                Preferences.Default.Filenames = new System.Collections.Specialized.StringCollection();

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
                Console.WriteLine(e.KeyData.Keyname);
            }
        }

        private void RefreshSoundList()
        {
            soundList.Items.Clear();

            for (int i = 0; i < Preferences.Default.Filenames.Count; i++)
                soundList.Items.Add(Preferences.Default.Filenames[i]);
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

            string filepath = await DownloadAudio(id);

            AddSound(id, filepath);

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

        private void AddSound(string id, string filename)
        {
            soundList.Items.Add(filename);
            Preferences.Default.Filenames.Add(filename);
            Preferences.Default.Save();
        }

        public void PlaySound(string filepath)
        {
            m_remotePlayer.PlaySound(filepath);
            m_localPlayer.PlaySound(filepath);
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

        private void OnSoundSelected(object sender, EventArgs e)
        {
            string filename = (string)soundList.SelectedItem;
            PlaySound(filename);
        }
    }
}
