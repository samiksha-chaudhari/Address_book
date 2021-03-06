using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using Newtonsoft.Json;


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
        //list for sorting elememts
        List<Contacts> SortedList = new List<Contacts>();

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

        

        public void ChooseSort()
        {
            Console.WriteLine("Sort By:-");
            Console.WriteLine("1.Name\n2.City\n3.State\n4.ZipCode");
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Dictionary<string, Contacts> sortList = addressBook.OrderBy(x => x.Value.first_name).ToDictionary(x => x.Key, x => x.Value);
                    foreach (var element in sortList)
                    {
                        Console.WriteLine(element.Value.first_name + " " + element.Value.last_name + " " + element.Value.phone_no);
                    }
                    break;
                case "2":
                    Dictionary<string, Contacts> sortCity = addressBook.OrderBy(x => x.Value.city).ToDictionary(x => x.Key, x => x.Value);
                    foreach (var element in sortCity)
                    {
                        Console.WriteLine(element.Value.first_name + " " + element.Value.last_name + " " + element.Value.city + " " + element.Value.phone_no);
                    }
                    break;
                case "3":
                    Dictionary<string, Contacts> sortState = addressBook.OrderBy(x => x.Value.state).ToDictionary(x => x.Key, x => x.Value);
                    foreach (var element in sortState)
                    {
                        Console.WriteLine(element.Value.first_name + " " + element.Value.last_name + " " + element.Value.state + " " + element.Value.phone_no);
                    }
                    break;
                case "4":
                    Dictionary<string, Contacts> sortZip = addressBook.OrderBy(x => x.Value.zip).ToDictionary(x => x.Key, x => x.Value);
                    foreach (var element in sortZip)
                    {
                        Console.WriteLine(element.Value.first_name + " " + element.Value.last_name + " " + element.Value.state + " " + element.Value.zip + " " + element.Value.phone_no);
                    }
                    break;
                default:
                    Console.WriteLine("Invalid choise");
                    break;
            }
        }

        public string FilePath = @"D:\new1\bridgelabz_fellowship\Address_book\Address_book\StoredContact.txt";
        public string CSVPath = @"D:\new1\bridgelabz_fellowship\Address_book\Address_book\CSVFileData.csv";
        public string JSONPath = @"D:\new1\bridgelabz_fellowship\Address_book\Address_book\AddressRecord.json";

        /// <summary>
        /// write the data using file IO
        /// </summary>
        public void StreamWriteFile()
        {
            if (File.Exists(FilePath))
            {
                using (StreamWriter streamWriter = File.AppendText(FilePath))
                {
                    foreach (Contacts person in listcontacts)
                    {
                        streamWriter.WriteLine("\nFirstName: " + person.first_name);
                        streamWriter.WriteLine("LastName: " + person.last_name);
                        streamWriter.WriteLine("Address: " + person.address);
                        streamWriter.WriteLine("City    : " + person.city);
                        streamWriter.WriteLine("State   : " + person.state);
                        streamWriter.WriteLine("ZipCode: " + person.zip);
                        streamWriter.WriteLine("PhoneNum: " + person.phone_no);
                        streamWriter.WriteLine("Email   : " + person.email);
                    }
                    streamWriter.Close();
                }
                Console.WriteLine("Data Added in to the File");
            }
        }
        /// <summary>
        /// Read the file using file IO
        /// </summary>
        public void StreamReadFile()
        {
            if (File.Exists(FilePath))
            {
                using (StreamReader streamReader = File.OpenText(FilePath))
                {
                    String ContactDetails = "";
                    while ((ContactDetails = streamReader.ReadLine()) != null)
                    {
                        Console.WriteLine((ContactDetails));
                    }
                }
            }
            else
            {
                Console.WriteLine("No such file exists");
            }
        }

        /// <summary>
        ///method to write the file using csv 
        /// </summary>     
        public void WriteContactsCsv()
        {
            using (StreamWriter stream = new StreamWriter(CSVPath))
            using (CsvWriter csvWriter = new CsvWriter(stream, CultureInfo.InvariantCulture))
            {
                csvWriter.WriteRecords(listcontacts);
            }
            Console.WriteLine("\nData line added to CSV file...");

            ReadContactsCSV();
        }

        /// <summary>
        /// method to read the file using csv 
        /// </summary>
        public void ReadContactsCSV()
        {    
            using (StreamReader reader = new StreamReader(CSVPath))
            using (var read = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var contacts = read.GetRecords<Contacts>().ToList();
                foreach (Contacts contact in contacts)
                {
                    Console.WriteLine(contact.first_name + "," + contact.last_name + "," + contact.address + "," + contact.city + "," + contact.state + "," + contact.zip + "," + contact.phone_no + "," + contact.email);
                }
            }
        }

        /// <summary>
        /// write to file using JSON
        /// </summary>
        /// <param name="addressBookDictionary"></param>
       
        public void convertToJson()
        {
            JSON.WriteToJson(addressBook);
        }
    }
}
