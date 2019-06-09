using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using QuanLyNongTraiLonThit.TangDuLieu;

namespace QuanLyNongTraiLonThit.TangNghiepVu
{
   public class Singleton
    {
      public static QuanLyNongTraiLonDBContext  shared = new  QuanLyNongTraiLonDBContext();
    }
}
