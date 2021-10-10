using System;

namespace Address_book
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Address Book Program");
            opration option = new opration();  //Creating new object
            int defcount = 0;//counter to break the while loop

            while (defcount == 0)
            {
                Console.WriteLine("1:Add Contact  2:Print Contact  3:Edit Contact  4:Delete  5.Search by Contact  6.Search City State  7.Add Existing Contact  8.Sort By Properties  9.FileIO Write  10.Exit");
                int choice = Convert.ToInt32(Console.ReadLine());//variable for taking choice from the user
                
                switch (choice)  //switch case
                {
                    case 1:
                        Console.WriteLine("How many contacts want to add : ");
                        int n = Convert.ToInt32(Console.ReadLine());
                        for (int i = 0; i < n; i++)
                        {
                            option.Add();//to add contact
                        }
                        break;
                    case 2:
                        option.Print();//to print contact 
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
                        option.Edit(name, first,last, add,cityN, stateN,zipN, no);//to edit contact details
                        break;
                    case 4:
                        Console.WriteLine("Enter First Name To Delete:");
                        string firstname = Console.ReadLine();
                        option.Delete(firstname);//to delete contact
                        break;
                    case 5:
                        Console.WriteLine("Search person first name by city or state");
                        Console.Write("Enter City Name : ");
                        string city = Console.ReadLine();

                        Console.WriteLine("Enter State Name : ");
                        string state = Console.ReadLine();

                        option.SearchContact(city, state);//searching person name base on city or state
                        break;
                    case 6:
                        Console.WriteLine("Search person first name by city or state");
                        Console.Write("Enter City Name : ");
                        string city1 = Console.ReadLine();

                        Console.WriteLine("Enter State Name : ");
                        string state1 = Console.ReadLine();
                        option.SearchCityState(city1, state1);//searching and counting person live in city and state

                        break;
                    case 7:
                        option.listcontacts.Add(new Contacts()
                        {
                            first_name = "samiksha",
                            last_name = "chaudhari",
                            address = "jalgaon",
                            city = "jalgaon",
                            state = "maharashtra",
                            zip = 425001,
                            phone_no = 56982685,
                            email = "samiksha@gmail.com"
                        });
                        
                        option.listcontacts.Add(new Contacts()
                        {
                            first_name = "nikita",
                            last_name = "arora",
                            address = "mumbai",
                            city = "mumbai",
                            state = "maharashtra",
                            zip = 457029,
                            phone_no = 896523895,
                            email = "nikita@gmail.com"
                        });
                       
                        option.listcontacts.Add(new Contacts()
                        {
                            first_name = "aaaradha",
                            last_name = "attarde",
                            address = "pune",
                            city = "pune",
                            state = "maharashtra",
                            zip = 586535,
                            phone_no = 655324895,
                            email = "tushar@gmail.com"
                        });
                        
                        option.listcontacts.Add(new Contacts()
                        {
                            first_name = "mayur",
                            last_name = "chaudhari",
                            address = "mumbai",
                            city = "mumbai",
                            state = "maharashtra",
                            zip = 478653,
                            phone_no = 865445321,
                            email = "mayur@gmail.com"
                        });
                        
                        option.listcontacts.Add(new Contacts()
                        {
                            first_name = "ashwini",
                            last_name = "mahajan",
                            address = "aurangabad",
                            city = "aurangabad",
                            state = "maharashtra",
                            zip = 446565,
                            phone_no = 545454487,
                            email = "ashwini@gmail.com"
                        });


                        break;

                    case 8:
                        option.ChooseSort();
                        break;
                    
                    default:
                        Console.WriteLine("End");//default condition
                        defcount++;
                        break;
                }
            }
            
        }
    }
}
