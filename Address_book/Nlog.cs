using System;
using System.Collections.Generic;
using System.Text;

namespace Address_book
{ 
    public class Nlog
    {      
            public void Add()//add method for contact details
            {
                Console.WriteLine("Enter Personal Details : ");
                Console.Write("First Name : ");
                string first_Name = Console.ReadLine();
                Console.Write("Last Name : ");
                string last_Name = Console.ReadLine();
                Console.Write("Address : ");
                string address = Console.ReadLine();
                Console.Write("City : ");
                string city = Console.ReadLine();
                Console.Write("State : ");
                string state = Console.ReadLine();
                Console.Write("Zip Code : ");
                double zip = Convert.ToDouble(Console.ReadLine());
                Console.Write("Phone No. : ");
                double phone_No = Convert.ToDouble(Console.ReadLine());
                Console.Write("E-mail ID : ");
                string email = Console.ReadLine();
            }
            
        }

  
}
