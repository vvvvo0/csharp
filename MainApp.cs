using System;


/*
읽기 전용 메소드: 건드려서는 안되는 상태를 수정하는 실수를 방지.
readonly 한정자를 이용해서 메소드에게 상태를 바꾸지 않도록 강제.
구조체안에서만 선언 가능.

readonly로 한정한 메소드에서 객체의 필드를 바꾸려 하면 컴파일 에러 발생해서 알려줌.

 */


namespace ReadonlyMothod
{
    struct ACSetting
    {
        public double currentInCelsius; // 현재 온도(°C)
        public double target; // 희망 온도

        public readonly double GetFahrenheit()
        {
            target = currentInCelsius * 1.8 + 32; // 화씨(°F) 계산 결과를 target에 저장
                                                  // 오류: 읽기 전용인 'target'에는 할당할 수 없습니다.
                                                  // readonly로 한정한 메소드에서 객체의 필드를 바꾸려 해서 컴파일 에러 발생함.
            return target; // target 반환
        }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            ACSetting acs;
            acs.currentInCelsius = 25;
            acs.target = 25;

            Console.WriteLine($"{acs.GetFahrenheit()}");
            Console.WriteLine($"{acs.target}");
        }
    }
}
