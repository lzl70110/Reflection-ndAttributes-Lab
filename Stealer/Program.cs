using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace Stealer;

    public class Program
    {
        public static void Main(string[] args)
        {
            Spy spy = new Spy();
            var result = Spy.StealFieldInfo("Stealer.Hacker", "username", "password");
            Console.WriteLine(result);
        }

       
        
    }
