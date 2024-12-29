using System;
using System.Linq;


/*
join:
두 데티어 원본을 연결하는 연산입니다.
각 데이터 원본에서 특정 필드의 값을 비교하여 일치하는 데이터끼리 연결합니다.

(1) Inner Join(내부 조인):
두 데이터 원본 사이에서 일치하는 데이터들만 연결한 후 반환합니다.(교집합과 비슷)
구체적으로, 첫 번째 데이터 원본과 두 번째 데이터 원본의 특정 필드를 비교해서 일치하는 데이터를 반환합니다.
이때 기준은 '첫 번째 데이터 원본'입니다.
기준 데이터 원본에는 존재하지만 연결할 데이터 원본에는 존재하지 않는 데이터는 조인 결과에 포함되지 않습니다.

내부 조인은 join 절을 통해 수행합니다.

fromm a in A
join b in B on a.XXXX equals b.YYYY

기준 데이터 a는 from 절에서 뽑아낸 범위 변수이고,
연결 대상 데이터 b는 join 절에서 뽑아낸 변수입니다.
on 키워드는 조인 조건을 수반합니다.
on 절의 조인 조건은 동등(Equality)만 허용됩니다. 즉, '~보다 큼' 같은 비교 연사나은 허락되지 않습니다.
이때 '==' 연산자가 아닌, 'equals' 키워드를 사용해야 합니다.

(2) Outer Join(외부 조인):
내부 조인과 달리, 조인 결과에 기준이 되는 데이터 원본이 모두 포함됩니다.
따라서 연결할 데이터 원본에 기준 데이터 원본의 데이터와 일치하는 데이터가 없다면, 
그 부분은 빈 값으로 결과를 채우게 됩니다.


LINQ는 원래 DBMS에서 사용하던 SQL을 본떠 프로그래밍 언어 안에 통합한 것입니다.
원래 SQL에서 지원하는 외부 조인에는 왼쪽, 오른쪽, 완전 외부 조인이 있으나,
LINQ는 왼쪽 조인만 지원합니다.
 */


// LINQ를 사용하여 두 개의 데이터 배열(Profile, Product)을 조인하는 방법
// 
namespace Join
{
    // (1)  클래스 정의
    class Profile
    {
        public string Name { get; set; }
        public int Height { get; set; }
    }

    class Product
    {
        public string Title { get; set; }
        public string Star { get; set; }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            // (2) 데이터 배열 생성
            Profile[] arrProfile = // 5개의 Profile 객체를 생성하고,
                                   // 중괄호 {} 안에 각 객체의 Name과 Height 프로퍼티 값을 초기화하고 있습니다. 
                                   // 이렇게 생성된 5개의 객체를 arrProfile 배열에 저장합니다.
            {
                new Profile(){Name="정우성", Height=186},
                new Profile(){Name="김태희", Height=158},
                new Profile(){Name="고현정", Height=172},
                new Profile(){Name="이문세", Height=178},
                new Profile(){Name="하하", Height=171}
            };

            Product[] arrProduct = // 5개의 Pro duct 객체를 생성하여
                                   // arrProduct 배열에 저장합니다.
            {
                new Product(){Title="비트",        Star="정우성"},
                new Product(){Title="CF 다수",     Star="김태희"},
                new Product(){Title="아이리스",    Star="김태희"},
                new Product(){Title="모래시계",    Star="고현정"},
                new Product(){Title="Solo 예찬",   Star="이문세"}
            };


            // (3) 내부 조인 (Inner Join)
            var listProfile =
                from profile in arrProfile // arrProfile 배열의 각 profile 요소와
                join product in arrProduct on profile.Name equals product.Star // arrProduct 배열의 각 product 요소를
                                                                               // profile.Name 프로퍼티 값과 product.Star 프로퍼티 값이 같은 경우에
                                                                               // 조인합니다.
                                                                               // 즉, 배우 이름으로 프로필 정보와 제품 정보를 연결합니다.
                select new // 조인된 결과에서 Name, Work, Height라는 세 개의 프로퍼티를 가진 익명 객체를 생성합니다.
                           // 이는 '조인 결과를 원하는 형태로 가공하여 새로운 객체를 생성하는 과정'입니다.
                {
                    Name = profile.Name, // 새로운 객체의 Name 프로퍼티에 profile.Name 값을 할당합니다.
                                         // 즉, arrProfile 배열에서 가져온 프로필의 이름을,
                                         // 새로운 객체의 Name 프로퍼티에 저장합니다.
                    Work = product.Title, // 새로운 객체의 Work 프로퍼티에 product.Title 값을 할당합니다.
                                          // 즉, arrProduct 배열에서 가져온 제품의 이름을,
                                          // 새로운 객체의 Work 프로퍼티에 저장합니다.
                    Height = profile.Height // 새로운 객체의 Height 프로퍼티에 profile.Height 값을 할당합니다.
                                            // 즉, arrProfile 배열에서 가져온 프로필의 키를, 
                                            // 새로운 객체의 Height 프로퍼티에 저장합니다.
                };

            Console.WriteLine("--- 내부 조인 결과 ---");
            foreach (var profile in listProfile) // 내부 조인 결과를 출력합니다. 
            {
                Console.WriteLine("이름:{0}, 작품:{1}, 키:{2}cm",
                    profile.Name, profile.Work, profile.Height);
            }


            // (4) 외부 조인 (Outer Join)
            listProfile =
                from profile in arrProfile // arrProfile 배열의 각 profile 요소와 
                join product in arrProduct on profile.Name equals product.Star into ps // arrProduct 배열의 각 product 요소를
                                                                                       // profile.Name 프로퍼티 값과 product.Star 프로퍼티 값이 같은 경우에
                                                                                       // 조인하고, 결과를 ps라는 그룹 변수에 저장합니다.
                from sub_product in ps.DefaultIfEmpty(new Product() { Title = "그런거 없음" }) // ps 그룹 변수에서 DefaultIfEmpty() 메서드를 사용하여
                                                                                          // 조인 결과가 없는 경우 (즉, 해당 배우가 출연한 작품이 없는 경우),
                                                                                          // "그런거 없음"이라는 제목을 가진 새로운 Product 객체를 생성합니다.
                select new // 조인된 결과에서 Name, Work, Height라는 세 개의 프로퍼티를 가진 익명 객체를 생성합니다.
                {
                    Name = profile.Name,
                    Work = sub_product.Title,
                    Height = profile.Height
                };


            Console.WriteLine();
            Console.WriteLine("--- 외부 조인 결과 ---");
            foreach (var profile in listProfile) // 외부 조인 결과를 출력합니다. 
            {
                Console.WriteLine("이름:{0}, 작품:{1}, 키:{2}cm",
                    profile.Name, profile.Work, profile.Height);
            }
        }
    }
}


/*
출력 결과

--- 내부 조인 결과 ---
이름:정우성, 작품:비트, 키:186cm
이름:김태희, 작품:CF 다수, 키:158cm
이름:김태희, 작품:아이리스, 키:158cm
이름:고현정, 작품:모래시계, 키:172cm
이름:이문세, 작품:Solo 예찬, 키:178cm

--- 외부 조인 결과 ---
이름:정우성, 작품:비트, 키:186cm
이름:김태희, 작품:CF 다수, 키:158cm
이름:김태희, 작품:아이리스, 키:158cm
이름:고현정, 작품:모래시계, 키:172cm
이름:이문세, 작품:Solo 예찬, 키:178cm
이름:하하, 작품:그런거 없음, 키:171cm

 */