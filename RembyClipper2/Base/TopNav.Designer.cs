using System;
using RembyClipper2.DrawingTool.Editors;

namespace RembyClipper2.Base
{
    partial class TopNav
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TopNav));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gettingStartedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.trayScreenCaptureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trayVideoCaptureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trayTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filesUploadTSMI2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.sendLogViaSkypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showDebugLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openLogFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.checkForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripTopNav = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.screenCaptureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.screenVideoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filesUploadTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.openWindowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.gotoMyStuffToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.gotoMyBooksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.recentITemsTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelCurrentTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.recentUploadsSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.clearListTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.editBookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelUploadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutRIconTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerClose = new System.Windows.Forms.Timer(this.components);
            this.timerDragnDrop = new System.Windows.Forms.Timer(this.components);
            this.panel3 = new RembyClipper2.DrawingTool.Editors.DoubleBufferedPanel();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStripTopNav.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Text = "RembyCollector";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.gettingStartedToolStripMenuItem,
            this.toolStripSeparator2,
            this.trayScreenCaptureToolStripMenuItem,
            this.trayVideoCaptureToolStripMenuItem,
            this.trayTextToolStripMenuItem,
            this.filesUploadTSMI2,
            this.toolStripSeparator5,
            this.sendLogViaSkypeToolStripMenuItem,
            this.showDebugLogToolStripMenuItem,
            this.openLogFolderToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.toolStripSeparator1,
            this.checkForUpdatesToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(235, 404);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(234, 30);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // gettingStartedToolStripMenuItem
            // 
            this.gettingStartedToolStripMenuItem.Name = "gettingStartedToolStripMenuItem";
            this.gettingStartedToolStripMenuItem.Size = new System.Drawing.Size(234, 30);
            this.gettingStartedToolStripMenuItem.Text = "Getting started";
            this.gettingStartedToolStripMenuItem.Click += new System.EventHandler(this.gettingStartedToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(231, 6);
            // 
            // trayScreenCaptureToolStripMenuItem
            // 
            this.trayScreenCaptureToolStripMenuItem.Image = global::RembyClipper2.NewDesign.icon_screenshots;
            this.trayScreenCaptureToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.trayScreenCaptureToolStripMenuItem.Name = "trayScreenCaptureToolStripMenuItem";
            this.trayScreenCaptureToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Shift+S";
            this.trayScreenCaptureToolStripMenuItem.Size = new System.Drawing.Size(234, 30);
            this.trayScreenCaptureToolStripMenuItem.Text = "Screen Capture";
            this.trayScreenCaptureToolStripMenuItem.Click += new System.EventHandler(this.pictureBoxPhoto_Click);
            // 
            // trayVideoCaptureToolStripMenuItem
            // 
            this.trayVideoCaptureToolStripMenuItem.Image = global::RembyClipper2.NewDesign.icon_video;
            this.trayVideoCaptureToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.trayVideoCaptureToolStripMenuItem.Name = "trayVideoCaptureToolStripMenuItem";
            this.trayVideoCaptureToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Shift+V";
            this.trayVideoCaptureToolStripMenuItem.Size = new System.Drawing.Size(234, 30);
            this.trayVideoCaptureToolStripMenuItem.Text = "Screen Video";
            this.trayVideoCaptureToolStripMenuItem.Click += new System.EventHandler(this.pictureBoxVideo_Click);
            // 
            // trayTextToolStripMenuItem
            // 
            this.trayTextToolStripMenuItem.Image = global::RembyClipper2.Properties.Resources.text1;
            this.trayTextToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.trayTextToolStripMenuItem.Name = "trayTextToolStripMenuItem";
            this.trayTextToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Shift+T";
            this.trayTextToolStripMenuItem.Size = new System.Drawing.Size(234, 30);
            this.trayTextToolStripMenuItem.Text = "Text";
            this.trayTextToolStripMenuItem.Visible = false;
            this.trayTextToolStripMenuItem.Click += new System.EventHandler(this.TetToolStripMenuItemClick);
            // 
            // filesUploadTSMI2
            // 
            this.filesUploadTSMI2.Image = global::RembyClipper2.Properties.Resources.files;
            this.filesUploadTSMI2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.filesUploadTSMI2.Name = "filesUploadTSMI2";
            this.filesUploadTSMI2.Size = new System.Drawing.Size(234, 30);
            this.filesUploadTSMI2.Text = "Upload";
            this.filesUploadTSMI2.Click += new System.EventHandler(this.filesUploadTSMI_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(231, 6);
            // 
            // sendLogViaSkypeToolStripMenuItem
            // 
            this.sendLogViaSkypeToolStripMenuItem.Name = "sendLogViaSkypeToolStripMenuItem";
            this.sendLogViaSkypeToolStripMenuItem.Size = new System.Drawing.Size(234, 30);
            this.sendLogViaSkypeToolStripMenuItem.Text = "Send log via Skype";
            this.sendLogViaSkypeToolStripMenuItem.Visible = false;
            this.sendLogViaSkypeToolStripMenuItem.Click += new System.EventHandler(this.sendLogViaSkypeToolStripMenuItem_Click);
            // 
            // showDebugLogToolStripMenuItem
            // 
            this.showDebugLogToolStripMenuItem.Name = "showDebugLogToolStripMenuItem";
            this.showDebugLogToolStripMenuItem.Size = new System.Drawing.Size(234, 30);
            this.showDebugLogToolStripMenuItem.Text = "Show debug log";
            this.showDebugLogToolStripMenuItem.Visible = false;
            this.showDebugLogToolStripMenuItem.Click += new System.EventHandler(this.showDebugLogToolStripMenuItem_Click);
            // 
            // openLogFolderToolStripMenuItem
            // 
            this.openLogFolderToolStripMenuItem.Name = "openLogFolderToolStripMenuItem";
            this.openLogFolderToolStripMenuItem.Size = new System.Drawing.Size(234, 30);
            this.openLogFolderToolStripMenuItem.Text = "Open log folder";
            this.openLogFolderToolStripMenuItem.Click += new System.EventHandler(this.openLogFolderToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Image = global::RembyClipper2.NewDesign.cm_icon_settings;
            this.optionsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(234, 30);
            this.optionsToolStripMenuItem.Text = "Settings";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(231, 6);
            // 
            // checkForUpdatesToolStripMenuItem
            // 
            this.checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
            this.checkForUpdatesToolStripMenuItem.Size = new System.Drawing.Size(234, 30);
            this.checkForUpdatesToolStripMenuItem.Text = "Check for updates";
            this.checkForUpdatesToolStripMenuItem.Visible = false;
            this.checkForUpdatesToolStripMenuItem.Click += new System.EventHandler(this.checkForUpdatesToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(234, 30);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // contextMenuStripTopNav
            // 
            this.contextMenuStripTopNav.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.screenCaptureToolStripMenuItem,
            this.screenVideoToolStripMenuItem,
            this.textToolStripMenuItem,
            this.filesUploadTSMI,
            this.toolStripSeparator3,
            this.openWindowsToolStripMenuItem,
            this.toolStripSeparator6,
            this.gotoMyStuffToolStripMenuItem1,
            this.gotoMyBooksToolStripMenuItem,
            this.toolStripSeparator9,
            this.recentITemsTSMI,
            this.editBookToolStripMenuItem,
            this.historyToolStripMenuItem,
            this.cancelUploadToolStripMenuItem,
            this.toolStripSeparator7,
            this.toolStripMenuItem5,
            this.toolStripSeparator4,
            this.aboutRIconTSMI,
            this.toolStripSeparator8,
            this.closeToolStripMenuItem});
            this.contextMenuStripTopNav.Name = "contextMenuStripTopNav";
            this.contextMenuStripTopNav.Size = new System.Drawing.Size(235, 460);
            this.contextMenuStripTopNav.MouseLeave += new System.EventHandler(this.pictureBox5_MouseLeave);
            // 
            // screenCaptureToolStripMenuItem
            // 
            this.screenCaptureToolStripMenuItem.Image = global::RembyClipper2.NewDesign.icon_screenshots;
            this.screenCaptureToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.screenCaptureToolStripMenuItem.Name = "screenCaptureToolStripMenuItem";
            this.screenCaptureToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Shift+S";
            this.screenCaptureToolStripMenuItem.Size = new System.Drawing.Size(234, 30);
            this.screenCaptureToolStripMenuItem.Text = "Screen Capture";
            this.screenCaptureToolStripMenuItem.Click += new System.EventHandler(this.pictureBoxPhoto_Click);
            // 
            // screenVideoToolStripMenuItem
            // 
            this.screenVideoToolStripMenuItem.Image = global::RembyClipper2.NewDesign.icon_video;
            this.screenVideoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.screenVideoToolStripMenuItem.Name = "screenVideoToolStripMenuItem";
            this.screenVideoToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Shift+V";
            this.screenVideoToolStripMenuItem.Size = new System.Drawing.Size(234, 30);
            this.screenVideoToolStripMenuItem.Text = "Screen Video";
            this.screenVideoToolStripMenuItem.Click += new System.EventHandler(this.pictureBoxVideo_Click);
            // 
            // textToolStripMenuItem
            // 
            this.textToolStripMenuItem.Image = global::RembyClipper2.Properties.Resources.text1;
            this.textToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.textToolStripMenuItem.Name = "textToolStripMenuItem";
            this.textToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Shift+T";
            this.textToolStripMenuItem.Size = new System.Drawing.Size(234, 30);
            this.textToolStripMenuItem.Text = "Text";
            this.textToolStripMenuItem.Visible = false;
            this.textToolStripMenuItem.Click += new System.EventHandler(this.TetToolStripMenuItemClick);
            // 
            // filesUploadTSMI
            // 
            this.filesUploadTSMI.Image = global::RembyClipper2.Properties.Resources.files;
            this.filesUploadTSMI.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.filesUploadTSMI.Name = "filesUploadTSMI";
            this.filesUploadTSMI.Size = new System.Drawing.Size(234, 30);
            this.filesUploadTSMI.Text = "Upload";
            this.filesUploadTSMI.Click += new System.EventHandler(this.filesUploadTSMI_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(231, 6);
            this.toolStripSeparator3.Visible = false;
            // 
            // openWindowsToolStripMenuItem
            // 
            this.openWindowsToolStripMenuItem.Name = "openWindowsToolStripMenuItem";
            this.openWindowsToolStripMenuItem.Size = new System.Drawing.Size(234, 30);
            this.openWindowsToolStripMenuItem.Text = "Open windows";
            this.openWindowsToolStripMenuItem.Visible = false;
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(231, 6);
            // 
            // gotoMyStuffToolStripMenuItem1
            // 
            this.gotoMyStuffToolStripMenuItem1.Name = "gotoMyStuffToolStripMenuItem1";
            this.gotoMyStuffToolStripMenuItem1.Size = new System.Drawing.Size(234, 30);
            this.gotoMyStuffToolStripMenuItem1.Text = "#Go to Create page#";
            this.gotoMyStuffToolStripMenuItem1.Click += new System.EventHandler(this.gotoMyStuffToolStripMenuItem1_Click);
            // 
            // gotoMyBooksToolStripMenuItem
            // 
            this.gotoMyBooksToolStripMenuItem.Enabled = false;
            this.gotoMyBooksToolStripMenuItem.Name = "gotoMyBooksToolStripMenuItem";
            this.gotoMyBooksToolStripMenuItem.Size = new System.Drawing.Size(234, 30);
            this.gotoMyBooksToolStripMenuItem.Text = "#Go to MyBooks#";
            this.gotoMyBooksToolStripMenuItem.Visible = false;
            this.gotoMyBooksToolStripMenuItem.Click += new System.EventHandler(this.gotoMyBooksToolStripMenuItem_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(231, 6);
            // 
            // recentITemsTSMI
            // 
            this.recentITemsTSMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cancelAllToolStripMenuItem,
            this.cancelCurrentTSMI,
            this.toolStripSeparator10,
            this.recentUploadsSeparator,
            this.clearListTSMI});
            this.recentITemsTSMI.Name = "recentITemsTSMI";
            this.recentITemsTSMI.Size = new System.Drawing.Size(234, 30);
            this.recentITemsTSMI.Text = "#Recent upload#";
            // 
            // cancelAllToolStripMenuItem
            // 
            this.cancelAllToolStripMenuItem.Enabled = false;
            this.cancelAllToolStripMenuItem.Image = global::RembyClipper2.Properties.Resources.delete;
            this.cancelAllToolStripMenuItem.Name = "cancelAllToolStripMenuItem";
            this.cancelAllToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.cancelAllToolStripMenuItem.Text = "#Cancel All#";
            this.cancelAllToolStripMenuItem.Click += new System.EventHandler(this.cancelAllToolStripMenuItem_Click);
            // 
            // cancelCurrentTSMI
            // 
            this.cancelCurrentTSMI.Enabled = false;
            this.cancelCurrentTSMI.Image = global::RembyClipper2.Properties.Resources.delete;
            this.cancelCurrentTSMI.Name = "cancelCurrentTSMI";
            this.cancelCurrentTSMI.Size = new System.Drawing.Size(165, 22);
            this.cancelCurrentTSMI.Text = "#Cancel current#";
            this.cancelCurrentTSMI.Click += new System.EventHandler(this.cancelCurrentTSMI_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(162, 6);
            // 
            // recentUploadsSeparator
            // 
            this.recentUploadsSeparator.Name = "recentUploadsSeparator";
            this.recentUploadsSeparator.Size = new System.Drawing.Size(162, 6);
            this.recentUploadsSeparator.Visible = false;
            // 
            // clearListTSMI
            // 
            this.clearListTSMI.Enabled = false;
            this.clearListTSMI.Image = global::RembyClipper2.Properties.Resources.draw_eraser;
            this.clearListTSMI.Name = "clearListTSMI";
            this.clearListTSMI.Size = new System.Drawing.Size(165, 22);
            this.clearListTSMI.Text = "#Clear List#";
            this.clearListTSMI.Click += new System.EventHandler(this.clearListTSMI_Click);
            // 
            // editBookToolStripMenuItem
            // 
            this.editBookToolStripMenuItem.Enabled = false;
            this.editBookToolStripMenuItem.Name = "editBookToolStripMenuItem";
            this.editBookToolStripMenuItem.Size = new System.Drawing.Size(234, 30);
            this.editBookToolStripMenuItem.Text = "Edit book";
            this.editBookToolStripMenuItem.Visible = false;
            // 
            // historyToolStripMenuItem
            // 
            this.historyToolStripMenuItem.Enabled = false;
            this.historyToolStripMenuItem.Name = "historyToolStripMenuItem";
            this.historyToolStripMenuItem.Size = new System.Drawing.Size(234, 30);
            this.historyToolStripMenuItem.Text = "History (refreshing)";
            this.historyToolStripMenuItem.Visible = false;
            this.historyToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // cancelUploadToolStripMenuItem
            // 
            this.cancelUploadToolStripMenuItem.Name = "cancelUploadToolStripMenuItem";
            this.cancelUploadToolStripMenuItem.Size = new System.Drawing.Size(234, 30);
            this.cancelUploadToolStripMenuItem.Text = "Cancel upload";
            this.cancelUploadToolStripMenuItem.Visible = false;
            this.cancelUploadToolStripMenuItem.Click += new System.EventHandler(this.cancelUploadToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(231, 6);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Image = global::RembyClipper2.NewDesign.cm_icon_settings;
            this.toolStripMenuItem5.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(234, 30);
            this.toolStripMenuItem5.Text = "Settings";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(231, 6);
            // 
            // aboutRIconTSMI
            // 
            this.aboutRIconTSMI.Name = "aboutRIconTSMI";
            this.aboutRIconTSMI.Size = new System.Drawing.Size(234, 30);
            this.aboutRIconTSMI.Text = "&About";
            this.aboutRIconTSMI.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(231, 6);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(234, 30);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // timerClose
            // 
            this.timerClose.Interval = 5000;
            this.timerClose.Tick += new System.EventHandler(this.timerClose_Tick);
            // 
            // timerDragnDrop
            // 
            this.timerDragnDrop.Interval = 1000;
            this.timerDragnDrop.Tick += new System.EventHandler(this.timerDragnDrop_Tick);
            // 
            // panel3
            // 
            this.panel3.AllowDrop = true;
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BackgroundImage = global::RembyClipper2.NewDesign.clipper_icon;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(47, 47);
            this.panel3.TabIndex = 6;
            this.panel3.DragDrop += new System.Windows.Forms.DragEventHandler(this.pictureBox5_DragDrop);
            this.panel3.DragEnter += new System.Windows.Forms.DragEventHandler(this.pictureBox5_DragEnter);
            this.panel3.DragLeave += new System.EventHandler(this.panel3_DragLeave);
            this.panel3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxSmallR_MouseDown);
            this.panel3.MouseEnter += new System.EventHandler(this.pictureBox5_MouseEnter);
            this.panel3.MouseLeave += new System.EventHandler(this.pictureBox5_MouseLeave);
            this.panel3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxSmallR_MouseMove);
            this.panel3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxSmallR_MouseUp);
            // 
            // TopNav
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(47, 47);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TopNav";
            this.ShowInTaskbar = false;
            this.Text = "Remby Clipper";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TopNav_FormClosed);
            this.Load += new System.EventHandler(this.TopNav_Load);
            this.SizeChanged += new System.EventHandler(this.TopNav_SizeChanged);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.pictureBox5_DragDrop);
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStripTopNav.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem showDebugLogToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTopNav;
        private System.Windows.Forms.ToolStripMenuItem screenCaptureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem screenVideoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Timer timerClose;
        private System.Windows.Forms.ToolStripMenuItem historyToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem openWindowsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendLogViaSkypeToolStripMenuItem;
        private DoubleBufferedPanel panel3;
        private System.Windows.Forms.ToolStripMenuItem textToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openLogFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gettingStartedToolStripMenuItem;
        private System.Windows.Forms.Timer timerDragnDrop;
        private System.Windows.Forms.ToolStripMenuItem trayScreenCaptureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trayVideoCaptureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trayTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem editBookToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem cancelUploadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkForUpdatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gotoMyStuffToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem gotoMyBooksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filesUploadTSMI;
        private System.Windows.Forms.ToolStripMenuItem filesUploadTSMI2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem recentITemsTSMI;
        private System.Windows.Forms.ToolStripMenuItem cancelAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelCurrentTSMI;
        private System.Windows.Forms.ToolStripMenuItem clearListTSMI;
        private System.Windows.Forms.ToolStripMenuItem aboutRIconTSMI;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripSeparator recentUploadsSeparator;
    }
}