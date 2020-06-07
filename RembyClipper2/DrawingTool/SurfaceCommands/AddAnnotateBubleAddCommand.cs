using System;
using System.Windows.Forms;
using Localization;

namespace RembyClipper2.DrawingTool.SurfaceCommands
{
    public class AddAnnotateBubleAddCommand : SurfaceAddCommandBase
    {
        public AddAnnotateBubleAddCommand(FigureCreator.FigureCreator creator, FigureCreator.FigureCreator reverseCreator, IDrawingSurface surface)
            : base(creator, surface)
        {
            //_reverseCreator = reverseCreator;

            _item = new ToolStripButton(LanguageMgr.LM.GetText(Labels.AnnotateBubble), RembyClipper2.Properties.Resources.annotate, (s, a) => Execute());
            _item.ImageScaling = ToolStripItemImageScaling.None;
            _item.DisplayStyle = ToolStripItemDisplayStyle.Image;
            _item.ToolTipText = LanguageMgr.LM.GetText(Labels.AddAnnotateBubble);


//            ToolStripDropDownButton btn = new ToolStripDropDownButton("", RembyClipper2.Properties.Resources.annotate, (s, a) => Execute());
//            btn.ImageScaling = ToolStripItemImageScaling.None;
//            btn.DisplayStyle = ToolStripItemDisplayStyle.Image;
//            btn.ShowDropDownArrow = false;
//            ToolStripDropDownButton item; /*= new ToolStripDropDownButton(LanguageMgr.LM.GetText(Labels.AnnotateBubble), RembyClipper2.Properties.Resources.annotate, (s, a) => Execute());
//            item.ImageScaling = ToolStripItemImageScaling.None;
//            item.DisplayStyle = ToolStripItemDisplayStyle.Image;
//            item.ToolTipText = LanguageMgr.LM.GetText(Labels.AddAnnotateBubble);
//            //((ToolStripDropDownButton)_item).DropDownItems.Add(btn);
//            ((ToolStripDropDownButton)_item).DropDownItems.Add(item);


//            btn = new ToolStripDropDownButton("", RembyClipper2.Properties.Resources.annotateReverse, (s, a) => ExecuteCustom());
//            btn.ImageScaling = ToolStripItemImageScaling.None;
//            btn.DisplayStyle = ToolStripItemDisplayStyle.Image;
//            btn.ShowDropDownArrow = false;
//            //((ToolStripDropDownButton)_item).DropDownItems.Add(btn);
//*/
//            item = new ToolStripDropDownButton(LanguageMgr.LM.GetText(Labels.AnnotateBubble), RembyClipper2.Properties.Resources.annotate, (s, a) => Execute());
//            item.ImageScaling = ToolStripItemImageScaling.None;
//            item.DisplayStyle = ToolStripItemDisplayStyle.Image;
//            item.ToolTipText = LanguageMgr.LM.GetText(Labels.AddAnnotateBubble);
//            ((ToolStripDropDownButton)_item).DropDownItems.Add(item);


        }


//        public void ExecuteCustom()
//        {
//            _surface.InitiateFigureAdding(_reverseCreator);
//        }
    }
}