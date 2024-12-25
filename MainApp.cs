using System;


/*
일반화 대리자(Generic Delegate):
대리자(Delegate)는 일반화(Generic) 메서드도 참조할 수 있습니다.
이 때 대리자는 일반화 메서드를 참조할 수 있도록, 형식 매개변수를 이용하여 선언해야 합니다.  
 */


// 제네릭 델리게이트(일반화 대리자)를 사용하여 버블 정렬 알고리즘을 구현하고,
// '다양한 타입'의 배열을 오름차순과 내림차순으로 정렬하는 방법을 보여줌
namespace GenericDelegate
{

    delegate int Compare<T>(T a, T b); // Compare<T>라는 이름의 일반화 대리자(제네릭 델리게이트)를 선언합니다. 
                                       // 이 델리게이트는 두 개의 T 타입 매개변수를 받아
                                       // 정수 값을 반환하는 메서드를 참조할 수 있습니다.



    class MainApp
    {

        // AscendCompare() 메서드 일반화 버전
        static int AscendCompare<T>(T a, T b) where T : IComparable<T> // AscendCompare<T> 메서드:
                                                                       // 오름차순 정렬을 위한 비교 메서드.
                                                                       // 두 개의 T 타입 매개변수 a와 b를 비교하여,
                                                                       // a가 b보다 크면 양수, 같으면 0, 작으면 음수를 반환합니다.
                                                                       // where T : IComparable<T> 제약 조건:
                                                                       // T 타입이 IComparable<T> 인터페이스를 구현해야 함을 나타냅니다. 
                                                                       // IComparable<T> 인터페이스:
                                                                       // 객체를 비교하는 CompareTo() 메서드를 정의합니다.
                                                                       // 갑자기 IComparable<T> 인터페이스가 왜 나옴?
                                                                       // (그리고 AscendCompare() 메서드가 IComparable<T>를 상속하는 a 객체의
                                                                       // CompareTo() 메서드를 호출해서 그 결과를 호출?)
                                                                       // 모든 수치 형식과 System.string은 IComparable을 상속해서
                                                                       // CompareTo() 메서드를 구현하고 있기 때문에 바로 나올 수 있음.
                                                                       // CompareTo() 메서드: 매개변수가 자신보다 크면 -1, 같으면 0, 작으면 1을 반환합니다.
                                                                       // 따라서 AscendCompare() 메서드가 a.CompareTo(b)를 호출하면,
                                                                       // 오름차순 정렬에 필요한 비교 결과를 얻을 수 있습니다.
        {
            return a.CompareTo(b);
        }


        // DescendCompare() 메서드 일반화 버전
        static int DescendCompare<T>(T a, T b) where T : IComparable<T> // DescendCompare<T> 메서드:
                                                                        // 내림차순 정렬을 위한 비교 메서드.
                                                                        // 두 개의 T 타입 매개변수 a와 b를 비교하여,
                                                                        // a가 b보다 작으면 양수, 같으면 0, 크면 음수를 반환합니다. 
        {
            return a.CompareTo(b) * -1; // a.CompareTo(b) * -1를 통해 AscendCompare<T> 메서드의 결과를 반전시켜,
                                        // 내림차순 정렬을 구현합니다.
        }


        // BubbleSort() 메서드 일반화 버전. 형식 매개변수만 추가되면 됨.
        static void BubbleSort<T>(T[] DataSet, Compare<T> Comparer) // BubbleSort<T> 메서드:
                                                                    // T 타입의 배열 DataSet과 Compare<T> 델리게이트 Comparer를 매개변수로 받습니다.
                                                                    // 버블 정렬 알고리즘을 사용하여 DataSet 배열을 정렬합니다.
                                                                    // Comparer 델리게이트를 사용하여 두 요소를 비교합니다.
                                                                    // Comparer(DataSet[j], DataSet[j + 1]) > 0이면 두 요소의 순서를 바꿉니다.
        {
            int i = 0;
            int j = 0;
            T temp;

            for (i = 0; i < DataSet.Length - 1; i++)
            {
                for (j = 0; j < DataSet.Length - (i + 1); j++)
                {
                    if (Comparer(DataSet[j], DataSet[j + 1]) > 0)
                    {
                        temp = DataSet[j + 1];
                        DataSet[j + 1] = DataSet[j];
                        DataSet[j] = temp;
                    }
                }
            }
        }


        static void Main(string[] args)
        {
            int[] array = { 3, 7, 4, 2, 10 }; // 정수형 배열 array를 선언하고 초기화합니다.

            Console.WriteLine("Sorting ascending...");
            BubbleSort<int>(array, new Compare<int>(AscendCompare)); // BubbleSort<int> 메서드를 호출하여 
                                                                     // array 배열을 오름차순으로 정렬합니다.

            for (int i = 0; i < array.Length; i++)
                Console.Write($"{array[i]} ");


            string[] array2 = { "abc", "def", "ghi", "jkl", "mno" }; // 문자열 배열 array2를 선언하고 초기화합니다.

            Console.WriteLine("\nSorting descending...");
            BubbleSort<string>(array2, new Compare<string>(DescendCompare)); // BubbleSort<string> 메서드를 호출하여
                                                                             // array2 배열을 내림차순으로 정렬합니다.

            for (int i = 0; i < array2.Length; i++)
                Console.Write($"{array2[i]} ");

            Console.WriteLine();
        }
    }
}


/*
출력 결과

Sorting ascending...
2 3 4 7 10 
Sorting descending...
mno jkl ghi def abc 
*/