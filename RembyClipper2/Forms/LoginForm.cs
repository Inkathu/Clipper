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
    public partial class LoginForm : RembyClipper2.Base.BaseForm
    {
        public LoginForm()
        {
            InitializeComponent();
            if (!this.DesignMode)
            {
                this.Text = Localization.LanguageMgr.LM.GetText(Labels.Remby_Login_Title);
                this.rembyLoginControl1.OnLoginButtonClicked += new Base.CustomButtonClicked(rembyLoginControl1_OnOrangeClicked);
                this.rembyLoginControl1.OnCloseButtonClicked += new Base.CustomButtonClicked(rembyLoginControl1_OnBlackClicked);
            }
        }

        public bool ClosePressed { get; set; }

        void rembyLoginControl1_OnBlackClicked()
        {
            this.ClosePressed = true;
            this.Close();
        }

        void rembyLoginControl1_OnOrangeClicked()
        {
            if (this.rembyLoginControl1.Login())
            {
                AppConfig.Instance.Store();
                this.ClosePressed = false;
                this.Close();
            }
        }
    }
}
