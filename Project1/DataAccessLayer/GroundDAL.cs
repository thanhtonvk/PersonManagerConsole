using System.Collections.Generic;
using System.IO;
using System.Linq;
using Project1.DataAccessLayer.Service;
using Project1.Model;

namespace Project1.DataAccessLayer
{
    //Giao tiếp với csdl cho chức năng thêm sửa xóa lấy về ds
    public class GroundDAL:IGround
    {
        public List<Ground> GetAll() //lấy về toàn bộ danh sách
        {
            List<Ground> list = new List<Ground>(); //khởi tạo danh sách mới

            if (File.Exists(Ground.PATH)) //kiểm tra file tồn tại
            {
                StreamReader reader = new StreamReader(Ground.PATH); //mở luồn đọc file
                string line;
                while ((line = reader.ReadLine()) != null) //đọc file
                {
                    string[] arr = line.Split("#"); //tách chuỗi để lấy thông tin
                    Ground ground = new Ground(arr[0], arr[1]); //lưu thông tin vào đối tượng
                    list.Add(ground); //thêm vào danh sách
                }

                reader.Close(); //đóng luồng đọc file
            }

            return list;
        }

        public void Add(Ground ground)
        {
            List<Ground> list = GetAll(); //lấy về ds
            list.Add(ground); //thêm vào danh sách
            using (StreamWriter writer = new StreamWriter(Ground.PATH)) //mở luồng ghi file
            {
                foreach (Ground ctx in list) //duyệt danh sách
                {
                    writer.WriteLine(ctx.ToString()); //ghi file
                }
            }
        }

        public void Delete(int index)
        {
            List<Ground> list = GetAll(); //lấy về ds
            list.RemoveAt(index); //xóa đối tượng theo vị trí
            using (StreamWriter writer = new StreamWriter(Ground.PATH))
            {
                foreach (Ground ctx in list) //duyệt danh sácch
                {
                    writer.WriteLine(ctx.ToString()); //ghi file
                }
            }
        }

        public void Update(int idx, Ground ground)
        {
            List<Ground> list = GetAll(); //lấy về danh sách
            list[idx] = ground; //cập nhật thông tin theo vị trí
            using (StreamWriter writer = new StreamWriter(Ground.PATH)) //mở luồng ghì file
            {
                foreach (Ground ctx in list) //duyệt danh sách
                {
                    writer.WriteLine(ctx.ToString()); //ghi filee
                }
            }
        }

        public Ground DetailGround(string id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }
    }
}