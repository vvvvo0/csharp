using System;
using static System.Runtime.InteropServices.JavaScript.JSType;


/*
일반화 클래스:
데이터 형식을 일반화한 클래스.
각 클래스가 데이터 형식만 빼고 다른 부분이 모두 같으면,
형식 매개변수(T)를 이용해서 일반화할 수 있음.
 */


namespace Generic
{
    class MyList<T> // 제네릭 클래스 MyList<T> 선언
    {
        private T[] array; // T 타입의 배열 array 필드 선언

        public MyList() // 생성자
        {
            array = new T[3]; // array 필드를 초기 크기가 3인 배열로 초기화합니다.
        }


        public T this[int index] // 인덱서 정의 
        {
            get
            {
                return array[index]; // 인덱스에 해당하는 배열 요소 반환
            }

            set
            {
                if (index >= array.Length) // 인덱스가 배열 크기를 벗어나면
                {
                    Array.Resize<T>(ref array, index + 1); // 배열 크기 조정
                    Console.WriteLine($"Array Resized : {array.Length}"); // 크기 조정 메시지 출력
                }

                array[index] = value; // 인덱스에 해당하는 배열 요소에 값 할당
            }
        }


        public int Length // 배열의 길이를 반환하는 프로퍼티
        {
            get { return array.Length; } // array의 길이를 반환
        }
    }


    class MainApp
    {
        static void Main(string[] args)
        {
            MyList<string> str_list = new MyList<string>(); // 문자열(sting) 타입의 MyList 객체 str_list를 생성합니다.
            str_list[0] = "abc"; // 인덱서를 사용하여 str_list 객체에 값 할당
            str_list[1] = "def";
            str_list[2] = "ghi";
            str_list[3] = "jkl"; // 배열 크기가 3보다 크므로 자동으로 크기 조정
            str_list[4] = "mno";

            for (int i = 0; i < str_list.Length; i++) // for 문을 사용하여 str_list 객체의 모든 요소를 출력합니다.
                Console.WriteLine(str_list[i]); // 문자열 배열 출력

            Console.WriteLine();

            MyList<int> int_list = new MyList<int>(); // 정수(int) 타입의 MyList 객체 int_list를 생성합니다.
            int_list[0] = 0; // 인덱서를 사용하여 int_list 객체에 값 할당
            int_list[1] = 1;
            int_list[2] = 2;
            int_list[3] = 3; // 배열 크기가 3보다 크므로 자동으로 크기 조정
            int_list[4] = 4;

            for (int i = 0; i < int_list.Length; i++) // for 문을 사용하여 int_list 객체의 모든 요소를 출력합니다.
                Console.WriteLine(int_list[i]); // 정수 배열 출력
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