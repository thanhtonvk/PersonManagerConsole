using System.Collections.Generic;
using System.IO;
using System.Linq;
using Project1.Model;

namespace Project1.DataAccessLayer
{
    public class VillaDAL
    {
        public List<Villa> GetAll()
        {
            List<Villa> list = new List<Villa>();

            if (File.Exists(Villa.PATH))
            {
                StreamReader reader = new StreamReader(Villa.PATH);
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] arr = line.Split("#");
                    Villa villa = new Villa(arr[0], arr[1], (arr[2]), arr[3], int.Parse(arr[4]));
                    list.Add(villa);
                }

                reader.Close();
            }

            return list;
        }

        public void Add(Villa villa)
        {
            List<Villa> list = GetAll();
            list.Add(villa);
            using (StreamWriter writer = new StreamWriter(Villa.PATH))
            {
                foreach (Villa ctx in list)
                {
                    writer.WriteLine(ctx.ToString());
                }
            }
        }

        public void Delete(int idx)
        {
            List<Villa> list = GetAll();
            list.RemoveAt(idx);
            using (StreamWriter writer = new StreamWriter(Villa.PATH))
            {
                foreach (Villa ctx in list)
                {
                    writer.WriteLine(ctx.ToString());
                }
            }
        }

        public void Update(int idx, Villa villa)
        {
            List<Villa> list = GetAll();
            list[idx] = villa;
            using (StreamWriter writer = new StreamWriter(Villa.PATH))
            {
                foreach (Villa ctx in list)
                {
                    writer.WriteLine(ctx.ToString());
                }
            }
        }

        public Villa DetailVilla(string id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }

        public Category GetCategoryId(string id)
        {
            return new CategoryDAL().DetailCategory(id);
        }
    }
}