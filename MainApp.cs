using System;

namespace CopyingArray
{
    class MainApp
    {
        static void CopyArray<T>(T[] source, T[] target) // 제네릭 메서드 CopyArray<T>를 정의함.
                                                         // T는 제네릭 타입 매개변수로,
                                                         // 메서드를 호출할 때 구체적인 타입으로 지정됩니다.
        {
            for (int i = 0; i < source.Length; i++) // source 배열의 길이만큼 반복
                target[i] = source[i]; // source 배열의 요소를 target 배열에 복사
        }


        static void Main(string[] args)
        {
            int[] source = { 1, 2, 3, 4, 5 }; // 정수형 배열 source 선언하고 초기화
            int[] target = new int[source.Length]; // source 배열과 같은 크기의 정수형 배열 target 선언

            CopyArray<int>(source, target); // CopyArray<T> 메서드 호출하여,
                                            // source 배열의 요소를 target 배열에 복사합니다. 
                                            // T는 int로 지정됩니다.

            foreach (int element in target) // target 배열의 각 요소를 출력합니다.
                Console.WriteLine(element);

            string[] source2 = { "하나", "둘", "셋", "넷", "다섯" }; // 문자열 배열 source2 선언하고 초기화
            string[] target2 = new string[source2.Length]; // source2 배열과 같은 크기의 문자열 배열 target2를 선언

            CopyArray<string>(source2, target2); // CopyArray<T> 메서드 호출, T는 string으로 지정


            foreach (string element in target2) // target2 배열의 각 요소 출력
                Console.WriteLine(element);
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
하나
둘
셋
넷
다섯
*/