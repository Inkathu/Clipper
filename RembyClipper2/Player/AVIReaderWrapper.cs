/*using System;
using System.Collections.Generic;
using System.Text;
using StreamCoders.Reader;
using RembyClipper.Helpers;

namespace RembyClipper2.Player
{
    public class AVIReaderWrapper : AVIReader
    {
        protected override void Dispose(bool value)
        {
            try
            {
                DebugHelper.Log("Cleaning up AVIReader");
                base.Dispose(value);
            }
            catch (Exception e)
            {
                DebugHelper.Log(e.ToString());
            }
        }
    }
}
/*/