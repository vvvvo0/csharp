using System;
using System.Linq;


/*
group by:
LINQ 쿼리에서 데이터를 분류하는 기능.
group by를 사용하면 데이터를 그룹으로 나누고, 
각 그룹에 대한 추가적인 작업을 수행할 수 있습니다.
예를 들어, 각 그룹의 요소 개수를 세거나, 
각 그룹에서 특정 조건을 만족하는 요소를 찾는 등의 작업을 할 수 있습니다.
 */


// LINQ의 group by 절을 사용하여 Profile 객체 배열을 키에 따라 그룹화하는 방법을 보여줌
namespace GroupBy
{
    class Profile // Profile 객체는 Name과 Height 프로퍼티를 가집니다.
    {
        public string Name { get; set; }
        public int Height { get; set; }
    }


    class MainApp
    {
        static void Main(string[] args) // Main 메서드: 5개의 Profile 객체를 생성하여
                                        // arrProfile 배열에 저장합니다.
        {
            Profile[] arrProfile =
            {
                new Profile(){Name="정우성", Height=186},
                new Profile(){Name="김태희", Height=158},
                new Profile(){Name="고현정", Height=172},
                new Profile(){Name="이문세", Height=178},
                new Profile(){Name="하하", Height=171}
            };


            var listProfile = from profile in arrProfile // arrProfile 배열의 각 요소를 profile이라는 변수에 할당하며 쿼리를 시작합니다.
                              orderby profile.Height // profile의 Height 프로퍼티 값을 기준으로 오름차순으로 정렬합니다. 
                              group profile by profile.Height < 175 into g // profile.Height < 175 조건의 결과에 따라 profile을 그룹화합니다.
                                                                           // profile.Height가 175 미만이면 true 그룹(컬렉션)에,
                                                                           // profile.Height가 175 이상이면 false 그룹(컬렉션)에 속하게 됩니다.
                                                                           // g는 각 그룹을 나타내는 변수(그룹 변수)입니다.
                                                                           
                              select new { GroupKey = g.Key, Profiles = g }; // 무명 형식을 사용하여 GroupKey와 Profiles 프로퍼티를 가진 새로운 객체를 생성합니다.
                                                                             // GroupKey는 그룹의 키 값(true 또는 false)이고,
                                                                             // Profiles는 해당 그룹에 속하는 Profile 객체들의 컬렉션입니다.


            foreach (var Group in listProfile) // listProfile 쿼리 결과를 순회하며 각 그룹을 Group이라는 변수에 할당합니다.
            {
                Console.WriteLine($"- 175cm 미만? : {Group.GroupKey}"); // Group의 GroupKey 프로퍼티 값을 출력합니다.

                foreach (var profile in Group.Profiles) //  각 그룹에 속하는 Profile 객체를 순회하며 profile이라는 변수에 할당합니다.
                {
                    Console.WriteLine($"    {profile.Name}, {profile.Height}"); // profile의 Name과 Height 프로퍼티 값을 출력합니다.
                }
            }
        }
    }
}


/*
출력 결과

- 175cm 미만? : True
   김태희, 158
   하하, 171
   고현정, 172
- 175cm 미만? : False
   이문세, 178
   정우성, 186
 */
