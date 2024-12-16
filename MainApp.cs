using System;


/*
튜플은 분해자를 구현하고 있어서 분해가 가능.

위치 패턴 매칭: 분해자를 구현하고 있는 객체를 분해한 결과를
                Switch 문이나 Switch 식의 분기 조건에 활용한 것.
                
튜플의 요소들을 분해하고, 그 '분해된 요소의 위치'에 따라 값이 일치하는지 판단하여 
switch 문이나 switch 식의 분기 조건에 활용하는 기능임.
 */


// 튜플과 위치 패턴 매칭을 사용하여 클라이언트 유형에 따라 할인율을 계산하는 프로그램

namespace PosisionalPattern
{
    class MainApp
    {
        private static double GetDiscountRate(object client) // 매개변수 이름은 client이지만, 실제로 메서드에 전달하는 변수의 이름은 달라도 괜찮음.
                                                             // 즉, alice 튜플을 인자로 전달 가능.
                                                             // GetDiscountRate() 메서드는 object 타입의 매개변수를 받기 때문에,
                                                             // 어떤 이름의 변수든 object 타입으로 변환될 수 있다면 메서드에 전달할 수 있음.
        {
            return client switch // client의 값에 따라 할인율을 계산
            {
                ("학생", int n) when n < 18 => 0.2,  // client가 학생 & 18세 미만이면 0.2 (20%) 할인율을 반환함.
                ("학생", _) => 0.1,  // client가 학생이면 0.1 (10%) 할인율을 반환. _는 나이 값을 무시한다는 의미.
                                     // 즉, 나이 값에 관계없이 "학생"이면 0.1 (10%) 할인율을 적용한다는 의미
                ("일반", int n) when n < 18 => 0.1,  // client가 "일반"이고 나이가 18세 미만이면 0.1 (10%) 할인율을 반환합니다.
                ("일반", _) => 0.05, // client가 "일반"이면 나이에 관계없이 0.05 할인율을 반환.
                _ => 0, //  위 조건에 해당하지 않으면 0 (0%) 할인율을 반환
            };
        }

        static void Main(string[] args)
        {
            var alice = (job: "학생", age: 17); // alice라는 변수에 "학생"이라는 job과 17이라는 age를 튜플로 묶어서 저장
            var bob = (job: "학생", age: 23);
            var charlie = (job: "일반", age: 15);
            var dave = (job: "일반", age: 21);

            Console.WriteLine($"alice   : {GetDiscountRate(alice)}"); // GetDiscountRate(alice)는 GetDiscountRate() 메서드를 호출하면서 alice 튜플을 인자로 전달
            Console.WriteLine($"bob     : {GetDiscountRate(bob)}");
            Console.WriteLine($"charlie : {GetDiscountRate(charlie)}");
            Console.WriteLine($"dave    : {GetDiscountRate(dave)}");
        }
    }
}

// 출력 결과
// alice   : 0.2
// bob: 0.1
// charlie: 0.1
// dave: 0.05