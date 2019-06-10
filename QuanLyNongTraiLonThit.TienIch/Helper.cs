using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNongTraiLonThit.TienIch
{
    public static class Helper
    {
        public static List<string> trangThaiChuong = new List<string>()
        {   "Chưa sử dụng",
            "Đang sử dụng",
            "Đang hỏng"
        };

        public static List<string> trangThaiVatNuoi = new List<string>()
        {   "Đang nuôi",
            "Đang bị bệnh",
            "Có thể xuất bán",
            "Đã xuất bán"
        };
        public static List<string> dayChuong = new List<string>()
        {
            "A","B","C","D","E","F","G","H"
        };
        /// <summary>
        /// Tra ve trang thai vat nuoi
        /// 0 : Đang nuôi
        /// 1 : Đang bị bệnh
        /// 2 : Có thể xuất bán
        /// 3 : Đã xuất bán
        /// </summary>
        /// <param name="trangthai"></param>
        /// <returns></returns>
        public static string TrangThaiVatNuoi(byte? trangthai)
        {
            string result = "Đang nuôi";
            switch (trangthai)
            {
                case 0:
                    result = "Đang nuôi";
                    break;
                case 1:
                    result = "Đang bị bệnh";
                    break;
                case 2: result =  "Có thể xuất bán"; break;
                case 3:
                    result ="Đã xuất bán"; break;
                default:
                    break;
            }
            return result;
        }
        /// <summary>
        /// Check Null or White Space.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsBlank(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }

        /// <summary>
        /// Check not Null and White Space.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNotBlank(this string str)
        {
            return !string.IsNullOrWhiteSpace(str);
        }

        public static DateTime ConvertToDate(int numberDays, DateTime startTime = new DateTime())
        {

            startTime.AddDays(numberDays);

            return startTime;
        }

        public static DateTime CurrentTime()
        {
            return DateTime.Now;
        }

        /// <summary>
        /// So luong Số :
        /// true : 4
        /// false : 3
        /// </summary>
        /// <param name="tiento">Tiền tố bảng mã</param>
        /// <param name="maHienTai"> Mã số hiện tại</param>
        /// <param name="soluongSo"> Số chữ số muốn tạo. 3 hay 4</param>
        /// <returns></returns>
        public static string TaoMa(string tiento, int maHienTai, bool soluongSo = false)
        {
            StringBuilder maChuong = new StringBuilder(tiento);
            // Tang ma hien tai len 1. Va thuc hien tinh toan chen them cac so 0 .
            maHienTai++;
            int temp = maHienTai;

            int coutZero = 2;
            if (soluongSo)
            {
                coutZero = 3;
            }
          
            while (temp / 10 > 0)
            {
                coutZero--;
                temp /= 10;
            }
            while (coutZero > 0)
            {
                maChuong.Append('0');
                coutZero--;
            }
            maChuong.Append(maHienTai.ToString());
            return maChuong.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="maHienTai"> Mã phiếu lớn nhất hiện tại</param>
        /// <param name="tiento">Mã của bảng muốn tạo phiếu</param>
        /// <returns>Trả về mã phiếu tự động</returns>
        public static string TaoMaPhieu(int maHienTai, string tiento)
        {

            StringBuilder maphieu = new StringBuilder(tiento);

            maphieu.Append(GetNow());

            // Tang ma hien tai len 1. Va thuc hien tinh toan chen them cac so 0 .
            maHienTai++;
            int temp = maHienTai;
            int coutZero = 4;
            while (temp / 10 > 0)
            {
                coutZero--;
                temp /= 10;
            }
            while (coutZero > 0)
            {
                maphieu.Append('0');
                coutZero--;
            }
            maphieu.Append(maHienTai.ToString());
            return maphieu.ToString();
        }

        public static string GetNow()
        {
            DateTime now = new DateTime(DateTime.Now.Year - 2000, DateTime.Now.Month, DateTime.Now.Day);

            StringBuilder idPhieu = new StringBuilder();

            idPhieu.Append(now.Year < 10 ? '0' + now.Year.ToString() : now.Year.ToString());
            idPhieu.Append(now.Month < 10 ? '0' + now.Month.ToString() : now.Month.ToString());
            idPhieu.Append(now.Day < 10 ? '0' + now.Day.ToString() : now.Day.ToString());

            // Có thể các biến int ở dưới dạng toàn cục. Nhưng trong trường hợp ngày sử dụng thay đổi so với khi khởi chạy. :))
            // Lúc đó cần đến thread. 
            // Neu yearNow < 2010 || > 2099 :))

            return idPhieu.ToString();
        }

        public static string TrangThaiChuong(byte? trangthai)
        {
            string result = "Chưa sử dụng";
            switch (trangthai)
            {
                case 0:
                    result = " Chưa sử dụng";
                    break;
                case 1:
                    result = " Đang sử dụng";
                    break;
                case 2:
                    result = " Đang hỏng";
                    break;
                default:
                    result = " Chưa sử dụng";
                    break;
            }
            return result;
        }
    }
}
