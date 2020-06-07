using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RembyClipper2.Base
{
    public partial class CustomList : UserControl, IMouseWheelContrllable
    {
        public EventHandler ItemsCountChanged;
        public int ItemsCount
        {
            get { return panel1.Controls.Count; }
        }

        public List<CustomListItem> Items
        {
            get { return panel1.Controls.Cast<CustomListItem>().ToList(); }
        }

        //private List<CustomListItem> items;
        public CustomList()
        {
            InitializeComponent();
            //items = new List<CustomListItem>();
        }
        protected void CallItemsCountChange()
        {
            if (ItemsCountChanged != null)
            {
                ItemsCountChanged(this, EventArgs.Empty);
            }
        }
        public void AddItem(CustomListItem item)
        {
            panel1.Controls.Add(item);
            item.Dock = DockStyle.Top;
            item.RemoveClicked += new EventHandler(item_RemoveClicked);
            RedrawItemsBackground();
            CallItemsCountChange();
        }

        public void AddItemsRange(List<CustomListItem> items)
        {
            panel1.SuspendLayout();
            items.ForEach(item =>
                              {
                                  item.Dock = DockStyle.Top;
                                  item.RemoveClicked += new EventHandler(item_RemoveClicked);
                              });
            panel1.Controls.AddRange(items.Cast<Control>().ToArray());
            RedrawItemsBackground();
            panel1.ResumeLayout();
            CallItemsCountChange();
        }

        void item_RemoveClicked(object sender, EventArgs e)
        {
            var listItem = (CustomListItem)sender;
            int scroll = panel1.VerticalScroll.Value;
            if (!panel1.Controls.Contains(listItem))
            {
                return;
            }


            RemoveItem(listItem);

            RedrawItemsBackground();
            
            panel1.AutoScrollPosition = new Point(0, scroll);
            CallItemsCountChange();
        }

        public bool ContainsText(string text)
        {
            if(panel1.Controls.Count <= 0)
            {
                return false;
            }
            var listItem = panel1.Controls.Cast<CustomListItem>().FirstOrDefault(item => item.Text.Equals(text));
            bool res = listItem == null
                           ? false
                           : true;
            return res;
        }
        private void RemoveItem(CustomListItem listItem)
        {
            listItem.RemoveClicked -= item_RemoveClicked;
            panel1.Controls.Remove(listItem);
            listItem.Dispose();
            CallItemsCountChange();
        }

        public void ClearItems()
        {
            panel1.ResumeLayout();
            var items = panel1.Controls.Cast<CustomListItem>().ToList();
            items.ForEach(item => RemoveItem(item));
            panel1.ResumeLayout();
            
        }

        private void RedrawItemsBackground()
        {
            int itemNum = 0;
            panel1.Controls.Cast<CustomListItem>().Reverse().ToList().ForEach(item =>
                                                                        {
                                                                            item.Odd = (itemNum%2 == 0)
                                                                                           ? false
                                                                                           : true;
                                                                            itemNum++;
                                                                        });
        }

        public void DoMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
        }
    }

    public interface IMouseWheelContrllable
    {
        void DoMouseWheel(MouseEventArgs e);
    }
}
