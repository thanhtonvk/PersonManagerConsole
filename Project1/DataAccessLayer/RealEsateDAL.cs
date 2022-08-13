using System.Collections.Generic;
using System.IO;
using System.Linq;
using Project1.Model;

namespace Project1.DataAccessLayer
{
    public class RealEsateDAL
    {
        public List<RealEsate> GetAll()
        {
            List<RealEsate> list = new List<RealEsate>();

            if (File.Exists(RealEsate.PATH))
            {
                StreamReader reader = new StreamReader(RealEsate.PATH);
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] arr = line.Split("#");
                    RealEsate realEsate = new RealEsate(arr[0], arr[1], int.Parse(arr[2]), arr[3], arr[4],
                        int.Parse(arr[5]), arr[6]);
                    list.Add(realEsate);
                }

                reader.Close();
            }

            return list;
        }

        public void Add(RealEsate realEsate)
        {
            List<RealEsate> list = GetAll();
            list.Add(realEsate);
            using (StreamWriter writer = new StreamWriter(RealEsate.PATH))
            {
                foreach (RealEsate ctx in list)
                {
                    writer.WriteLine(ctx.ToString());
                }
            }
        }

        public void Delete(int idx)
        {
            List<RealEsate> list = GetAll();
            list.RemoveAt(idx);
            using (StreamWriter writer = new StreamWriter(RealEsate.PATH))
            {
                foreach (RealEsate ctx in list)
                {
                    writer.WriteLine(ctx.ToString());
                }
            }
        }

        public void Update(RealEsate realEsate)
        {
            List<RealEsate> list = GetAll();
            int idx = list.FindIndex(x => x.Name == realEsate.Name);
            list[idx] = realEsate;
            using (StreamWriter writer = new StreamWriter(RealEsate.PATH))
            {
                foreach (RealEsate ctx in list)
                {
                    writer.WriteLine(ctx.ToString());
                }
            }
        }

        public RealEsate DetailRealEsate(string id)
        {
            return GetAll().FirstOrDefault(x => x.Name == id);
        }

        public Category GetCategoryId(string id)
        {
            return new CategoryDAL().DetailCategory(id);
        }
    }
}