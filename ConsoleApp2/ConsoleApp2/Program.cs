using ConsoleApp2.DataAccess;
using ConsoleApp2.DataAccess.Dao;
using ConsoleApp2.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            GetAllCustomerList();

            InsertData();

            GetAllCustomerList();

            Console.ReadLine();
        }

        public static void GetPersonByName()
        {
            Console.Write("Enter search Name value : ");
            string name = Console.ReadLine().ToString();
            var persons = PersonDao.GetPersonByName(name);
            DisplayHelper.PrintLine();
            DisplayHelper.PrintRow("Id", "FirstName", "LastName", "Address", "City");
            DisplayHelper.PrintLine();

            foreach (var item in persons)
            {
                DisplayHelper.PrintRow(item.PersonID + "", item.FirstName, item.LastName, item.Address, item.City);
            }
            DisplayHelper.PrintLine();
        }
        public static void GetAllCustomerList()
        {
            var persons = PersonDao.GetAllPersonList(); ;
            DisplayHelper.PrintLine();
            DisplayHelper.PrintRow("Id", "FirstName", "LastName", "Address","City");
            DisplayHelper.PrintLine();

            foreach (var item in persons)
            {
                DisplayHelper.PrintRow(item.PersonID + "", item.FirstName, item.LastName, item.Address,item.City);
            }
            DisplayHelper.PrintLine();
        }

        public static void InsertData()
        {
            Console.Write("Enter Value ( FirstName,LastName,Address,City) : ");
            string data = Console.ReadLine().ToString();
            string[] datas = data.Split(',');
            var personData = new Person
            {
                  FirstName = datas[0].ToString(),
                LastName = datas[1].ToString(),
                Address = datas[2].ToString(),
                City = datas[3].ToString()
            };

            bool result = PersonDao.InsertPersonData(personData);
            if (result)
            {
                Console.WriteLine("New Person Data has been added!");
            }
            else
            {
                Console.WriteLine("Fail!");
            }
        }

        public static void UpdateData()
        {
            Console.Write("Enter Value ( FirstName,LastName,Address,City) : ");
            string data = Console.ReadLine().ToString();
            string[] datas = data.Split(',');
            var personData = new Person
            {
                FirstName = datas[0].ToString(),
                LastName = datas[1].ToString(),
                Address = datas[2].ToString(),
                City = datas[3].ToString()
            };

            bool result = PersonDao.InsertPersonData(personData);
            if (result)
            {
                Console.WriteLine("New Person Data has been added!");
            }
            else
            {
                Console.WriteLine("Fail!");
            }
        }


    }



}
