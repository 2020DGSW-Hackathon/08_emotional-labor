using MySql.Data.MySqlClient;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TipSoGo.ViewModel;

namespace TipSoGo
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        public static MySqlConnection conn { get; set; }
        public static BulletinBoardViewModel bulletinBoardViewModel;
        public static AuthViewModel authViewModel;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            conn = new MySqlConnection("Server = localhost; Database = tipsogo; Uid = root; Pwd = y28645506;");
            bulletinBoardViewModel = new BulletinBoardViewModel();
            authViewModel = new AuthViewModel();
        }
    }
}
