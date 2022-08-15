using System.Collections.Generic;
using System.IO;
using System.Linq;
using Project1.DataAccessLayer.Service;
using Project1.Model;

namespace Project1.DataAccessLayer
{
    //Giao tiếp với csdl cho chức năng thêm sửa xóa lấy về ds
    public class FlatDAL:IFlat
    {
        public List<Flat> GetAll() //lấy về toàn bộ danh sách
        {
            List<Flat> list = new List<Flat>(); //khởi tạo danh sách mới

            if (File.Exists(Flat.PATH)) //kiểm tra file tồn tại
            {
                StreamReader reader = new StreamReader(Flat.PATH); //mở luồn đọc file
                string line;
                while ((line = reader.ReadLine()) != null) //đọc file
                {
                    string[] arr = line.Split("#"); //tách chuỗi để lấy thông tin
                    Flat flat = new Flat(arr[0], int.Parse(arr[1])); //lưu thông tin vào đối tượng
                    list.Add(flat); //thêm vào danh sách
                }

                reader.Close(); //đóng luồng đọc file
            }

            return list;
        }

        public void Add(Flat flat)
        {
            List<Flat> list = GetAll(); //lấy về ds
            list.Add(flat); //thêm vào danh sách
            using (StreamWriter writer = new StreamWriter(Flat.PATH)) //mở luồng ghi file
            {
                foreach (Flat ctx in list) //duyệt danh sách
                {
                    writer.WriteLine(ctx.ToString()); //ghi file
                }
            }
        }

        public void Delete(int idx)
        {
            List<Flat> list = GetAll(); //lấy về ds
            list.RemoveAt(idx); //xóa đối tượng theo vị trí
            using (StreamWriter writer = new StreamWriter(Flat.PATH)) //mở luồng ghi file
            {
                foreach (Flat ctx in list) //duyệt danh sácch
                {
                    writer.WriteLine(ctx.ToString()); //ghi file
                }
            }
        }

        public void Update(int idx, Flat flat)
        {
            List<Flat> list = GetAll(); //lấy về danh sách
            list[idx] = flat; //cập nhật thông tin theo vị trí
            using (StreamWriter writer = new StreamWriter(Flat.PATH)) //mở luồng ghì file
            {
                foreach (Flat ctx in list) //duyệt danh sách
                {
                    writer.WriteLine(ctx.ToString()); //ghi filee
                }
            }
        }

        public Flat DetailFlat(string id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }
    }
}