using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Project1.Model;

namespace Project1.DataAccessLayer
{
    public class PersonDAL
    {
        public List<Person> GetAll()
        {
            List<Person> list = new List<Person>();

            if (File.Exists(Person.PATH))
            {
          
                StreamReader reader = new StreamReader(Person.PATH);
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    
                    string[] arr = line.Split("#");
                    Person person = new Person(int.Parse(arr[0]), arr[1], arr[2], arr[3]);
                    list.Add(person);
                }

                reader.Close();
            }

            return list;
        }

        public void Add(Person person)
        {
            List<Person> list = GetAll();
            list.Add(person);
            using (StreamWriter writer = new StreamWriter(Person.PATH))
            {
                foreach (Person ctx in list)
                {
                    writer.WriteLine(ctx.ToString());
                }
            }
        }

        public void Delete(string id)
        {
            List<Person> list = GetAll();
            list.Remove(list.FirstOrDefault(x => x.Name == id));
            using (StreamWriter writer = new StreamWriter(Person.PATH))
            {
                foreach (Person ctx in list)
                {
                    writer.WriteLine(ctx.ToString());
                }
            }
        }

        public void Update(Person person)
        {
            List<Person> list = GetAll();
            int idx = list.FindIndex(x => x.Name == person.Name);
            list[idx] = person;
            using (StreamWriter writer = new StreamWriter(Person.PATH))
            {
                foreach (Person ctx in list)
                {
                    writer.WriteLine(ctx.ToString());
                }
            }
        }

        public Person DetailPerson(string id)
        {
            return GetAll().FirstOrDefault(x => x.Name == id);
        }

        public int Login(string name, string password)
        {
            List<Person> list = GetAll();
            Person person = list.FirstOrDefault(x => x.Name == name && x.Password == password);
            if (person != null)
            {
                return person.Roles;
            }

            return 0;
        }
    }
}