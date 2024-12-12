using System;

namespace This
{
    class Employee
    {
        private string Name; // Employee 클래스의 필드 Name
        private string Position;

        public void SetName(string Name) // 매개변수 Name
        {
            this.Name = Name; // this.Name은 Employee 자신의 필드. Name은 메소드의 매개변수.
                              // 이처럼 this 키워드를 활용하면 모호성을 풀 수 있음.
                              // this 키워드: 객체 내부에서 자신의 필드나 메소드에 접근할 때 사용.
                              // (객체 외부에서 객체의 필드나 메소드에 접근할 때는 객체의 이름(변수)를 사용)
        }

        public string GetName()
        {
            return Name;
        }

        public void SetPosition(string Position)
        {
            this.Position = Position;
        }

        public string GetPosition()
        {
            return this.Position;
        }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            Employee pooh = new Employee();
            pooh.SetName("Pooh");
            pooh.SetPosition("Waiter");
            Console.WriteLine($"{pooh.GetName()} {pooh.GetPosition()}");

            Employee tigger = new Employee();
            tigger.SetName("Tigger");
            tigger.SetPosition("Cleaner");
            Console.WriteLine($"{tigger.GetName()} {tigger.GetPosition()}");
        }
    }
}
