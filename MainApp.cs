using System;


/*
구조체: 
값 형식 
-> 따라서 상속 불가능
-> 할당 연산자 =를 통해 모든 필드가 그대로 복사됨. (깊은 복사)
인스턴스를 선언만으로도 생성 가능 -> new 연산자 없어도 됨.
매개변수 없는 생성자 선언 불가.
(클래스와 비교해서 이해할 것.)

public 필드 선언? 구조체는 데이터를 담기 위한 자료구조로 사용되므로, 굳이 은닉성을 강하게 적용하지 않아도 됨.
 */


namespace Structure
{
    struct Point3D // struct 키워드를 이용해서 선언
    {
        public int X; // public으로 만든 필드 x. 
        public int Y;
        public int Z;

        public Point3D(int X, int Y, int Z)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }

        public override string ToString()
        {
            return string.Format($"{X}, {Y}, {Z}");
        }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            Point3D p3d1; // 선언만으로 인스턴스 생성.
            p3d1.X = 10;
            p3d1.Y = 20;
            p3d1.Z = 40;

            Console.WriteLine(p3d1.ToString());

            Point3D p3d2 = new Point3D(100, 200, 300); // 생성자를 이용한 인스턴스 생성 가능
            Point3D p3d3 = p3d2; // 구조체의 인스턴스를 다른 인스턴스에 할당 -> 깊은 복사 !
            p3d3.Z = 400;

            Console.WriteLine(p3d2.ToString()); // 100, 200, 300 
            Console.WriteLine(p3d3.ToString()); // 100, 200, 400 -> 깊은 복사가 이루어짐
        }
    }
}
