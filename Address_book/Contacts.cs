using System;
using System.Collections.Generic;
using System.Text;

namespace Address_book
{
    public class Contacts  //created class contact
    {
        //by using encapsulation
        public string first_name { get; set; } //property
        public string last_name { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int zip { get; set; }
        public int phone_no { get; set; }
        public string email { get; set; }
    }
}
