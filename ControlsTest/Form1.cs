using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RembyClipper2.Forms.InformationDialog;

namespace ControlsTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            figureCommandsTS.Items.Clear();
            var surfCommands = (from command in drawingSurface1.GetCommands()
                                select command.GetMenu()).ToArray();
            surfaceTS.Items.AddRange(surfCommands);
            drawingSurface1.Label = toolStripStatusLabel1;

        }

        private void drawingSurface1_figureSelected(RembyClipper2.DrawingTool.Figures.IFigure figure)
        {
            figureCommandsTS.Items.Clear();
            if(figure != null)
            {
                var menus = (from command in figure.GetCommands()
                             select command.GetMenu()).ToArray();
                figureCommandsTS.Items.AddRange(menus);
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //InfoBoxDispatcher.ShowBox("Test caption for info box", 5, true);
            //InfoBoxDispatcher.ShowError("Steller", "Something went wrong at the server side", 4, true);
            //InfoBoxDispatcher.ShowSuccess("Steller", "Operation successfully completed", 4, true);
            //InfoBoxDispatcher.ShowSuccessShare("Steller", "Operation successfully completed", @"http://www.youtube.com/watch?v=JFf3uazyXco", 4, true);
            //InfoBoxDispatcher.ShowTags((string tags) => MessageBox.Show(tags), "Steller", 999, true);

        }
    }
}
