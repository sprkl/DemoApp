using DemoApp.Services.Hello;

namespace DemoApp.iOS.Services
{
    public class HelloService : IHelloService
    {
        public HelloService()
        {
            //required
        }
        
        public string GetHelloString()
        {
            return "Bienvenue sur l'app iOS";
        }
    }
}