using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SimpleBot.Config
{
    public class ConfigLoader
    {
        //Приватность токена или что-то подобное, хуй знает
        public string Token { get; private set; }
        public string Prefix { get; private set; }

        public async Task LoadConfig()
        {
            using (StreamReader reader = new StreamReader("config.json"))
            {
                string config = await reader.ReadToEndAsync();
                ConfigStructure data = JsonConvert.DeserializeObject<ConfigStructure>(config);
                
                this.Token = data.Token;
                this.Prefix = data.Prefix;
            }
        }
    }
    
    internal sealed class ConfigStructure
    {
        public ConfigStructure(string token, string prefix)
        {
            Token = token;
            Prefix = prefix;
        }

        public string Token { get; }
        public string Prefix { get; }
    }
}