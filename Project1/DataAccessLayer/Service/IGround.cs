using Project1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.DataAccessLayer.Service
{
    public interface IGround
    {
        List<Ground> GetAll(); //lấy về toàn bộ danh sách


        void Add(Ground ground);


        void Delete(int index);


        void Update(int idx, Ground ground);


        Ground DetailGround(string id);

    }
}
