using System;
using Project1.Utilites;

namespace Project1.Presentation
{
    public class ManagerUI
    {
        //menu manager
        public void ManagerMenu()
        {
            while (true)
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("              Manager          ");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("     1. Category Management");
                Console.WriteLine("     2. RealEsate Management");
                Console.WriteLine("     0. Back");
                Console.WriteLine("--------------------------------------");
                int choose = Validation.InputNumber();
                switch (choose)
                {
                    case 1:
                        new CategoryUI().CategoryMenu();
                        break;
                    case 2:
                        new RealEsateUI().RealEstaMenu();
                        break;
                    default: break;
                }

                if (choose == 0) break;
            }
        }
    }
}