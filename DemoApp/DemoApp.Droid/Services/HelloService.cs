using DemoApp.Services.Hello;

namespace DemoApp.Droid.Services
{
    public class HelloService : IHelloService
    {
        public HelloService()
        {
            //require
        }
        
        public string GetHelloString()
        {
            return "Bienvenue sur l'app Android";
        }
    }
}