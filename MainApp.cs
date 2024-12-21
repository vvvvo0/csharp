using System;


/*
가변 배열(Jagged Array):
다양한 길이의 배열을 요소로 갖는 배열.
즉, 각 배열 요소의 크기가 다를 수 있습니다.
 */

namespace JaggedArray
{
    class MainApp
    {
        static void Main(string[] args)
        {
            int[][] jagged = new int[3][]; // 3개의 요소를 가진 가변 배열 jagged를 선언.
                                           // 각 요소는 정수형 배열입니다.
            jagged[0] = new int[5] { 1, 2, 3, 4, 5 }; // jagged 배열의 첫 번째 요소에 5개의 정수 값을 가진 배열을 할당합니다.
            jagged[1] = new int[] { 10, 20, 30 }; // jagged 배열의 두 번째 요소에 3개의 정수 값을 가진 배열을 할당합니다.
            jagged[2] = new int[] { 100, 200 }; // jagged 배열의 세 번째 요소에 2개의 정수 값을 가진 배열을 할당합니다.


            foreach (int[] arr in jagged) // 중첩된 foreach 문을 사용하여 가변 배열의 각 요소를 순회합니다.
                                          //
                                          // jagged 배열의 각 요소를 arr 변수에 할당하며 반복합니다. 
                                          // jagged 배열은 정수형 배열의 배열이므로, arr 변수는 정수형 배열을 나타냅니다.
                                          // int[]는 int형 데이터를 여러 개 담을 수 있는 배열 자료형.
                                          // int는 정수 하나를 저장하는 자료형이고, int[]는 정수 여러 개를 저장하는 배열 자료형.
                                          // int는 1, 2, 3과 같은 정수 하나를 저장할 수 있지만,
                                          // int[]는 {1, 2, 3}과 같이 여러 개의 정수를 저장할 수 있다.
                                          // C#에서는 배열을 선언할 때 [] 기호를 사용함. 따라서 int[]는 정수형 배열을 나타내는 자료형.
            {
                Console.Write($"Length : {arr.Length}, "); // 현재 배열 요소의 길이를 출력합니다.
                                                           // arr.Length는 arr 배열에 포함된 요소의 개수(길이)를 나타냅니다.


                foreach (int e in arr) // arr 배열의 각 요소를 e 변수에 할당하며 반복합니다.
                                       // arr 배열은 정수형 배열이므로, e 변수는 정수 값을 나타냅니다.
                {
                    Console.Write($"{e} "); // 현재 배열 요소의 값을 출력합니다.
                                            // e 변수의 값을 출력합니다.

                }
                Console.WriteLine(""); // 줄 바꿈을 합니다.
            }

            Console.WriteLine("");


            int[][] jagged2 = new int[2][] //  2개의 요소를 가진 가변 배열 jagged2를 선언과 동시에 초기화합니다. 각 요소는 정수형 배열입니다.
            {
                new int[] { 1000, 2000 },
                new int[4] { 6, 7, 8, 9 } };



            foreach (int[] arr in jagged2) // 중첩된 foreach 문을 사용하여 가변 배열의 각 요소를 순회합니다.
            {
                Console.Write($"Length : {arr.Length}, "); // 현재 배열 요소의 길이(개수)를 출력합니다.
                foreach (int e in arr)
                {
                    Console.Write($"{e} ");
                }
                Console.WriteLine();
            }
        }
    }
}


/*
출력 결과

Length : 5, 1 2 3 4 5 
Length : 3, 10 20 30 
Length : 2, 100 200 

Length : 2, 1000 2000 
Length : 4, 6 7 8 9
*/