using System;
using System.Collections;


/*
ArrayList:
다양한 타입의 객체를 저장할 수 있는 동적 배열.
배열과 달리, 컬렉션을 생성할 때 용량을 미리 지정할 필요 없이 자동으로 용량이 늘어나거나 줄어드는 게 장점.
컬렉션 클래스 중 하나.

컬렉션: 같은 성격을 띤 데이터의 모음을 담는 자료구조.
 */

namespace UsingList
{
    class MainApp
    {
        static void Main(string[] args)
        {
            ArrayList list = new ArrayList(); //  ArrayList 클래스의 인스턴스를 생성

            // 요소 추가. Add() 메서드
            for (int i = 0; i < 5; i++) // for 문을 사용하여 0부터 4까지의 정수를 list에 추가합니다.
                list.Add(i); // list에 정수 i를 추가합니다.


            foreach (object obj in list) // foreach 문을 사용하여 list의 모든 요소를 순회합니다.
                Console.Write($"{obj} "); // 현재 요소를 출력합니다.
            Console.WriteLine();


            // 요소 삭제. RemoveAt() 메서드
            list.RemoveAt(2); // list에서 인덱스 2의 요소를 삭제합니다.

            foreach (object obj in list)
                Console.Write($"{obj} ");
            Console.WriteLine();


            // 요소 삽입. Insert() 메서드
            list.Insert(2, 2); // list의 인덱스 2에 정수 2를 삽입합니다.

            foreach (object obj in list)
                Console.Write($"{obj} ");
            Console.WriteLine();


            list.Add("abc"); // list에 문자열 "abc"를 추가합니다.
            list.Add("def"); // list에 문자열 "def"를 추가합니다.


            for (int i = 0; i < list.Count; i++) // for 문을 사용하여 list의 모든 요소를 순회합니다.
                                                 // list.Count는 list의 요소 개수를 반환합니다. 
                Console.Write($"{list[i]} "); // 현재 요소를 출력합니다.
            Console.WriteLine();
        }
    }
}


/*
출력 결과

0 1 2 3 4 
0 1 3 4 
0 1 2 3 4 
0 1 2 3 4 abc def 
*/