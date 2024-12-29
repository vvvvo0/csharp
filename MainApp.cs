using System;
using System.Linq; // where(), OrderBy(), Select() 등의 메서드 호출 코드를 사용하려면,
                   // 'System.Collections.Generic' 네임스페이스 using 문이 아니라,
                   // 'System.Linq' 네임스페이스 using 문을 선언해야 합니다.
                   // 왜냐하면 이들 메서드는 System.Linq 네임스페이스에 정의되어 있는
                   // IEnumerable<T>의 확장 메서드이기 때문입니다.


/*
LINQ 쿼리식을 메서드 호출 코드로 바꾸기:
LINQ 쿼리식을 메서드 호출 코드로 바꾸면, 
쿼리식에서 지원하지 않는 Aggregate, All, Any, Average, Concat 등과 같은 
다양한 LINQ 표준 연산 메서드를 사용할 수 있습니다.
 */


// LINQ 쿼리식을 메서드 호출 코드로 바꾸기.
// LINQ를 사용하여 Profile 객체 배열에서
// 특정 조건을 만족하는 프로필을 선택하고, 정렬하고, 새로운 형태로 변환하는 방법을 보여줌.
namespace SimpleLinq2
{
    class Profile
    {
        public string Name { get; set; }
        public int Height { get; set; }
    }


    class MainApp
    {
        static void Main(string[] args)
        {
            Profile[] arrProfile =
            {
                new Profile(){Name="정우성", Height=186},
                new Profile(){Name="김태희", Height=158},
                new Profile(){Name="고현정", Height=172},
                new Profile(){Name="이문세", Height=178},
                new Profile(){Name="하하", Height=171}
            };


            // LINQ 쿼리식을 메서드 호출 코드로 바꾸기.
            // from절의 범위 변수 profile은 각 메서드에 입력되는 람다식의 매개변수로 바꿈.
            var profiles = arrProfile
                              .Where(profile => profile.Height < 175) // where를 Where() 메서드로 바꿈.
                              .OrderBy(profile => profile.Height) // orderby를 OrderBy() 메서드로 바꿈. 
                              .Select(profile =>
                                     new
                                     {
                                         Name = profile.Name,
                                         InchHeight = profile.Height * 0.393
                                     }); // select를 Select() 메서드로 바꿈.

            foreach (var profile in profiles)
                Console.WriteLine($"{profile.Name}, {profile.InchHeight}");
        }
    }
}


/*
출력 결과

김태희, 62.094
하하, 67.203
고현정, 67.596
 */