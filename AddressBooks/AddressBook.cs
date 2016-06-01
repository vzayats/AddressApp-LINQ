using AddressBooks_Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AddressBooks
{
    public class AddressBook
    {
        //Singleton (Early instance creation)
        private static AddressBook instance = new AddressBook();
        private AddressBook()
        {
            _addresses = new List<Users>();
            UsersInitialize();
        }

        List<Users> _addresses;

        public static AddressBook GetInstance()
        {
            //Return the instance
            return instance;
        }
        public string ReturnValue;

        //Hometask 3
        //1 Пользователи, у которых Email-адрес имеет домен “gmail.com”;
        public void Query1()
        {
            var query = _addresses.Where(s => s.Email.Contains("@gmail.com"));
                            
            foreach (var user in query)
            {
                Console.WriteLine("{0} {1}, {2}", user.FirstName, user.LastName, user.Email);
            }
        }

        //2 Пользователи, которым больше 18-ти лет и которые проживают в Киеве
        public IEnumerable<Users> Query2()
        {
            var users = _addresses.ExtensionQuery();
            return users;
        }

        //3 Пользователи, которые являются девушками и были добавлены за последние 10 дней
        public void Query3()
        {
            var query =
                from u in _addresses
                where u.Gender == GenderEnum.Female &&
                      (u.TimeAdded.Date <= DateTime.Now.Date && u.TimeAdded.Date >= DateTime.Now.AddDays(-10))
                select u;

            foreach (var user in query)
            {
                Console.WriteLine("{0} {1}, add date: {2}", user.FirstName, user.LastName, user.TimeAdded.ToShortDateString());
            }
        }

        //4 Cписок пользователей, которые родились в январе, и при этом имеют заполненые поля 
        //адреса и - телефона. Список должен быть отсортирован по фамилии пользователя в обратном порядке
        public void Query4()
        {
            var query = _addresses.OrderByDescending(a => a.LastName)
                    .Where(a => a.BirthDate.Month == 01 && (a.Address != null) && a.PhoneNumber != null);

            foreach (var user in query)
            {
                Console.WriteLine("{0} {1}, {2}", user.FirstName, user.LastName, user.BirthDate.ToShortDateString());
            }
        }

        //5 словарь, имеющий два ключа “man” и “woman”. По каждому из ключей словарь должен содержать 
        //список пользователей, которые соответствуют ключу словаря
        public void Query5()
        {
            var users = new Dictionary<string, List<Users>>
            {
                {"man", _addresses.Where(m => m.Gender == GenderEnum.Male).Select(m => m).ToList()},
                {"woman", _addresses.Where(w => w.Gender == GenderEnum.Female).Select(w => w).ToList()}
            };

            foreach (var genderKey in users)
            {
                Console.WriteLine(genderKey.Key + ":");
                foreach (var user in genderKey.Value)
                {
                    Console.WriteLine("{0} {1}", user.FirstName, user.LastName);
                }
            }
        }

        //6 Выбрать пользователей, передавая произвольное условие (лямбда - выражение) и два параметра - 
        //с какого элемента выбирать и по какой (paging).
        public void Query6(int skip, int pageSize)
        {
            var query = _addresses.Where(u => u.City == "Lviv").Skip(1 * skip).Take(pageSize).ToList();

            foreach (var user in query)
            {
                Console.WriteLine("{0} {1}, {2}", user.FirstName, user.LastName, user.City);
            }
        }

        //7 Количество пользователей, из города (передать в параметрах), у которых сегодня день рождения.
        public void Query7(string city)
        {
            var query =
                (from u in _addresses
                 where u.City == city && u.BirthDate.Day == DateTime.Today.Day && u.BirthDate.Month == DateTime.Now.Month
                 select u).Count();

            Console.WriteLine(query + " users from the " + city + " has a birthday today.");
        }

        //Користувачі, в яких сьогодні День народження (для BirthdayNotifier)
        public void BirthdayNotifierQuery()
        {
            var s = string.Join(" , ", _addresses.Where(p => p.BirthDate.Month == DateTime.Now.Month
            && p.BirthDate.Day == DateTime.Now.Day).Select(p => p.Email.ToString()));
               ReturnValue = s;
        }

        public void UsersInitialize()
        {
            _addresses = new List<Users>()
        {
            new Users()
            {
                LastName = "Pavlyuk",
                FirstName = "Andriy",
                BirthDate = new DateTime(1990, 05, 25),
                TimeAdded = new DateTime(2016, 05, 15),
                City = "Kiev",
                Address = "Myrhorodska st. 150",
                PhoneNumber = null,
                Gender = GenderEnum.Male,
                Email = "apavlyuk@outlook.com"
            },
            new Users()
            {
                LastName = "Onyshchuk",
                FirstName = "Serhiy",
                BirthDate = new DateTime(1985, 06, 01),
                TimeAdded = new DateTime(2016, 06, 01),
                City = "Lviv",
                Address = "Gorodocka st., 150",
                PhoneNumber = "+380951679456",
                Gender = GenderEnum.Male,
                Email = "Onyshchuk@gmail.com"
            },
            new Users()
            {
                LastName = "Andriychuk",
                FirstName = "Yuliya",
                BirthDate = new DateTime(1989, 01, 25),
                TimeAdded = new DateTime(2016, 05, 29),
                City = "Lviv",
                Address = "Mlynova st., 15/5",
                PhoneNumber = "+380957546879",
                Gender = GenderEnum.Female,
                Email = "yuliyaandriychuk@gmail.com"
            },
            new Users()
            {
                LastName = "Mariya",
                FirstName = "Savchuk",
                BirthDate = new DateTime(2005, 06, 01),
                TimeAdded = new DateTime(2016, 05, 25),
                City = "Kiev",
                Address = "Naukova st., 10/5",
                PhoneNumber = "+380979647463",
                Gender = GenderEnum.Female,
                Email = "msavchuk@gmail.com"
            },
            new Users()
            {
                LastName = "Andrukhiv",
                FirstName = "Vasylyna",
                BirthDate = new DateTime(1970, 06, 01),
                TimeAdded = new DateTime(2016, 07, 30),
                City = "Kiev",
                Address = "Sadova st., 25/10",
                PhoneNumber = "+380507641345",
                Gender = GenderEnum.Female,
                Email = "VasylynaAndrukhiv@outlook.com"
            },
            new Users()
            {
                LastName = "Pasichnyk",
                FirstName = "Volodumur",
                BirthDate = new DateTime(2005, 01, 01),
                TimeAdded = new DateTime(2016, 04, 30),
                City = "Lviv",
                Address = "Tekhnichna st., 100/15",
                PhoneNumber = null,
                Gender = GenderEnum.Male,
                Email = "vpasichnyk@yamdex.ru"
            },
            new Users()
            {
                LastName = "Kovalenko",
                FirstName = "Ira",
                BirthDate = new DateTime(1992, 09, 01),
                TimeAdded = new DateTime(2016, 05, 10),
                City = "Lviv",
                Address = "Tekhnichna st., 100/15",
                PhoneNumber = "+38095463486",
                Gender = GenderEnum.Female,
                Email = "irakovalenko@yahoo.com"
            },
            new Users()
            {
                LastName = "Yurchenko",
                FirstName = "Ivan",
                BirthDate = new DateTime(1986, 11, 17),
                TimeAdded = new DateTime(2016, 04, 15),
                City = "Kiev",
                Address = "Torhova st., 15",
                PhoneNumber = null,
                Gender = GenderEnum.Male,
                Email = "ivanyurchenko@yahoo.com"
            },
            new Users()
            {
                LastName = "Dudko",
                FirstName = "Yana",
                BirthDate = new DateTime(1995, 01, 25),
                TimeAdded = new DateTime(2016, 03, 09),
                City = "Kiev",
                Address = "Mlynova st., 110/18",
                PhoneNumber = "+380504631674",
                Gender = GenderEnum.Female,
                Email = "yanadudko@gmail.com"
            },
            new Users()
            {
                LastName = "Mukolayenko",
                FirstName = "Volodumur",
                BirthDate = new DateTime(1987, 09, 25),
                TimeAdded = new DateTime(2016, 03, 10),
                City = "Lviv",
                Address = "Kovalska st., 50",
                PhoneNumber = "+380971671358",
                Gender = GenderEnum.Female,
                Email = "mukolayenko@gmail.com"
            }
        };
        }

        private readonly string lastName = string.Empty;

        //Events during add and remove users
        public event EventHandler UserAdded;
        public event EventHandler UserRemoved;
         
        private void UserAddedEvent()
        {
            UserAdded?.Invoke(this, EventArgs.Empty);
        }
        private void UserRemovedEvent()
        {
            UserRemoved?.Invoke(this, EventArgs.Empty);    
        }

        public bool AddUser(Users user)
        {
            Users users = new Users();
            Users result = Find(lastName);

            if (result == null)
            {
                _addresses.Add(users);
                UserAddedEvent();
                return true;
            }
            else
            {
                return false;
                throw new Exception("Cannot add a new user!");
            }
        }

        public bool RemoveUser(string lastName)
        {
            Users users = Find(lastName);
             
            if (users == null)
            {
                _addresses.Remove(users);
                UserRemovedEvent();
                return true;
            }
            else
            {
                return false;
                throw new Exception("Cannot remove a user!");
            }
        }

        public Users Find(string lastName)
        {
            Users users = _addresses.Find(
              delegate (Users u)
              {
                  return u.LastName == lastName;
              }
            );
            return users;
        }
    }

    //Метод розширення
    public static class ExtensionMethod
    {
        public static IEnumerable<Users> ExtensionQuery(this IEnumerable<Users> userList)
        {
            //Пользователи, которым больше 18-ти лет и которые проживают в Киеве
            DateTime moreThanYers = DateTime.Today.AddYears(-18);

            var query = from u in userList
                where moreThanYers.Year > u.BirthDate.Year && u.City == "Kiev"
                select u;

            foreach (Users users in query)
            {
                yield return users;
            }
        }
    }
}
