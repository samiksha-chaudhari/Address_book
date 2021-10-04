using System;
using System.Collections.Generic;
using System.Text;

namespace Address_book
{
    
    public class opration //created class for different oprations
    {
        //list declaration to store the personal details
       public List<Contacts> listcontacts = new List<Contacts>();

        Dictionary<string, Contacts> addressBook = new Dictionary<string, Contacts>();//dictionary created
        List<Contacts> searchlist = new List<Contacts>();
        List<Contacts> listCity = new List<Contacts>();
        List<Contacts> listState = new List<Contacts>();

        /// <summary>
        /// method to add data 
        /// </summary>
        public void Add() 
            {
                Console.WriteLine("Enter Personal Details : ");
                Console.Write("First Name : ");
                string first_name = Console.ReadLine();
                Console.Write("Last Name : ");
                string last_name = Console.ReadLine();
                Console.Write("Address : ");
                string address = Console.ReadLine();
                Console.Write("City : ");
                string city = Console.ReadLine();
                Console.Write("State : ");
                string state = Console.ReadLine();
                Console.Write("Zip Code : ");
                int zip = Convert.ToInt32(Console.ReadLine());
                Console.Write("Phone No. : ");
                int phone_no = Convert.ToInt32(Console.ReadLine());
                Console.Write("E-mail ID : ");
                string email = Console.ReadLine();

                //adding the details in list
                listcontacts.Add(new Contacts()
                {
                    first_name = first_name,
                    last_name = last_name,
                    address = address,
                    city = city,
                    state = state,
                    zip = zip,
                    phone_no = phone_no,
                    email = email
                });
        }

        /// <summary>
        /// method to print data
        /// </summary>
        public void Print() 
        {
            for (int i = 0; i < listcontacts.Count; i++)
            {
                Contacts contact = listcontacts[i];

                if (!addressBook.ContainsKey(contact.first_name))//if condition to check the key is present or not
                {
                    addressBook.Add(contact.first_name, contact);//if not the add into the addressbook
                }
                else
                {
                    Console.WriteLine("This Name {0} is already there", contact.first_name);
                }
            }
            foreach (var i in addressBook)
            {
                Console.WriteLine("First Name : " + i.Key);
                Console.WriteLine("Last Name : " + i.Value.last_name);
                Console.WriteLine("Address : " + i.Value.address);
                Console.WriteLine("City Name : " + i.Value.city);
                Console.WriteLine("State Name : " + i.Value.state);
                Console.WriteLine("Zip Code : " + i.Value.zip);
                Console.WriteLine("Phone No. : " + i.Value.phone_no);
                Console.WriteLine("Email ID : " + i.Value.email);
                Console.WriteLine("\n");
            }
        }

        /// <summary>
        /// Edit method 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="first"></param>
        /// <param name="last"></param>
        /// <param name="add"></param>
        /// <param name="cityN"></param>
        /// <param name="stateN"></param>
        /// <param name="zipN"></param>
        /// <param name="no"></param>
        public void Edit(string name, string first, string last, string add, string cityN, string stateN, int zipN, int no)
        {
            int indexOfContact = -1;
            for (int i = 0; i < listcontacts.Count; i++)
            {
                if (listcontacts[i].first_name == name)
                {
                    indexOfContact = i;
                }
            }
            
                var editContact = listcontacts[indexOfContact];
                editContact.first_name = first;
                editContact.last_name = last;
                editContact.address = add;
                editContact.city = cityN;
                editContact.state = stateN;
                editContact.zip = zipN;
                editContact.phone_no = no;
                listcontacts[indexOfContact] = editContact;  
              
        }

        /// <summary>
        /// method to delete contact
        /// </summary>
        /// <param name="firstname"></param>
        public void Delete(string firstname) //Delete method
        {
            int indexOfContact = -1;
            for (int i = 0; i < listcontacts.Count; i++)
            {
                if (listcontacts[i].first_name == firstname)
                {
                    indexOfContact = i;
                }
            }
            listcontacts.RemoveAt(indexOfContact);
               
        }
        /// <summary>
        /// method to search person first name by city or state
        /// </summary>
        /// <param name="cityName"></param>
        /// <param name="statename"></param>
        public void SearchContact(string city, string state)
        {
            searchlist = listcontacts.FindAll(x => (x.city == city || x.state == state));//Lambda Expression

            foreach (Contacts i in searchlist)
            {
                Console.WriteLine("First Name : " + i.first_name);
            }
        }
        
        /// <summary>
        /// method to search person first name by city and state
        /// </summary>
        /// <param name="cityName"></param>
        /// <param name="stateName"></param>
        public void SearchCityState(string cityName, string stateName)
        {
            int a = 0;
            int b = 0;

            listCity = listcontacts.FindAll(x => (x.city == cityName));//to check the names in city

            foreach (Contacts i in listCity)
            {
                Console.WriteLine("person live in {0} City is : {1}", cityName, i.first_name);
                a++;
            }
            Console.WriteLine("\nTotal number of person live in city {0} is : {1}",cityName ,+a);

            listState = listcontacts.FindAll(x => (x.state == stateName));//to check the Names in State
            foreach (Contacts i in listState)
            {
                Console.WriteLine("person live in {0} State is : {1}", stateName, i.first_name);
                b++;
            }
            Console.WriteLine("\nTotal number of person live in state {0} is : {1}", stateName, +b);
        }

    }

  
}
