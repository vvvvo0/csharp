using System;
using System.Collections;


/*
Queue:
선입선출(FIFO) 방식으로 데이터를 저장하는 자료 구조.
즉, 먼저 들어간 데이터가 먼저 나오는 구조.
프린터가 여러 문서를 출력할 때, 동영상 스트리밍 서비스에서 콘텐츠를 버퍼링할 때 등에 쓰임.


컬렉션 vs 클래스?
컬렉션:  여러 데이터를 모아서 저장하는 자료 구조. 배열, 리스트, 큐, 스택 등이 컬렉션에 속합니다.
클래스: 객체 지향 프로그래밍에서 객체를 만들기 위한 틀. 객체의 속성과 메서드를 정의합니다.

C#에서는 컬렉션을 구현하기 위해 클래스를 사용합니다.
즉, 컬렉션은 클래스의 일종이지만, 모든 클래스가 컬렉션은 아닙니다.
Queue는 컬렉션의 한 종류입니다.
Queue 클래스는 선입선출(FIFO) 방식으로 데이터를 저장하는 컬렉션을 구현합니다.
Queue는 큐 자료 구조(큐 컬렉션)를 구현한 클래스입니다.
 */


// Queue 컬렉션을 사용하는 방법
namespace UsingQueue
{
    class MainApp
    {
        static void Main(string[] args)
        {
            Queue que = new Queue(); // Queue 클래스의 인스턴스를 생성
                                     // 'Queue는 클래스'이기 때문에, Queue 클래스의 기능을 사용하려면
                                     // 먼저 Queue 클래스의 인스턴스를 생성해야 합니다.
                                     // Queue 클래스의 인스턴스는 new Queue()와 같이 new 키워드를 사용하여 생성할 수 있습니다.
                                     // Queue 클래스의 인스턴스를 생성하면, Enqueue(), Dequeue(), Peek(), Count 등
                                     // Queue 클래스에서 제공하는 메서드와 프로퍼티를 사용하여 큐를 조작할 수 있습니다.


            
            que.Enqueue(1); // que에 정수 1을 추가합니다. 
                            // Enqueue() 메서드: 큐의 맨 뒤에 요소를 추가합니다.
            que.Enqueue(2);
            que.Enqueue(3);
            que.Enqueue(4);
            que.Enqueue(5);


            while (que.Count > 0) // que에 요소가 남아있는 동안 반복합니다.
                                  // que.Count: que에 저장된 요소의 개수를 반환합니다.

                Console.WriteLine(que.Dequeue()); // que에서 맨 앞 요소를 제거하고 반환합니다.
                                                  // Dequeue() 메서드: 큐의 맨 앞에서 요소를 제거하고 반환합니다.
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