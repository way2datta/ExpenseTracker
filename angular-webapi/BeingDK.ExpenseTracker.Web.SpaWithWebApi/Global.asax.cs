using System.Web.Http;
using Newtonsoft.Json.Serialization;

namespace BeingDK.ExpenseTracker.Web.SpaWithWebApi
{
  public class WebApiApplication : System.Web.HttpApplication
  {
    protected void Application_Start()
    {
      GlobalConfiguration.Configure(WebApiConfig.Register);
      var config = GlobalConfiguration.Configuration;

      var json = config.Formatters.JsonFormatter;
      //json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
      config.Formatters.Remove(config.Formatters.XmlFormatter);

      config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
      config.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;
    }
  }
}