using System;
using System.Collections;
using static System.Console;


/*
컬렉션(ArrayList, Stack, Queue)을 초기화하는 방법
(1) 배열을 이용한 컬렉션 초기화
(2) 컬렉션 초기화자{}를 이용한 컬렉션 초기화
 */


namespace InitializingCollections
{
    class MainApp
    {
        static void Main(string[] args)
        {
            // (1) 배열을 이용한 컬렉션 초기화
            int[] arr = { 123, 456, 789 }; // 3개의 정수 값을 가진 arr '배열을 선언'하고 초기화합니다.

           
            ArrayList list = new ArrayList(arr); // arr 배열을 사용하여 ArrayList를 초기화합니다. 
                                                 // 즉, arr 배열의 모든 요소가 list에 추가됩니다.

            foreach (object item in list) // foreach 문을 사용하여 list의 모든 요소를 출력합니다.
                WriteLine($"ArrayList : {item}");
            WriteLine();


            Stack stack = new Stack(arr); // arr 배열을 사용하여 Stack을 초기화합니다. 
                                          // Stack은 LIFO (Last-In, First-Out) 방식으로 동작하므로, 
                                          // 배열의 마지막 요소가 스택의 맨 위에 추가됩니다.

            foreach (object item in stack) // foreach 문을 사용하여 stack의 모든 요소를 출력합니다.
                WriteLine($"Stack : {item}");
            WriteLine();


            Queue queue = new Queue(arr); // arr 배열을 사용하여 Queue를 초기화합니다.
                                          // Queue는 FIFO (First-In, First-Out) 방식으로 동작하므로,
                                          //  배열의 첫 번째 요소가 큐의 맨 앞에 추가됩니다.

            foreach (object item in queue) // foreach 문을 사용하여 queue의 모든 요소를 출력합니다.
                WriteLine($"Queue : {item}");
            WriteLine();


            // (2) 컬렉션 초기화자를 이용한 컬렉션 초기화
            ArrayList list2 = new ArrayList() { 11, 22, 33 }; // 컬렉션 초기화자{}를 사용하여 ArrayList를 초기화합니다.
                                                              // 중괄호 안에 초기값을 쉼표로 구분하여 나열합니다.
            
            foreach (object item in list2) // foreach 문을 사용하여 list2의 모든 요소를 출력합니다.
                WriteLine($"ArrayList2 : {item}");
            WriteLine();
        }
    }
}


/*
출력 결과

ArrayList : 123
ArrayList : 456
ArrayList : 789Stack : 789
Stack : 456
Stack : 123

Queue : 123
Queue : 456
Queue : 789

ArrayList2 : 11
ArrayList2 : 22
ArrayList2 : 33
*/