﻿using System; //네임스페이스 전체를 사용한다. System.Console.WriteLine() -> Console.WriteLine()

namespace Hello //비슷한 것들끼리 하나의 이름 아래 묶음.
{
    class MainApp /* MainApp이라는 클래스(c#프로그램을 구성하는 기본단위)를 만듦.
                     클래스: 데이터와 데이터를 처리하는 기능(메소드)으로 구성됨.*/
    {
        //프로그램 실행이 시작되는 곳
        static void Main(string[] args) //Main() 메소드. c의 Main함수랑 비슷.
         //static은 한정자. 메소드나 변수 등을 수식.
         // static 키워드로 수식되는 코드는 프로그램이 처음 구동될 때부터 메모리에 할당된다. 
        {
            Console.WriteLine("Hello World!"); // 프롬프트에 출력


            //Object 형식
            int a = 123; // 숫자
            string b = a.ToString(); // 숫자를 문자열로 변환
            Console.WriteLine(b);

            float c = 3.14f;
            string d = c.ToString();
            Console.WriteLine(d);

            int e = int.Parse("12345"); // 문자를 숫자열로 변환
            float f = float.Parse("123.45"); 
            Console.WriteLine(e);
            Console.WriteLine(f);
        }
    }
}
