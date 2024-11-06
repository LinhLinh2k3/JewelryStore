using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //=========Auth=========//
            routes.MapRoute(
                name: "Register",
                url: "account/register",
                defaults: new { controller = "account", action = "register" }
            );

            routes.MapRoute(
                name: "Login",
                url: "account/login",
                defaults: new { controller = "account", action = "login" }
            );

            routes.MapRoute(
                name: "Logout",
                url: "account/logout",
                defaults: new { controller = "account", action = "logout" }
            );

            //=========Admin=========//
            //Authentication
            routes.MapRoute(
                "admLogin",
                "admin/login",
                new { controller = "admin", action = "login" }
            );

            routes.MapRoute(
                "admLogout",
                "admin/logout",
                new { controller = "admin", action = "logout" }
            );

            //Dashboard
            routes.MapRoute(
                name: "admDashboard",
                url: "admin/dashboard",
                defaults: new { controller = "admin", action = "index" }
            );

            //Products
            routes.MapRoute(
                name: "product-index",
                url: "admin/product/create",
                defaults: new { controller = "products", action = "index" }
            );
            routes.MapRoute(
                name: "product-create",
                url: "admin/product/create",
                defaults: new { controller = "products", action = "create" }
            );

            routes.MapRoute(
               name: "product-update",
               url: "admin/product/edit/{link}",
               defaults: new { controller = "products", action = "edit", link = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "product-delete",
                url: "admin/product/delete/{link}",
                defaults: new { controller = "products", action = "delete", link = UrlParameter.Optional }
            );

            //Categories
            routes.MapRoute(
                name: "category-index",
                url: "admin/category/create",
                defaults: new { controller = "categories", action = "index" }
            );
            routes.MapRoute(
                name: "category-create",
                url: "admin/category/create",
                defaults: new { controller = "categories", action = "create" }
            );

            routes.MapRoute(
               name: "category-update",
               url: "admin/category/edit/{link}",
               defaults: new { controller = "categories", action = "edit", link = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "category-delete",
                url: "admin/category/delete/{link}",
                defaults: new { controller = "categories", action = "delete", link = UrlParameter.Optional }
            );

            //Materials
            routes.MapRoute(
                name: "material-index",
                url: "admin/material/create",
                defaults: new { controller = "materials", action = "index" }
            );
            routes.MapRoute(
                name: "material-create",
                url: "admin/material/create",
                defaults: new { controller = "materials", action = "create" }
            );

            routes.MapRoute(
               name: "material-update",
               url: "admin/material/edit/{link}",
               defaults: new { controller = "materials", action = "edit", link = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "material-delete",
                url: "admin/material/delete/{link}",
                defaults: new { controller = "materials", action = "delete", link = UrlParameter.Optional }
            );

            //=========User=========//
            //Route cho shop
            routes.MapRoute(
                name: "shop",
                url: "shop",
                defaults: new { controller = "products", action = "shop" }
            );

            //Route cho sản phẩm
            routes.MapRoute(
                name: "product-detail",
                url: "product/detail/{link}",
                defaults: new { controller = "products", action = "show", link = UrlParameter.Optional }
            );

            //Route cho kiểu loại
            routes.MapRoute(
                name: "category-detail",
                url: "category/{link}",
                defaults: new { controller = "categories", action = "show", link = UrlParameter.Optional }
            );

            //Route cho chủng loại
            routes.MapRoute(
                name: "material-detail",
                url: "material/{link}",
                defaults: new { controller = "materials", action = "show", link = UrlParameter.Optional }
            );

            //Route cho wishlist
            routes.MapRoute(
                name: "Wishlist",
                url: "wishlist",
                defaults: new { controller = "product", action = "wishlist" }
            );

            //Route cho cart
            routes.MapRoute("Cart", "cart", new { controller = "cart", action = "index" });
            routes.MapRoute("add2Cart", "cart/add", new { controller = "cart", action = "addToCart" });
            routes.MapRoute("updateCart", "cart/update", new { controller = "cart", action = "updateCart" });
            routes.MapRoute("remFCart", "cart/remove", new { controller = "cart", action = "removeFromCart" });

            //ERROR
            routes.MapRoute("error404", "error/404", new { controller = "error", action = "NotFound" });
            routes.MapRoute("error500", "error/500", new { controller = "error", action = "InternalServerError" });

            //Mặc định
            routes.MapRoute(
                name: "Default",
                url: "{action}",
                defaults: new { controller = "page", action = "index" }
            );
        }
    }
}