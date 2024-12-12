using System;

namespace DeepCopy
{
    class MyClass
    {
        public int MyField1; 
        public int MyField2; 

        public MyClass DeepCopy()
        {
            MyClass newCopy = new MyClass(); // 클래스는 참조 형식이기 때문에
                                             // 깊은 복사를 위해서는 이처럼 코드를 만들어야 함.
                                             // 객체를 힙에 새로 할당해서 그곳에 자신의 멤버를 일일이 복사해 넣음.
            newCopy.MyField1 = this.MyField1;
            newCopy.MyField2 = this.MyField2;

            return newCopy;
        }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Shallow Copy");

            {
                MyClass source = new MyClass();  // source 인스턴스 생성
                source.MyField1 = 10;
                source.MyField2 = 20;

                MyClass target = source; // target 인스턴스 생성
                                         // 얕은 복사: 객체를 복사할 때 참조만 복사함
                target.MyField2 = 30;

                Console.WriteLine($"{source.MyField1} {source.MyField2}");
                Console.WriteLine($"{target.MyField1} {target.MyField2}");
            }

            Console.WriteLine("Deep Copy");

            {
                MyClass source = new MyClass();
                source.MyField1 = 10;
                source.MyField2 = 20;

                MyClass target = source.DeepCopy(); // 깊은 복사: 힙에 보관되어 있는 내용을 source로부터 복사해서,
                                                    // 별도의 힙 공간에 객체를 보관
                target.MyField1 = 30;
                target.MyField2 = 30;

                Console.WriteLine($"{source.MyField1} {source.MyField2}");
                Console.WriteLine($"{target.MyField1} {target.MyField2}");
            }
            
        }
    }
}

