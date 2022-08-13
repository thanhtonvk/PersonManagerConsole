using System;
using Project1.Utilites;

namespace Project1.Model
{
    public class House
    {
        private string id, bedRoom, bathRoom, yard;
        public static string PATH = "House.txt"; //tên file lưu dữ liệu

        public House(string id, string bedRoom, string bathRoom, string yard)
        {
            this.id = id;
            this.bedRoom = bedRoom;
            this.bathRoom = bathRoom;
            this.yard = yard;
        }

        public void Input() //nhập thông tin
        {
            Console.Write("Bedroom: ");
            bedRoom = Validation.InputString();
            Console.Write("Bathroom: ");
            bathRoom = Validation.InputString();
            Console.Write("Yard: ");
            yard = Validation.InputString();
            Console.Clear();
        }

        public void Display()
        {
            Console.WriteLine("{0,-20}|{1,-20}|{2,-20}", bedRoom, bathRoom, yard); //hiển thị thông tin của 1 object
        }

        public override string ToString()
        {
            return id + "#" + bedRoom + "#" + bathRoom + "#" + yard; //trả về chuỗi, các thông tin cách nhau bởi dấu #
        }

        public House()
        {
        }

        public string Id
        {
            get => id;
            set => id = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string BedRoom
        {
            get => bedRoom;
            set => bedRoom = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string BathRoom
        {
            get => bathRoom;
            set => bathRoom = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string Yard
        {
            get => yard;
            set => yard = value ?? throw new ArgumentNullException(nameof(value));
        }
    }
}