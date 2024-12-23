using System;
using System.Collections;
using System.Collections.Generic;


/*
배경:
IEnumerable인터페이스를 상속해서 foreach를 사용할 수 있는 클래스를 만들 수 있음.
문제는 foreach 문을 통해 요소를 순회할 때마다 형식 변환을 수행해야 해서 성능 저하가 발생함.

결과:
IEnumerable<T> 인터페이스, IEnumerator<T> 인터페이스를 상속하면,
형식 변환으로 인한 성능 저하 없이 foreach 순회가 가능한 클래스를 작성할 수 있음.
 

IEnumerable<T> 인터페이스의 메소드?
(1) IEnumerator GetEnumerator(): IEnumerator 형식의 객체를 반환(IEnumerable로부터 상속받은 메소드임)
(2) IEnumerator<T> GetEnumerator(): IEnumerator<T> 형식의 객체를 반환(새로 선언)
 
IEnumerator<T> 인터페이스의 메소드와 프로퍼티?
(1) bloolean MoveNext()
(2) void Reset()
(3) Object Current{get;}: 컬렉션의 현재 요소를 반환(IEnumerator로부터 상속받은 프로퍼티임)
(4) T Current{get;}: 컬렉션의 현재 요소를 반환(새로 선언)
 */


// MyList<T>라는 클래스를 정의하고, 
// 이 클래스가 IEnumerable<T>와 IEnumerator<T> 인터페이스를 구현하여 
// foreach 문에서 사용할 수 있도록 하는 코드.
// (IEnumerable<T>과 IEnumerator<T> 인터페이스를 구현하여,
// 제네릭 클래스를 foreach 문에서 사용할 수 있도록 하는 방법을 보여줍니다.)
namespace EnumerableGeneric
{
    class MyList<T> : IEnumerable<T>, IEnumerator<T>
    {
        private T[] array; // T 타입의 배열을 저장할 array 필드를 선언
        int position = -1; // 현재 요소의 인덱스를 저장할 position 필드를 선언하고,
                           //  -1로 초기화합니다.
                           // position은 현재 배열 요소의 위치를 나타내는 필드입니다. 
                           // -1은 초기 상태를 의미합니다.
                           // 왜 0이 아니라 -1로 초기화 할까?
                           // MoveNext() 메서드를 보면, 처음 호출될 때 position 값을 1 증가시키고
                           // 배열의 0번째 요소부터 접근하게 됩니다.
                           // 만약 position을 0으로 초기화한다면, MoveNext() 메서드를 처음 호출했을 때
                           // position이 1이 되어 배열의 1번째 요소부터 접근하게 되버림.
                           // 따라서 배열의 0번째 요소부터 순회하기 위해 position을 -1로 초기화하는 것입니다. 


        public MyList() // MyList<T> 클래스의 생성자입니다. 
                        // 객체가 생성될 때 호출되며,
                        // array 필드를 초기 크기가 3인 배열로 초기화합니다.
        {
            array = new T[3];
        }


        public T this[int index] // 인덱서를 정의합니다. 
        {
            get // get 접근자는 array[index]를 통해, 인덱스에 해당하는 배열 요소를 반환하고, 
            {
                return array[index];
            }

            set // set 접근자는 array[index] = value를 통해, 인덱스에 해당하는 배열 요소에 값을 할당합니다.
            {
                if (index >= array.Length) // index가 배열의 크기를 벗어나면,
                {
                    Array.Resize<T>(ref array, index + 1); // 배열의 크기를 index + 1로 조정합니다.
                    Console.WriteLine($"Array Resized : {array.Length}");
                }

                array[index] = value;
            }
        }


        public int Length // array 필드의 길이를 반환하는 프로퍼티인 Length를 선언.
                          // MyList<T> 클래스에서 array 필드의 길이를 반환하는 프로퍼티를 선언하는 이유?
                          // MyList<T> 객체를 사용하는 외부 코드에서 
                          // 배열의 길이를 알 수 있도록 하기 위해서입니다.
                          // array 필드는 private 접근 제한자를 가지므로, 
                          // MyList<T> 클래스 외부에서는 직접 접근할 수 없습니다. 
                          // 따라서 Length 프로퍼티를 통해 array 필드의 길이를 간접적으로 제공하는 것입니다.
                          // Length 프로퍼티는 get 접근자만 가지고 있으므로 읽기 전용입니다. 
                          // 외부 코드에서 Length 프로퍼티를 통해 배열의 길이를 읽을 수는 있지만,
                          // 값을 변경할 수는 없습니다.
        {
            get { return array.Length; }
        }


        public IEnumerator<T> GetEnumerator() // IEnumerator<T> 인터페이스를 구현하는
                                              // GetEnumerator() 메서드를 정의합니다. 
                                              // 이 메서드는 현재 객체(this)를 반환합니다.
        {
            return this;
        }


        IEnumerator IEnumerable.GetEnumerator() // IEnumerable 인터페이스를 구현하는
                                                // GetEnumerator() 메서드를 정의합니다.
                                                // 이 메서드는 현재 객체(this)를 반환합니다.
        {
            return this;
        }


        public T Current // 현재 요소를 반환하는 프로퍼티입니다.
                         // IEnumerator<T> 인터페이스의 멤버입니다.
        {
            get { return array[position]; }
        }


        object IEnumerator.Current // 현재 요소를 반환하는 프로퍼티입니다.
                                   // IEnumerator 인터페이스의 멤버입니다.
        {
            get { return array[position]; }
        }


        public bool MoveNext() // 다음 요소로 이동하는 메서드입니다. 
                               // IEnumerator<T> 인터페이스의 멤버입니다.
        {
            if (position == array.Length - 1)
            {
                Reset();
                return false;
            }

            position++;
            return (position < array.Length);
        }


        public void Reset() // 인덱스를 초기화하는 메서드입니다. 
                            // IEnumerator<T> 인터페이스의 멤버입니다.
        {
            position = -1; ;
        }


        public void Dispose() // 리소스를 해제하는 메서드입니다.
                              // IEnumerator<T> 인터페이스의 멤버입니다.
        {

        }
    }


    class MainApp
    {
        static void Main(string[] args)
        {
            MyList<string> str_list = new MyList<string>(); // 문자열 타입의 MyList<string> 객체
                                                            // str_list를 생성합니다.
            str_list[0] = "abc"; // 인덱서를 사용하여 str_list 객체에 문자열 값을 할당합니다. 
                                 //  index가 배열 크기를 벗어나면 배열의 크기가 자동으로 조정됩니다.
            str_list[1] = "def";
            str_list[2] = "ghi";
            str_list[3] = "jkl";
            str_list[4] = "mno";

            foreach (string str in str_list) // foreach 문을 사용하여 str_list 객체의 모든 요소를 출력합니다.
                Console.WriteLine(str);

            Console.WriteLine();

            MyList<int> int_list = new MyList<int>(); // 정수 타입의 MyList<int> 객체
                                                      // int_list를 생성합니다.
            int_list[0] = 0; // 인덱서를 사용하여 int_list 객체에 정수 값을 할당합니다.
                             // 인덱스가 배열 크기를 벗어나면 배열의 크기가 자동으로 조정됩니다.
            int_list[1] = 1;
            int_list[2] = 2;
            int_list[3] = 3;
            int_list[4] = 4;

            foreach (int no in int_list) // foreach 문을 사용하여 int_list 객체의 모든 요소를 출력합니다.
                Console.WriteLine(no);
        }
    }
}


/*
출력 결과

Array Resized : 4
Array Resized : 5
abc
def
ghi
jkl
mno

Array Resized : 4
Array Resized : 5
0
1
2
3
4
*/