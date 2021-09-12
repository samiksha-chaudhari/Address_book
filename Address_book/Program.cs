using System;

namespace Address_book
{
    class Program
    {
        static void Main(string[] args)
        {
            //Title Of the Program
            Console.WriteLine("Address Book Program");
            //Object for the Operations Class
            Nlog option = new Nlog();
            Console.WriteLine("How many contacts want to add : ");
            int n = Convert.ToInt32(Console.ReadLine());
            for(int i=0;i<n;i++)
            {  
               option.Add(); 
            }
            
            
        }
    }
}
