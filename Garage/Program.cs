using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.CompilerServices;


namespace GarageMaker
{
    class Program
    {
        static void Main(string[] args)
        {
            IManager manager = new Manager();
           
            manager.Run();
             

        }
    }
}