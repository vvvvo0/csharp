using System;


/*
BirthdayInfo라는 클래스를 정의하고, 이 클래스의 객체를 생성하여 속성을 초기화하는 방법을 보여줍니다.
특히, 객체 초기화자를 사용하여 객체를 생성하면서 속성 값을 설정하는 방법을 보여줍니다.
 
 */


namespace ConstructorWithProperty
{

    // BirthdayInfo 클래스
    // Name, Birthday, Age 세 개의 속성을 가지고 있음
    class BirthdayInfo
    {

        public string Name // Name은 자동 구현 속성으로, 컴파일러가 자동으로 private 필드를 생성하고,
                           // get/set 접근자를 통해 필드에 접근

                            // 따라서 객체 초기화자에서 Name = "서현"과 같이 속성에 값을 할당하면, 컴파일러가 자동으로 생성한 private 필드에 값이 할당됩니다.
                            // 즉, 콜론(:)을 사용하지 않아도 속성 이름과 값을 구분할 수 있습니다.
        {
            get;
            set;
        }


        public DateTime Birthday // Bitthday는 자동 구현 속성으로, 컴파일러가 자동으로 private 필드를 생성하고,
                                 // get/set 접근자를 통해 필드에 접근
        {
            get;
            set;
        }


        public int Age // Age는 읽기 전용 속성으로,  get 접근자만 가지고 있으며,
                       // 현재 날짜와 Birthday 속성의 차이를 계산하여 나이를 반환
        {
            get
            {
                return new DateTime(DateTime.Now.Subtract(Birthday).Ticks).Year;
            }
        }
    }


    class MainApp
    {
        static void Main(string[] args)
        {
            BirthdayInfo birth = new BirthdayInfo() // BirthdayInfo 객체를 생성
                                                    // 객체 초기화자를 사용하여 Name 속성과 Birthday 속성을 초기화
            {
                Name = "서현", // 콤마로 구분, 초기화 하고 싶은 프로퍼티만 {} 안(객체 초기화자)에 넣어서 초기화 하면 됨.

                Birthday = new DateTime(1991, 6, 28) // 객체 초기화자는 중괄호 {} 안에 속성 이름과 값을 콜론(:)으로 구분하여 작성
                                                     // 단, Name과 Birthday 속성이 자동 구현 속성이므로 콜론으로 구분안하고
                                                     // 바로 =를 이용해 값을 할당 가능
            };


            // Console.WriteLine을 사용하여 Name, Birthday, Age 속성 값을 출력
            Console.WriteLine("Name : {0}", birth.Name); 
            Console.WriteLine("Birthday : {0}", birth.Birthday.ToShortDateString()); // birth.Birthday: birth 객체의 Birthday 속성 값을 가져옵니다. 이 값은 DateTime 객체임
                                                                                     // ToShortDateString(): DateTime 객체를 간단한 날짜 형식의 문자열로 변환합니다.
                                                                                     // (예: 2023-08-17)
                                                                                     // 즉, birth 객체의 Birthday 속성 값(DateTime 객체)을 간단한 날짜 형식의 문자열로 변환하여 출력
            Console.WriteLine("Age : {0}", birth.Age);
        }
    }
}
