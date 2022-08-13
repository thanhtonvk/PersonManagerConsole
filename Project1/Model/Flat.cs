using System;
using Project1.Utilites;

namespace Project1.Model
{
    // chứa thông tin của Flat
    public class Flat
    {
        private string id;
        private int floorNumber;

        public static string PATH = "Flat.txt";//tên file lưu dữ liệu
        public Flat()
        {
        }

        public Flat(string id, int floorNumber)
        {
            this.id = id;
            this.floorNumber = floorNumber;
        }

        public void Input()//nhập thông tin
        {
           
            Console.Write("Floor number: ");
            floorNumber = Validation.InputNumber();     Console.Clear();
        }

        public void Display()
        {
            Console.WriteLine("{0,-20}", floorNumber);//hiển thị thông tin của 1 object
        }

        public string Id
        {
            get => id;
            set => id = value ?? throw new ArgumentNullException(nameof(value));
        }

        public int FloorNumber
        {
            get => floorNumber;
            set => floorNumber = value;
        }

        public override string ToString()
        {
            return id + "#" + floorNumber;//trả về chuỗi, các thông tin cách nhau bởi dấu #
        }
    }
}