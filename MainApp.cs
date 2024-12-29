using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;


/*
Reflection 기능:
프로그램 실행 중(런타임)에 객체의 타입 정보를 조사하고 활용할 수 있게 해주는 기능입니다.
프로그램 실행 중에 객체의 형식 이름부터 프로퍼티 목록, 메서드 목록, 필드, 이벤트 목록을 열어볼 수 있습니다.
'형식의 이름'만 있다면 동적으로 인스턴스를 만들 수 있고, 그 인스턴스의 메서드를 호출할 수도 있습니다.
새로운 데이터 형식을 동적으로 만들수도 있습니다.


Reflection을 이용하여 객체의 형식 정보를 들여다 보는 방법:
Object.GetType() 메서드, Type 클래스

Object 형식은 모든 데이터 형식의 조상임. 
이 Object 형식이 갖고 있는 메서드는여러 가지인데, 
그 중에 GetType() 메서드를 만들어 놓아 
어떤 객체에 대해서든 이 메서드를 호출해서 그 객체의 형식 정보를 들여다 볼 수 있습니다.
GetType() 메서드는 Type 형식의 결과를 반환합니다.

Type 형식:
.NET에서 사용하는 데이터 형식의 모든 정보를 담고 있습니다.
Type 형식의 메서드를 이용하면 다른 정보들을 뽑아낼 수 있습니다.
(형식 이름, 소속된 어셈블리 이름, 프로퍼티 목록, 
메서드 목록, 이벤트 목록, 이 형식이 상속하는 인터페이스 목록 등)
 */


// C#의 Reflection 기능을 사용하여 int 타입의 정보를 가져와서 출력
namespace GetType
{
    class MainApp
    {
        static void PrintInterfaces(Type type) // PrintInterfaces() 메서드: Type 객체를 입력으로 받아
                                               // 해당 타입이 구현하는 인터페이스 목록을 출력합니다.
        {
            Console.WriteLine("-------- Interfaces -------- ");

            Type[] interfaces = type.GetInterfaces(); // type 객체의 GetInterfaces() 메서드를 호출하여,
                                                      // 해당 타입이 구현하는 인터페이스 목록을 Type 배열로 가져옵니다.

            foreach (Type i in interfaces) // interfaces 배열의 각 요소를 순회하며 인터페이스의 이름을 출력합니다.
                Console.WriteLine("Name:{0}", i.Name);

            Console.WriteLine();
        }


        static void PrintFields(Type type) // PrintFields() 메서드: Type 객체를 입력으로 받아
                                           // 해당 타입의 필드 목록을 출력합니다.
        {
            Console.WriteLine("-------- Fields -------- ");

            FieldInfo[] fields = type.GetFields( 
                BindingFlags.NonPublic |
                BindingFlags.Public |
                BindingFlags.Static |
                BindingFlags.Instance); // type 객체의 GetFields() 메서드를 호출하여,
                                        // 해당 타입의 필드 목록을 FieldInfo 배열로 가져옵니다.
                                        // BindingFlags는 필드의 접근성을 지정하는 데 사용됩니다.
                                        // BindingFlags 열거형:
                                        // GetFields()나 GetMethods() 같은 메소드의 검색 옵션을 지정.
                                        // 예를 들어, public 항목만 조회하는 등이 가능.

            foreach (FieldInfo field in fields) // fields 배열의 각 요소를 순회하며
                                                // 필드의 접근 수준, 타입, 이름을 출력합니다.
            {
                String accessLevel = "protected";
                if (field.IsPublic) accessLevel = "public";
                else if (field.IsPrivate) accessLevel = "private";

                Console.WriteLine("Access:{0}, Type:{1}, Name:{2}",
                    accessLevel, field.FieldType.Name, field.Name);
            }

            Console.WriteLine();
        }

        static void PrintMethods(Type type) // PrintMethods() 메서드: Type 객체를 입력으로 받아
                                            // 해당 타입의 메서드 목록을 출력합니다.
        {
            Console.WriteLine("-------- Methods -------- ");

            MethodInfo[] methods = type.GetMethods(); // type 객체의 GetMethods() 메서드를 호출하여
                                                      // 해당 타입의 메서드 목록을 MethodInfo 배열로 가져옵니다.

            foreach (MethodInfo method in methods) // methods 배열의 각 요소를 순회하며
                                                   // 메서드의 반환 타입, 이름, 매개변수 목록을 출력합니다.
            {
                Console.Write("Type:{0}, Name:{1}, Parameter:",
                    method.ReturnType.Name, method.Name);

                ParameterInfo[] args = method.GetParameters();
                for (int i = 0; i < args.Length; i++)
                {
                    Console.Write("{0}", args[i].ParameterType.Name);
                    if (i < args.Length - 1)
                        Console.Write(", ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void PrintProperties(Type type) // PrintProperties() 메서드: Type 객체를 입력으로 받아
                                               // 해당 타입의 프로퍼티 목록을 출력합니다.
        {
            Console.WriteLine("-------- Properties -------- ");

            PropertyInfo[] properties = type.GetProperties(); // type 객체의 GetProperties() 메서드를 호출하여
                                                              // 해당 타입의 프로퍼티 목록을 PropertyInfo 배열로 가져옵니다.
            foreach (PropertyInfo property in properties) // properties 배열의 각 요소를 순회하며
                                                          // 프로퍼티의 타입과 이름을 출력합니다.
                Console.WriteLine("Type:{0}, Name:{1}",
                    property.PropertyType.Name, property.Name);

            Console.WriteLine();
        }


        static void Main(string[] args)
        {
            int a = 0; // 정수형 변수 a를 선언하고 0으로 초기화합니다.
            Type type = a.GetType(); // a 변수의 GetType() 메서드를 호출하여, int 타입을 나타내는 Type 객체를 가져옵니다.

            // 각 메서드를 호출하여, int 타입의 인터페이스, 필드, 프로퍼티, 메서드 정보를 출력합니다.
            PrintInterfaces(type); 
            PrintFields(type);
            PrintProperties(type);
            PrintMethods(type);
        }
    }
}


/*
출력 결과

-------- Interfaces --------
Name:IComparable
Name:IConvertible
Name:ISpanFormattable
Name:IFormattable
Name:IComparable`1
Name:IEquatable`1
Name:IBinaryInteger`1
Name:IBinaryNumber`1
Name:IBitwiseOperators`3
Name:INumber`1
Name:IComparisonOperators`3
Name:IEqualityOperators`3
Name:IModulusOperators`3
Name:INumberBase`1
Name:IAdditionOperators`3
Name:IAdditiveIdentity`2
Name:IDecrementOperators`1
Name:IDivisionOperators`3
Name:IIncrementOperators`1
Name:IMultiplicativeIdentity`2
Name:IMultiplyOperators`3
Name:ISpanParsable`1
Name:IParsable`1
Name:ISubtractionOperators`3
Name:IUnaryPlusOperators`2
Name:IUnaryNegationOperators`2
Name:IUtf8SpanFormattable
Name:IUtf8SpanParsable`1
Name:IShiftOperators`3
Name:IMinMaxValue`1
Name:ISignedNumber`1
Name:IBinaryIntegerParseAndFormatInfo`1

-------- Fields --------
Access:private, Type:Int32, Name:m_value
Access:public, Type:Int32, Name:MaxValue
Access:public, Type:Int32, Name:MinValue

-------- Properties --------

-------- Methods --------
Type:Int64, Name:BigMul, Parameter:Int32, Int32
Type:Int32, Name:CompareTo, Parameter:Object
Type:Int32, Name:CompareTo, Parameter:Int32
Type:Boolean, Name:Equals, Parameter:Object
Type:Boolean, Name:Equals, Parameter:Int32
Type:Int32, Name:GetHashCode, Parameter:
Type:String, Name:ToString, Parameter:
Type:String, Name:ToString, Parameter:String
Type:String, Name:ToString, Parameter:IFormatProvider
Type:String, Name:ToString, Parameter:String, IFormatProvider
Type:Boolean, Name:TryFormat, Parameter:Span`1, Int32&, ReadOnlySpan`1, IFormatProvider
Type:Boolean, Name:TryFormat, Parameter:Span`1, Int32&, ReadOnlySpan`1, IFormatProvider
Type:Int32, Name:Parse, Parameter:String
Type:Int32, Name:Parse, Parameter:String, NumberStyles
Type:Int32, Name:Parse, Parameter:String, IFormatProvider
Type:Int32, Name:Parse, Parameter:String, NumberStyles, IFormatProvider
Type:Int32, Name:Parse, Parameter:ReadOnlySpan`1, NumberStyles, IFormatProvider
Type:Boolean, Name:TryParse, Parameter:String, Int32&
Type:Boolean, Name:TryParse, Parameter:ReadOnlySpan`1, Int32&
Type:Boolean, Name:TryParse, Parameter:ReadOnlySpan`1, Int32&
Type:Boolean, Name:TryParse, Parameter:String, NumberStyles, IFormatProvider, Int32&
Type:Boolean, Name:TryParse, Parameter:ReadOnlySpan`1, NumberStyles, IFormatProvider, Int32&
Type:TypeCode, Name:GetTypeCode, Parameter:
Type:ValueTuple`2, Name:DivRem, Parameter:Int32, Int32
Type:Int32, Name:LeadingZeroCount, Parameter:Int32
Type:Int32, Name:PopCount, Parameter:Int32
Type:Int32, Name:RotateLeft, Parameter:Int32, Int32
Type:Int32, Name:RotateRight, Parameter:Int32, Int32
Type:Int32, Name:TrailingZeroCount, Parameter:Int32
Type:Boolean, Name:IsPow2, Parameter:Int32
Type:Int32, Name:Log2, Parameter:Int32
Type:Int32, Name:Clamp, Parameter:Int32, Int32, Int32
Type:Int32, Name:CopySign, Parameter:Int32, Int32
Type:Int32, Name:Max, Parameter:Int32, Int32
Type:Int32, Name:Min, Parameter:Int32, Int32
Type:Int32, Name:Sign, Parameter:Int32
Type:Int32, Name:Abs, Parameter:Int32
Type:Int32, Name:CreateChecked, Parameter:TOther
Type:Int32, Name:CreateSaturating, Parameter:TOther
Type:Int32, Name:CreateTruncating, Parameter:TOther
Type:Boolean, Name:IsEvenInteger, Parameter:Int32
Type:Boolean, Name:IsNegative, Parameter:Int32
Type:Boolean, Name:IsOddInteger, Parameter:Int32
Type:Boolean, Name:IsPositive, Parameter:Int32
Type:Int32, Name:MaxMagnitude, Parameter:Int32, Int32
Type:Int32, Name:MinMagnitude, Parameter:Int32, Int32
Type:Boolean, Name:TryParse, Parameter:String, IFormatProvider, Int32&
Type:Int32, Name:Parse, Parameter:ReadOnlySpan`1, IFormatProvider
Type:Boolean, Name:TryParse, Parameter:ReadOnlySpan`1, IFormatProvider, Int32&
Type:Int32, Name:Parse, Parameter:ReadOnlySpan`1, NumberStyles, IFormatProvider
Type:Boolean, Name:TryParse, Parameter:ReadOnlySpan`1, NumberStyles, IFormatProvider, Int32&
Type:Int32, Name:Parse, Parameter:ReadOnlySpan`1, IFormatProvider
Type:Boolean, Name:TryParse, Parameter:ReadOnlySpan`1, IFormatProvider, Int32&
Type:Type, Name:GetType, Parameter:
 */