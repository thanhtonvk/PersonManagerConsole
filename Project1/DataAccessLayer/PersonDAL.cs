using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Project1.Model;

namespace Project1.DataAccessLayer
{//Giao tiếp với csdl cho chức năng thêm sửa xóa lấy về ds
    public class PersonDAL
    {
        public List<Person> GetAll()//lấy về toàn bộ danh sách
        {
            List<Person> list = new List<Person>();//khởi tạo danh sách mới

            if (File.Exists(Person.PATH))//kiểm tra file tồn tại
            {
          
                // mo luong doc file
                StreamReader reader = new StreamReader(Person.PATH);
                string? line;
                // doc file
                while ((line = reader.ReadLine()) != null)
                {
                    // tach chuoi
                    string[] arr = line.Split("#");
                    // luu thong tin vao obj
                    Person person = new Person(int.Parse(arr[0]), arr[1], arr[2], arr[3]);
                    list.Add(person);
                }

                reader.Close();
            }

            return list;
        }

        public void Add(Person person)
        {
            // get ve ds
            List<Person> list = GetAll();
            //add vao danh sach
            list.Add(person);
            // mo luong ghi file 
            using (StreamWriter writer = new StreamWriter(Person.PATH))
            { 
                // duyet danh sach va ghi file
                foreach (Person ctx in list)
                {
                    writer.WriteLine(ctx.ToString());
                }
            }
        }

        public void Delete(string id)
        {
            // get ve ds
            List<Person> list = GetAll();
            // xoa theo doi tuong
            list.Remove(list.FirstOrDefault(x => x.Name == id));
            // mo luong ghi file
            using (StreamWriter writer = new StreamWriter(Person.PATH))
            {
                //duyet danh sach va ghi filee
                foreach (Person ctx in list)
                {
                    writer.WriteLine(ctx.ToString());
                }
            }
        }

        public void Update(Person person)
        { // get ve ds
            List<Person> list = GetAll();
            // cap nhat theo vi tri
            int idx = list.FindIndex(x => x.Name == person.Name);
            list[idx] = person;
            // mo luong ghi file
            using (StreamWriter writer = new StreamWriter(Person.PATH))
            {
                //duyet danh sach va ghi filee
                foreach (Person ctx in list)
                {
                    writer.WriteLine(ctx.ToString());
                }
            }
        }

        public Person DetailPerson(string id)
        {
            // get by name
            return GetAll().FirstOrDefault(x => x.Name == id);
        }

        public int Login(string name, string password)//dang nhap
        {
            
            List<Person> list = GetAll();
            //kiem tra doi tuong co trung tai khoan hay mat khau khong
            Person person = list.FirstOrDefault(x => x.Name == name && x.Password == password);
            if (person != null)
            {
                return person.Roles;
            }

            return 0;
        }
    }
}