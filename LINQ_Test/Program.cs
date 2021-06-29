using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_Test
{
    class Program
    {
        static void Main()
        {
            var users = new List<User>
            {
                new User {Id = 1, Name = "A"},
                new User {Id = 2, Name = "AA"},
                new User {Id = 3, Name = "B"},
                new User {Id = 4, Name = "BB"},
            };
            var phones = new List<Phone>
            {
                new Phone {Id = 1, UserId = 1, Number = "+7123"},
                new Phone {Id = 2, UserId = 1, Number = "12"},
                new Phone {Id = 3, UserId = 2, Number = "123"},
                new Phone {Id = 4, UserId = 3, Number = "456"},
                new Phone {Id = 5, UserId = 4, Number = "789"},
                new Phone {Id = 6, UserId = 1, Number = "0"}
            };
            PrintUsers(users);
            PrintPhones(phones);

            var select = (from user in users 
                from phone in phones 
                where phone.UserId == user.Id
                select (user.Name, phone.Number)).ToList();
            PrintUserPhones(select);

            var select_join = (from phone in phones
                join user in users on phone.UserId equals user.Id
                group user by user.Name into res
                select (res.Key, res.Count())).ToList();
            foreach (var item in select_join)
            {
                Console.Write($"{item.Key}: {item.Item2}\t");
            }
        }

        static void PrintUsers(IEnumerable<User> users)
        {
            foreach (var user in users)
            {
                Console.Write($"{{{user.Id}: {user.Name}}}\t");
            }
            Console.WriteLine();
        }

        static void PrintPhones(IEnumerable<Phone> phones)
        {
            foreach (var phone in phones)
            {
                Console.Write($"{{{phone.Id}: {phone.UserId}, {phone.Number}}}\t");
            }
            Console.WriteLine();
        }

        static void PrintUserPhones(IEnumerable<(string name, string phone)> list)
        {
            foreach (var item in list)
            {
                Console.Write($"{{{item.name} - {item.phone}}}\t");
            }
            Console.WriteLine();
        }
    }
}