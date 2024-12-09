using System; 

namespace Hello 
{
    class MainApp 
    {
        static void Main(string[] args)  
        {
            int[] numbers = { 0, 1, 2, 3, 4 }; // 0부터 4까지의 값을 가진 배열 선언


            foreach (int a in numbers) // numbers 배열의 각 요소를 a에 할당하며 반복
            {
                Console.WriteLine(a); // a 값 출력
            }
        }
    }
}
