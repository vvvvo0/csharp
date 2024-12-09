using System; 

namespace Hello 
{
    class MainApp 
    {
        static void Main(string[] args)  
        {

            int[] numbers = new int[] { 0, 1, 2, 3, 4 }; //new int[]를 사용하여 0부터 4까지의 정수 값을 가진 numbers 배열을 선언

            //int[] numbers = { 0, 1, 2, 3, 4 }; // 0부터 4까지의 정수 값을 가진 numbers 배열을 선언.
            //두 가지 방식 모두 배열을 선언하고 초기화하는 데 사용할 수 있는 유효한 방법
            //new int[]를 사용하는 방식은 배열의 크기를 명시적으로 지정하지 않아도 되는 장점.


            foreach (int a in numbers) // numbers 배열의 각 요소를 순회하며, 각 요소를 a 변수에 할당
            {
                Console.WriteLine(a); // a 변수에 저장된 값을 콘솔에 출력
            }
        }
    }
}
