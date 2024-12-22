using System;


/*
형식 매개변수(Type Parameter)의 조건에 제약 걸기
: 일반화 메소드나 일반화 클래스가 입력받는 형식 매개변수 T는 '모든' 데이터 형식을 대신할 수 있다. 
하지만 특정 조건을 갖춘 형식에만 대응하는 형식 매개변수가 필요할 때가 있다.
이럴 때 형식 매개변수의 조건에 제약을 걸 수 있다.


제약 조건의 종류?
(1) where T : struct: 값 형식(struct) 제약 조건
(2) where T : class: 참조 형식(class) 제약 조건
(3) where T : new(): 매개변수 없는 생성자 제약 조건
(4) where T : Base: 기본 클래스 제약 조건
(5) where T : U: 타입 매개변수 제약 조건

-> 제약 조건을 사용하면, 제네릭 타입 매개변수에 대한 제약을 설정하여 
   타입 안전성을 확보하고 코드의 유연성을 높일 수 있습니다.
 */


// 제네릭 타입 매개변수에 제약 조건을 설정하는 방법을 보여줍니다.
// 제네릭은 타입을 매개변수로 사용하여 코드를 재사용할 수 있도록 하는 기능입니다. 
// 제약 조건은 제네릭 타입 매개변수에 대해 특정 조건을 지정하여
// 타입 안전성을 확보하고 코드의 유연성을 높입니다.
namespace ConstraintsOnTypeParameters
{
    class StructArray<T> where T : struct // 값 형식(struct)만 허용하는 제네릭 클래스 StructArray<T> 입니다.
                                          // T는 값 형식이어야 합니다.
    {
        public T[] Array { get; set; } // T 타입의 배열을 저장하는 프로퍼티입니다.
        public StructArray(int size) // 생성자로,
        {
            Array = new T[size]; // size 크기의 T 타입 배열을 생성하여 Array 필드에 할당합니다.
        }
    }


    class RefArray<T> where T : class // 참조 형식(class)만 허용하는 제네릭 클래스 RefArray<T> 입니다.
                                      // T는 참조 형식이어야 합니다.
    {
        public T[] Array { get; set; } // T 타입의 배열을 저장하는 프로퍼티입니다.
        public RefArray(int size) // 생성자로, 
        {
            Array = new T[size]; // size 크기의 T 타입 배열을 생성합니다.
        }
    }

    class Base { }
    class Derived : Base { }
    class BaseArray<U> where U : Base // 제네릭 클래스 BaseArray<U>는 
                                      // U 타입 매개변수가 Base 클래스 또는 Base 클래스에서 파생된 클래스여야 함
    {
        public U[] Array { get; set; } // U 타입의 배열을 저장하는 프로퍼티입니다.
        public BaseArray(int size) // 생성자로, 
        {
            Array = new U[size]; // size 크기의 U 타입 배열을 생성합니다.
        }

        public void CopyyArray<T>(T[] Target) where T : U // Target 배열의 요소를 Array 배열에 복사하는 제네릭 메서드입니다. 
                                                          // where T : U 제약 조건을 사용하여, 
                                                          // T 타입 매개변수가 U 타입 매개변수와 같거나 
                                                          // U 타입 매개변수에서 파생된 타입이어야 함을 지정합니다.

        {
            Target.CopyTo(Array, 0);
        }
    }

    class MainApp
    {
        public static T CreateInstance<T>() where T : new() // T 타입의 객체를 생성하여 반환하는 메서드입니다. 
                                                            // where T : new() 제약 조건을 사용하여,
                                                            // T 타입 매개변수가 매개변수 없는 생성자를 가져야 함을 지정합니다.
        {
            return new T();
        }


        static void Main(string[] args)
        {
            
            StructArray<int> a = new StructArray<int>(3); 
            // int 타입의 StructArray 객체를 생성합니다.
            a.Array[0] = 0;
            a.Array[1] = 1;
            a.Array[2] = 2;


            RefArray<StructArray<double>> b = new RefArray<StructArray<double>>(3);
            // StructArray<double> 타입의 RefArray 객체를 생성합니다.
            b.Array[0] = new StructArray<double>(5);
            b.Array[1] = new StructArray<double>(10);
            b.Array[2] = new StructArray<double>(1005);


            BaseArray<Base> c = new BaseArray<Base>(3);
            // Base 타입의 BaseArray 객체를 생성합니다.
            c.Array[0] = new Base();
            c.Array[1] = new Derived();
            c.Array[2] = CreateInstance<Base>();


            BaseArray<Derived> d = new BaseArray<Derived>(3);
            // Derived 타입의 BaseArray 객체를 생성합니다.
            d.Array[0] = new Derived(); // Base 형식은 여기에 할당 할 수 없다.
            d.Array[1] = CreateInstance<Derived>();
            d.Array[2] = CreateInstance<Derived>();

            BaseArray<Derived> e = new BaseArray<Derived>(3);
            // Derived 타입의 BaseArray 객체를 생성합니다.
            e.CopyyArray<Derived>(d.Array); // 각 배열에 값을 할당하고,
                                            // CopyyArray() 메서드를 사용하여 배열을 복사합니다.
        }
    }
}
