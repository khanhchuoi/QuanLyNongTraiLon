﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyNongTraiLonThit.TienIch;
namespace QuanLyNongTraiLonThit.TangGiaoDien.Security
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (HttpContext.Current == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                         new System.Web.Routing.RouteValueDictionary(
                          new
                          {
                              Controller = "Login",
                              Action = "DangNhap",
                              Areas = "",
                              ReturnUrl = filterContext.HttpContext.Request.RawUrl
                          }));
                return;
            }
            var acc = (TaiKhoan)HttpContext.Current.Session[Common.Session.USER_SESSION];

            if (acc == null)
            {
                //  filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { Controller = "Account", Action = "Index" }));
                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary(
                        new
                        {
                            Controller = "Login",
                            Action = "DangNhap",
                            Areas="",
                            ReturnUrl = filterContext.HttpContext.Request.RawUrl
                        }));
            }
            else
            {
                CustomPrincipal cp = new CustomPrincipal(acc);
                if (!cp.IsInRole(Roles))
                {
                    filterContext.Result = new RedirectToRouteResult(
                        new System.Web.Routing.RouteValueDictionary(
                            new { Controller = "Login", Action = "DangNhap",Areas="" }));
                }
            }
        }
    }
}