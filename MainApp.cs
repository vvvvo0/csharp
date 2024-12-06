using System; //네임스페이스 전체를 사용한다. System.Console.WriteLine() -> Console.WriteLine()
using static System.Console;

namespace Hello //비슷한 것들끼리 하나의 이름 아래 묶음.
{
    class MainApp /* MainApp이라는 클래스(c#프로그램을 구성하는 기본단위)를 만듦.
                     클래스: 데이터와 데이터를 처리하는 기능(메소드)으로 구성됨.*/
    {
        static void Main(string[] args) //Main() 메소드. c의 Main함수랑 비슷.
         //static은 한정자. 메소드나 변수 등을 수식.
         // static 키워드로 수식되는 코드는 프로그램이 처음 구동될 때부터 메모리에 할당된다. 
        {
            string name = "김튼튼";
            int age = 23;
            WriteLine($"{name,-10},{age:D3}"); // 김튼튼       ,023
            // |김|튼|튼| | | | |,|0|2|3|
            // {name,-10} 에서 -10은 name 문자열 ("김튼튼")을 포함하여 총 10칸을 할당하고,
            // - 부호는 좌측 정렬을 의미
            // 즉, "김튼튼"을 왼쪽부터 채우고 나머지 7칸은 공백으로 채워짐
            //,는 쉼표 문자 자체를 출력하는 것이므로, 10칸의 공간 계산에는 포함하지 않음


            name = "박날씬"; 
            age = 30; 
            WriteLine($"{name}, {age,-10:D3}"); // 박날씬, 030
            // |박|날|씬|,| |0|3|0| | | | | | | |
            // name ("박날씬")은 3글자이며, 그대로 출력
            // ,와 뒤의 공백은 문자 그대로 출력
            // age (30)은 D3 형식으로 3자리 정수(030)로 출력되고,
            // -10 이므로 10칸을 왼쪽부터 030을 채우고 7칸의 공백이 뒤에 추가됨
            // 총 14칸

            name = "이비실";
            age = 17;
            WriteLine($"{name}, {(age > 20 ? "성인" : "미성년자")}"); // 이비실, 미성년자


        }
    }
}
