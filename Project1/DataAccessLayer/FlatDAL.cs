using System.Collections.Generic;
using System.IO;
using System.Linq;
using Project1.Model;

namespace Project1.DataAccessLayer
{
    public class FlatDAL
    {
        public List<Flat> GetAll()
        {
            List<Flat> list = new List<Flat>();

            if (File.Exists(Flat.PATH))
            {
                StreamReader reader = new StreamReader(Flat.PATH);
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] arr = line.Split("#");
                    Flat flat = new Flat(arr[0], int.Parse(arr[1]));
                    list.Add(flat);
                }

                reader.Close();
            }

            return list;
        }

        public void Add(Flat flat)
        {
            List<Flat> list = GetAll();
            list.Add(flat);
            using (StreamWriter writer = new StreamWriter(Flat.PATH))
            {
                foreach (Flat ctx in list)
                {
                    writer.WriteLine(ctx.ToString());
                }
            }
        }

        public void Delete(int idx)
        {
            List<Flat> list = GetAll();
            list.RemoveAt(idx);
            using (StreamWriter writer = new StreamWriter(Flat.PATH))
            {
                foreach (Flat ctx in list)
                {
                    writer.WriteLine(ctx.ToString());
                }
            }
        }

        public void Update(int idx, Flat flat)
        {
            List<Flat> list = GetAll();
            list[idx] = flat;
            using (StreamWriter writer = new StreamWriter(Flat.PATH))
            {
                foreach (Flat ctx in list)
                {
                    writer.WriteLine(ctx.ToString());
                }
            }
        }

        public Flat DetailFlat(string id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }
    }
}