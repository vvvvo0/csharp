using System;

namespace ThisConstructor
{
    class MyClass
    {
        int a, b, c; // int 형식의 필드 a, b, c

        public MyClass() // 생성자 MyClass() : 매개변수를 입력받아 필드를 원하는 값으로 초기화
        {
            this.a = 5425;
            Console.WriteLine("MyClass()");
        }

        public MyClass(int b) : this() // this()는 자기 자신의 생성자를 가리킴.
                                       // 생성자에서만 사용 가능. 얘처럼 생성자의 코드 블록 앞쪽에서만.
                                       // this()는 MyClass()를 호출함.
                                       // 이렇게 하는 이유는 a를 초기화 하려고 MyClass()를 호출해서 처리시킬 수 없는데, 
                                       // 왜냐하면 원래는 new 연산자 없이 생성자를 호출할 수는 없기 때문.
                                       // new 연산자를 쓰게 되면 해당 객체 외에 또 다른 객체를 만들어야 함.
                                       // 이럴때 this()를 쓰면 자기 자신의 생성자를 가리키니까 new 연산자 안쓰고 해결 가능.
        {
            this.b = b;
            Console.WriteLine($"MyClass({b})");
        }

        public MyClass(int b, int c) : this(b) // this(int)는 MyClass(int)를 호출함.
        {
            this.c = c;
            Console.WriteLine($"MyClass({b}. {c})");
        }

        public void PrintFields()
        {
            Console.WriteLine($"a:{a}, b:{b}, c:{c}");
        }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            MyClass a = new MyClass();
            a.PrintFields();
            Console.WriteLine();

            MyClass b = new MyClass(1);
            b.PrintFields();
            Console.WriteLine();

            MyClass c = new MyClass(10, 20);
            c.PrintFields();
        }
    }
}
