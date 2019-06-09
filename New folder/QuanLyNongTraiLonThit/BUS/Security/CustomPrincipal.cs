
using System.Security.Principal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyNongTraiLonThit.TienIch;
namespace QuanLyNongTraiLonThit.TangGiaoDien.Security
{
    public class CustomPrincipal: IPrincipal
    {
        private TaiKhoan taiKhoan;
        public CustomPrincipal(TaiKhoan taiKhoan)
        {
            this.taiKhoan = taiKhoan;
            this.Identity = new GenericIdentity(taiKhoan.TenDangNhap);
        }

        public IIdentity Identity
        {
            get;
            set;
        }
        public bool IsInRole(string role)
        {
            var roles = role.Split(new char[] { ',' });
            bool kq = roles.Any(r => this.taiKhoan.Roles.Contains(r));
            return kq;
        }
    }
}