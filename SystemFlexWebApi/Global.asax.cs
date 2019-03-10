using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Serialization;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebMatrix.WebData;
using SystemFlexWebApi.App_Start;

namespace SystemFlexWebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            HttpConfiguration config = GlobalConfiguration.Configuration;
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapper.Mapper.Initialize(c => {
                c.AddProfile(new AutoMapperWebConfig());
                c.AddProfile(new SystemFlexModel.Tools.AutoMapperConfig());
            });
            SqlServerTypes.Utilities.LoadNativeAssemblies(Server.MapPath("~/bin"));
            //WebSecurity.InitializeDatabaseConnection("IngemannModelContext", "Usuarios",
            //  "UsuarioId", "Usuario", autoCreateTables: true);
        }
    }
}
