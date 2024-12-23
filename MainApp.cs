using System;
using System.Collections.Generic;


/*
Stack<T>:
후입선출(LIFO) 방식으로 데이터를 저장하는 자료 구조.
즉, 나중에 들어간 데이터가 먼저 나오는 구조입니다.
<T>는 스택에 저장될 데이터의 형식을 나타내는 제네릭 타입 매개변수입니다.
 */


// Stack<T> 제네릭 컬렉션을 사용하는 방법을 보여줌.
namespace UsingGenericStack
{
    class MainApp
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>(); // int형 데이터를 저장하는
                                                 // Stack<int> 컬렉션 stack을 생성합니다.

            stack.Push(1); // stack에 정수 1을 추가합니다. 
                           // Push() 메서드: 스택의 맨 위에 요소를 추가합니다.
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);

            while (stack.Count > 0) // stack에 요소가 남아있는 동안 반복합니다. 
                                    // stack.Count: stack에 저장된 요소의 개수를 반환합니다.
                Console.WriteLine(stack.Pop()); // stack에서 맨 위 요소를 제거하고 반환합니다. 
                                                // Pop() 메서드: 스택의 맨 위에서 요소를 제거하고 반환합니다. 
                                                // Console.WriteLine() 메서드: 제거된 요소를 콘솔에 출력합니다.
        }
    }
}


/*
출력 결과

5
4
3
2
1
 */