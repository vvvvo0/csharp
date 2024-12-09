using System; 

namespace Hello 
{
    class MainApp 
    {
        static void Main(string[] args)  
        {
            int i = 10;

            do
            {
                Console.WriteLine("i(1) : {0}", i--);
            }

            while (i > 0);
            do
            {
                Console.WriteLine("i(2) : {0}", i--);
            }
            while (i > 0);
        }
    }
}
