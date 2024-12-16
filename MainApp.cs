using System;


/*
튜플: 여러 필드를 담을 수 있는 구조체. 
단, 형식 이름이 없음. -> 따라서 형식을 선언할 떄가 아닌 즉석에서 사용할 복합 데이터 형식을 선언할 때 적합!
구조체 -> 값 형식. 
 */


namespace Tuple
{
    class MainApp
    {
        static void Main(string[] args)
        {
            // 명명되지 않은 튜플
            var a = ("슈퍼맨", 9999); // 튜플은 var로 선언. 괄호 안에 두 개 이상의 필드를 지정함으로써 생성.
            Console.WriteLine($"{a.Item1}, {a.Item2}");

            // 명명된 튜플
            var b = (Name: "박상현", Age: 17); // '필드명:' 꼴로 필드 이름 지정하여 튜플 선언.
            Console.WriteLine($"{b.Name}, {b.Age}");

            // 분해
            var (name, age) = b; // (var name, var age) = b;
            Console.WriteLine($"{name}, {age}");

            // 분해2
            var (name2, age2) = ("박문수", 34); // 튜플 분해: 여러 변수를 단번에 생성하고 초기화 가능(튜플 만들자 마자 분해).
            Console.WriteLine($"{name2}, {age2}"); // 출력: 박문수, 34

            // 명명된 튜플 = 명명되지 않은 튜플
            b = a; // // 명명0 명명x 튜플 간에 필드의 수와 형식이 같으면 이렇게 할당이 가능함.
            Console.WriteLine($"{b.Name}, {b.Age}"); 

        }
    }
}
