using System.Collections.Generic;
using System.IO;
using System.Linq;
using Project1.Model;

namespace Project1.DataAccessLayer
{
    public class CategoryDAL
    {
        public List<Category> GetAll()
        {
            List<Category> list = new List<Category>();

            if (File.Exists(Category.PATH))
            {
                StreamReader reader = new StreamReader(Category.PATH);
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] arr = line.Split("#");
                    Category category = new Category(arr[0], arr[1]);
                    list.Add(category);
                }

                reader.Close();
            }

            return list;
        }

        public void Add(Category category)
        {
            List<Category> list = GetAll();
            list.Add(category);
            using (StreamWriter writer = new StreamWriter(Category.PATH))
            {
                foreach (Category ctx in list)
                {
                    writer.WriteLine(ctx.ToString());
                }
            }
        }

        public void Delete(int idx)
        {
            List<Category> list = GetAll();
            list.RemoveAt(idx);
            using (StreamWriter writer = new StreamWriter(Category.PATH))
            {
                foreach (Category ctx in list)
                {
                    writer.WriteLine(ctx.ToString());
                }
            }
        }

        public void Update(Category category)
        {
            List<Category> list = GetAll();
            int idx = list.FindIndex(x => x.Id == category.Id);
            list[idx] = category;
            using (StreamWriter writer = new StreamWriter(Category.PATH))
            {
                foreach (Category ctx in list)
                {
                    writer.WriteLine(ctx.ToString());
                }
            }
        }

        public Category DetailCategory(string id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }
    }
}