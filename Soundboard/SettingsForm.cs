using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Soundboard
{
    public partial class SettingsForm : Form
    {
        private MainForm m_mainForm;

        public SettingsForm(MainForm mainForm)
        {
            m_mainForm = mainForm;

            InitializeComponent();

            RefreshDeviceList(remoteDeviceCombo, Preferences.Default.RemoteDevice + 1);
            RefreshDeviceList(localDeviceCombo, Preferences.Default.LocalDevice + 1);
        }

        public void RefreshDeviceList(ComboBox box, int selectedIndex)
        {
            box.Items.Clear();

            for (int i = -1; i < WaveOut.DeviceCount; i++)
                box.Items.Add(WaveOut.GetCapabilities(i).ProductName);

            box.SelectedIndex = selectedIndex;
        }

        private void mainDeviceCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Preferences.Default.RemoteDevice = ((ComboBox)sender).SelectedIndex - 1;
            Preferences.Default.Save();
            m_mainForm.OnRemoteDeviceChange();
        }

        private void localDeviceCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Preferences.Default.LocalDevice = ((ComboBox)sender).SelectedIndex - 1;
            Preferences.Default.Save();
            m_mainForm.OnLocalDeviceChange();
        }

    }
}
