using System;

namespace TypeCasting
{
    class Mammal // 포유류를 나타내는 클래스입니다. Nurse() 메서드를 가지고 있습니다.
    {
        public void Nurse()
        {
            Console.WriteLine("Nurse()");
        }
    }

    class Dog : Mammal // Mammal 클래스를 상속받는 개를 나타내는 클래스입니다. Bark() 메서드를 가지고 있습니다.
    {
        public void Bark()
        {
            Console.WriteLine("Bark()");
        }
    }

    class Cat : Mammal // Mammal 클래스를 상속받는 고양이를 나타내는 클래스입니다. Meow() 메서드를 가지고 있습니다.
    {
        public void Meow()
        {
            Console.WriteLine("Meow()");
        }
    }


    class MainApp
    {
        static void Main(string[] args)
        {
            Mammal mammal = new Dog(); // Mammal 타입의 변수 mammal을 선언하고 Dog 객체를 할당합니다.
                                       // 이는 암시적 형변환입니다. 파생 클래스 객체를 기본 클래스 타입 변수에 할당할 수 있습니다.
            Dog dog;

            if (mammal is Dog) // mammal 변수가 Dog 타입인지 확인합니다. is 연산자는 객체가 특정 타입인지 확인하는 데 사용됩니다.
            {
                dog = (Dog)mammal; // mammal 변수를 Dog 타입으로 명시적 형변환합니다.
                                   // mammal 변수가 실제로 Dog 객체를 참조하고 있기 때문에 형변환이 가능합니다.
                dog.Bark(); // dog 변수를 사용하여 Bark() 메서드를 호출합니다.
            }

            Mammal mammal2 = new Cat(); // Mammal 타입의 변수 mammal2를 선언하고 Cat 객체를 할당합니다.

            Cat cat = mammal2 as Cat; // mammal2 변수를 Cat 타입으로 형변환하려고 시도합니다. 
                                      // as 연산자는 객체를 지정된 타입으로 형변환하는 데 사용됩니다.
                                      // 형변환이 가능하면 변환된 객체를 반환하고, 불가능하면 null을 반환합니다.
            if (cat != null) // cat 변수가 null이 아닌지 확인합니다. 즉, 형변환이 성공했는지 확인합니다.
                cat.Meow(); // cat 변수를 사용하여 Meow() 메서드를 호출합니다.

            Cat cat2 = mammal as Cat; // mammal 변수를 Cat 타입으로 형변환하려고 시도합니다. 
                                      // mammal 변수는 Dog 객체를 참조하고 있기 때문에 형변환이 실패하고 cat2 변수에는 null이 할당됩니다.
            if (cat2 != null) // cat2 변수가 null이 아닌지 확인합니다. 즉, 형변환이 성공했는지 확인합니다.
                cat2.Meow(); // cat2 변수가 null이 아니면 Meow() 메서드를 호출합니다.
            else // cat2 변수가 null이면 "cat2 is not a Cat"을 출력합니다.
                Console.WriteLine("cat2 is not a Cat");
        }
    }
}

/* 
 C#에서 형변환, is 연산자, as 연산자를 사용하는 방법을 보여줍니다. 
 is 연산자는 객체가 특정 타입인지 확인하는 데 사용되고, 
 as 연산자는 객체를 지정된 타입으로 형변환하는 데 사용됩니다. 
 형변환이 실패하면 as 연산자는 null을 반환합니다.
 */