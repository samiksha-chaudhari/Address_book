using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace Address_book
{
    class FileIO
    {
        public void WriteDataToTxt(Dictionary<string, Contacts> addressBook)
        {
            const string PATH = @"D:\new1\bridgelabz_fellowship\Address_book\Address_book\StoredContact.txt";
            if (File.Exists(PATH))
            {
                using (TextWriter tw = new StreamWriter(PATH))
                {
                    tw.WriteLine(string.Format("FirstName,LastName,Address,City,State,ZipCode,PhoneNumber,Email"));
                    foreach (var element in addressBook)
                    {
                        tw.WriteLine(string.Format($"{element.Value.first_name},{element.Value.last_name},{element.Value.address},{element.Value.city},{element.Value.state},{element.Value.zip},{element.Value.phone_no},{element.Value.email}"));
                    }
                }
            }
            else Console.WriteLine("File doesn't exist, Check the Path");
        }
    }
}
