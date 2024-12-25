using System;


/*
이벤트(Event):
어떤 일이 생겼을 때 이를 알려주는 객체가 필요한 경우가 있음.
이벤트는 이런 객체를 만들 때 사용.
대리자(Delegate)를 event 한정자로 수식해서 만듦.

대리자(Delegate) vs 이벤트(Event)?
이벤트는 public 한정자로 수식되어 있어도 자신이 선언된 클래스 외부에서는 호출이 불가능함.
대리자는 public이나 internal 한정자로 수식되어 있으면 클래스 외부에서도 호출이 가능.

이벤트(Event) 사용 이유?
객체의 상태를 허위로 나타낼 수 있는 위험을 이벤트로 막을 수 있음.

대리자: 콜백 용도로 사용(메서드에 대한 참조를 저장하고, 마치 메서드를 변수처럼 사용할 수 있도록 하는 형식)
이벤트: 객체의 상태 변화를 일으키거나 사건의 발생을 알리는 용도로 사용
 */


namespace EventTest
{
    // (1) 대리자를 선언합니다. 이 대리자는 클래스 밖에 선언 해도 되고 안에 선언해도 됩니다.
    delegate void EventHandler(string message); // EventHandler라는 이름의 델리게이트를 선언합니다.
                                                // 이 델리게이트는 문자열 매개변수를 하나 받고
                                                // void를 반환하는 메서드를 참조할 수 있습니다.

    class MyNotifier
    {
        // (2) 이벤트를 선언합니다.
        // 선언한 대리자(EventHandler)의 인스턴스를 event 한정자로 수식해서, '클래스 내'에 선언합니다.
        public event EventHandler SomethingHappened; // EventHandler 델리게이트 타입의 이벤트 SomethingHappened 선언


        public void DoSomething(int number) // DoSomething() 메서드: 숫자를 입력받아 처리하는 메서드.
                                            // 숫자를 입력받아
                                            // 10으로 나눈 나머지가 0이 아니고 & 3으로 나누어 떨어지면
                                            // SomethingHappened 이벤트를 발생시킵니다

        {
            int temp = number % 10; // number를 10으로 나눈 나머지를 temp에 저장

            if (temp != 0 && temp % 3 == 0) // temp가 0이 아니고 3으로 나누어 떨어지면
            {
                SomethingHappened(String.Format("{0} : 짝", number)); // SomethingHappened 이벤트 발생
            }
        }
    }

    class MainApp
    {
        // (3) 이벤트 핸들러를 작성합니다. 대리자(EventHandler)의 형식과 동일한 메서드면 됩니다.
        static public void MyHandler(string message) // MyHandler() 메서드: 이벤트 처리 메서드입니다.
                                                     // message를 콘솔에 출력합니다.
                                                     // SomethingHappened 이벤트에서 사용할 이벤트 핸들러(MyHandler)는,
                                                     // 대리자(EventHandler)의 형식과 동일한 형식.
        {
            Console.WriteLine(message);
        }


        static void Main(string[] args)
        {
            // (4) 클래스의 인스턴스를 생성하고, 이 인스턴스의 이벤트에 이벤트 핸들러를 등록합니다.
            MyNotifier notifier = new MyNotifier(); // MyNotifier 인스턴스를 생성
            notifier.SomethingHappened += new EventHandler(MyHandler); // SomethingHappened 이벤트에 MyHandler() 메서드를
                                                                       // 이벤트 핸들러로 추가(등록)합니다.

            // (5) 이벤트가 발생하면 이벤트 핸들러(MyHandler())가 호출됩니다.
            for (int i = 1; i < 30; i++) // 1부터 29까지의 숫자를 DoSomething 메서드에 전달
            {
                notifier.DoSomething(i);
            }
        }
    }
}


/*
실행 결과

3 : 짝
6 : 짝
9 : 짝
13 : 짝
16 : 짝
19 : 짝
23 : 짝
26 : 짝
29 : 짝
*/