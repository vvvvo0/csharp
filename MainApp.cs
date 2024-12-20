using System;

/*
배열:
같은 성격을 가진 다량의 데이트를 한 번에 다뤄야 하는 경우에 유용함.
데이터를 담는 상자와 같아서, 필요한 용량을 가진 배열을 만든 다음 여기에 데이터를 넣을 수 있음.
예를 들어, 300개의 변수를 선언하는 대신, 300개의 용량을 가진 변수를 '한 개'만 선언해서 사용할 수 있음.
 */

// 배열을 사용하여 5개의 점수를 저장하고, 점수의 평균을 계산하는 프로그램
namespace ArraySample
{
    class MainApp
    {
        static void Main(string[] args)
        {
            int[] scores = new int[5]; //  5개의 정수를 저장할 수 있는 scores라는 배열을 선언
            scores[0] = 80; // 배열의 첫 번째 요소(scores[0])에 80을 할당.
                            // 즉, 인덱스는 0부터 시작함.
            scores[1] = 74;
            scores[2] = 81;
            scores[3] = 90;
            scores[4] = 34;

            foreach (int score in scores) // foreach 문을 사용하여 scores 배열의 각 요소를 순회합니다.
                                          // 각 반복에서 score 변수에는 현재 요소의 값이 할당됨
                Console.WriteLine(score); // score 변수의 값을 콘솔에 출력


            int sum = 0; // 점수의 합을 저장할 sum 변수를 선언하고 0으로 초기화
            foreach (int score in scores) // foreach 문을 사용하여 scores 배열의 각 요소를 순회
                sum += score; // 각 반복에서 sum += score;는 sum 변수에 score 변수의 값을 더합니다.

            int average = sum / scores.Length; // sum 변수를 배열의 길이(scores.Length)로 나누어 평균을 계산하고,
                                               // average 변수에 저장

            Console.WriteLine($"Average Score : {average}"); // 문자열 보간을 사용하여 "Average Score : " 문자열과
                                                             // average 변수의 값을 결합하여 콘솔에 출력
        }
    }
}


/*
출력 결과

80
74
81
90
34
Average Score : 71
 */