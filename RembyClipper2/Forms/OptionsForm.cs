using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using RembyClipper2.Config;
using RembyClipper2.Helpers;
using RembyClipper2.Base;
using RembyClipper.Helpers;
using RembyClipper2.VideoEngine;

namespace RembyClipper2.Forms
{
    public partial class OptionsForm : BaseForm
    {
        public OptionsForm()
        {
            InitializeComponent();
            //SetRegion();
            this.Icon = global::RembyClipper2.NewDesign.clipper32x32;
            buttonOrangeSave.Text = "Save";
            buttonOrangeClear.Text = "Clear credentials?";
            buttonBlack1.Text = "Cancel";
            buttonOrangeLoadXML.Text = "Load XML";

            imageList1.Images.Add(global::RembyClipper2.Properties.Resources.Icon_photo);
            imageList1.Images.Add(global::RembyClipper2.Properties.Resources.Icon_video);
            tabPage2.ImageIndex = 0;
            tabPage3.ImageIndex = 1;

            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void buttonBlack1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OptionsForm_Load(object sender, EventArgs e)
        {
            if (AppConfig.GetInstance().Username != "")
            {
                label1.Text += AppConfig.GetInstance().Username;
            }
            else
            {
                buttonOrangeClear.Visible = false;
                label1.Text = "Not logged in.";
            }

            checkBoxYTPrivate.Checked = AppConfig.GetInstance().VideoPrivate;
            textBoxFrameRate.Text = AppConfig.Instance.VideoFPS.ToString();

            textBoxBitrate.Text = AppConfig.Instance.audioBitrate.ToString();
            textBoxBitsPerSample.Text = AppConfig.Instance.audioBitsPerSample.ToString();
            textBoxChannels.Text = AppConfig.Instance.audioChannels.ToString();
            textBoxSampleFreq.Text = AppConfig.Instance.audioSampleFreq.ToString();

            checkBox1.Checked = AppConfig.Instance.AutoStart;

            comboBoxDevice.Items.AddRange((object[])CameraControl.GetCameras());
            if (comboBoxDevice.Items.Count > 0)
            {
                comboBoxDevice.SelectedItem = AppConfig.Instance.CaptureDevice;
                if (comboBoxDevice.SelectedItem == null)
                    comboBoxDevice.SelectedIndex = 0;
            }

            comboBoxCaptureFPS.SelectedItem = AppConfig.Instance.CaptureFPS.ToString();
            comboBoxCaptureResolution.SelectedItem = AppConfig.Instance.CaptureWidth + "x" + AppConfig.Instance.CaptureHeight;

#if INTERNAL
            textBoxRembyURL.Text = AppConfig.Instance.rembyURL;
            textBoxMediaStore.Text = AppConfig.Instance.mediaStoreURL;
            checkBoxLegacy.Checked = AppConfig.Instance.legacyStorage;

            var x = new XmlSerialisation();

            richTextBox1.AppendText(x.SerializeObject(AppConfig.Instance, typeof(AppConfig)));
#else
            tabControl1.TabPages.Remove(tabPage4);
#endif
        }
        //0721366993 0745871276
        private void buttonOrangeClear_Click(object sender, EventArgs e)
        {
            //AppConfig.GetInstance().Username = "";
            //AppConfig.GetInstance().Password = "";
            AppConfig.Instance.ClearPasswordOnExit = true;

            label1.Text = "You will be signed out once you exit the application.";
            buttonOrangeClear.Visible = false;
        }

        private void buttonOrangeSave_Click(object sender, EventArgs e)
        {
            try
            {
                int frameRate = Convert.ToInt32(textBoxFrameRate.Text);
                int bitRate = Convert.ToInt32(textBoxBitrate.Text);
                int bitsPerSample = Convert.ToInt32(textBoxBitsPerSample.Text);
                int channels = Convert.ToInt32(textBoxChannels.Text);
                int sampleFreq = Convert.ToInt32(textBoxSampleFreq.Text);

                AppConfig.Instance.audioBitrate = bitRate;
                AppConfig.Instance.audioBitsPerSample = bitsPerSample;
                AppConfig.Instance.audioChannels = channels;
                AppConfig.Instance.audioSampleFreq = sampleFreq;
                AppConfig.Instance.VideoFPS = frameRate;
                AppConfig.Instance.VideoPrivate = checkBoxYTPrivate.Checked;

                AppConfig.Instance.CaptureFPS = Convert.ToInt32(comboBoxCaptureFPS.SelectedItem);
                AppConfig.Instance.CaptureWidth = Convert.ToInt32(comboBoxCaptureResolution.SelectedItem.ToString().Split('x')[0]);
                AppConfig.Instance.CaptureHeight = Convert.ToInt32(comboBoxCaptureResolution.SelectedItem.ToString().Split('x')[1]);
                AppConfig.Instance.CaptureDevice = comboBoxDevice.SelectedItem.ToString();

#if INTERNAL
                AppConfig.Instance.legacyStorage = checkBoxLegacy.Checked;
                AppConfig.Instance.mediaStoreURL = textBoxMediaStore.Text;
                AppConfig.Instance.rembyURL = textBoxRembyURL.Text;
#endif
                AppConfig.Instance.AutoStart = checkBox1.Checked;

                if (AppConfig.Instance.AutoStart)
                    ShortcutManager.createShortcut(Environment.SpecialFolder.Startup);
                else
                    ShortcutManager.removeShortcut(Environment.SpecialFolder.Startup);

                AppConfig.Instance.Store();

                this.Close();
            }
            catch
            {
                MessageBox.Show("There was an error saving the configuration file, please make sure all the data you changed is valid.", "Remby", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonOrangeLoadXML_Click(object sender, EventArgs e)
        {
            XmlSerialisation xs = new XmlSerialisation();
            AppConfig ac = (AppConfig)xs.DeserializeObject(richTextBox1.Text, typeof(AppConfig));
            AppConfig.Instance = ac;
            this.Close();
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Font TabFont;
            Brush BackBrush = new SolidBrush(Color.Transparent);
            Brush ForeBrush = new SolidBrush(Color.White);

            if (e.Index == tabControl1.SelectedIndex)
                TabFont = new Font(e.Font, FontStyle.Italic | FontStyle.Bold);
            else
                TabFont = e.Font;

            string TabName = this.tabControl1.TabPages[e.Index].Text;
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            e.Graphics.FillRectangle(BackBrush, e.Bounds);
            Rectangle r = e.Bounds;
            r = new Rectangle(r.X, r.Y + 3, r.Width, r.Height - 3);
            e.Graphics.DrawString(TabName, TabFont, ForeBrush, r, sf);

            sf.Dispose();
            if (e.Index == tabControl1.SelectedIndex)
            {
                TabFont.Dispose();
                BackBrush.Dispose();
            }
            else
            {
                BackBrush.Dispose();
                ForeBrush.Dispose();
            }
        }
    }
}
