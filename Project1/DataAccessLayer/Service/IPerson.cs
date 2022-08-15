using Project1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.DataAccessLayer.Service
{
    internal interface IPerson
    {
        List<Person> GetAll();//lấy về toàn bộ danh sách


        void Add(Person person);


        void Delete(string id);

        void Update(Person person);


        Person DetailPerson(string id);


        int Login(string name, string password);//dang nhap
       
    }
}
