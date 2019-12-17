using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DapperBasicCrud.Data;
using DapperBasicCrud.Entities;

namespace DapperBasicCrud
{
    class Program
    {
        static void Main(string[] args)
        {
            //contact list
            Repository repository = new Repository();
            //var contactList = repository.GetList();
            //foreach (var VARIABLE in contactList)
            //{
            //    Console.WriteLine(VARIABLE.ContactId);
            //    Console.WriteLine(VARIABLE.FirstName);
            //    Console.WriteLine(VARIABLE.LastName);
            //    Console.WriteLine(VARIABLE.City);
            //}

            //single record
            //var contact = repository.Get(1);
            //Console.WriteLine(contact.FirstName);
            //Console.WriteLine(contact.LastName);
            //Console.ReadLine();


            //add data to db with parameters
            //Contact c = new Contact();
            //c.FirstName = Console.ReadLine();
            //c.LastName = Console.ReadLine();
            //c.ProfilePicture = Console.ReadLine();
            //c.City = Console.ReadLine();
            //c.Country = Console.ReadLine();
            //repository.Add(c);

            Contact c = new Contact();
            c.ContactId = Convert.ToInt32(Console.ReadLine());
            repository.Delete(c);
        }
    }
}
