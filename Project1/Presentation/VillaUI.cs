using System;
using System.Collections.Generic;
using System.Linq;
using Project1.DataAccessLayer;
using Project1.Model;
using Project1.Utilites;

namespace Project1.Presentation
{
    public class VillaUI
    {
        private VillaDAL _dal = new VillaDAL();
        private string idRealEsate;

        public VillaUI(string idRealEsate)
        {
            this.idRealEsate = idRealEsate;
        }

        public void Add()
        {
            Villa Villa = new Villa();
            Villa.Input();
            Villa.Id = idRealEsate;
            _dal.Add(Villa);
            Console.WriteLine("Successfully");
            Console.ReadKey();
            Console.Clear();
        }

        public void Display()
        {
            List<Villa> Villas = _dal.GetAll().Where(x => x.Id == idRealEsate).ToList();
            Console.WriteLine("{0,-20}|{1,-20}|{2,-20}|{3,-20}|", "Backyard","Pool","Garage","Number of Floor");
            foreach (var Villa in Villas)
            {
                Villa.Display();
            }

            Console.ReadKey();
          
        }

        public void Update()
        {
            List<Villa> Villas = _dal.GetAll();
            Console.WriteLine("{0,-20}|{1,-20}|{2,-20}|{3,-20}|{4,-20}", "Index","Backyard","Pool","Garage","Number of Floor");
            foreach (var Villa in Villas)
            {
                Console.Write("{0,-20}|", Villas.IndexOf(Villa));
                Villa.Display();
            }

            int choose = Validation.InputNumber();
            if (choose >= Villas.Count)
            {
                Console.WriteLine("Choose incorrect");
                Console.ReadKey();
                Console.Clear();
            }

            else
            {
                Villa Villa = Villas[choose];
                Villa.Input();
                _dal.Update(choose, Villa);
                Console.WriteLine("Successfully");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public void Delete()
        {
            List<Villa> Villas = _dal.GetAll();
            Console.WriteLine("{0,-20}|{1,-20}|{2,-20}|{3,-20}|{4,-20}", "Index","Backyard","Pool","Garage","Number of Floor");
            foreach (var Villa in Villas)
            {
                Console.Write("{0,-20}|", Villas.IndexOf(Villa));
                Villa.Display();
            }

            int choose = Validation.InputNumber();
            if (choose >= Villas.Count)
            {
                Console.WriteLine("Choose incorrect");
                Console.ReadKey();
                Console.Clear();
            }

            else
            {
                _dal.Delete(choose);
                Console.WriteLine("Successfully");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public void VillaMenu()
        {
            while (true)
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("             Villa Manager           ");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("     1. Add new Villa");
                Console.WriteLine("     2. Update Villa");
                Console.WriteLine("     3. Delete Villa");
                Console.WriteLine("     4. Villa list");
                Console.WriteLine("     0. Back");
                Console.WriteLine("--------------------------------------");
                int choose = Validation.InputNumber();
                switch (choose)
                {
                    case 1:
                        Add();
                        break;
                    case 2:
                        Update();
                        break;
                    case 3:
                        Delete();
                        break;
                    case 4:
                        Display();
                        break;
                    default: break;
                }

                if (choose == 0) break;
            }
        }
    }
}