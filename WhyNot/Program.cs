using System.Net;
using System.Text;
using System.Text.Encodings.Web;


namespace WhyNot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Proccess proccess = new();

            while(true)
            {
                proccess.Speak();

                Console.ReadLine();
            }
            
        }
    }
}