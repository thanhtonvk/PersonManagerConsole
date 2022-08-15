using Project1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.DataAccessLayer.Service
{
    internal interface IHouse
    {
        List<House> GetAll();

        void Add(House house);


        void Delete(int idx);


        void Update(int idx, House house);


        House DetailHouse(string id);
    }

}
