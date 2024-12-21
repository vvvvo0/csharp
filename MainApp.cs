using System;
using System.Collections; // ArrayList, Hashtable, Queue, Stack 등과 같은 제네릭이 아닌 컬렉션을 사용할 때 필요합니다. 
                          // 다만, 최근에는 제네릭 컬렉션(List<T>, Dictionary<TKey, TValue> 등)을 사용하는 것이 더 일반적입니다. 
                          // 제네릭 컬렉션은 타입 안전성을 제공하고 성능이 더 좋기 때문입니다.
                          // 제네릭 컬렉션을 사용하려면 using System.Collections.Generic;을 사용해야 합니다.

using static System.Console; // Console 클래스의 정적 멤버들을 클래스 이름 없이 바로 사용할 수 있습니다. 
                             // 예를 들어, Console.WriteLine("Hello, world!"); 대신,
                             // WriteLine("Hello, world!");처럼 사용할 수 있습니다.


/*
Hashtable:
키-값 쌍을 저장하는 컬렉션입니다.
각 요소는 키와 값으로 구성되며, 키를 사용하여 값에 접근할 수 있습니다.
따라서 키와 값의 쌍으로 이루어진 데이터를 다룰 때 사용합니다.
(예를 들어, 사전을 보면 "book"을 키로, "책"을 값으로 입력하는 식입니다.)

장점?
int 형식, float 형식, 직접 만든 클래스 등도 키로 사용할 수 있음.
배열에서 인덱스를 이용해 배열 요소에 접근하는 것에 준하는 탐색 속도.
(ArrayList에서는 원하는 데이터를 찾으려면 컬렉션을 정렬해 이진 탐색을 수행하거나 순차적으로 리스트를 탐색하지만,
Hashtable은 키를 이용해서 단번에 데이터가 저장된 컬렉션 내의 주소를 찾아냄.)



키 데이터를 그대로 인덱스로 사용함.
<-> 배열: 데이터를 저장할 요소의 위치를 인덱스로 사용함.
 */


// Hashtable을 사용하는 방법
namespace UsingHashtable
{
    class MainApp
    {
        static void Main(string[] args)
        {
            Hashtable ht = new Hashtable(); // Hashtable 클래스의 인스턴스를 생성합니다.
            ht["하나"] = "one"; // ht에 키 "하나"와 값 "one"을 추가합니다.
            ht["둘"] = "two";
            ht["셋"] = "three";
            ht["넷"] = "four";
            ht["다섯"] = "five";

            WriteLine(ht["하나"]); // ht에서 키 "하나"에 해당하는 값을 출력합니다.
            WriteLine(ht["둘"]);
            WriteLine(ht["셋"]);
            WriteLine(ht["넷"]);
            WriteLine(ht["다섯"]);
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