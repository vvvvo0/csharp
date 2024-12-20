using System;


/*
2차원 배열: 행과 열로 이루어진 표 형태의 데이터 구조
 */

// 2차원 배열을 선언하고 초기화하는 다양한 방법을 보여줌.
namespace _2DArray
{
    class MainApp
    {
        static void Main(string[] args)
        {
            int[,] arr = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } }; //  2행 3열의 2차원 배열 arr을 선언하고 초기화합니다.
                                                                     // 중괄호{}를 사용하여 각 행의 값을 지정합니다.

            // 중첩된 for 문을 사용하여 2차원 배열의 각 요소를 순회합니다.
            for (int i = 0; i < arr.GetLength(0); i++) // arr.GetLength(0): arr 배열의 첫 번째 차원(행)의 길이를 반환합니다.
            {
                for (int j = 0; j < arr.GetLength(1); j++) // arr.GetLength(1): arr 배열의 두 번째 차원(열)의 길이를 반환합니다.
                {
                    Console.Write($"[{i}, {j}] : {arr[i, j]} "); // 현재 요소의 인덱스와 값을 출력합니다.
                }
                Console.WriteLine();
            }
            Console.WriteLine();


            int[,] arr2 = new int[,] { { 1, 2, 3 }, { 4, 5, 6 } }; // 2차원 배열 arr2를 선언하고 초기화합니다. 
                                                                   // 배열의 크기를 명시적으로 지정하지 않고, 초기화 값을 통해 크기를 유추합니다.
                                                                   

            for (int i = 0; i < arr2.GetLength(0); i++)
            {
                for (int j = 0; j < arr2.GetLength(1); j++)
                {
                    Console.Write($"[{i}, {j}] : {arr2[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();


            int[,] arr3 = { { 1, 2, 3 }, { 4, 5, 6 } }; // 2차원 배열 arr3를 선언하고 초기화합니다. 
                                                        // new 키워드와 배열 크기를 생략하고, 초기화 값만으로 배열을 선언합니다.



            for (int i = 0; i < arr2.GetLength(0); i++)
            {
                for (int j = 0; j < arr2.GetLength(1); j++)
                {
                    Console.Write($"[{i}, {j}] : {arr3[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}

/*
출력 결과

[0, 0] : 1 [0, 1] : 2 [0, 2] : 3
[1, 0] : 4 [1, 1] : 5 [1, 2] : 6

[0, 0] : 1 [0, 1] : 2 [0, 2] : 3
[1, 0] : 4 [1, 1] : 5 [1, 2] : 6

[0, 0] : 1 [0, 1] : 2 [0, 2] : 3
[1, 0] : 4 [1, 1] : 5 [1, 2] : 6
 */