using System; 

namespace Hello 
{
    class MainApp 
    {
        static void Main(string[] args)  
        {
            for (int i = 1; i <= 5; i++)  // i는 1부터 5까지 증가
            {
                for (int j = 1; j <= i; j++)  // j는 1부터 i까지 증가
                {
                    Console.Write("*");
                }
                Console.WriteLine();  // 줄 바꿈
            }
        }
    }
}
