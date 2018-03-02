using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilRouge.Library;

namespace FilRouge.Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            Contact Admin = new Contact("EXAMPLE", "Admin", "0233353637", "example.admin@example.com", "Admin");

            Console.WriteLine(Admin.ToString());
            Console.ReadLine();

            Technologies cSharp = new Technologies("C#", "oui");
            Console.WriteLine(cSharp.ToString());
            Console.ReadLine();

            Quizz pQuizz = new Quizz("Extreme", 1, 1, "crapaud", "jean-michel", false, 50);
            Console.WriteLine(pQuizz.ToString());
            Console.ReadLine();

        }
    }
}
