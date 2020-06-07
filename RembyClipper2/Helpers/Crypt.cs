using System;
using System.Collections.Generic;
using System.Text;

namespace RembyClipper2.Helpers
{
    internal static class Crypt
    {
        internal static byte[] key;
        internal static byte[] iv;
        internal static string m_key;
        internal static string m_iv;

        internal static void CreateKeyIV()
        {
            CreateKeyIV("dacebfghjklnompqrsdfghtyqrewxwza", "acbdefghjklmnopqrsdfghtyreqwxzaw");
        }

        internal static void CreateKeyIV(string key_val, string iv_val)
        {
            key = new byte[32];
            iv = new byte[32];

            int i;
            m_key = key_val;
            m_iv = iv_val;
            //key calculation, depends on first constructor parameter
            for (i = 0; i < m_key.Length; i++)
            {
                key[i] = Convert.ToByte(m_key[i]);
            }
            //IV calculation, depends on second constructor parameter
            for (i = 0; i < m_iv.Length; i++)
            {
                iv[i] = Convert.ToByte(m_iv[i]);
            }
        }
    }
}
