using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMAPP
{
    internal class Designs
    {
        public static void LogInAnime()
        {
            
            for (int i = 0; i < 58; i++)
            {
                Thread.Sleep(10);
                Console.Write("-");
               
            }
        }

        public  static void LongLine()
        {
            Console.WriteLine("----------------------------------------------------------");
        }

        public static void Options()
        {
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Balance");
            Console.WriteLine("4. Transfer");
            Console.WriteLine("0. Log Out");
        }

        public static void LanguageOptions()
        {
            Console.WriteLine("Please choose a language");
            Console.WriteLine("1. English");
            Console.WriteLine("2. Igbo");
            Console.WriteLine("3. Pidgin");
            Console.WriteLine("0. Exit");
        }

        internal static void IgboOptions()
        {
            Console.WriteLine("otu. Tinye ego");
            Console.WriteLine("abuo. Weta ego");
            Console.WriteLine("ato. Mara Ego one inwe");
            Console.WriteLine("ano. Tinyere mmadu ego");
            Console.WriteLine("0. Puo");
        }

        internal static void PidginOptions()
        {
            Console.WriteLine("1. Put money");
            Console.WriteLine("2. Comot money");
            Console.WriteLine("3. See your money");
            Console.WriteLine("4. Send money give person");
            Console.WriteLine("0. Begin dey go");
        }
    }
}
