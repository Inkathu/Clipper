using System;
using System.Drawing;

namespace RembyClipper2.Utils.Meesenger
{
    public interface INotification
    {
        string Text { get; set; }
        Image Image { get; set; }
        bool CanBeRemoved { get; set; }
        DateTime TTL { get; set; }
        object Tag { get; set; }
        int Height { get; set; }
        int Width { get; set; }

        INotification ExtendTTL(int seconds);
        void OnNotificationRemoved();

        void ShowTTL();
    }
}