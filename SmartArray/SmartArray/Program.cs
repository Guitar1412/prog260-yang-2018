using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartArray
{
    class Program
    {
        static void Main(string[] args)
        {
            SmartArrayClass mySmartArray = new SmartArrayClass(5);
            mySmartArray.SetAtIndex(2, 102);
            mySmartArray.SetAtIndex(4, 104);
            mySmartArray.PrintAllElements();
            Console.WriteLine();

            int x = mySmartArray.GetAtIndex(4);
            Console.WriteLine("x is {0}", x);
            Console.WriteLine();

            bool found = mySmartArray.Find(102);
            Console.WriteLine(found);

            Console.ReadLine();

        }
    }
}
