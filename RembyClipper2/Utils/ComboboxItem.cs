using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RembyClipper2.Utils
{
    public class ComboboxItem<T>
    {
        public T Value { get; set; }
        public virtual String Text { get; set; }

         public ComboboxItem()
         {
             
         }

        public ComboboxItem(T item, string text)
        {
            Value = item;
            Text = text;
        }

        public override string ToString()
        {
            return Text;
        }

    }
}
