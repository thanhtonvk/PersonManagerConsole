using System;
using Project1.Utilites;

namespace Project1.Model
{
    //Lưu thông tin của đối tượng Villa
    public class Villa
    {
        private string id, backyard, pool, garage;
        private int numberOfFloor;
        public static string PATH = "Villa.txt";//đường dẫn file

        public Villa(string id, string backyard, string pool, string garage, int numberOfFloor)
        {
            this.id = id;
            this.backyard = backyard;
            this.pool = pool;
            this.garage = garage;
            this.numberOfFloor = numberOfFloor;
        }

        public Villa()
        {
        }

        //Nhập thông tin cho object
        public void Input()
        {
            Console.Write("Backyard: ");
            backyard = Validation.InputString();
            Console.Write("Pool: ");
            pool = Validation.InputString();
            Console.Write("Garage: ");
            garage = Validation.InputString();
            Console.Write("Number of floor: ");
            numberOfFloor = Validation.InputNumber();
            Console.Clear();
        }

        public void Display()
        {
            Console.WriteLine("{0,-20}|{1,-20}|{2,-20}|{3,-20}", backyard, pool, garage, numberOfFloor);//hiển thị thông tin
        }

        public override string ToString()
        {
            return id + "#" + backyard + "#" + pool + "#" + garage + "#" + numberOfFloor;//thông tin dạng chuỗi, cách nhau bởi dấu #
        }

        public string Id
        {
            get => id;
            set => id = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string Backyard
        {
            get => backyard;
            set => backyard = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string Pool
        {
            get => pool;
            set => pool = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string Garage
        {
            get => garage;
            set => garage = value ?? throw new ArgumentNullException(nameof(value));
        }

        public int NumberOfFloor
        {
            get => numberOfFloor;
            set => numberOfFloor = value;
        }
    }
}