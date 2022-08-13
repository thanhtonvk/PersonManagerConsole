using System;
using System.Collections.Generic;
using Project1.DataAccessLayer;
using Project1.Model;
using Project1.Utilites;

namespace Project1.Presentation
{
    public class RealEsateUI
    {
        private RealEsateDAL _dal = new RealEsateDAL();

// thêm mới
        public void Add()
        {
            RealEsate realEsate = new RealEsate();
            realEsate.Input();
            _dal.Add(realEsate);
            Console.WriteLine("Successfully");
            Console.ReadKey();
            Console.Clear();
        }

// hiển thị
        public void Display()
        {
            List<RealEsate> realEsates = _dal.GetAll();
            Console.WriteLine("{0,-30}|{1,-30}|{2,-30}|{3,-30}|{4,-30}|{5,-30}", "Index", "Name", "Price",
                "House Ownership Certificate",
                "Amount Bedroom And BathRoom", "Description");

            foreach (var realEsate in realEsates)
            {
                Console.Write("{0,-30}|", realEsates.IndexOf(realEsate));
                realEsate.Display();
            }


            //view more detail
// hiển thị thông tin chi tiết 
            Console.Write("Choose view details: ");
            int choose = Validation.InputNumber();
            if (choose >= realEsates.Count)
            {
                Console.WriteLine("Invalid");
            }
            else
            {
                RealEsate realEsate = realEsates[choose];
                Console.Clear();
                Console.WriteLine("Name: {0}", realEsate.Name);
                Console.WriteLine("House Ownership Certificate: {0}", realEsate.HouseOwnershipCertificate);
                Console.WriteLine("Amount Bedroom And BathRoom: {0}", realEsate.AmountBedroomAndBathRoom);
                Console.WriteLine("Price: {0}", realEsate.Price);
                Console.WriteLine("Description: {0}", realEsate.Description);
                Console.WriteLine("List Ground");
                new GroundUI(realEsate.Id).Display();
                Console.WriteLine("List Flat");
                new FlatUI(realEsate.Id).Display();
                Console.WriteLine("List Villa");
                new VillaUI(realEsate.Id).Display();
                Console.WriteLine("List House");
                new HouseUI(realEsate.Id).Display();
                MenuDetails(realEsate.Id);
            }

            Console.ReadKey();
            Console.Clear();
        }

// menu quản lý chi tiết
        public void MenuDetails(String realEsateId)
        {
            while (true)
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("       Details Real Esate Manager     ");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("     1. Ground Management");
                Console.WriteLine("     2. Flat Management");
                Console.WriteLine("     3. Villa Management");
                Console.WriteLine("     4. House Management");
                Console.WriteLine("     0. Back");
                Console.WriteLine("--------------------------------------");
                int choose = Validation.InputNumber();
                switch (choose)
                {
                    case 1:
                        new GroundUI(realEsateId).GroundMenu();
                        break;
                    case 2:
                        new FlatUI(realEsateId).FlatMenu();
                        break;
                    case 3:
                        new VillaUI(realEsateId).VillaMenu();
                        break;
                    case 4:
                        new HouseUI(realEsateId).HouseMenu();
                        break;
                    default: break;
                }

                if (choose == 0) break;
            }
        }

//cap nhat
        public void Update()
        {
            List<RealEsate> realEsates = _dal.GetAll();
            Console.WriteLine("{0,-30}|{1,-30}|{2,-30}|{3,-30}|{4,-30}|{5,-30}", "Index", "Name", "Price",
                "House Ownership Certificate",
                "Amount Bedroom And BathRoom", "Description");

            foreach (var realEsate in realEsates)
            {
                Console.Write("{0,-30}|", realEsates.IndexOf(realEsate));
                realEsate.Display();
            }

            int choose = Validation.InputNumber();
            if (choose >= realEsates.Count)
            {
                Console.WriteLine("Choose incorrect");
                Console.ReadKey();
                Console.Clear();
            }

            else
            {
                RealEsate realEsate = realEsates[choose];
                realEsate.Input();
                _dal.Update(realEsate);
                Console.WriteLine("Successfully");
                Console.ReadKey();
                Console.Clear();
            }
        }

// xóa thông tin
        public void Delete()
        {
            List<RealEsate> realEsates = _dal.GetAll();
            Console.WriteLine("{0,-30}|{1,-30}|{2,-30}|{3,-30}|{4,-30}|{5,-30}", "Index", "Name", "Price",
                "House Ownership Certificate",
                "Amount Bedroom And BathRoom", "Description");

            foreach (var realEsate in realEsates)
            {
                Console.Write("{0,-30}|", realEsates.IndexOf(realEsate));
                realEsate.Display();
            }

            int choose = Validation.InputNumber();
            if (choose >= realEsates.Count)
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

// menu
        public void RealEstaMenu()
        {
            while (true)
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("           Real Esate Manager          ");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("     1. Add new Esate");
                Console.WriteLine("     2. Update Esate");
                Console.WriteLine("     3. Delete Esate");
                Console.WriteLine("     4. Real Esate list");
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