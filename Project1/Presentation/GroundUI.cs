using System;
using System.Collections.Generic;
using System.Linq;
using Project1.DataAccessLayer;
using Project1.Model;
using Project1.Utilites;

namespace Project1.Presentation
{
    public class GroundUI
    {
        private GroundDAL _dal = new GroundDAL();
        private string idRealEsate;

        public GroundUI(string idRealEsate)
        {
            this.idRealEsate = idRealEsate;
        }

        public void Add()
        {
            Ground Ground = new Ground();
            Ground.Input();
            Ground.Id = idRealEsate;
            _dal.Add(Ground);
            Console.WriteLine("Successfully");
            Console.ReadKey();
            Console.Clear();
        }

        public void Display()
        {
            List<Ground> Grounds = _dal.GetAll().Where(x => x.Id == idRealEsate).ToList();
            Console.WriteLine("{0,-20}", "Type of ground");
            foreach (var Ground in Grounds)
            {
                Ground.Display();
            }

            Console.ReadKey();
          
        }

        public void Update()
        {
            List<Ground> Grounds = _dal.GetAll();
            Console.WriteLine("{0,-20}|{1,-20}", "Index", "Type of ground");
            foreach (var Ground in Grounds)
            {
                Console.Write("{0,-20}|", Grounds.IndexOf(Ground));
                Ground.Display();
            }

            int choose = Validation.InputNumber();
            if (choose >= Grounds.Count)
            {
                Console.WriteLine("Choose incorrect");
                Console.ReadKey();
                Console.Clear();
            }

            else
            {
                Ground Ground = Grounds[choose];
                Ground.Input();
                _dal.Update(choose, Ground);
                Console.WriteLine("Successfully");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public void Delete()
        {
            List<Ground> Grounds = _dal.GetAll();
            Console.WriteLine("{0,-20}|{1,-20}", "Index", "Type of ground");
            foreach (var Ground in Grounds)
            {
                Console.Write("{0,-20}|", Grounds.IndexOf(Ground));
                Ground.Display();
            }

            int choose = Validation.InputNumber();
            if (choose >= Grounds.Count)
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

        public void GroundMenu()
        {
            while (true)
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("             Ground Manager           ");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("     1. Add new Ground");
                Console.WriteLine("     2. Update Ground");
                Console.WriteLine("     3. Delete Ground");
                Console.WriteLine("     4. Ground list");
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