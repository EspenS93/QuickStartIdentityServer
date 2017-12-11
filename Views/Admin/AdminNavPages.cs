using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace QuickStartIdentityServer.Views.Admin
{
    public static class AdminNavPages
    {
        public static string ActivePageKey => "ActivePage";
        public static string Index => "Index";
        public static string Users => "Users";
        public static string Roles => "Roles";
        public static string Products => "Products";
        public static string Licenses => "Licenses";
        public static string Invoices => "Invoices";
        public static string Specials => "Specials";


        public static string IndexNavClass(ViewContext viewContext) => PageNavClass(viewContext, Index);
        public static string UsersNavClass(ViewContext viewContext) => PageNavClass(viewContext, Users);
        public static string RolesNavClass(ViewContext viewContext) => PageNavClass(viewContext, Roles);
        public static string ProductsNavClass(ViewContext viewContext) => PageNavClass(viewContext, Products);
        public static string LicensesNavClass(ViewContext viewContext) => PageNavClass(viewContext, Licenses);
        public static string InvoicesNavClass(ViewContext viewContext) => PageNavClass(viewContext, Invoices);
        public static string SpecialsNavClass(ViewContext viewContext) => PageNavClass(viewContext, Specials);


        public static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string;
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }

        public static void AddActivePage(this ViewDataDictionary viewData, string activePage) => viewData[ActivePageKey] = activePage;
    }
}
