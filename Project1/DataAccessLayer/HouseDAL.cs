using System.Collections.Generic;
using System.IO;
using System.Linq;
using Project1.DataAccessLayer.Service;
using Project1.Model;

namespace Project1.DataAccessLayer
{//Giao tiếp với csdl cho chức năng thêm sửa xóa lấy về ds
    public class HouseDAL:IHouse
    {//lấy về toàn bộ danh sách
        public List<House> GetAll()
        {
            List<House> list = new List<House>();//khởi tạo danh sách mới

            if (File.Exists(House.PATH))//kiểm tra file tồn tại
            {
                StreamReader reader = new StreamReader(House.PATH);//mở luồn đọc file
                string line;
                while ((line = reader.ReadLine()) != null)//đọc file
                {
                    string[] arr = line.Split("#");//tách chuỗi để lấy thông tin
                    House house = new House(arr[0], arr[1],arr[2],arr[3]);//lưu thông tin vào đối tượng
                    list.Add(house);//thêm vào danh sách
                }

                reader.Close();//đóng luồng đọc file
            }

            return list;
        }

        public void Add(House house)
        {
            List<House> list = GetAll();//lấy về ds
            list.Add(house);//thêm vào danh sách
            using (StreamWriter writer = new StreamWriter(House.PATH))//mở luồng ghi file
            {
                foreach (House ctx in list)
                {
                    writer.WriteLine(ctx.ToString());//ghi file
                }
            }
        }

        public void Delete(int idx)
        {
            List<House> list = GetAll();//lấy về ds
            list.RemoveAt(idx);//xóa đối tượng theo vị trí
            using (StreamWriter writer = new StreamWriter(House.PATH))//mở luồng ghi file
            {
                foreach (House ctx in list)//duyệt danh sácch
                {
                    writer.WriteLine(ctx.ToString());//ghi file
                }
            }
        }

        public void Update(int idx, House house)
        {
            List<House> list = GetAll();//lấy về danh sách
            list[idx] = house;//cập nhật thông tin theo vị trí
            using (StreamWriter writer = new StreamWriter(House.PATH))//mở luồng ghì file
            {
                foreach (House ctx in list)//duyệt danh sách
                {
                    writer.WriteLine(ctx.ToString());//ghi filee
                }
            }
        }

        public House DetailHouse(string id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }
    }
}