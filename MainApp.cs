using System;
using System.Collections.Generic; // List<T>와 같은 제네릭 컬렉션을 사용하기 위해 필요
                                  // List<T>는 배열과 유사하지만 크기가 동적으로 변하는 컬렉션
using System.Linq; // LINQ(Language Integrated Query)를 사용하기 위해 필요 


/*
where:
필터(Filter) 역할.
from 절이 데이터 원본으로부터 뽑아낸 범위 변수가 가져야 하는 조건을 
where 연산자에 인수로 입력하면, LINQ는 해당 조건에 부합하는 데이터만 걸러냅니다.

orderby:
데이터의 정렬을 수행하는 연산자입니다.

select:
select 절은 최종 결과를 추출합니다.

->
from 절에서 데이터 원본으로부터 범위 변수를 뽑아내고,
where 절에서 이 범위 변수의 조건을 검사한 후,
orderby 절에서 그 결과를 정렬하고,
select 문을 이요하여 최종 결과를 추출합니다.
 */


// List<Profile>을 사용하여 Profile 객체의 컬렉션을 생성하고,
// LINQ를 사용하여 컬렉션을 쿼리하고 결과를 출력합니다.
namespace SimpleLinq
{
    class Profile // Name과 Height 프로퍼티를 가진 클래스 Profile
    {
        public string Name { get; set; }
        public int Height { get; set; }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            Profile[] arrProfile = // 5개의 Profile 객체를 생성하여
                                   // arrProfile 배열에 저장합니다.
            {
                new Profile(){Name="정우성", Height=186},
                new Profile(){Name="김태희", Height=158},
                new Profile(){Name="고현정", Height=172},
                new Profile(){Name="이문세", Height=178},
                new Profile(){Name="하하", Height=171}
            };


            // var 형식으로 선언된 profiles의 실제 형식?
            // LINQ 질의(쿼리) 결과는 IEnumerable<T>로 반환되는데, 이때 형식 매개변수 T는 select 문에 의해 결정됨.
            // select new { Name = profile.Name, InchHeight = profile.Height * 0.393 } 부분에서
            // new { ... } 구문을 사용하여 익명 형식을 생성하고 있음.
            // 따라서 profiles 변수는 익명 형식임.
            // 익명 형식은 이름이 없는 클래스와 같습니다. 컴파일러가 익명 형식의 이름을 자동으로 생성하고,
            // Name과 InchHeight 프로퍼티를 가진 클래스를 정의합니다.
            // var 키워드는 컴파일러가 변수의 타입을 자동으로 유추하도록 하는 키워드입니다.
            // 이 경우 컴파일러는 select 문의 결과를 보고 profiles 변수의 타입을 익명 형식으로 유추합니다.
            // 따라서 profiles 변수는 Name과 InchHeight 프로퍼티를 가진 익명 형식의 객체를 저장하는 컬렉션입니다.
            var profiles = from profile in arrProfile // arrProfile 배열의 각 요소를
                                                      // profile이라는 변수에 할당

                           where profile.Height < 175 // profile의 Height 프로퍼티 값이 175보다 작은 요소만 선택하고,

                           orderby profile.Height // 선택된 요소를 Height 프로퍼티 값을 기준으로 오름차순으로 정렬

                           select new // new { ... } 구문(익명 형식)을 사용하여,
                                      // Name과 InchHeight 프로퍼티를 가진 새로운 객체를 생성합니다.
                                      // InchHeight는 Height 값에 0.393을 곱하여 센티미터를 인치로 변환한 값입니다.
                           {
                               Name = profile.Name,
                               InchHeight = profile.Height * 0.393
                           };

            foreach (var profile in profiles) // profiles 쿼리 결과를 순회하며 각 요소를 profile이라는 변수에 할당합니다.
                Console.WriteLine($"{profile.Name}, {profile.InchHeight}"); // profile의 Name과 InchHeight 프로퍼티 값을 출력합니다.
        }
    }
}


/*
출력 결과

김태희, 62.204
하하, 67.322
고현정, 67.716
*/