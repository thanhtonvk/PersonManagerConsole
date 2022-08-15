using System.Collections.Generic;
using System.IO;
using System.Linq;
using Project1.DataAccessLayer.Service;
using Project1.Model;

namespace Project1.DataAccessLayer
{ //Giao tiếp với csdl cho chức năng thêm sửa xóa lấy về ds
    public class RealEsateDAL: IRealEsate
    {
        // lấy về toàn bộ thông tin từ file
        public List<RealEsate> GetAll()
        {
            List<RealEsate> list = new List<RealEsate>(); //khởi tạo danh sách mới

            if (File.Exists(RealEsate.PATH))//kiểm tra file tồn tại
            {
                StreamReader reader = new StreamReader(RealEsate.PATH);//mở luồn đọc file
                string line;
                while ((line = reader.ReadLine()) != null)//đọc file
                {
                    string[] arr = line.Split("#");//tách chuỗi để lấy thông tin
                    //lưu thông tin vào đối tượng
                    RealEsate realEsate = new RealEsate(arr[0], arr[1], int.Parse(arr[2]), arr[3], arr[4],
                        int.Parse(arr[5]), arr[6]);
                    list.Add(realEsate);//thêm vào danh sách
                }

                reader.Close();//đóng luồng đọc file
            }

            return list;
        }

        public void Add(RealEsate realEsate)
        {
            List<RealEsate> list = GetAll();//lấy về ds
            list.Add(realEsate);//thêm vào danh sách
            using (StreamWriter writer = new StreamWriter(RealEsate.PATH))//mở luồng ghi file
            {
                foreach (RealEsate ctx in list)//duyệt danh sách
                {
                    writer.WriteLine(ctx.ToString());//ghi file
                }
            }
        }

        public void Delete(int idx)
        {
            List<RealEsate> list = GetAll();//lấy về ds
            list.RemoveAt(idx);//xóa đối tượng theo vị trí
            using (StreamWriter writer = new StreamWriter(RealEsate.PATH))//mở luồng ghi file
            {
                foreach (RealEsate ctx in list)//duyệt danh sácch
                {
                    writer.WriteLine(ctx.ToString());//ghi file
                }
            }
        }

        public void Update(int idx,RealEsate realEsate)
        {
            List<RealEsate> list = GetAll();//lấy về danh sách
          
            list[idx] = realEsate;//cập nhật thông tin theo vị trí
            using (StreamWriter writer = new StreamWriter(RealEsate.PATH))//mở luồng ghì file
            {
                foreach (RealEsate ctx in list)//duyệt danh sách
                {
                    writer.WriteLine(ctx.ToString());//ghi filee
                }
            }
        }

        public RealEsate DetailRealEsate(string id)
        {
            return GetAll().FirstOrDefault(x => x.Name == id);
        }

        public Category GetCategoryId(string id)
        {
            return new CategoryDAL().DetailCategory(id);
        }
    }
}