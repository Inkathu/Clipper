using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Localization;
using RembyClipper2.Config;

namespace RembyClipper2.Forms
{
    public partial class GettingStarted : Form
    {
        private Image[] images = new Image[] { global::RembyClipper2.Properties.Resources.dragndrop, 
            global::RembyClipper2.Properties.Resources.editor,
            global::RembyClipper2.Properties.Resources.keyboard_vista_archigraphs,
            global::RembyClipper2.Properties.Resources.WebcamPIP,
            global::RembyClipper2.Properties.Resources.WebcamPIP
        };

        private string[] texts;

        public GettingStarted()
        {
            InitializeComponent();
            ApplyLanguage();
            this.Icon = global::RembyClipper2.NewDesign.clipper32x32;
            AppConfig.topnav.languageChanged += new EventHandler(topnav_languageChanged);
        }

        void topnav_languageChanged(object sender, EventArgs e)
        {
            ApplyLanguage();
        }

        private void ApplyLanguage()
        {
            texts = new string[]
                        {
                            Localization.LanguageMgr.LM.GetText(Labels.GettingStarted_Note1),
                            Localization.LanguageMgr.LM.GetText(Labels.GettingStarted_Note2),
                            Localization.LanguageMgr.LM.GetText(Labels.GettingStarted_Note3),
                            Localization.LanguageMgr.LM.GetText(Labels.GettingStarted_Note4),
                            Localization.LanguageMgr.LM.GetText(Labels.GettingStarted_Note5),
                        };
            labelText.Text = texts[0];
            closeButton.Text = Localization.LanguageMgr.LM.GetText(Labels.GettingStarted_Button_Close);
            nextButton.Text = Localization.LanguageMgr.LM.GetText(Labels.Button_Next);
            didYouKnowLabel.Text = Localization.LanguageMgr.LM.GetText(Labels.GettingStarted_DidYouKnow);
            checkBox1.Text = Localization.LanguageMgr.LM.GetText(Labels.GettingStarted_DontShowAgain);
            titleLabel.Text = Localization.LanguageMgr.LM.GetText(Labels.RembyClipper);
            Text = Localization.LanguageMgr.LM.GetText(Labels.RembyClipper);
            nextButtonClick(this, EventArgs.Empty);

        }

        private void GettingStarted_Load(object sender, EventArgs e)
        {
        }

        private void closeButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GettingStarted_FormClosed(object sender, FormClosedEventArgs e)
        {
            AppConfig.Instance.GettingStartedWizardShown = checkBox1.Checked;
            AppConfig.Instance.Store();
        }

        int currentOne = 0;
        private void nextButtonClick(object sender, EventArgs e)
        {
            //Random r = new Random();
            //int v = r.Next(0, texts.Length);
            //while (v == currentOne)
            //    v = r.Next(0, texts.Length);
            if (nextElement.Count == 0)
                QueueElements();
            
            int v = nextElement.Dequeue();
            labelText.Text = texts[v];
            panel2.BackgroundImage = images[v];
            currentOne = v;
        }

        Queue<int> nextElement = new Queue<int>();

        private void QueueElements()
        {
            List<int> l = new List<int>();
            for (int i = 0; i < images.Length; i++)
                l.Add(i);
            
            ShuffleList<int>(l);
            foreach (int i in l)
                nextElement.Enqueue(i);
        }

        private static Random random = new Random();

        private static void ShuffleList<E>(IList<E> list)
        {
            if (list.Count > 1)
            {
                for (int i = list.Count - 1; i >= 0; i--)
                {
                    E tmp = list[i];
                    int randomIndex = random.Next(i + 1);

                    //Swap elements
                    list[i] = list[randomIndex];
                    list[randomIndex] = tmp;
                }
            }
        }

    }
}
