using Project1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1.DataAccessLayer.Service
{
    public interface IRealEsate
    {
        List<RealEsate> GetAll();


        void Add(RealEsate realEsate);

        void Delete(int idx);


        void Update(int idx, RealEsate realEsate);


        RealEsate DetailRealEsate(string id);

        Category GetCategoryId(string id);
       
    }
}
