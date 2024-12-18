using System;


/*
프로퍼티: Get/Set 메소드를 대체함

 */

namespace Property
{
    class BirthdayInfo
    {
        private string name; // 이름을 저장하는 private 필드
        private DateTime birthday; // 생일을 저장하는 private 필드

        public string Name // name 필드에 접근하기 위한 public 속성
        {
            get // get 접근자: name 필드의 값을 읽어옴
            {
                return name;
            }
            set // set 접근자: name 필드에 값을 할당함
            {
                name = value;
            }
        }

        public DateTime Birthday // birthday 필드에 접근하기 위한 public 속성
        {
            get
            {
                return birthday; // birthday 필드의 값을 반환
            }
            set
            {
                birthday = value; // birthday 필드에 value 값을 할당
            }
        }

        public int Age // 나이를 계산하여 반환하는 public 속성
        {
            get
            {
                return new DateTime(DateTime.Now.Subtract(birthday).Ticks).Year; // 현재 날짜와 birthday 필드의 차이를 계산하여 나이를 반환
            }
        }
    }
        }

    }

    class MainApp
    {
        static void Main(string[] args)
        {
            BirthdayInfo birth = new BirthdayInfo(); // BirthdayInfo 클래스의 객체 birth 생성
            birth.Name = "서현"; // / Name 속성을 사용하여 이름 설정
            birth.Birthday = new DateTime(1991, 6, 28); // Birthday 속성을 사용하여 생일 설정

            Console.WriteLine("Name : {0}", birth.Name); // Name 속성 값 출력
        Console.WriteLine("Birthday : {0}", birth.Birthday.ToShortDateString()); // Birthday 속성 값 출력
        Console.WriteLine("Age : {0}", birth.Age); // Age 속성 값 출력
    }
    }
}
