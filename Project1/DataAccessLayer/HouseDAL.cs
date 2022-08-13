using System.Collections.Generic;
using System.IO;
using System.Linq;
using Project1.Model;

namespace Project1.DataAccessLayer
{
    public class HouseDAL
    {
        public List<House> GetAll()
        {
            List<House> list = new List<House>();

            if (File.Exists(House.PATH))
            {
                StreamReader reader = new StreamReader(House.PATH);
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] arr = line.Split("#");
                    House house = new House(arr[0], arr[1],arr[2],arr[3]);
                    list.Add(house);
                }

                reader.Close();
            }

            return list;
        }

        public void Add(House house)
        {
            List<House> list = GetAll();
            list.Add(house);
            using (StreamWriter writer = new StreamWriter(House.PATH))
            {
                foreach (House ctx in list)
                {
                    writer.WriteLine(ctx.ToString());
                }
            }
        }

        public void Delete(int idx)
        {
            List<House> list = GetAll();
            list.RemoveAt(idx);
            using (StreamWriter writer = new StreamWriter(House.PATH))
            {
                foreach (House ctx in list)
                {
                    writer.WriteLine(ctx.ToString());
                }
            }
        }

        public void Update(int idx, House house)
        {
            List<House> list = GetAll();
            list[idx] = house;
            using (StreamWriter writer = new StreamWriter(House.PATH))
            {
                foreach (House ctx in list)
                {
                    writer.WriteLine(ctx.ToString());
                }
            }
        }

        public House DetailHouse(string id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }
    }
}