using EasyLOB.Environment;
using Syncfusion.EJ2.Navigations;
using System.Collections.Generic;
using System.Web.Mvc;

namespace EasyLOB
{
    public class EasyLOBMenuAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            Controller controller = (Controller)filterContext.Controller;
            if (controller != null)
            {

                MenuFieldSettings menuFieldSettings = new MenuFieldSettings
                {
                    Id = "Id",
                    Text = "Text",
                    ParentId = "ParentId",
                    Url = "Url"
                };
                controller.ViewBag.MenuFields = menuFieldSettings;

                IAuthenticationManager authenticationManager = DependencyResolver.Current.GetService<IAuthenticationManager>();
                List<AppMenu> menu = MenuHelper.Menu(authenticationManager);
                //controller.ViewBag.Menu = menu;

                List<AppMenuEJ2> menuEJ2 = new List<AppMenuEJ2>();
                foreach (AppMenu appMenu in menu)
                {
                    AppMenuEJ2 appMenuEJ2 = new AppMenuEJ2
                    {
                        Id = appMenu.Id.ToString(),
                        Text = appMenu.Text,
                        ParentId = appMenu.ParentId == null ? null : appMenu.ParentId.ToString(),
                        Url = appMenu.Url
                    };
                    menuEJ2.Add(appMenuEJ2);
                }
                controller.ViewBag.Menu = menuEJ2;
            }
        }
    }
}