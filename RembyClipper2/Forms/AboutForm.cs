using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using System.Reflection;
using System.Windows.Forms;
using Localization;
using RembyClipper2.Base;
using System.Diagnostics;
using RembyClipper2.Config;

namespace RembyClipper2.Forms
{
    partial class AboutForm : BaseForm
    {
        public AboutForm()
        {
            InitializeComponent();
            ApplyLanguage();
            AppConfig.topnav.languageChanged += new EventHandler(topnav_languageChanged);
            //this.labelCompanyName.Text = AssemblyCompany;
            //this.textBoxDescription.Text = AssemblyDescription;
        }

        private void ApplyLanguage()
        {
            this.Text = String.Format("{0} {1}", Localization.LanguageMgr.LM.GetText(Labels.About), AssemblyTitle);
            productNameLabel.Text = AssemblyProduct;
            versionLabel.Text = String.Format("{0} {1}", Localization.LanguageMgr.LM.GetText(Labels.Version), AssemblyVersion);
            copyRightsLabel.Text = AssemblyCopyright;
            reservedRightsLabel.Text = Localization.LanguageMgr.LM.GetText(Labels.AllRightsReserved);
            linkLabel.Text = Localization.LanguageMgr.LM.GetText(Labels.RembyLink);
            linkLabel.LinkClicked += new LinkLabelLinkClickedEventHandler(linkLabel_LinkClicked);
        }

        void topnav_languageChanged(object sender, EventArgs e)
        {
            ApplyLanguage();
        }

        void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process t = new Process();
            t.StartInfo.FileName = linkLabel.Text;
            t.Start();
        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
                {
                    Version version = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion;
                    return version.ToString();
                }
                else
                    return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion

        private void textBoxDescription_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process t = new Process();
            t.StartInfo.FileName = e.LinkText;
            t.Start();
        }

        private void grayButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
