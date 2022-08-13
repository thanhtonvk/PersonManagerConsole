using System;
using Project1.Utilites;

namespace Project1.Model
{
    //Chứa thông tin của category
    public class Category
    {
        
        public static string PATH = "Category.txt"; //tên file lưu dữ liệu


        private string id, categoryName;

        public Category(string id, string categoryName)
        {
            this.id = id;
            this.categoryName = categoryName;
        }

        public Category()
        {
        }

        public string Id
        {
            get => id;
            set => id = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string CategoryName
        {
            get => categoryName;
            set => categoryName = value ?? throw new ArgumentNullException(nameof(value));
        }


        public void Input() //nhập thông tin
        {
            id = new Random(1000).Next().ToString();
            Console.Write("Category Name: ");
            categoryName = Validation.InputString();
            Console.Clear();
        }

        
        public void Display()
        {
            Console.WriteLine("{0,-20}|{1,-20}", id, categoryName); //hiển thị thông tin của 1 object
        }

        public override string ToString()
        {
            return id + "#" + categoryName; //trả về chuỗi, các thông tin cách nhau bởi dấu #
        }
    }
}