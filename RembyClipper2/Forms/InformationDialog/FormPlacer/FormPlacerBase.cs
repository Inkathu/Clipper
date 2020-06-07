using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RembyClipper2.Forms.InformationDialog.FormPlacer
{
    public abstract class FormPlacerBase : IFormPlacer
    {
        
        public List<Form> VisibleForms { get; set; }

        protected FormPlacerBase()
        {
            VisibleForms  = new List<Form>();
        }

        public virtual void Place(Form form)
        {
            InfoBox.ShowAnimation = ShowWindowAnimation;
            InfoBox.HideAnimation = HideWindowAnimation;
        }

        public abstract void SlideWindow(Form wnd, int slideDiff);
        

        public virtual AnimateWindowFlags ShowWindowAnimation
        {
            get { return AnimateWindowFlags.AW_BLEND | AnimateWindowFlags.AW_ACTIVATE; }
        }
        public virtual AnimateWindowFlags HideWindowAnimation
        {
            get { return AnimateWindowFlags.AW_BLEND | AnimateWindowFlags.AW_HIDE; }
        }
    }
}