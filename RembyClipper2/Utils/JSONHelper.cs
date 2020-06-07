using System;
using JsonExSerializer;
using RembyClipper.Helpers;

namespace RembyClipper2.Utils
{
    /// <summary>
    /// JSON helper utility class
    /// </summary>
    public class JsonHelper
    {
        /// <summary>
        /// This method performs to translate
        /// </summary>
        /// <typeparam name="T">result class</typeparam>
        /// <param name="stream">json object</param>
        /// <returns>Real object or null</returns>
        public static T Translate<T>(string stream) where T : new()
        {
            T result = default(T);
            try
            {
                Serializer serializer = new Serializer(typeof(T));
                result = (T)serializer.Deserialize(stream);
            }
            catch (Exception e)
            {
                DebugHelper.Log("[JSONHelper] : Decode - " + e.ToString());
            }
            return result;
        }
    }
}