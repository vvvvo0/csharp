using System;


/*
무명 형식:
이름이 없는 형식으로, 컴파일러가 자동으로 형식을 생성함.

형식의 선언과 동시에 인스턴스를 할당함.
따라서 인스턴스를 만들고 다시는 사용하지 않을 때 요긴하게 사용.
무명 형식의 프로퍼티에 할당된 값은 변경 불가능함. (즉, 읽기 전용 프로퍼티)

주로 LINQ 쿼리에서 데이터를 일시적으로 저장하는 데 사용.

new { 속성1 = 값1, 속성2 = 값2, ... }와 같이,
new 키워드와 객체 초기화자를 사용하여 생성

형식 이름을 정의하지 않고도 간단하게 객체를 생성할 수 있으므로,
코드를 간결하게 작성할 수 있음

형식의 이름이 필요한 이유?
형식의 이름을 이용해서 인스턴스를 만들기 때문.
int a;
double b;
 */


// 무명 형식을 사용하여 간단한 데이터 구조를 표현하는 방법을 보여줌
namespace AnonymousType
{
    class MainApp
    {
        static void Main(string[] args)
        {
            var a = new { Name = "박상현", Age = 123 }; // Name 프로퍼티와 Age 프로퍼티를 가진 무명 형식의 객체를 생성
            Console.WriteLine("Name:{0}, Age:{1}", a.Name, a.Age); // 무명 형식 객체의 프로퍼티 값을 출력

            var b = new { Subject = "수학", Scores = new int[] { 90, 80, 70, 60 } }; // Subject 프로퍼티와 Scores 프로퍼티를 가진
                                                                                     // 무명 형식의 객체를 생성

            Console.Write("Subject:{0}, Scores: ", b.Subject); //  무명 형식 객체의 Subject 프로퍼티 값을 출력
            
            foreach (var score in b.Scores) // Scores 배열의 각 요소를 출력
                Console.Write("{0} ", score);

            Console.WriteLine();
        }
    }
}


/*
출력 결과

Name:박상현, Age:123
Subject:수학, Scores: 90 80 70 60 
 */