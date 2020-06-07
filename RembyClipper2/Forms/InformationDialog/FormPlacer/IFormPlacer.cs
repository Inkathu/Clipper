using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RembyClipper2.Forms.InformationDialog.FormPlacer
{

    public enum Place
    {
        BottomRight,
        TopRight,
        NearIcon,
    }
    public class PlaceCombobxItem
    {
        public Place Value { get; set; }
        public string Descriprion { get; set; }

        public PlaceCombobxItem(Place value, string descriprion)
        {
            Value = value;
            Descriprion = descriprion;
        }

        public override string ToString()
        {
            return Descriprion;
        }
    }


    public interface IFormPlacer
    {
        void Place(Form form);
        List<Form> VisibleForms { get; set; }
        void SlideWindow(Form wnd, int slideDiff);
        AnimateWindowFlags ShowWindowAnimation { get;}
        AnimateWindowFlags HideWindowAnimation { get;}
    }
}