using System;


/*
익명 메서드(anonymous method):
이름이 없는 메서드.
원래 메서드는 한정자가 없어도, 반환할 값이 없어도(coid), 매개변수가 없어도 괜찮지만 이름만은 있어야 함.
익명 메서드를 참조할 대리자의 형식과 동일한 형식으로 선언되어야 함. 
(동일한 매개변수 형식, 반환 형식)

익명 메서드의 장점?
코드를 간결하게 작성할 수 있습니다.
메서드를 정의할 필요 없이 델리게이트에 직접 코드를 전달할 수 있습니다.

언제 사용?
대리자가 참조할 메서드를 넘겨야 할 때, 이 메서드가 두 번 다시 사용할 일이 없다고 판단되면 사용.
 */


// 익명 메서드를 사용하여 델리게이트에 비교 로직을 전달하는 방법
namespace AnonymouseMethod
{
    delegate int Compare(int a, int b); // Compare라는 이름의 델리게이트를 선언
                                        // 이 델리게이트는 두 개의 정수를 매개변수로 받아
                                        // 정수 값을 반환하는 메서드를 참조할 수 있습니다.


    class MainApp
    {
        static void BubbleSort(int[] DataSet, Compare Comparer) // BubbleSort 메서드:
                                                                // 정수형 배열 DataSet과 Compare 델리게이트 Comparer를 매개변수로 받습니다.
                                                                // 버블 정렬 알고리즘을 사용하여 DataSet 배열을 정렬합니다.
                                                                // Comparer 델리게이트를 사용하여 두 요소를 비교합니다.
                                                                // Comparer(DataSet[j], DataSet[j + 1]) > 0이면 두 요소의 순서를 바꿉니다.
        {
            int i = 0; // <벨로그: delegate 사용하여 정렬> 참고!
            int j = 0;
            int temp = 0;

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
            BubbleSort(array, delegate (int a, int b) // BubbleSort 메서드를 호출하여 array 배열을 오름차순으로 정렬합니다.
                                                      // 두 번째 인자로 익명 메서드(delegate (int a, int b))를 전달합니다. 
                                                      // 익명 메서드(delegate (int a, int b))는
                                                      // Compare 델리게이트와 동일한 매개변수 형식, 반환 형식를 가지며, 
                                                      // 두 개의 정수를 비교하여 오름차순 정렬을 위한 비교 로직을 제공합니다.
            {
                if (a > b)
                    return 1;
                else if (a == b)
                    return 0;
                else
                    return -1;
            });


            for (int i = 0; i < array.Length; i++) // for 문을 사용하여 정렬된 array 배열을 출력합니다.
                Console.Write($"{array[i]} ");


            int[] array2 = { 7, 2, 8, 10, 11 }; // 정수형 배열 array2를 선언하고 초기화합니다.
            Console.WriteLine("\nSorting descending...");
            BubbleSort(array2, delegate (int a, int b) // BubbleSort 메서드를 호출하여 array2 배열을 내림차순으로 정렬합니다. 
                                                       // 두 번째 인자로 익명 메서드를 전달합니다.
                                                       // 익명 메서드는 Compare 델리게이트와 동일한 매개변수 형식, 반환 형식를 가지며,
                                                       // 두 개의 정수를 비교하여 내림차순 정렬을 위한 비교 로직을 제공합니다.
            {
                if (a < b)
                    return 1;
                else if (a == b)
                    return 0;
                else
                    return -1;
            });


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