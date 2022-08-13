using System;
using System.Collections.Generic;
using System.Linq;
using Project1.DataAccessLayer;
using Project1.Model;
using Project1.Utilites;

namespace Project1.Presentation
{
    public class HouseUI
    {
        private HouseDAL _dal = new HouseDAL();
        private string idRealEsate;

        public HouseUI(string idRealEsate)
        {
            this.idRealEsate = idRealEsate;
        }

        public void Add()
        {
            House House = new House();
            House.Input();
            House.Id = idRealEsate;
            _dal.Add(House);
            Console.WriteLine("Successfully");
            Console.ReadKey();
            Console.Clear();
        }

        public void Display()
        {
            List<House> Houses = _dal.GetAll().Where(x => x.Id == idRealEsate).ToList();
            Console.WriteLine("{0,-20}|{1,-20}|{2,-20}", "Bedroom", "Bathroom", "Yard");
            foreach (var House in Houses)
            {
                House.Display();
            }

            Console.ReadKey();
          
        }

        public void Update()
        {
            List<House> Houses = _dal.GetAll();
            Console.WriteLine("{0,-20}|{1,-20}|{2,-20}|{4,-20}", "Index", "Bedroom", "Bathroom", "Yard");
            foreach (var House in Houses)
            {
                Console.Write("{0,-20}|", Houses.IndexOf(House));
                House.Display();
            }

            int choose = Validation.InputNumber();
            if (choose >= Houses.Count)
            {
                Console.WriteLine("Choose incorrect");
                Console.ReadKey();
                Console.Clear();
            }

            else
            {
                House House = Houses[choose];
                House.Input();
                _dal.Update(choose, House);
                Console.WriteLine("Successfully");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public void Delete()
        {
            List<House> Houses = _dal.GetAll();
            Console.WriteLine("{0,-20}|{1,-20}|{2,-20}|{4,-20}", "Index", "Bedroom", "Bathroom", "Yard");
            foreach (var House in Houses)
            {
                Console.Write("{0,-20}|", Houses.IndexOf(House));
                House.Display();
            }

            int choose = Validation.InputNumber();
            if (choose >= Houses.Count)
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

        public void HouseMenu()
        {
            while (true)
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("             House Manager           ");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("     1. Add new House");
                Console.WriteLine("     2. Update House");
                Console.WriteLine("     3. Delete House");
                Console.WriteLine("     4. House list");
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