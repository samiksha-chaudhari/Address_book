using System;

namespace Address_book
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Address Book Program");
            Nlog option = new Nlog();  //Creating new object
            int defcount = 0;//counter to break the while loop

            while (defcount == 0)
            {
                Console.WriteLine("1:Add Contact  2:Print Contact  3:Edit Contact  5:Exit");
                int choice = Convert.ToInt32(Console.ReadLine());//variable for taking choice from the user
                //Switch Case for doing Operations
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("How many contacts want to add : ");
                        int n = Convert.ToInt32(Console.ReadLine());
                        for (int i = 0; i < n; i++)
                        {
                            option.Add();
                        }
                        break;
                    case 2:
                        option.Print();//To Print Contact 
                        break;
                    case 3:
                        Console.WriteLine("Enter name of existing contact which you want to edit :-");
                        string name = Console.ReadLine();
                        Console.WriteLine("-------------:Edit Sequence :------------");
                        Console.WriteLine("First name,Last name,Address, City, State, Zip, Phone no. :-");
                        string first = Console.ReadLine();
                        string last = Console.ReadLine();
                        string add = Console.ReadLine();
                        string cityN = Console.ReadLine();
                        string stateN = Console.ReadLine();
                        int zipN = Convert.ToInt32(Console.ReadLine());
                        int no = Convert.ToInt32(Console.ReadLine());
                        option.Edit(name, first,last, add,cityN, stateN,zipN, no);//Edit the Contact by passing parameters from users in the method
                        break;
                    default:
                        Console.WriteLine("End");//Default Condition For Exit the while loop
                        defcount++;
                        break;
                }
            }
            
        }
    }
}
