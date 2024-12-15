using System;
/*
 읽기 전용 필드: 읽기만 가능한 필드
 클래스나 구조체의 멤버로만 존재할 수 있음.
 생성자 안에서만 초기화 할 수 있음.
 생성자 안에서 한 번 값을 지정하면 그 후로는 값을 변경할 수 없음.
 readonly 키워드를 사용하서 선언.
 */

namespace ReadonlyFields
{
    class Configuration
    {
        readonly int min; // readonly를 사용해서 읽기 전용 필드 선언
        readonly int max; // readonly를 사용해서 읽기 전용 필드 선언

        public Configuration(int v1, int v2) // 읽기 전용 필드는 생성자 안에서만 초기화 가능
        {
            min = v1;
            min = v2;
        }

        public void ChangeMax(int newMax) // 생성자가 아닌 다른 곳에서 값을 수정하면 컴파일 에러 발생
                                          // 읽기 전용 필드에는 할당할 수 없습니다.
                                          // 단, 필드가 정의된 형식의 생성자 또는 초기값 전용 setter나 변수 이니셜라이저에서는 예외입니다.
        {
            max = newMax;
        }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            Configuration c = new Configuration(100, 10);
        }
    }
}
