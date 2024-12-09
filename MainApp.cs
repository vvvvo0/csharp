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
            object obj = null; //어떤 타입의 값이든 저장할 수 있는 obj라는 변수를 선언하고 초기화
            string s = Console.ReadLine(); //Console.ReadLine()은 콘솔에서 사용자의 입력을 한 줄 읽어오는 메서드
                                           //사용자가 Enter 키를 누를 때까지 입력한 모든 문자를 문자열로 반환문자열 입력 받음
                                           //Console.ReadLine() 메서드가 반환한 문자열을 s 변수에 저장


            if (s != null) //Console.ReadLine()의 결과값 s가 null인지 확인
                           //s가 null이 아닌 경우에만 int.TryParse()와 float.TryParse() 메서드를 호출
            {


                if (int.TryParse(s, out int out_i)) //Tryparse()는 Parse()와 같은 기능(문자열을 숫자로 변환).
                                                    //out 키워드는 출력 전용 매개변수임을 나타내는 용도로 쓰임
                                                    //int.TryParse() 메서드 내부에서 out_i 변수에 변환된 값을 저장하여
                                                    //메서드 외부에서도 사용할 수 있도록 하는 것
                                                    //out 키워드는 함수의 매개변수에 사용되는 키워드이긴 하지만, 일반적인 매개변수와는 조금 다른 역할을 합니다.
                                                    //일반적인 매개변수는 함수에 값을 전달하기 위한 용도로 사용됨. 즉, 함수를 호출할 때 매개변수에 값을 넣어서 함수 내부에서 사용하도록 하는 것.
                                                    //반면 out 키워드는 함수에서 값을 반환하기 위한 용도로 사용됨.즉, 함수 내부에서 out 키워드로 지정된 매개변수에 값을 저장하면,
                                                    //함수 호출 후에 그 값을 외부에서 사용할 수 있게 됨.
                    obj = out_i;


                else if (float.TryParse(s, out float out_f)) //int로 Tryparse()를 지정하니까 실수를 넣어도 모르는 형식이라고
                                                             //출력됨. 따라서 float.Tryparse()로 수정했음.

                                                            
                    obj = out_f; //obj 변수에 3.14가 저장됨

                //float.TryParse()는 문자열을 float 타입으로 변환하는 메서드인데, 변환에 성공하면 true를 반환하고, 실패하면 false를 반환
                //out float out_f는 out 키워드를 사용하여 out_f 변수를 출력 전용 매개변수로 지정하는 것입니다.
                //즉, float.TryParse() 메서드 내부에서 out_f 변수에 변환된 값을 저장하여 메서드 외부에서도 사용할 수 있도록 하는 것
                //out float out_f 부분은 s 문자열이 실수로 변환될 경우, 그 변환된 값을 저장할 out_f라는 변수를 선언하는 것.
                //따라서 float.TryParse(s, out float out_f) 가 성공적으로 실행되었다면, out_f 변수에는 변환된 실수 값이 저장됨.

                //TryParse() 메서드는 변환 성공 여부( true 또는 false)를 반환하기 때문에, 변환된 값을 얻으려면 out 키워드를 사용하여 변수를 지정해야 함!!


                //s가 "3.14"와 같이 실수 형태라면 float.TryParse(s, out float out_f)는 true를 반환하고,
                //out_f에는 3.14라는 값이 저장됩니다.
                //그 후 obj = out_f;를 통해 obj 변수에 3.14가 저장됩니다.

                else
                    obj = s;
            }
            

            switch (obj) 
            {
                case int:
                    Console.WriteLine($"{(int)obj}는 int 형식입니다.");
                    break;

                case float f when f>=0: //obj가 float 형식이며 0보다 크거나 같은 경우
                    Console.WriteLine($"{(float)obj}는 양의 float 형식입니다.");
                    break;
                case float: 
                    Console.WriteLine($"{(float)obj}는 음의 float 형식입니다.");
                    break;
                default:
                    Console.WriteLine($"{(obj)}(은)는 모르는 형식입니다.");
                    break;

            }
        }
    }
}
