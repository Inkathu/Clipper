using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;
using Localization;
using RembyClipper2.Config;
using System.Diagnostics;
using RembyClipper2.Utils;

namespace RembyClipper2.Base
{
    public partial class RembyLoginControl : BaseControl
    {
        public event CustomButtonClicked OnLoginButtonClicked;
        public event CustomButtonClicked OnCloseButtonClicked;
        
        public RembyLoginControl()
        {
            InitializeComponent();
            if(LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                ApplyLanguage();
            }
        }

        public void ApplyLanguage()
        {
            this.closeButton.Text = Localization.LanguageMgr.LM.GetText(Labels.Button_Close);
            this.loginButton.Text = Localization.LanguageMgr.LM.GetText(Labels.Button_Login);
            
            label1.Text = Localization.LanguageMgr.LM.GetText(Labels.RembyLogin_Title);
            label2.Text = Localization.LanguageMgr.LM.GetText(Labels.RembyLogin_Username);
            label3.Text = Localization.LanguageMgr.LM.GetText(Labels.RembyLogin_Password);
            checkBox1.Text = Localization.LanguageMgr.LM.GetText(Labels.RembyLogin_RememberMe);
            label4.Text = Localization.LanguageMgr.LM.GetText(Labels.RembyLogin_DontHaveAccount);
            signupLabel.Text = Localization.LanguageMgr.LM.GetText(Labels.RembyLogin_CreateAccount);
        }

        private void LoginButtonClick(object sender, EventArgs e)
        {
            if (OnLoginButtonClicked != null)
                OnLoginButtonClicked();
        }

        private void CloseButtonClicked(object sender, EventArgs e)
        {
            if (OnCloseButtonClicked != null)
                OnCloseButtonClicked();
        }

        private bool CheckPasswords()
        {
            if (AppConfig.GetInstance().Username == "" && textBoxUsername.Text == "")
            {
                textBoxUsername.Focus();
                return false;

            }
            if (AppConfig.GetInstance().Password == "" && textBoxPassword.Text == "")
            {
                textBoxPassword.Focus();
                return false;
            }
            return true;
        }

        public bool Login()
        {
            if (!CheckPasswords())
                return false;

            AppConfig.Instance.ClearPasswordOnExit = !checkBox1.Checked;
            AppConfig.Instance.Store();

            bool result = RembyClipper.Helpers.RembyServices.login(textBoxUsername.Text, textBoxPassword.Text, false, false);

            if (!result)
                
                ShowError(Localization.LanguageMgr.LM.GetText(Labels.Error_InvalidCredentials));

            return result;
        }

        protected virtual void SignUpLabelClick(object sender, EventArgs e)
        {
            Process t = new Process();
            t.StartInfo.FileName = RembyConstants.RembySignUpLink;
            t.Start();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            pictureBox1.Visible = false;
            pictureBoxError.Visible = false;
            labelError.Visible = false;
        }

        public void ShowError(string text)
        {
            timer1.Enabled = true;
            pictureBox1.Visible = true;
            pictureBoxError.Visible = true;
           
            labelError.Visible = true;
            labelError.Text = text;
            labelError.BringToFront();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1_Click(sender, e);
        }

        private void textBoxUsername_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                if (OnLoginButtonClicked != null)
                    OnLoginButtonClicked();

            }
            else
                e.Handled = false;
        }

        Cursor t;

        private void label5_MouseEnter(object sender, EventArgs e)
        {
            t = Cursor.Current;
            Cursor.Current = Cursors.Hand;
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            Cursor.Current = t;
        }
    }
}
