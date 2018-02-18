using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soundboard
{
    class SoundPlayer
    {

        private WaveOutEvent m_player;
        private AudioFileReader m_audioFile;

        private Action m_delayedAction;

        private float m_volume;

        public SoundPlayer(int deviceNumber)
        {
            m_player = new WaveOutEvent();
            m_player.DeviceNumber = deviceNumber;
            m_player.PlaybackStopped += PlaybackStopped;
        }

        private void PlaybackStopped(object sender, StoppedEventArgs e)
        {
            m_audioFile.Dispose();
            m_audioFile = null;

            if(m_delayedAction != null)
                m_delayedAction();
        }

        public void PlaySound(string filename)
        {
            if(m_player.PlaybackState != PlaybackState.Stopped)
            {
                m_delayedAction = () => PlaySound(filename);
                m_player.Stop();
            }
            else
            {
                m_audioFile = new AudioFileReader("Library\\" + filename);
                m_player.Init(m_audioFile);
                m_player.Play();
                m_delayedAction = null;
            }
        }

        public void Stop()
        {
            m_player.Stop();
        }

        public void SetVolume(float volume)
        {
            m_volume = volume;
            m_player.Volume = volume;
        }

        public void Dispose()
        {
            //if(m_player.PlaybackState != PlaybackState.Stopped)
            //{
            //    m_delayedAction = Dispose;
            //    m_player.Stop();
            //}
            //else
                m_player.Dispose();
        }

    }
}
