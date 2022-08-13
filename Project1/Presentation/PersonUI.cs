using System;
using System.Collections.Generic;
using Project1.DataAccessLayer;
using Project1.Model;
using Project1.Utilites;

namespace Project1.Presentation
{
    public class PersonUI
    {
        private PersonDAL _dal = new PersonDAL();

        public void Add()
        {
            Person person = new Person();
            person.Input();
            _dal.Add(person);
            Console.WriteLine("Successfully");
            Console.ReadKey();
            Console.Clear();
        }

        public void Display()
        {
            List<Person> persons = _dal.GetAll();
            Console.WriteLine("{0,-20}|{1,-20}|{2,-20}|{3,-20}", "Name", "Email Address", "Password", "Roles");
            Console.WriteLine("-----------------------------------------------------------------------------------------");
            foreach (var person in persons)
            {
                person.Display();
            }

            Console.ReadKey();
            Console.Clear();
        }

        public void Update()
        {
            List<Person> persons = _dal.GetAll();
            Console.WriteLine("{0,-20}|{1,-20}|{2,-20}|{3,-20}|{4,-20}", "Index", "Name", "Email Address", "Password",
                "Roles");
            Console.WriteLine("-----------------------------------------------------------------------------------------");
            foreach (var person in persons)
            {
                Console.Write("{0,-20}", persons.IndexOf(person));
                person.Display();
            }

            int choose = Validation.InputNumber();
            if (choose >= persons.Count)
            {
                Console.WriteLine("Choose incorrect");
                Console.ReadKey();
                Console.Clear();
            }

            else
            {
                Person person = persons[choose];
                person.Input();
                _dal.Update(person);
                Console.WriteLine("Successfully");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public void Delete()
        {
            List<Person> persons =_dal.GetAll();
            Console.WriteLine("{0,-20}|{1,-20}|{2,-20}|{3,-20}|{4,-20}", "Index", "Name", "Email Address", "Password",
                "Roles");
            Console.WriteLine("-----------------------------------------------------------------------------------------");
            foreach (var person in persons)
            {
                Console.Write("{0,-20}", persons.IndexOf(person));
                person.Display();
            }

            int choose = Validation.InputNumber();
            if (choose >= persons.Count)
            {
                Console.WriteLine("Choose incorrect");
                Console.ReadKey();
                Console.Clear();
            }

            else
            {
                Person person = persons[choose];
                _dal.Delete(person.Name);
                Console.WriteLine("Successfully");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public void PersonMenu()
        {
            while (true)
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("             Person Manager           ");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("     1. Signup new account");
                Console.WriteLine("     2. Update account");
                Console.WriteLine("     3. Delete account");
                Console.WriteLine("     4. Account list");
                Console.WriteLine("     0. Back");
                Console.WriteLine("--------------------------------------");
                int choose = Validation.InputNumber();
                switch (choose)
                {
                    case 1:
                        Add();
                        break;
                    case 2:
                        Update();
                        break;
                    case 3:
                        Delete();
                        break;
                    case 4:
                        Display();
                        break;
                    default: break;
                }

                if (choose == 0) break;
            }
        }
    }
}