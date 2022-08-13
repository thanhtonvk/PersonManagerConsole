using System.Collections.Generic;
using System.IO;
using System.Linq;
using Project1.Model;

namespace Project1.DataAccessLayer
{
    public class GroundDAL
    {
        public List<Ground> GetAll()
        {
            List<Ground> list = new List<Ground>();

            if (File.Exists(Ground.PATH))
            {
                StreamReader reader = new StreamReader(Ground.PATH);
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] arr = line.Split("#");
                    Ground ground = new Ground(arr[0], arr[1]);
                    list.Add(ground);
                }

                reader.Close();
            }

            return list;
        }

        public void Add(Ground ground)
        {
            List<Ground> list = GetAll();
            list.Add(ground);
            using (StreamWriter writer = new StreamWriter(Ground.PATH))
            {
                foreach (Ground ctx in list)
                {
                    writer.WriteLine(ctx.ToString());
                }
            }
        }

        public void Delete(int index)
        {
            List<Ground> list = GetAll();
            list.RemoveAt(index);
            using (StreamWriter writer = new StreamWriter(Ground.PATH))
            {
                foreach (Ground ctx in list)
                {
                    writer.WriteLine(ctx.ToString());
                }
            }
        }

        public void Update(int idx, Ground ground)
        {
            List<Ground> list = GetAll();
            list[idx] = ground;
            using (StreamWriter writer = new StreamWriter(Ground.PATH))
            {
                foreach (Ground ctx in list)
                {
                    writer.WriteLine(ctx.ToString());
                }
            }
        }

        public Ground DetailGround(string id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }
    }
}