using System;


/*
Attribute(애트리뷰트):
코드에 대한 부가 정보를 기록하고 읽을 수 있는 기능입니다.
애트리뷰트를 이용해서 클래스나 구조체, 메서드, 프로퍼티 등에 데이터를 기록해두면,
C# 컴파일러나 C#으로 작성된 프로그램이 이 정보를 읽고 사용할 수 있습니다.

Attribute vs 주석:
주석이 사람이 작성하고 사람이 읽는 정보라면,
애트리뷰트는 사람이 작성하고 컴퓨터가 읽는 정보다.

Metadate(메타데이터):
데이터의 데이터를 말합니다.
C# 코드도 데이터지만 이 코드에 대한 정보도 존재하는데, 이 정보를 메타데이터라고 합니다.
따라서 애트리뷰트나 리플렉션을 통해 얻는 정보들은 C# 코드의 메타데이터라고 할 수 있습니다.

Obsolete 애트리뷰트:
메서드, 클래스, 프로퍼티 등에 적용하여 해당 요소가 더 이상 사용되지 않거나, 
향후 버전에서 제거될 예정임을 나타냅니다.
.NET에서 기본적으로 제공하는 애트리뷰트입니다.

Obsolete 애트리뷰트의 용도:
더 이상 사용되지 않는 코드를 표시하여 개발자에게 알립니다.
향후 버전에서 제거될 예정인 코드를 표시하여 개발자가 미리 대비할 수 있도록 합니다.
Obsolete 애트리뷰트를 사용하면 코드의 가독성과 유지보수성을 높일 수 있습니다.
 */


// 애트리뷰트 사용하기
// Obsolete 애트리뷰트를 사용하여 메서드가 더 이상 사용되지 않음을 나타내는 방법.
// 프로그래머가 OldMethod()를 사용하는 코드를 그대로 둔 채 컴파일 하면,
// "OldMethod는 폐기되었습니다. NewMethod()를 이용하세요."라는 경고 메시지를 보게 됩니다.
// 컴파일 할 때 비주얼 스튜디오의 [오류 목록] 창을 확인하면 경고 메시지가 있는 것을 확인할 수 있습니다.
namespace BasicAttribute
{
    class MyClass
    {
        // 애트리뷰트를 사용할 떄는 설명하려는 코드 요소 앞에 대괄호 []를 붙이고,
        // 그 안에 애트리뷰트의 이름을 넣으면 됩니다.
        [Obsolete("OldMethod는 폐기되었습니다. NewMethod()를 이용하세요.")]
        public void OldMethod()
        {
            Console.WriteLine("I'm old");
        }

        public void NewMethod()
        {
            Console.WriteLine("I'm new");
        }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            MyClass obj = new MyClass();

            obj.OldMethod();
            obj.NewMethod();
        }
    }
}


/*
출력 결과

I'm old
I'm new
 */