using System;
using Project1.Utilites;

namespace Project1.Model
{
    //Lưu thông tin của đói tượng person kế thừa từ lớp Manager
    public class Person : Manager
    {
        private string name, emailAddress, password;


        public static string PATH = "Person.txt"; //tên file lưu dữ liệu

        public Person(int roles, string name, string emailAddress, string password) : base(roles)
        {
            this.name = name;
            this.emailAddress = emailAddress;
            this.password = password;
        }

        public Person(string name, string emailAddress, string password)
        {
            this.name = name;
            this.emailAddress = emailAddress;
            this.password = password;
        }

        public void Input() //nhập thông tin
        {
            Console.Write("Name: ");
            name = Validation.InputString();
            Console.Write("Email Address: ");
            emailAddress = Validation.InputString();
            Console.Write("Password: ");
            password = Validation.InputString();
            Console.Write("Roles \n 1. Admin 2. Manager ");
            Roles = Validation.InputNumber();
            Console.Clear();
        }

        public void Display()
        {
            Console.WriteLine("{0,-20}|{1,-20}|{2,-20}|{3,-20}", name, emailAddress, password,
                Roles); //hiển thị thông tin của 1 object
        }

        public Person()
        {
        }

        public string Name
        {
            get => name;
            set => name = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string EmailAddress
        {
            get => emailAddress;
            set => emailAddress = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string Password
        {
            get => password;
            set => password = value ?? throw new ArgumentNullException(nameof(value));
        }

        public override string ToString()
        {
            return Roles + "#" + name + "#" + emailAddress + "#" +
                   password; //trả về chuỗi, các thông tin cách nhau bởi dấu #
        }
    }
}