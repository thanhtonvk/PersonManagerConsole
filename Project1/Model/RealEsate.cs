using System;
using System.Collections.Generic;
using Project1.DataAccessLayer;
using Project1.Utilites;

namespace Project1.Model
{
    //Chứa thông tin của RealEsate
    public class RealEsate
    {
        public static string ID_REALESATE;


        private string id, name;
        private int price;
        private string categoryId, houseOwnershipCertificate;
        private int amountBedroomAndBathRoom;
        private string description;
        public static string PATH = "RealEsate.txt"; //tên file lưu dữ liệu

        public RealEsate(string id, string name, int price, string categoryId, string houseOwnershipCertificate,
            int amountBedroomAndBathRoom, string description)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.categoryId = categoryId;
            this.houseOwnershipCertificate = houseOwnershipCertificate;
            this.amountBedroomAndBathRoom = amountBedroomAndBathRoom;
            this.description = description;
        }

        public void Input() //nhập thông tin
        {
            id = new Random(1000).Next().ToString();
            Console.Write("Name: ");
            name = Validation.InputString();
            Console.Write("Price: ");
            price = Validation.InputNumber();
            Console.Write("House ownership Certificate: ");
            houseOwnershipCertificate = Validation.InputString();
            Console.Write("Amount of bedroom and bathroom: ");
            amountBedroomAndBathRoom = Validation.InputNumber();
            Console.Write("Description: ");
            description = Validation.InputString();
            List<Category> categories = new CategoryDAL().GetAll();
            Console.WriteLine("{0,-20}|{1,-20}|{2,-20}", "Index", "ID", "Category Name");
            foreach (var category in categories)
            {
                Console.Write("{0,-20}", categories.IndexOf(category));
                category.Display();
            }

            int choose = Validation.InputNumber();
            if (choose >= categories.Count)
            {
                Console.WriteLine("Ivalid");
            }
            else
            {
                categoryId = categories[choose].Id;
            }

            Console.Clear();
        }

        public void Display()
        {
            Console.WriteLine("{0,-30}|{1,-30}|{2,-30}|{3,-30}|{4,-30}", name, price, houseOwnershipCertificate,
                amountBedroomAndBathRoom, description); //hiển thị thông tin của 1 object
        }

        public RealEsate()
        {
        }

        public string Id
        {
            get => id;
            set => id = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string Name
        {
            get => name;
            set => name = value ?? throw new ArgumentNullException(nameof(value));
        }

        public int Price
        {
            get => price;
            set => price = value;
        }

        public string CategoryId
        {
            get => categoryId;
            set => categoryId = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string HouseOwnershipCertificate
        {
            get => houseOwnershipCertificate;
            set => houseOwnershipCertificate = value ?? throw new ArgumentNullException(nameof(value));
        }

        public int AmountBedroomAndBathRoom
        {
            get => amountBedroomAndBathRoom;
            set => amountBedroomAndBathRoom = value;
        }

        public string Description
        {
            get => description;
            set => description = value ?? throw new ArgumentNullException(nameof(value));
        }

        public override string ToString()
        {
            return id + "#" + name + "#" + price + "#" + categoryId + "#" + houseOwnershipCertificate + "#" +
                   amountBedroomAndBathRoom +
                   "#" + description; //trả về chuỗi, các thông tin cách nhau bởi dấu #
        }
    }
}