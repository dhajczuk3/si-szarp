using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace ArrayDataStruct
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Test();
            Console.ReadKey();
        }

        public static void Test()
        {
            LinearArrayList test = new LinearArrayList(10);


            //test values
            test.add(16);
            test.add(12);
            test.add(4);
            test.add(6);
            test.add(5);
            test.add(7);
            test.add(7);
            test.add(8123);
            test.add(39);
            test.add(1044);






            /////displayUI() test
            test.displayUI();
            //PASS

            /////destroy() test
            //test.destroy();
            //PASS

            /////isEmpty() test
            //test.isEmpty();
            //PASS

            /////isFull() test
            //test.isFull();
            //PASS

            /////addFirst(int value) test
            //test.addFirst(100);
            //PASS

            /////addLast(int value) test
            //test.addLast(103);
            //PASS

            /////removeFirst() test
            //test.removeFirst();
            //PASS

            /////removeLast() test
            //test.removeLast();
            //PASS


            //search test
            //test.search(3);

            //sort test
            test.sort();

            /////display an array for test
            Console.WriteLine("Array after implementing a test method:");

            Console.WriteLine("Array count: " + test.count);

            test.displayUI();
        }
    }
}
