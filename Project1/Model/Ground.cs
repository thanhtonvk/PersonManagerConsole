using System;
using Project1.Utilites;

namespace Project1.Model
{
    public class Ground
    {
        private string id, typeOfGround;
        public static string PATH = "Ground.txt";
        public Ground(string id, string typeOfGround)
        {
            this.id = id;
            this.typeOfGround = typeOfGround;
        }

        public Ground()
        {
        }

        public void Input()
        {
          
            Console.Write("Type of ground: ");
            typeOfGround = Validation.InputString();     Console.Clear();
        }

        public void Display()
        {
            Console.WriteLine("{0,-20}", typeOfGround);
        }

        public string Id
        {
            get => id;
            set => id = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string TypeOfGround
        {
            get => typeOfGround;
            set => typeOfGround = value ?? throw new ArgumentNullException(nameof(value));
        }

        public override string ToString()
        {
            return id + "#" + typeOfGround;
        }
    }
}