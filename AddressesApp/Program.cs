using System;
using System.Collections.Generic;
using AddressBooks;
using AddressBooks_Data;
using AddressBooks_Logger;
using AddressesApp.Notifier;
using Logger.Strategy;

namespace AddressBooks_Main
{
    class Program
    {
        static Loggers logger;
        static void Main(string[] args)
        {
            AddressBook addressBook = AddressBook.GetInstance();
            addressBook.UserAdded += new EventHandler(UserAddedEvent);
            addressBook.UserRemoved += new EventHandler(UserRemovedEvent);

            ConsoleLogger cl = new ConsoleLogger();
            WindowsEventLogger wl = new WindowsEventLogger();
            FileLogger fl = new FileLogger();
            //Comment if WindowsEventLogger
            //or FileLogger not working
            logger = new Loggers(wl);  
            logger = new Loggers(fl);  
            logger = new Loggers(cl);

            //logger.Debug test
            logger.Debug("AddressApp started at: ");

            //Hometask 3
            Console.WriteLine("\nHometask 3:");
            Console.WriteLine("\nUsers who email-address in the domain 'gmail.com':");
            addressBook.Query1();

            Console.WriteLine("\nUsers who are over 18 years old and living in Kiev:");
            IEnumerable<Users> users = addressBook.Query2();
            foreach (var user in users)
            {
                Console.WriteLine(user.LastName + " " + user.FirstName + " : " + user.BirthDate.ToShortDateString());
            }

            Console.WriteLine("\nUsers who are girls and have been added in the last 10 days:");
            addressBook.Query3();

            Console.WriteLine("\nUsers who were born in January, and have fields address and phone:");
            addressBook.Query4();

            Console.WriteLine("\nUsers that match the key of the dictionary: 'man' and 'woman':");
            addressBook.Query5();

            Console.WriteLine("\nNumber of users from Lviv, who has a birthday today:");
            addressBook.Query7(city: "Lviv");

            //Запускаємо BirthdayNotifier
            EmailSheduler.Start();
            Console.WriteLine("\nStarted Birthday Notifier.The message will be sent at 10.00 am.");

            //Hometask 2
            //Add user for test
            Console.WriteLine();
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Hometask 2:");
            Users us = new Users();
            try
                {
                us.LastName = "Barnes";
                us.FirstName = "Bill";
                us.BirthDate = new DateTime(1990, 1, 18);
                us.TimeAdded = DateTime.Now;
                us.City = "Lviv";
                us.Address = "ul. Gorodoc'ka, 100";
                us.PhoneNumber = "+380951234567";
                us.Gender = GenderEnum.Male;
                us.Email = "Barnes@gmail.com";

                    addressBook.AddUser(us);
                }
                catch (Exception e)
                {
                    logger.Error(e.Message);
                }

            us.ShowUsers();

            //Delete user
            try
            {
                string lastName = "Barnes";
                addressBook.RemoveUser(lastName);
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }
            Console.ReadKey();

            logger.Debug("AddressApp closed at: ");
        }

        private static void UserAddedEvent(object sender, EventArgs e)
        {
            Console.WriteLine();
            string addMessage = "User was added to address book! ";
            logger.Info(addMessage);
             
        }
        private static void UserRemovedEvent(object sender, EventArgs e)
        {
            Console.WriteLine();
            string removeMessage = "User has been deleted from address book! ";
            logger.Warning(removeMessage);
        }
    }
}
