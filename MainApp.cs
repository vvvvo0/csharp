using System;
using System.Reflection;
using System.Reflection.Emit;


/*
리플렉션 이밋(Reflection Emit):
리플렉션을 이용하여 프로그램 실행 중에(=동적으로=런타임에) 새로운 형식을 만들어낼 수 있는 기능.
프로그램이 실행 중에 만들어낸 새 형식을 CLR의 메모리에 내보내는 것.
런타임에 IL(Intermediate Language) 코드를 생성하여, 새로운 어셈블리, 모듈, 타입, 메서드를 동적으로 생성하는 기능
 */

namespace EmitTest
{
    public class MainApp
    {
        public static void Main()
        {
            // (1) 에셈블리를 만듭니다.
            // AssemblyBuilder 클래스를 이용해야하지만, AssemblyBuilder는 스스로를 생성하는 생성자가 없습니다.
            // 따라서 다른 팩토리 클래스의 도움을 받아야 합니다.
            // DefineDynamicAssembly() 메서드를 호출하면 AssemblyBuilder의 인스턴스를 만들 수 있습니다.
            // "CalculatorAssembly"라는 이름의 동적 어셈블리를 생성합니다.
            AssemblyBuilder newAssembly =
                AssemblyBuilder.DefineDynamicAssembly( 
                    new AssemblyName("CalculatorAssembly"), AssemblyBuilderAccess.Run);


            // (2) 모듈을 만듭니다.
            // AssemblyBuilder는 동적 모듈을 생성하는 DefineDynamicModule() 메서드를 가지고 있으므로,
            // 이 메서드를 호출해서 모듈을 만들면 됩니다.
            // "Calculator"라는 이름의 모듈을 만듭니다.
            ModuleBuilder newModule = newAssembly.DefineDynamicModule("Calculator");

            // (3) 클래스를 만듭니다.
            // ModuleBuilder의 DefineType() 메서드를 이용해서 클래스를 생성합니다.
            // "SumTo100"이라는 이름의 클래스를 만듭니다.
            TypeBuilder newType = newModule.DefineType("Sum1To100");


            // (4) 메서드를 만듭니다.
            // TypeBuilder 클래스의 DefineMethod() 메서드를 호출해서,
            // "Calculate()" 라는 이름의 메서드를 만듭니다.
            // Calculate() 메서드의 접근성은 Public이며, 반환 형식은 int, 매개변수는 없습니다.
            MethodBuilder newMethod = newType.DefineMethod(
                "Calculate",
                MethodAttributes.Public,
                typeof(int),    // 반환 형식
                new Type[0]);   // 매개 변수


            // (5) 앞에서 생성한 것이 메서드이므로, 메서드가 실행할 코드(IL 명령어)를 채워 넣습니다.
            // 이 작업은 ILGenerator 객체를 통해 이루어집니다.
            // MethodBuilder 클래스의 GetILGenerator() 메서드를 통해 ILGenerator 객체를 얻을 수 있습니다.
            ILGenerator generator = newMethod.GetILGenerator();

            generator.Emit(OpCodes.Ldc_I4, 1); // 32비트 정수(1)를 계산 스택에 넣습니다.

            for (int i = 2; i <= 100; i++)
            {
                generator.Emit(OpCodes.Ldc_I4, i); // 32비트 정수(i)를 계산 스택에 넣습니다.
                generator.Emit(OpCodes.Add); // 계산 후 계산 스택에 담겨 있는 두 개의 값을 꺼내서 더한 후,
                                             // 그 결과를 다시 계산 스택에 넣습니다.
            }

            generator.Emit(OpCodes.Ret); // 계산 스택에 담겨 있는 값을 반환합니다.
            newType.CreateType();

            object sum1To100 = Activator.CreateInstance(newType);
            MethodInfo Calculate = sum1To100.GetType().GetMethod("Calculate");
            Console.WriteLine(Calculate.Invoke(sum1To100, null));
        }
    }
}


/*
출력 결과

5050
 */