using System;


/*
requierd: 
required 키워드는 객체를 생성할 때 해당 프로퍼티(속성)를 반드시 초기화해야 함을 나타냄.
초기화가 필요한 프로퍼티(속성)를 실수로 초기화하지 않는 실수 방지해 줌.
컴파일러는 required 속성이 초기화되지 않은 경우 오류를 발생시키므로, 객체 생성 시 필수 속성을 초기화하도록 강제.
(<-> init 접근자: 프로퍼티를 객체 초기화 시에만 값을 할당할 수 있게 함.)
 */


namespace RequiredProperty
{
    class BirthdayInfo // BirthdayInfo 클래스는 Name, Birthday, Age 세 개의 속성을 가지고 있음
    {

        public required string Name { get; set; } // Name: required 키워드를 사용하여 초기화가 필수적인 문자열(string) 프로퍼티(속성)임,
                                                  // set 접근자를 통해 값을 변경할 수 있음.

        public required DateTime Birthday { get; init; } // Birthday: required 키워드와 init 접근자를 사용하여 초기화가 필수적인 DateTime 프로퍼티(속성)임,
                                                         // init 접근자를 사용하여 객체 생성 시에만 값을 할당할 수 있습니다.


        public int Age // Age: Age는 get 접근자만 가지고 있기 때문에 읽기 전용 프로퍼티로, 현재 날짜와 Birthday 프로퍼티의 차이를 계산하여 나이를 반환합니다.
        {

            get
            {
                return new DateTime(DateTime.Now.Subtract(Birthday).Ticks).Year; // Subtract() 메서드는 DateTime 구조체에서 제공하는 기본 메서드.
                                                                                 // DateTime 구조체는 날짜와 시간 정보를 나타내는 데 사용되며, 
                                                                                 // Subtract() 메서드는 두 날짜 사이의 차이를 계산하는 데 사용됩니다.
                                                                                 // 
            }
        }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            BirthdayInfo birth = new BirthdayInfo { Name = "서현", Birthday = new DateTime(1991, 6, 28) }; // BirthdayInfo 객체를 생성.
                                                                                                         // 객체 초기화자를 사용하여 Name 속성과 Birthday 속성을 초기화
                                                                                                         // required 키워드가 붙은 속성은 반드시 초기화해야 하므로,
                                                                                                         // 객체 초기화자에서 Name과 Birthday 속성에 반드시 값을 할당해야 함
                                                                                                         // 만약 Name 또는 Birthday 속성에 값을 할당하지 않으면 컴파일 오류가 발생해서 알려줌.

            Console.WriteLine("Name : {0}", birth.Name);
            Console.WriteLine("Birthday : {0}", birth.Birthday.ToShortDateString());
            Console.WriteLine("Age : {0}", birth.Age);
        }
    }
}
