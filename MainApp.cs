using System;


/*
인덱스 from end 연산자(^):
^연산자는 컬렉션의 마지막부터 역순으로 인덱스를 지정하는 기능.

^1: 배열(컬렉션)의 마지막 요소를 나타내는 인덱스
^2: 마지막에서 두 번째 요소를 나타내는 인덱스
 */


namespace ArraySample2
{
    class MainApp
    {
        static void Main(string[] args)
        {
            int[] scores = new int[5]; // 5개의 정수를 저장할 수 있는 scores라는 배열을 선언

            scores[0] = 80; // 배열의 첫 번째 요소(scores[0])에 80을 할당
            scores[1] = 74;
            scores[2] = 81;

            scores[^2] = 90;  // 배열의 마지막-1
                              // 배열의 마지막에서 두 번째 요소에 90을 할당합니다.
            scores[^1] = 34;  // 배열의 마지막
                              //  배열의 마지막 요소에 34를 할당합니다.


            foreach (int score in scores) // foreach 문: scores라는 배열의 각 요소를
                                          // 차례대로 score라는 변수에 담으면서 코드 실행.
                                          // 각 반복에서 score 변수에는 현재 요소의 값이 할당됨.
                Console.WriteLine(score); // score 변수의 값을 콘솔에 출력


            int sum = 0; // 점수의 합을 저장할 sum 변수를 선언하고 0으로 초기화
            foreach (int score in scores) // foreach 문을 사용하여 scores 배열의 각 요소를 순회함
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
