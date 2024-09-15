using Newtonsoft.Json;

namespace LoanApp.Application.Helpers
{
    public class JsonConexion
    {
        public Appsettings GetConStr()
        {
            var path = @"" + Directory.GetCurrentDirectory() + "\\appsettings.json";

            using (StreamReader jsonStream = File.OpenText(path))
            {
                var json = jsonStream.ReadToEnd();
                Appsettings appsetting = JsonConvert.DeserializeObject<Appsettings>(json);

                return appsetting;
            }
        }
    }

    public class Appsettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
    }
    public class ConnectionStrings
    {
        public string LoanDB { get; set; }
    }
}
