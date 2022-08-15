using Project1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.DataAccessLayer.Service
{
    public interface IFlat
    {
        List<Flat> GetAll(); //lấy về toàn bộ danh sách


        void Add(Flat flat);

        void Delete(int idx);


        void Update(int idx, Flat flat);


        Flat DetailFlat(string id);
       
    }
}
