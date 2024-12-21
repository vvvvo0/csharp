using System;
using System.Collections;



/*
Stack:
후입선출(LIFO) 방식으로 데이터를 저장하는 자료 구조.
즉, 먼저 들어온 데이터가 나중에 나가고,
나중에 들어온 데이터가 먼저 나가는 구조의 컬렉션입니다.
마치 접시를 쌓아 올렸을 때, 가장 위에 있는 접시를 먼저 가져가는 것과 같은 순서입니다.

 */


// Stack 컬렉션을 사용하는 방법
namespace UsingStack
{
    class MainApp
    {
        static void Main(string[] args)
        {
            Stack stack = new Stack(); // Stack 클래스의 인스턴스를 생성합니다.

            stack.Push(1); // stack에 정수 1을 추가합니다. 
                           // Push() 메서드: 스택의 맨 위에 요소를 추가합니다.
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);


            while (stack.Count > 0) // stack에 요소가 남아있는 동안 반복합니다.
                                    // stack.Count: stack에 저장된 요소의 개수를 반환합니다.
                Console.WriteLine(stack.Pop()); // stack에서 맨 위 요소를 제거하고 반환합니다.
                                                // Pop() 메서드: 스택의 맨 위에 있는 요소를 제거하고 반환합니다.
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