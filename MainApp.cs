using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Scripting; // 동적 언어 런타임(DLR)을 위한 네임스페이스
using Microsoft.Scripting.Hosting; // DLR 호스팅 API를 위한 네임스페이스
using IronPython.Hosting; // IronPython을 사용하기 위한 네임스페이스


/*
DLR(Dynamic Language Runtime):
CLR 위에서 동작하며, 파이썬이나 루비 같은 동적 언어를 .NET 플랫폼에서 실행할 수 있습니다.
파이썬이나 루비 같은 동적 언어의 코드에서 만들어진 객체에,
C#이나 VB 같은 정적 언어의 코드에서 접근할 수 있게 해줍니다.
(즉, C# 코드에서 직접 파이썬이나 루비 코드를 실행하고 결과를 받아볼 수 있습니다.)
DLR API를 기반으로 구현된 동적 언어라도 호스팅(Hosting) 할 수 있습니다.
(즉, 파이썬을 쭉 사용하다가 파이썬에는 없는 라이브러리가 루비에 있는 경우,
바로 루비 라이브러리를 이용하는 코드를 호스팅할 수 있습니다.)


dynamic 형식:
COM과 .NET의 상호 운영성 문제에 사용했던 dynamic을, 
CLR과 DLR 사이의 상호 운용성 문제를 해결하는 데 사용할 수 있습니다.
왜냐하면 미리 형식 검사를 할 수 없는 동적 형식 언어에서 만들어진 객체를,
C#의 dynamic 형식이 받아낼 수 있기 때문입니다.


DLR 나온 배경:
CLR(Common Language Runtime)은 IL(Intermediate Language)로 컴파일할 수 있는 언어들은 지원하지만,
동적 언어(Python, Ruby처럼 실행할 때 코드를 해석해서 실행하는 방식의 언어)는 지원할 수 없었습니다.
그래서 마이크로소프트는 동적 언어를 실행할 수 있도록 하는 플랫폼인 DLR(Dynamic Language Runtime)을 선보였습니다.


DLR이 제공하는 클래스들:
(1) ScriptRuntime
(2) ScriptScope
(3) ScriptEngine
(4) ScriptSource
(5) CompiledCode
 */


// IronPython 엔진(별도로 설치해야 함)을 사용하여 Python 코드를 C#에서 실행
namespace WithPython
{
    class MainApp
    {
        static void Main(string[] args)
        {
            ScriptEngine engine = Python.CreateEngine(); // IronPython 엔진 생성
            ScriptScope scope = engine.CreateScope(); // Python 코드 실행을 위한 스코프 생성
            scope.SetVariable("n", "박상현"); // 스코프에 변수 n을 "박상현"으로 설정
            scope.SetVariable("p", "010-123-4566"); // 스코프에 변수 p를 "010-123-4566"으로 설정

            ScriptSource source = engine.CreateScriptSourceFromString( // Python 코드를 문자열로부터 생성
                @"
class NameCard : // NameCard 클래스 정의
    name = '' // name 필드 초기화
    phone = '' // phone 필드 초기화

    def __init__(self, name, phone) :  // 생성자
        self.name = name  // name 필드에 매개변수 name 값 할당
        self.phone = phone // phone 필드에 매개변수 phone 값 할당

    def printNameCard(self) : // 이름과 전화번호를 출력하는 메서드
        print self.name + ', ' + self.phone  // name과 phone 필드 값 출력

NameCard(n, p) // NameCard 객체 생성
");
            dynamic result = source.Execute(scope); // Python 코드 실행하고,
                                                    // 결과를 result 변수에 저장합니다.
                                                    // dynamic 키워드는 런타임에 타입 검사를 수행합니다.
            result.printNameCard(); // result 객체의 printNameCard 메서드 호출

            Console.WriteLine("{0}, {1}", result.name, result.phone); // result 객체의 name과 phone 필드 값 출력
        }
    }
}


/*
출력 결과

박상현, 010-123-4566
박상현, 010-123-4566
 */