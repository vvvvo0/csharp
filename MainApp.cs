using System;
using System.Collections.Generic; // Queue<T>를 사용하기 위해 필요한 네임스페이스



/*
Queue<T> 제네릭 컬렉션을 사용하는 방법:
Queue<T>는 선입선출(FIFO) 방식으로 데이터를 저장하는 자료 구조.
즉, 먼저 들어간 데이터가 먼저 나오는 구조입니다.
<T>는 큐에 저장될 데이터의 형식을 나타내는 제네릭 타입 매개변수입니다.
 */


// Queue<T> 제네릭 컬렉션을 사용하는 방법을 보여줌
namespace UsingGenericQueue
{
    class MainApp
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>(); // int형 데이터를 저장하는 Queue<int> 컬렉션 queue를 생성합니다.

            queue.Enqueue(1); // queue에 정수 1을 추가합니다. 
                              // Enqueue() 메서드: 큐의 맨 뒤에 요소를 추가합니다.
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);

            while (queue.Count > 0) // queue에 요소가 남아있는 동안 반복합니다. 
                                    // queue.Count: queue에 저장된 요소의 개수를 반환합니다.
                Console.WriteLine(queue.Dequeue()); // queue에서 맨 앞 요소를 제거하고 반환합니다. 
                                                    // Dequeue() 메서드: 큐의 맨 앞에서 요소를 제거하고 반환합니다. 
                                                    // Console.WriteLine() 메서드: 제거된 요소를 콘솔에 출력합니다.
        }
    }
}


/*
출력 결과

1
2
3
4
5
*/