using System;

class Global
{
    public static int Count = 0; // static으로 수식한 필드는 프로그램 전체에 걸쳐 하나만 존재.
                                 // 따라서 프로그램 전체에 걸쳐 공유해야 한느 변수는 정적 필드 이용이 적절.
}

class ClassA
{
    public ClassA()
    {
        Global.Count++; // 다른 클래스인 ClassA에서 Global 클래스의 정적 필드에 접근함.
    }
}

class ClassB
{
    public ClassB()
    {
        Global.Count++; // 다른 클래스인 ClassB에서 Global 클래스의 정적 필드에 접근함.
    }
}

class MainApp
{
    static void Main()
    {
        Console.WriteLine($"Global.Count : {Global.Count}");

        new ClassA();
        new ClassA();
        new ClassB();
        new ClassB();

        Console.WriteLine($"Global.Count : {Global.Count}");
    }
}
