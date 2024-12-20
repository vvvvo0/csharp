using System;


/*
슬라이스(Slice): 배열의 일부분을 추출하여 새로운 배열을 만드는 기능
Array.Copy() 메서드보다 편함.

Range 타입(System.Range 형식)과 인덱스 from end 연산자(^)를 사용하여 배열의 슬라이스를 생성할 수 있습니다.
System.Range 타입: 
이름에서 처럼 시작 인덱스와 마지막 인덱스를 이용해서 범위를 나타냄.

.. 연산자:
두 번째 피연산자, 즉 마지막 인덱스는 배열 분할 결과에서 제외되므로 주의.
예를 들어, int[] slied3 = scores[..3]; // 첫 번째(0) 요소부터 세 번째(2) 요소까지임
 */


// 배열의 슬라이스(Slice) 기능을 사용하는 방법을 보여준다.
namespace Slice
{
    class MainApp
    {
        static void PrintArray(System.Array array) // 배열을 입력으로 받아 배열의 모든 요소를 출력합니다.
                                                   // foreach 문의 괄호 안에 System.Array를 붙이는 이유는
                                                   // PrintArray() 메서드가 모든 종류의 배열을 입력으로 받을 수 있도록 하기 위해서입니다.
                                                   // 즉, int[], char[], string[] 등 모든 배열은 System.Array 타입으로 취급될 수 있습니다.
                                                   // PrintArray() 메서드의 매개변수를 System.Array 타입으로 선언하면,
                                                   // 어떤 종류의 배열이든 PrintArray() 메서드에 전달할 수 있습니다.
        {
            foreach (var e in array) // array 배열의 각 요소를 순회하며, 각 요소를 e 변수에 할당함.
                                     // var 키워드는 컴파일러가 변수의 타입을 자동으로 유추하도록 하는 키워드.
                                     // 여기서 array가 char[] 타입이므로, e 변수는 char 타입으로 선언됨.
                Console.Write(e); // Console.Write: 값을 출력만 하고 줄 바꿈을 하지 않습니다.
            Console.WriteLine();
        }


        static void Main(string[] args)
        {
            char[] array = new char['Z' - 'A' + 1]; //  'A'부터 'Z'까지의 문자를 저장할 수 있는, array 배열을 선언합니다.
            for (int i = 0; i < array.Length; i++) // array 배열에 'A'부터 'Z'까지의 문자를 저장합니다.
                                                   // i 변수를 0부터 array.Length - 1까지 반복합니다.
                                                   // array.Length는 배열의 크기, 즉 배열에 저장할 수 있는 요소의 개수를 나타냅니다.
                                                   // 이 경우 array 배열은 'Z' - 'A' + 1, 즉 26개의 요소를 가집니다.
                array[i] = (char)('A' + i); // 각 반복에서 array[i] = (char)('A' + i); 코드가 실행됩니다.
                                            // (1) 'A' + i: 문자 'A'의 ASCII 값에 i 값을 더합니다,
                                            // i는 0부터 25까지 반복되므로, 'A'부터 'Z'까지의 ASCII 값을 순서대로 생성합니다.
                                            // 참고로 'A'는  ASCII 값으로 65입니다. 'Z'는 90.
                                            // (2) (char)(...): 'A' + i 연산의 결과를 char 타입으로 형변환합니다,
                                            //  ASCII 값을 문자로 변환하여, 배열에 저장하기 위해 형변환을 사용합니다.
                                            // (3) array[i] = ...: 형변환된 문자를 array 배열의 i번째 요소에 저장합니다.
                                            // 예를 들어, 두 번째 반복(i = 1)에서는 'A' + 1 = 'B'가 되어, array[1]에 'B'가 저장됨.


            PrintArray(array[..]);    // array 배열의 모든 요소를 출력합니다.
                                      // array[..]: array 배열의 모든 요소를 포함하는 슬라이스를 생성합니다, 
                                      // ..는 범위 연산자로, 시작 인덱스와 끝 인덱스를 생략하면 배열의 처음부터 끝까지를 의미합니다.
                                      // 0번째부터 마지막까지

            PrintArray(array[5..]);   // array 배열의 5번째 요소부터 마지막 요소까지 출력합니다.
                                      // array[5..]: array 배열의 5번째 요소부터 마지막 요소까지를 포함하는 슬라이스를 생성합니다.
                                      // 5번째부터 끝까지


            Range range_5_10 = 5..10; // 5부터 10까지의 범위를 나타내는 range_5_10 변수를 선언합니다.

            PrintArray(array[range_5_10]); // array 배열의 5번째 요소부터 9(10-1)번째 요소까지 출력합니다.
                                           // array[range_5_10]: array 배열의 5번째 요소부터 9번째 요소까지를 포함하는 슬라이스를 생성합니다, 
                                           // Range 타입을 사용하면 슬라이스의 범위를 명확하게 지정할 수 있습니다.
                                           // 5번째부터 9(10-1)번째까지      

            Index last = ^0; // 배열의 마지막 요소를 나타내는 last 변수를 선언합니다.
                             // ^0: 인덱스 from end 연산자로, 배열의 마지막 요소를 나타냅니다.

            Range range_5_last = 5..last; // 5부터 마지막 요소까지의 범위를 나타내는 range_5_last 변수를 선언합니다.
           
            
            PrintArray(array[range_5_last]); // array 배열의 5번째 요소부터 마지막 요소(^)까지 출력합니다.
                                             // array[range_5_last]: array 배열의 5번째 요소부터 마지막 요소까지를 포함하는 슬라이스를 생성합니다.
                                             // 5번째부터 끝(^)까지      


            PrintArray(array[^4..^1]);  // array 배열의 끝에서 4번째 요소부터 끝에서 2번째 요소(^1)까지 출력합니다.
                                        // array[^4..^1]: array 배열의 끝에서 4번째 요소부터 끝에서 2번째 요소까지를 포함하는 슬라이스를 생성합니다.
                                        // 끝에서 4번째부터 끝(^)에서 2번째까지      
        }
    }
}

/*
출력 결과

ABCDEFGHIJKLMNOPQRSTUVWXYZ
FGHIJKLMNOPQRSTUVWXYZ
FGHIJ
FGHIJKLMNOPQRSTUVWXYZ
WXY
 */