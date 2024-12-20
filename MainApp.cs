using System;


/*
C#에서는 모든 것이 객체임. 따라서 배열도 객체이므로, 기반이 되는 형식이 있음.
.NET의 Commin Type System(CTS)에서 배열은 System.Array 클래스에 대응됨.

즉, C#에서 모든 배열은 System.Array 클래스에서 파생됨.

따라서 모든 배열은 System.Array 클래스의 멤버를 상속받아 사용할 수 있습니다. 

System.Array 클래스는 배열을 위한 기본 클래스로, 배열의 크기, 차원, 정렬, 검색 등 다양한 작업을 수행하는 메서드와 프로퍼티를 제공합니다.

이 System.Array 클래스에 있는 메소드와 프로퍼티들을 사용해서, 
배열 내부의 데이터를 원하는 순서대로 정렬하거나,특정 데이터를 배열 속에서 찾아내는 작업을 쉽게 할 수 있음.
예를 들어, Length 프로퍼티를 사용하여 배열의 크기를 가져오거나, Sort() 메서드를 사용하여 배열을 정렬할 수 있음.
 */


// 배열의 타입과 기본 타입을 출력
// int 기반의 배열이 System.Array 형식에서 파생됐을을 보여줌
namespace DerivedFromArray
{
    class MainApp
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 10, 30, 20, 7, 1 }; //  5개의 정수 값을 가진 array 배열을 선언하고 초기화

            Console.WriteLine($"Type Of array : {array.GetType()}"); // array '배열의 타입'을 출력
                                                                     // array.GetType()은 array 객체의 타입을 나타내는 Type 객체를 반환합니다.
                                                                     // 1차원 정수형 배열이므로 System.Int32[]가 출력됨. 

            Console.WriteLine($"Base type Of array : {array.GetType().BaseType}");
            // array '배열의 기본 타입'을 출력
            // array.GetType().BaseType는 array 객체의 '기본 타입'을 나타내는 Type 객체를 반환합니다.
            // '모든 배열'은 System.Array 클래스를 상속받으므로 System.Array가 출력됩니다.


            // array.GetType()
            // GetType() 메서드: 모든 객체가 가지고 있는 메서드로, 해당 객체의 타입 정보를 나타내는, Type 객체를 반환합니다.
            // array는 배열 객체이므로, array.GetType()은 '배열의 타입 정보'를 담고 있는, Type 객체를 반환합니다.
            // 예를 들어, int[] array = new int[5]; 라면 array.GetType()은 System.Int32[] 타입을 나타내는 Type 객체를 반환합니다.

            // array.GetType().BaseType
            // BaseType 프로퍼티는 Type 객체의 프로퍼티(닷넷 문서에서 BaseType이 Type 클래스의 프로퍼티로 정의되어 있기 때문)로,
            // 해당 타입의 '기본 타입 정보'를 나타내는, Type 객체를 반환합니다.
            // C#에서 모든 배열은 System.Array 클래스를 상속받습니다.
            // 따라서 array.GetType().BaseType는 System.Array 타입을 나타내는 Type 객체를 반환합니다.
        }
    }
}


/*
출력 결과

Type Of array : System.Int32[]
Base type Of array : System.Array
 */


/*
(번외)
배열마다 타입이 다를 수 있습니다.
C#에서 배열은 int[], string[], double[] 과 같이 저장하는 데이터의 종류에 따라 다른 타입을 가집니다.
int[] 배열은 정수형 데이터만 저장할 수 있고, string[] 배열은 문자열 데이터만 저장할 수 있으며, 
double[] 배열은 실수형 데이터만 저장할 수 있습니다.

따라서 GetType() 메서드와 BaseType 프로퍼티를 사용하여 배열의 타입 정보를 확인하고, 
배열 타입에 따라 다른 작업을 수행하는 코드를 작성할 수 있습니다.


 */