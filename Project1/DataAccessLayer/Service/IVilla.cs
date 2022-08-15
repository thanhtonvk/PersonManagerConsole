using Project1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.DataAccessLayer.Service
{
    public interface IVilla
    {
        List<Villa> GetAll();//lấy về toàn bộ danh sách


        void Add(Villa villa);


        void Delete(int idx);


        void Update(int idx, Villa villa);


        Villa DetailVilla(string id);


        Category GetCategoryId(string id);
       
    }
}
