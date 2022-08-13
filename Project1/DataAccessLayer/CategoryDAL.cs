using System.Collections.Generic;
using System.IO;
using System.Linq;
using Project1.Model;

namespace Project1.DataAccessLayer
{
    //Giao tiếp với csdl cho chức năng thêm sửa xóa lấy về ds
    public class CategoryDAL
    {
        //lấy về toàn bộ danh sách
        public List<Category> GetAll()
        {
            List<Category> list = new List<Category>(); //khởi tạo danh sách mới

            if (File.Exists(Category.PATH)) //kiểm tra file tồn tại
            {
                StreamReader reader = new StreamReader(Category.PATH); //mở luồn đọc file
                string line;
                while ((line = reader.ReadLine()) != null) //đọc file
                {
                    //tách chuỗi
                    string[] arr = line.Split("#");
                    // lưu thông tin vào đối tương
                    Category category = new Category(arr[0], arr[1]);
                    list.Add(category);
                }

                reader.Close();
            }

            return list;
        }

        public void Add(Category category)
        {
            //lấy về ds
            List<Category> list = GetAll();
            // /thêm vào danh sách
            list.Add(category);
            using (StreamWriter writer = new StreamWriter(Category.PATH)) //mở luồng ghi file
            {
                foreach (Category ctx in list) //duyệt danh sách
                {
                    writer.WriteLine(ctx.ToString()); //ghi file
                }
            }
        }

        public void Delete(int idx)
        {
            List<Category> list = GetAll(); //lấy về ds
            list.RemoveAt(idx); //xóa đối tượng theo vị trí
            using (StreamWriter writer = new StreamWriter(Category.PATH)) //mở luồng ghi file
            {
                foreach (Category ctx in list) //duyệt danh sácch
                {
                    writer.WriteLine(ctx.ToString()); //ghi file
                }
            }
        }

        public void Update(Category category)
        {
            List<Category> list = GetAll();//lấy về danh sách
            int idx = list.FindIndex(x => x.Id == category.Id);
            list[idx] = category;//cập nhật thông tin theo vị trí
            using (StreamWriter writer = new StreamWriter(Category.PATH))//mở luồng ghì file
            {
                foreach (Category ctx in list)//duyệt danh sách
                {
                    writer.WriteLine(ctx.ToString());//ghi filee
                }
            }
        }

        public Category DetailCategory(string id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }
    }
}