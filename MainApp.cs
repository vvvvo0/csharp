using System;
using MyExtension; // 확장 메소드를 담는 클래스의 네임스페이스를 사용함.


/*
 확장 메소드: '기존 클래스'의 기능을 확장 != 상속
 상속(기반 클래스를 물려 받아 파생 클래스를 만든 뒤 파생 클래스에 필드나 메소드 추가)과 다름
 */


namespace MyExtension // using에 사용함.
{
    public static class IntegerExtension // 기존 클래스를 static 한정자로 수식
    {
        public static int Square(this int myInt) // 확장 메소드
                                                 // 메소드를 static 한정자로 수식
                                                 // 첫 번째 매개변수는 반드시 this 키워드와 함께 확장하려는 클래스(or 형식)의 인스턴스여야 함.

        {
            return myInt * myInt;
        }

        public static int Power(this int myInt, int exponent) // 확장 메소드 Power()
                                                              // 첫 번째 매개변수에 this 키워드를 사용하여 int 형식에 대한 확장 메서드임을 나타냅니다.
                                                              // 메소드를 static 한정자로 수식
                                                              // 첫 번째 매개변수는 반드시 this 키워드와 함께 확장하려는 클래스(or 형식)의 인스턴스여야 함.
                                                              // , 뒤에가 확장 메소드를 호출할 때 입력되는 매개변수임.(여기서는 exponent)

        {
            int result = myInt;
            for (int i = 1; i < exponent; i++)
                result = result * myInt;

            return result;
        }
    }
}

namespace ExtensionMethod
{
    class MainApp
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"{3}^2 : {3.Square()}"); // 9
            Console.WriteLine($"{3}^{4} : {3.Power(4)}"); // 3.Power(4) >> Power()가 원래부터 int 형식의 메소드였던 것처럼 사용함.
                                                          // int 형식의 값 3에서 Power() 메서드를 호출하기 위해 사용.
                                                          // Power() 메서드는 IntegerExtension 클래스에 정의된 확장 메서드이므로,
                                                          // int 형식의 값에서 마치 int 클래스의 메서드처럼 호출할 수 있습니다.

            // Power(4)에서 괄호 안에 4를 넣은 것은 int 형식의 값을 인자로 전달한 것입니다.
            // Power() 메서드는 IntegerExtension 클래스에서 int 형식의 확장 메서드로 정의되어 있고,
            // 두 번째 매개변수로 int exponent를 받습니다.따라서 Power(4)와 같이 호출하면
            // 4라는 int 값이 exponent 매개변수에 전달됩니다.

            Console.WriteLine($"{2}^{10} : {2.Power(10)}"); // 1024
        }
    }
}


// Power() 메서드는 원래 int 형식의 메서드가 아니었지만, 확장 메서드를 통해 int 형식에서 사용할 수 있게 된 것.
// 확장 메서드는 기존 클래스에 새로운 메서드를 추가하는 것처럼 보이게 하는 기능입니다.
// 실제로는 별도의 static 클래스에 정의된 static 메서드이지만, 마치 원래 클래스의 메서드처럼 사용할 수 있습니다.
