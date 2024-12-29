using System;
using System.Linq;


/*
from 문 중첩:
여러 개의 데이터 원본에 질의(쿼리)하기
 */


// from 문을 중첩하면 여러 개의 데이터 원본에서 데이터를 쿼리할 수 있음을 보여줌
namespace FromFrom
{
    class Class // Name과 Score 프로퍼티를 가집니다.
                // Name은 문자열 타입이고, Score는 정수형 배열 타입입니다.
    {
        public string Name { get; set; }
        public int[] Score { get; set; }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            Class[] arrClass =
            {
                new Class(){Name="연두반", Score=new int[]{99, 80, 70, 24}},
                new Class(){Name="분홍반", Score=new int[]{60, 45, 87, 72}},
                new Class(){Name="파랑반", Score=new int[]{92, 30, 85, 94}},
                new Class(){Name="노랑반", Score=new int[]{90, 88, 0, 17}}
            };

            var classes = from c in arrClass // arrClass 객체에 from 절로 접근해서 범위 변수 c를 뽑고,
                          from s in c.Score // 다시 그 c 객체의 Score 필드에 또 다른 from 절로 접근해서
                                            // 새로운 범위 변수 s를 뽑습니다.
                                            // 범위 변수 s는 개별 점수를 나타냅니다.
                          where s < 60 // where 절을 사용해서 이 s가 60보다 낮은지 걸러내고,
                          orderby s
                          select new { c.Name, Lowest = s }; // new {...} 부분을 통해 무명 형식을 선언해서
                                                             // 낙제점을 맞은 학생의 학급 이름과 점수를 담아냅니다.

            foreach (var c in classes) // classes 쿼리 결과를 순회하면서 각 익명 객체를 c 변수에 할당합니다.
                Console.WriteLine($"낙제 : {c.Name} ({c.Lowest})"); // c 변수를 통해 익명 객체의 Name과 Lowest 프로퍼티에 접근하여
                                                                    // "낙제 : {반 이름} ({낙제 점수})" 형식으로 출력합니다.
        }
    }
}


/*
출력 결과

낙제 : 노랑반 (0)
낙제 : 노랑반 (17)
낙제 : 연두반 (24)
낙제 : 파랑반 (30)
낙제 : 분홍반 (45)
*/