using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ProductMan.Utilities;

namespace ProductMan.Helpers
{
    public class SerializationHelper
    {
        public static void Serialize(object data, string filePath)
        {
            try
            {
                StreamWriter fs = new StreamWriter(filePath, false);
                try
                {
                    MemoryStream streamMemory = new MemoryStream();
                    BinaryFormatter formatter = new BinaryFormatter();

                    formatter.Serialize(streamMemory, data);
                    string binaryData = Convert.ToBase64String(streamMemory.GetBuffer());
                    string cipherData = DataProtection.Encrypt(binaryData, DataProtection.Store.User);
                    fs.Write(cipherData);
                }
                finally
                {
                    fs.Flush();
                    fs.Close();
                }
            }
            catch(Exception ex)
            {
                LoggerBase.Instance.Error(ex.ToString());
            }
        }

        public static object Deserialize(string filePath)
        {
            object data = new object();

            try
            {
                StreamReader sr = new StreamReader(filePath);
                try
                {
                    MemoryStream streamMemory;
                    BinaryFormatter formatter = new BinaryFormatter();

                    string cipherData = sr.ReadToEnd();

                    byte[] binaryData = Convert.FromBase64String(DataProtection.Decrypt(cipherData, DataProtection.Store.User));

                    streamMemory = new MemoryStream(binaryData);
                    data = formatter.Deserialize(streamMemory);
                }
                catch
                {
                    data = null;
                }
                finally
                {
                    sr.Close();
                }
            }
            catch(Exception ex)
            {
                LoggerBase.Instance.Error(ex.ToString());
                data = null;
            }

            return data;
        }
    }
}
