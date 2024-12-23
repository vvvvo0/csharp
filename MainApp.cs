using System;
using System.Collections.Generic;


/*
List<T>:
비일반화 클래스인 ArrayList와 같은 기능을 하지만, 특정 자료형만 저장할 수 있도록 제네릭을 사용한다.
형식 매개변수에 입력한 형식 외에는 입력을 허용하지 않는다.
*/


namespace UsingGenericList
{
    class MainApp
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>(); // 정수형(int) 자료형을 저장하는 List 컬렉션 list를 생성합니다. 
            for (int i = 0; i < 5; i++) //  0부터 4까지의 정수를,
                list.Add(i); // list에 추가합니다.

            foreach (int element in list) // list의 모든 요소를 순회하며 각 요소를 element 변수에 할당하고,
                Console.Write($"{element} "); // 값을 출력
            Console.WriteLine();

            list.RemoveAt(2); // list에서 인덱스 2의 요소(값: 2)를 삭제합니다.

            foreach (int element in list)
                Console.Write($"{element} ");
            Console.WriteLine();

            list.Insert(2, 2); // list의 인덱스 2에 정수 2를 삽입합니다.

            foreach (int element in list)
                Console.Write($"{element} ");
            Console.WriteLine();
        }
    }
}


/*
출력 결과

0 1 2 3 4 
0 1 3 4 
0 1 2 3 4 
*/
