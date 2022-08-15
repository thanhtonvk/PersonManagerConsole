using Project1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.DataAccessLayer.Service
{
    public  interface ICategory
    {
        List<Category> GetAll();
        void Add(Category category);

        void Delete(int idx);

        void Update(int idx, Category category);
        Category DetailCategory(string id);
        
    }
}
