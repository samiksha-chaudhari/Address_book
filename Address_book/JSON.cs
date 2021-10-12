using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace Address_book
{
    class JSON
    {
        const string JSONPATH = @"D:\new1\bridgelabz_fellowship\Address_book\Address_book\AddressRecord.json";
        public static void WriteToJson(Dictionary<string, Contacts> DictName)
        {
            if (File.Exists(JSONPATH))
            {
                string Json = JsonConvert.SerializeObject(DictName);
                using (StreamWriter sw = new StreamWriter(JSONPATH))
                {
                    sw.WriteLine(Json);
                }
            }
        }
    }
}
