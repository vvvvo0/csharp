using System;
using System.Collections.Generic;


/*
Dictionary<TKey, TValue>:
키-값 쌍을 저장하는 컬렉션입니다. 
각 요소는 키와 값으로 구성되며, 키를 사용하여 값에 접근할 수 있습니다.
<TKey>는 키의 형식을 나타내는 제네릭 타입 매개변수이고, 
<TValue>는 값의 형식을 나타내는 제네릭 타입 매개변수입니다. 
 */


// Dictionary<TKey, TValue> 컬렉션을 사용하여 키-값 쌍을 저장하고,
// 키를 사용하여 값에 접근하는 방법을 보여줌.
namespace UsingDictionary
{
    class MainApp
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>(); // string형 키와 string형 값을 저장하는
                                                                               // Dictionary<string, string> 컬렉션 dic를 생성합니다.

            dic["하나"] = "one"; // dic에 키 "하나"와, 값 "one"을 추가합니다.
            dic["둘"] = "two";
            dic["셋"] = "three";
            dic["넷"] = "four";
            dic["다섯"] = "five";

            Console.WriteLine(dic["하나"]); // dic에서 키 "하나"에 해당하는 값을 출력합니다.
            Console.WriteLine(dic["둘"]);
            Console.WriteLine(dic["셋"]);
            Console.WriteLine(dic["넷"]);
            Console.WriteLine(dic["다섯"]);
        }
    }
}


/*
출력 결과

one
two
three
four
five
*/