using System;


/*
delegate 왜, 언제 사용?
'값'이 아닌 '코드' 자체를 매개변수에 넘기고 싶을 때 사용.
 */


// 델리게이트를 사용하여 버블 정렬 알고리즘을 구현하고, 오름차순과 내림차순으로 정렬하는 방법
// Comparer 델리게이트를 통해 정렬 방식을 동적으로 변경할 수 있다
namespace UsingCallback

{

    delegate int Compare(int a, int b); // Compare라는 이름의 델리게이트를 선언합니다.
                                        // 이 델리게이트는 두 개의 정수를 매개변수로 받아
                                        // 정수 값을 반환하는 메서드를 참조할 수 있습니다.


    class MainApp
    {
        static int AscendCompare(int a, int b) // AscendCompare():
                                               // Compare 대리자가 참조할 비교 메서드.
                                               // 두 개의 정수 a와 b를 비교하여,
                                               // a가 b보다 크면 1, 같으면 0, 작으면 -1을 반환합니다.
                                               // 오름차순 정렬을 위한 비교 메서드입니다.
        {
            if (a > b)
                return 1;
            else if (a == b)
                return 0;
            else
                return -1;
        }

        static int DescendCompare(int a, int b) // DescendCompare():
                                                // Compare 대리자가 참조할 비교 메서드.
                                                // 내림차순 정렬을 위한 비교 메서드입니다.

        {
            if (a < b)
                return 1;
            else if (a == b)
                return 0;
            else
                return -1;
        }


        // Comparer 델리게이트를 통해 정렬 방식을 동적으로 변경할 수 있다.
        static void BubbleSort(int[] DataSet, Compare Comparer) // BubbleSort(): 정렬을 위한 메서드
                                                                // 정수형 배열 타입의 DataSet과,
                                                                // Compare 델리게이트 타입의 Comparer를
                                                                // 매개변수로 받아,
                                                                // 버블 정렬 알고리즘을 사용하여 DataSet 배열을 정렬합니다.
                                                                // Comparer 델리게이트를 사용하여 두 요소를 비교합니다.
                                                                // Comparer(DataSet[j], DataSet[j + 1]) > 0이면
                                                                // 두 요소의 순서를 바꿉니다.

        {
            int i = 0; // i: 바깥쪽 반복문 카운터 변수
            int j = 0; // j: 안쪽 반복문의 카운터 변수
            int temp = 0; // temp: 두 요소의 값을 교환할 때 사용되는 임시 변수


            for (i = 0; i < DataSet.Length - 1; i++) // 배열의 크기 - 1만큼 반복합니다.
            {
                for (j = 0; j < DataSet.Length - (i + 1); j++) // 배열의 크기 - (i + 1)만큼 반복합니다.
                                                               // i가 증가할수록 안쪽 반복문의 횟수가 줄어들게 했는데,
                                                               // 바깥쪽 반복문을 한 번 돌 때마다
                                                               // 가장 큰 값이 배열의 마지막으로 이동하기 때문임.
                {
                    if (Comparer(DataSet[j], DataSet[j + 1]) > 0) // Comparer 델리게이트를 사용하여
                                                                  // DataSet[j]와 DataSet[j + 1] 요소를 비교합니다.
                                                                  // Comparer는 AscendCompare() 또는 DescendCompare() 메서드를 참조하며,
                                                                  // 이 메서드들은 두 요소를 비교하여 순서를 판별합니다.
                                                                  // 만약 Comparer의 반환 값이 0보다 크면, 
                                                                  // 즉 두 요소의 순서가 잘못되었으면
                                                                  // temp 변수를 사용하여 두 요소의 값을 교환합니다.

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
            BubbleSort(array, new Compare(AscendCompare)); // BubbleSort 메서드를 호출하여
                                                           // array 배열을 오름차순으로 정렬합니다. 
                                                           // new Compare(AscendCompare):
                                                           // 'AscendCompare ()메서드를 참조'하는 Compare 델리게이트를 생성합니다.
                                                           //
                                                           // BubbleSort 메서드를 호출할 때,
                                                           // array 배열과, AscendCompare 메서드를 참조하는 Compare 델리게이트를 전달합니다.


            for (int i = 0; i < array.Length; i++) // for 문을 사용하여 정렬된 array 배열을 출력합니다.
                Console.Write($"{array[i]} ");


            int[] array2 = { 7, 2, 8, 10, 11 }; // 정수형 배열 array2를 선언하고 초기화합니다.
            Console.WriteLine("\nSorting descending..."); 
            BubbleSort(array2, new Compare(DescendCompare)); // BubbleSort 메서드를 호출하여
                                                             // array2 배열을 내림차순으로 정렬합니다.
                                                             // new Compare(DescendCompare):
                                                             // 'DescendCompare() 메서드를 참조'하는 Compare 델리게이트를 생성합니다.

            for (int i = 0; i < array2.Length; i++) // for 문을 사용하여 정렬된 array2 배열을 출력합니다.
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
11 10 8 7 2 
*/