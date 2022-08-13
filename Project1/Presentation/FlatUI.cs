using System;
using System.Collections.Generic;
using System.Linq;
using Project1.DataAccessLayer;
using Project1.Model;
using Project1.Utilites;

namespace Project1.Presentation
{
    public class FlatUI
    {
        private FlatDAL _dal = new FlatDAL();
        private string idRealEsate;

        public FlatUI(string idRealEsate)
        {
            this.idRealEsate = idRealEsate;
        }
// thêm mới flat
        public void Add()
        {
            Flat Flat = new Flat();
            Flat.Input();
            Flat.Id = idRealEsate;
            _dal.Add(Flat);
            Console.WriteLine("Successfully");
            Console.ReadKey();
            Console.Clear();
        }
// hiển thị danh sách
        public void Display()
        {
            List<Flat> Flats = _dal.GetAll().Where(x => x.Id == idRealEsate).ToList();
            Console.WriteLine("{0,-20}", "Floor number");
            foreach (var Flat in Flats)
            {
                Flat.Display();
            }

            Console.ReadKey();
          
        }
// cập nhật
        public void Update()
        {
            List<Flat> Flats = _dal.GetAll();
            Console.WriteLine("{0,-20}|{1,-20}", "Index", "Floor number");
            foreach (var Flat in Flats)
            {
                Console.Write("{0,-20}|", Flats.IndexOf(Flat));
                Flat.Display();
            }

            int choose = Validation.InputNumber();
            if (choose >= Flats.Count)
            {
                Console.WriteLine("Choose incorrect");
                Console.ReadKey();
                Console.Clear();
            }

            else
            {
                Flat Flat = Flats[choose];
                Flat.Input();
                _dal.Update(choose, Flat);
                Console.WriteLine("Successfully");
                Console.ReadKey();
                Console.Clear();
            }
        }
// xóa
        public void Delete()
        {
            List<Flat> Flats = _dal.GetAll();
            Console.WriteLine("{0,-20}|{1,-20}", "Index", "Floor number");
            foreach (var Flat in Flats)
            {
                Console.Write("{0,-20}|", Flats.IndexOf(Flat));
                Flat.Display();
            }

            int choose = Validation.InputNumber();
            if (choose >= Flats.Count)
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
// menu chọn chức năng
        public void FlatMenu()
        {
            while (true)
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("             Flat Manager           ");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("     1. Add new Flat");
                Console.WriteLine("     2. Update Flat");
                Console.WriteLine("     3. Delete Flat");
                Console.WriteLine("     4. Flat list");
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