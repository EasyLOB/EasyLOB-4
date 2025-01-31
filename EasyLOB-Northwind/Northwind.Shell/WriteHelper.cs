using Newtonsoft.Json;
using System;
using System.Collections;
using System.ComponentModel;
using System.IO;

namespace EasyLOB
{
    public static class WriteHelper
    {
        #region Properties

        static JsonSerializerSettings DeserializeSettings
        {
            get
            {
                return new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };
            }
        }

        static JsonSerializerSettings SerializeSettings
        {
            get
            {
                return new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };
            }
        }

        #endregion

        #region Write to Console

        public static void WriteException(Exception exception)
        {
            Console.WriteLine(exception.Message, "");
        }

        public static void WriteException(Exception exception, string spaces)
        {
            Console.WriteLine(exception.Message);
            if (exception.InnerException != null)
            {
                WriteException(exception.InnerException, spaces + "  ");
            }
        }

        public static void WriteJSON(Object o)
        {
            if (o is string)
            {
                o = JsonConvert.DeserializeObject(o as string, DeserializeSettings);
            }
            string json = JsonConvert.SerializeObject(o, Formatting.Indented, SerializeSettings);
            Console.WriteLine(json);
        }

        public static void WriteObject(Object o, string spaces = "")
        {
            if (o is IEnumerable && !(o is string))
            {
                int i = 0;
                foreach (object oo in (o as IEnumerable))
                {
                    Console.WriteLine(spaces + "  [{0}]", i++);
                    WriteObject(oo, spaces + "    ");
                }
            }
            else
            {
                foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(o))
                {
                    string name = descriptor.Name;
                    object value = descriptor.GetValue(o);
                    if (name != "ExtensionData")
                    {
                        if (value == null || value.GetType().IsPrimitive || value is DateTime || value is string)
                        {
                            Console.WriteLine(spaces + "{0} = {1}", name, value);
                        }
                        else
                        {
                            Console.WriteLine(spaces + "{0}", name);
                            WriteObject(value, spaces + "  ");
                        }
                    }
                }
            }
        }

        public static void WriteOperationResult(ZOperationResult operationResult)
        {
            Console.WriteLine(operationResult.Text);
        }

        #endregion Write to Console

        #region Write to File

        public static void WriteFileJSON(string fileName, object o)
        {
            string filePath = System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(".exe", fileName);

            File.Delete(filePath);

            using (StreamWriter stream = new StreamWriter(filePath))
            using (JsonWriter writer = new JsonTextWriter(stream))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Formatting = Formatting.Indented;
                serializer.NullValueHandling = NullValueHandling.Ignore;
                serializer.Serialize(writer, o);
            }
        }

        public static void WriteLog(string s)
        {
            string log = System.Reflection.Assembly.GetExecutingAssembly().Location.Replace(".exe", ".log");
            StreamWriter sr = new StreamWriter(log, true);
            sr.Write(string.Format("{0:yyyyMMdd.HHmmssfff}", DateTime.Now) + " | " + s);
            sr.Flush();
            sr.Close();
            sr.Dispose();
            sr = null;
        }

        #endregion Write to File
    }
}
