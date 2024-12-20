using System;


/*
C#에서 모든 배열은 System.Array 클래스에서 파생됨.
따라서 모든 배열은 System.Array 클래스의 멤버를 상속받아 사용할 수 있음.

System.Array 클래스에 있는 메소드와 프로퍼티들을 사용해서,
배열 내부의 데이터를 원하는 순서대로 정렬하거나,특정 데이터를 배열 속에서 찾아내는 작업 등을 쉽게 할 수 있음.
 */


// 배열을 다루는 다양한 메서드와 프로퍼티(Array 클래스의 메서드와 프로퍼티)를 사용하는 방법을 보여줌
namespace MoreOnArray
{
    class MainApp
    {
        private static bool CheckPassed(int score) // CheckPassed 메서드:
                                                   // 정수형 점수를 입력으로 받아 60점 이상이면 true, 미만이면 false를 반환합니다.
        {
            return score >= 60; 
        }

        private static void Print(int value) // Print 메서드:
                                             // 정수형 값을 입력으로 받아 콘솔에 출력합니다.
        {
            Console.Write($"{value} ");
        }

        static void Main(string[] args)
        {
            int[] scores = new int[] { 80, 74, 81, 90, 34 }; //  5개의 정수 값을 가진 scores 배열을 선언하고 초기화합니다.

            foreach (int score in scores) // foreach 문을 사용하여 scores 배열의 각 요소를 출력합니다.
                Console.Write($"{score} ");
            Console.WriteLine();


            Array.Sort(scores); // scores 배열을 오름차순으로 정렬합니다.

            Array.ForEach<int>(scores, new Action<int>(Print)); // scores 배열의 각 요소에 대해 Print 메서드를 호출합니다.
                                                                // Print 메서드는 배열 요소를 콘솔에 출력합니다.
                                                                // <T>는 형식(Type) 매개변수로, 
                                                                // <T>가 포함된 메서드를 호출할 때는 T 대신 배열의 기반 자료형(여기선 int)을
                                                                // 인수로 입력하면 컴파일러가 해당 형식에 맞춰 동작하도록 메서드를 컴파일합니다.

            Console.WriteLine();


            Console.WriteLine($"Number of dimensions : {scores.Rank}"); // scores 배열의 차원 수를 출력합니다.
                                                                        // 1차원 배열이므로 1이 출력됩니다.


            Console.WriteLine($"Binary Search : 81 is at " +
                $"{Array.BinarySearch<int>(scores, 81)}"); // scores 배열에서 81을 이진(Binary) 검색하여 인덱스를 출력합니다.
                                                           // Binary(이진) 검색은 배열의 중간 값을 확인하고,
                                                           // 찾는 값보다 크면 오른쪽 절반, 작으면 왼쪽 절반을 다시 검색하는 방식으로
                                                           // 빠르게 값을 찾는 알고리즘입니다.
                                                           // 따라서 이진 검색은 배열이 정렬된 상태여야만 정확한 결과를 반환합니다.


            Console.WriteLine($"Linear Search : 90 is at " +
                $"{Array.IndexOf(scores, 90)}"); //  scores 배열에서 90을 선형 검색하여 인덱스를 출력합니다.


            Console.WriteLine($"Everyone passed ? : " +
                $"{Array.TrueForAll<int>(scores, CheckPassed)}"); // scores 배열의 모든 요소가 CheckPassed 메서드의 조건을 만족하는지 확인합니다.


            int index = Array.FindIndex<int>(scores, (score) => score < 60); // scores 배열에서 60보다 작은 첫 번째 요소의 인덱스를 찾습니다,
            scores[index] = 61; // 해당 인덱스의 값을 61로 변경합니다.


            Console.WriteLine($"Everyone passed ? : " +
                $"{Array.TrueForAll<int>(scores, CheckPassed)}"); // scores 배열의 모든 요소가 CheckPassed 메서드의 조건을 만족하는지 다시 확인합니다.
                                                                  // TrueForAll() 메서드는 배열과 함께, 조건을 검사하는 메서드를 매개변수로 받습니다.

            Console.WriteLine("Old length of scores : " +
                $"{scores.GetLength(0)}"); // GetLength(0): scores 배열의 현재 길이를 출력합니다.


            Array.Resize<int>(ref scores, 10); // scores 배열의 크기를 10으로 조정합니다.
            Console.WriteLine($"New length of scores : {scores.Length}"); // 크기 조정 된 후 scores 배열의 길이를 출력합니다.


            Array.ForEach<int>(scores, new Action<int>(Print)); // scores 배열의 각 요소에 대해 Print 메서드를 호출합니다.
            Console.WriteLine();


            Array.Clear(scores, 3, 7); //  scores 배열의 3번째 인덱스부터 7개의 요소를 0으로 초기화합니다.

            Array.ForEach<int>(scores, new Action<int>(Print)); // scores 배열의 각 요소에 대해 Print 메서드를 호출합니다.
            Console.WriteLine();


            int[] sliced = new int[3]; //  3개의 정수를 저장할 수 있는 sliced 배열을 선언합니다.

            Array.Copy(scores, 0, sliced, 0, 3); // scores 배열의 0번째 인덱스부터 3개의 요소를, sliced 배열의 0번째 인덱스부터 복사합니다.

            Array.ForEach<int>(sliced, new Action<int>(Print)); // sliced 배열의 각 요소에 대해 Print 메서드를 호출합니다.
            Console.WriteLine();
        }
    }
}


/*
출력 결과

80 74 81 90 34 
34 74 80 81 90
Number of dimensions : 1
Binary Search : 81 is at 3
Linear Search : 90 is at 4
Everyone passed ? : False
Everyone passed ? : True
Old length of scores : 5
New length of scores : 10
61 74 80 81 90 0 0 0 0 0
61 74 80 0 0 0 0 0 0 0
61 74 80
 */