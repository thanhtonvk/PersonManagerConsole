using System.Collections.Generic;
using System.IO;
using System.Linq;
using Project1.DataAccessLayer.Service;
using Project1.Model;

namespace Project1.DataAccessLayer
{
    //Giao tiếp với csdl cho chức năng thêm sửa xóa lấy về ds
    public class VillaDAL:IVilla
    {
        
        public List<Villa> GetAll() //lấy về toàn bộ danh sách
        {
            List<Villa> list = new List<Villa>(); //khởi tạo danh sách mới

            if (File.Exists(Villa.PATH))//kiểm tra file tồn tại
            {
                StreamReader reader = new StreamReader(Villa.PATH);//mở luồn đọc file
                string line;
                while ((line = reader.ReadLine()) != null)//đọc file
                {
                    string[] arr = line.Split("#");//tách chuỗi để lấy thông tin
                    Villa villa = new Villa(arr[0], arr[1], (arr[2]), arr[3], int.Parse(arr[4])); //lưu thông tin vào đối tượng
                    list.Add(villa);//thêm vào danh sách
                }

                reader.Close();//đóng luồng đọc file
            }

            return list;
        }

        public void Add(Villa villa)
        {
            List<Villa> list = GetAll();//lấy về ds
            list.Add(villa);//thêm vào danh sách
            using (StreamWriter writer = new StreamWriter(Villa.PATH))//mở luồng ghi file
            {
                foreach (Villa ctx in list)//duyệt danh sách
                {
                    writer.WriteLine(ctx.ToString());//ghi file
                }
            }
        }

        public void Delete(int idx)
        {
            List<Villa> list = GetAll();//lấy về ds
            list.RemoveAt(idx);//xóa đối tượng theo vị trí
            using (StreamWriter writer = new StreamWriter(Villa.PATH))//mở luồng ghi file
            {
                foreach (Villa ctx in list)//duyệt danh sácch
                {
                    writer.WriteLine(ctx.ToString());//ghi file
                }
            }
        }

        public void Update(int idx, Villa villa)
        {
            List<Villa> list = GetAll();//lấy về danh sách
            list[idx] = villa;//cập nhật thông tin theo vị trí
            using (StreamWriter writer = new StreamWriter(Villa.PATH))//mở luồng ghì file
            {
                foreach (Villa ctx in list)//duyệt danh sách
                {
                    writer.WriteLine(ctx.ToString());//ghi filee
                }
            }
        }

        public Villa DetailVilla(string id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }

        public Category GetCategoryId(string id)
        {
            return new CategoryDAL().DetailCategory(id);
        }
    }
}