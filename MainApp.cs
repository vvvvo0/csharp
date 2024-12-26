using System;
using System.Linq.Expressions; // 식 트리를 사용하기 위해 필요.
                               // System.Linq.Expressions 네임스페이스는
                               // 식 트리를 다루는 데 필요한 클래스와 메서드를 제공합니다.
                               // (Expression 클래스와 파생 클래스들)


/*
식 트리(Expression Tree):
식을 트리로 표현한 자료구조.
한 부모 노드가 단 두개만의 자식 노드를 가질 수 있는 이진 트리(Binary Tree).
코드를 '데이터'로 보관할 수 있음.

Expression 클래스: 
식 트리의 노드를 표현하는 기본 클래스입니다.
따라서 Expression 클래스를 상속받는 클래스들이 식 트리의 각 노트를 표현할 수 있음.
Expression 클래스의 파생 클래스들의 인스턴스를 생성하는 역할도 함.
Expression 클래스 자신은 abstract로 선언되어 자신의 인스턴스는 만들 수 없지만,
파생 클래스의 인스턴스를 생성하는 기능을 가진 정적 '팩토리 메서드'를 제공함.

Expression.Constant(), Expression.Parameter(), Expression.Add(), Expression.Subtract() 등의 메서드:
 다양한 종류의 식 트리 노드를 생성하는 데 사용됩니다.

팩토리 메서드(Factory Method):
클래스의 인스턴스를 생성하는 일을 담당하는 메서드.
C#에는 객체를 생성하는 생성자 메서드가 있긴 하지만, 객체의 생성에 복잡한 논리가 필요한 경우,
객체 생성 과정을 별도의 메서드에 구현해 놓으면 코드가 덜 복잡해짐.

팩토리 메서드 장점?
프로그래머가 각 노드가 어떤 타입인지 신경 쓰지 않고 Expression 타입의 참조를 선언해서 사용할 수 있음.
예를 들어,
Expression cons1 = Expression.Constant(1);
// Expression.Constant() 팩토리 메서드로, ConstantExpression 타입의 const1 객체를 선언함.
// Expression 타입인 cont1을 으로 선언한게 아님.
 */


// 식 트리를 사용하여 식( 1 * 2 + (x - y) )을 표현하고 컴파일하여 실행하는 방법을 보여줌 
namespace UsingExpressionTree
{
    class MainApp
    {
        static void Main(string[] args)
        {
            // 1*2+(x-y)
            // (1) 식 트리 생성
            Expression const1 = Expression.Constant(1); // 상수 1을 나타내는 Expression 타입의 객체를 생성(x)
                                                        // 상수 1을 나타내는 ConstantExpression 타입의 객체를 생성(o)
                                                        // const1 변수는 Expression 타입이지만,
                                                        // 실제로는 ConstantExpression 객체를 참조합니다.
                                                        // 왜냐하면 Expression 클래스는 식 트리의 기본 클래스이고, 
                                                        // ConstantExpression은 상수를 나타내는 Expression의 파생 클래스이기 때문입니다.

            Expression const2 = Expression.Constant(2); // 상수 2를 나타내는 ConstantExpression 객체 생성

            Expression leftExp = Expression.Multiply(const1, const2); // const1과 const2를 곱하는 연산을 나타내는
                                                                      // BinaryExpression 객체 생성

            Expression param1 =
                Expression.Parameter(typeof(int)); // x을 위한 변수
                                                   // int 타입의 매개변수를 나타내는 ParameterExpression 객체를 생성

            Expression param2 =
                Expression.Parameter(typeof(int)); // y을 위한 변수
                                                   // int 타입의 매개변수를 나타내는 ParameterExpression 객체를 생성

            Expression rightExp = Expression.Subtract(param1, param2); // x - y
                                                                       // param1에서 param2를 빼는 연산을 나타내는
                                                                       // BinaryExpression 객체를 생성

            Expression exp = Expression.Add(leftExp, rightExp); // leftExp와 rightExp를 더하는 연산을 나타내는
                                                                // BinaryExpression 객체를 생성


            // (2) 람다식 생성:
            // 식 트리는 '식'을 트리로 표현한 것에 불과함.
            // 즉, exp 식 트리는 실행가능한 상태가 아니라 '데이터'상태에 머물러 있음.
            // 따라서 실행하려면 람다식으로 컴파일 되어야 함.
            Expression<Func<int, int, int>> expression = // Expression<TDelegate>: 델리게이트를 '식 트리'로 표현하는 형식입니다.
                                                         // 여기서는 Func<int, int, int> 델리게이트를 식 트리로 표현하기 위해,
                                                         // Expression<Func<int, int, int>>를 사용합니다.
                                                         // 델리게이트를 식 트리로 표현하는 이유?
                                                         // 델리게이트가 컴파일 시점에 알 수 없는 메서드를 참조할 수 있기 때문입니다.
                Expression<Func<int, int, int>>.Lambda<Func<int, int, int>>(
                    exp, new ParameterExpression[]{
                        (ParameterExpression)param1,
                        (ParameterExpression)param2});
            // Expression.Lambda<TDelegate>(Expression body, IEnumerable<ParameterExpression> parameters) 메서드:
            // 식 트리를 '람다 식'으로 변환합니다.
            // body: 람다 식의 본문이 되는 식 트리입니다. 여기서는 exp 식 트리가 해당됩니다.
            // parameters: 람다 식의 매개변수 목록입니다. 여기서는 param1과 param2가 매개변수로 사용됩니다.
            // 따라서 이 코드는 exp 식 트리를 본문으로 하고, param1과 param2를 매개변수로 하는 람다 식을 
            // expression 변수에 저장합니다.
            // 이렇게 생성된 람다 식은 Func<int, int, int> 델리게이트와 동일한 기능을 수행합니다. 
            // 즉, 두 개의 정수를 입력으로 받아 정수 값을 반환하는 함수를 나타냅니다.


            // (3) 델리게이트 컴파일
            // 실행 가능한 코드로 컴파일
            Func<int, int, int> func = expression.Compile(); // expression.Compile(): expression 식 트리를 컴파일하여
                                                             //  Func<int, int, int> 델리게이트를 생성합니다.

            // (4) 델리게이트 실행
            // x = 7, y = 8
            Console.WriteLine($"1*2+({7}-{8}) = {func(7, 8)}"); // func(7, 8): func 델리게이트를 호출하여
                                                                // x = 7, y = 8일 때의 결과를 계산합니다.
        }
    }
}


/*
출력 결과

1*2+(7-8) = 1
*/