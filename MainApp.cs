using System;
using System.Collections; // IEnumerable, IEnumerator 인터페이스를 사용하기 위해 필요합니다.


/*
IEnumerator 인터페이스의 메소드 및 프로퍼티?
(1) boolean MoveNext()
(2) void Reset()
(3) Object Current {get;}
 */


// MyList라는 클래스를 정의하고,
// 이 클래스가 IEnumerable과 IEnumerator 인터페이스를 구현함으로써,
// foreach 문에서 사용할 수 있도록 하는 방법을 보여줌.
namespace Enumerable
{

    class MyList : IEnumerable, IEnumerator // MyList 클래스를 정의하고, IEnumerable, IEnumerator 인터페이스를 구현합니다.
    {
        private int[] array; // 정수형 배열을 저장할 array 필드를 선언합니다.
        int position = -1; // 현재 요소의 인덱스를 저장할 position 필드를 선언하고,-1로 초기화합니다.
                           // 현재 배열 요소의 위치를 나타내는 필드입니다. 
                           // -1은 초기 상태를 의미합니다.
                           // 왜 0이 아니라 -1로 초기화 할까?
                           // MoveNext() 메서드를 보면, 처음 호출될 때 position 값을 1 증가시키고
                           // 배열의 0번째 요소부터 접근하게 됩니다.
                           // 만약 position을 0으로 초기화한다면, MoveNext() 메서드를 처음 호출했을 때
                           // position이 1이 되어 배열의 1번째 요소부터 접근하게 되버림.
                           // 따라서 배열의 0번째 요소부터 순회하기 위해 position을 -1로 초기화하는 것입니다.

        public MyList() // MyList 클래스의 생성자입니다.
                        // 객체가 생성될 때 호출되며, array 필드를 초기 크기가 3인 배열로 초기화합니다.
        {
            array = new int[3];
        }


        public int this[int index] // 인덱서를 정의합니다. 
        {
            get // get 접근자는 array[index]를 통해 인덱스에 해당하는 배열 요소를 반환하고, 
            {
                return array[index];
            }

            set // set 접근자는 array[index] = value를 통해 인덱스에 해당하는 배열 요소에 값을 할당합니다.
            {
                if (index >= array.Length) // index가 배열의 크기를 벗어나면 
                {
                    Array.Resize<int>(ref array, index + 1); // 배열의 크기를 index + 1로 조정합니다.
                    Console.WriteLine($"Array Resized : {array.Length}"); // 크기 조정 메시지 출력
                }

                array[index] = value; // 인덱스에 해당하는 배열 요소에 값 할당
            }
        }


        // IEnumerator 멤버
        public object Current // 컬렉션의 현재 요소를 반환하는 프로퍼티입니다. 
                              // IEnumerator 인터페이스의 멤버입니다.  
        {
            get
            {
                return array[position];
            }
        }


        // IEnumerator 멤버
        public bool MoveNext() // 다음 요소로 이동하는 메서드입니다.
                               // 컬렉션의 끝을 지난 경우에는 false,
                               // 이동이 성공한 경우에는 true를 반환합니다.
                               // IEnumerator 인터페이스의 멤버입니다.
                               // MoveNext() 메서드의 핵심은 다음 요소가 있는지 확인하고,
                               // 있다면 현재 위치를 다음 요소로 이동하는 것입니다. 
                               // 따라서 position 값을 증가시키는 것은
                               // 다음 요소로 이동하기 위한 하나의 방법일 뿐, 필수적인 것은 아닙니다.
                               // 중요한 것은 MoveNext() 메서드가 호출될 때마다 컬렉션의 다음 요소로 이동하여
                               // Current 프로퍼티가 다음 요소를 반환하도록 하는 것입니다.
        {
            if (position == array.Length - 1) // 마지막 요소에 도달하면
            {
                Reset(); // 인덱스 초기화
                return false; // false 반환
            }

            position++; // 인덱스 증가
            return (position < array.Length); // 다음 요소가 있으면 true 반환
        }


        // IEnumerator 멤버
        public void Reset() // 인덱스를 초기화하는 메서드입니다. 
                            // 컬렉션의 첫 번째 위치의 '앞'으로 이동합니다.
                            // 첫 번째 위치가 0번인 경우 Reset()을 호출하면 -1번으로 이동합니다.
                            // 첫 번째 위치로의 이동은 MoveNext()를 호출한 다음에 이루어집니다.
                            // IEnumerator 인터페이스의 멤버입니다.

        {
            position = -1; // 인덱스를 -1로 설정
        }


        // IEnumerable 멤버
        public IEnumerator GetEnumerator() // 반복기를 반환하는 메서드입니다. 
                                           // IEnumerable 인터페이스의 멤버입니다.
        {
            return this; // 현재 객체 반환
                         // MoveNext(), Reset() 메서드와 Current 프로퍼티를 구현하면 
                         // IEnumerator의 요구사항을 충족하므로, MyList는 IEnumerator가 됩니다.
                         // 따라서 IEnumerable이 요구하는 GetEnumerator() 메서드를 구현할 때는,
                         // 이처럼 그저 자기 자신(this)을 반환하기만 하면 되게 됩니다.
        }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            MyList list = new MyList(); // MyList 클래스의 객체 list를 생성합니다.
            for (int i = 0; i < 5; i++) // 첫 번째 for 문은 0부터 4까지 반복하며, 
                list[i] = i; // list[i] = i;를 통해 list 객체의 인덱서를 사용하여 값을 할당합니다.

            foreach (int e in list) // list 객체를 foreach 문에서 사용합니다.
                                    // list 객체는 IEnumerable 인터페이스를 구현했기 때문에,
                                    // foreach 문에서 사용할 수 있습니다!!
                Console.WriteLine(e);
        }
    }
}


/*
출력 결과

Array Resized : 4
Array Resized : 5
0
1
2
3
4
*/