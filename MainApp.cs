using System;
using System.Xml.Linq;


/*
자동 구현 프로퍼티
 
 */

namespace AutoImplementedProperty
{
    class BirthdayInfo
    {
        public string Name { get; set; } = "Unknown";  // 자동 구현 속성, 기본값 "Unknown"
        public DateTime Birthday { get; set; } = new DateTime(1, 1, 1); // 자동 구현 속성, 기본값 1년 1월 1일
        public int Age
        {
            get
            {
                return new DateTime(DateTime.Now.Subtract(Birthday).Ticks).Year; // 현재 날짜와 Birthday의 차이를 계산하여 나이 반환
            }
        }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            BirthdayInfo birth = new BirthdayInfo();// BirthdayInfo 객체 생성
            Console.WriteLine($"Name : {birth.Name}"); // Name 속성 출력("Unknown")
            Console.WriteLine($"Birthday : {birth.Birthday.ToShortDateString()}"); // Birthday 속성 출력 (1/1/1)
            Console.WriteLine($"Age : {birth.Age}"); // Age 속성 출력 (현재 연도 - 1)

            birth.Name = "서현"; // Name 속성에 "서현" 할당
            birth.Birthday = new DateTime(1991, 6, 28); // Birthday 속성에 1991년 6월 28일 할당


            Console.WriteLine($"Name : {birth.Name}"); // Name 속성 출력("서현")
            Console.WriteLine($"Birthday : {birth.Birthday.ToShortDateString()}"); // Birthday 속성 출력 (1991-06-28)
            Console.WriteLine($"Age : {birth.Age}"); // Age 속성 출력 (현재 연도 - 1991)
        }
    }
}
