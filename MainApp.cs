using System; //네임스페이스 전체를 사용한다. System.Console.WriteLine() -> Console.WriteLine()
using static System.Console;

namespace Hello //비슷한 것들끼리 하나의 이름 아래 묶음.
{
    class MainApp /* MainApp이라는 클래스(c#프로그램을 구성하는 기본단위)를 만듦.
                     클래스: 데이터와 데이터를 처리하는 기능(메소드)으로 구성됨.*/
    {
        //프로그램 실행이 시작되는 곳
        static void Main(string[] args) //Main() 메소드. c의 Main함수랑 비슷.
         //static은 한정자. 메소드나 변수 등을 수식.
         // static 키워드로 수식되는 코드는 프로그램이 처음 구동될 때부터 메모리에 할당된다. 
        {
            Console.WriteLine("Hello World!"); // 프롬프트에 출력


            //Object 형식
            int a = 123; // 숫자
            string b = a.ToString(); // 숫자를 문자열로 변환
            Console.WriteLine(b);

            float c = 3.14f;
            string d = c.ToString();
            Console.WriteLine(d);

            int e = int.Parse("12345"); // 문자를 숫자열로 변환
            float f = float.Parse("123.45"); 
            Console.WriteLine(e);
            Console.WriteLine(f);

            //문자열 보간
            string name = "김튼튼";
            int age = 23;
            WriteLine($"{name,-10},{age:D3}"); //{name,-10} : name 문자열을 왼쪽 정렬하고, 10칸을 확보.
                                               //즉, "김튼튼" 뒤에 3칸의 공백이 추가함.
                                               //,{age:D3} : ,는 단순히 쉼표를 출력하고,
                                               //{age:D3}는 age를 3자리 정수 형태로 출력합니다. (23 -> 023)

            //$"텍스트{보간식[,길이] [:서식]}텍스트{...}..."
            //name 왼쪽부터 채워,age
            //Console.WriteLine("{0, -10: D}", 123);
            //{서식 항목의 첨자, 왼쪽/오른쪽 맞춤, 변환 서식 지정 문자열}

            name = "박날씬"; //{name} : name 문자열을 그대로 출력함. ("박날씬")
            age = 30; //, {age,-10:D3} : ,는 쉼표와 공백을 출력함.
                      //{age,-10:D3}는 age를 3자리 정수 형태로 출력하고, 왼쪽 정렬하여 10칸을 확보합니다.
                      //즉, "030" 앞에 7칸의 공백이 추가됩니다.
                      
            WriteLine($"{name}, {age, -10:D3}");

            name = "이비실";
            age = 17;
            WriteLine($"{name}, {(age > 20 ? "성인" : "미성년자")}");
           
        }
    }
}
