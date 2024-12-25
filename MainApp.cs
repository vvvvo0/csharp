using System;


/*
Delegate Chains(대리자 체인):
여러 개의 메서드를 하나의 델리게이트에 연결하여 순차적으로 호출할 수 있도록 하는 기능.

대리자는 메소드의 참조인데,
대리자 하나가 메소드 여러 개를 동시에 참조할 수 있다.
 */



namespace DelegateChains
{
    delegate void Notify(string message); // Notify라는 이름의 대리자를 선언합니다. 
                                          // 이 대리자는 문자열 매개변수를 하나 받고
                                          // void를 반환하는 메서드를 참조할 수 있습니다.

    class Notifier // Notify 대리자의 인스턴스인 EventOccured를 가지는 클래스 Notifier 선언
    {
        public Notify EventOccured; // EventOccured라는 Notify 델리게이트 타입의 이벤트를 선언합니다.
                                    // 이 이벤트는 특정 상황이 발생했을 때 다른 객체에 알리는 데 사용됩니다.
    }


    class EventListener
    {
        private string name; // EventListener 객체의 이름을 저장할 name이라는 필드 선언

        public EventListener(string name) // 생성자
        {
            this.name = name; // name 필드 초기화
        }

        public void SomethingHappend(string message) // 이벤트 발생 시 호출될 메서드 
                                                     // 이 메서드는 이벤트 메시지를 콘솔에 출력합니다.
        {
            Console.WriteLine($"{name}.SomethingHappened : {message}");
        }
    }


    class MainApp
    {
        static void Main(string[] args)
        {
            Notifier notifier = new Notifier(); // Notifier 클래스의 객체를 생성
            EventListener listener1 = new EventListener("Listener1"); // EventListener 클래스의 생성자를 호출하여 
                                                                      // EventListener 클래스의 객체를 생성하고,
                                                                      // listener1이라는 변수에 그 객체를 저장함.
                                                                      // 괄호안에 인수를 넣는 이유?
                                                                      // EventListener 클래스의 생성자는 string name이라는 매개변수를 가지고 있습니다.
                                                                      // 즉, EventListener 객체를 생성할 때 문자열 값을 전달해야 합니다. 
                                                                      // 이 문자열 값은 EventListener 객체의 name 필드에 저장됩니다.
                                                                      // 이 코드에서는 "Listener1"이라는 문자열을 생성자의 인자로 전달합니다. 
                                                                      // 따라서 listener1 객체의 name 필드에는 "Listener1"이라는 값이 저장됩니다.
            EventListener listener2 = new EventListener("Listener2");
            EventListener listener3 = new EventListener("Listener3");


            // += 연산자를 이용한 체인 만들기
            notifier.EventOccured += listener1.SomethingHappend; // += 연산자를 사용하여, EventListener 객체의 SomethingHappend 메서드를
                                                                 // notifier.EventOccured 대리자에 추가합니다.
                                                                 // 이렇게 하면 notifier.EventOccured 이벤트가 발생했을 때, 
                                                                 // 추가된 모든 메서드가 순차적으로 호출됩니다.
                                                                 // listener1의 SomethingHappend 메서드를 EventOccured 이벤트에 추가
            notifier.EventOccured += listener2.SomethingHappend; // listener2의 SomethingHappend 메서드를 EventOccured 이벤트에 추가
            notifier.EventOccured += listener3.SomethingHappend;
            notifier.EventOccured("You've got mail."); // notifier.EventOccured 델리게이트를 호출함.
                                                       // 체인에 연결된 모든 메서드가 호출됩니다.
                                                       // EventOccured 이벤트 발생

            Console.WriteLine();


            // -=연산자를 이용한 체인 끊기
            notifier.EventOccured -= listener2.SomethingHappend; // EventListener 객체의 SomethingHappend 메서드를
                                                                 // notifier.EventOccured 델리게이트에서 제거
            notifier.EventOccured("Download complete.");

            Console.WriteLine();


            // +, = 연산자를 이용한 체인 만들기
            notifier.EventOccured = new Notify(listener2.SomethingHappend)
                                  + new Notify(listener3.SomethingHappend); // + 연산자를 사용하여 델리게이트를 결합
            notifier.EventOccured("Nuclear launch detected.");

            Console.WriteLine();

            Notify notify1 = new Notify(listener1.SomethingHappend);
            Notify notify2 = new Notify(listener2.SomethingHappend);


            // Delegate.Combine() 메서드를 이용한 체인 만들기
            notifier.EventOccured =
                (Notify)Delegate.Combine(notify1, notify2);
            notifier.EventOccured("Fire!!");

            Console.WriteLine();


            // Delegate.Remove() 메서드를 이용한 체인 끊기
            notifier.EventOccured =
                (Notify)Delegate.Remove(notifier.EventOccured, notify2);
            notifier.EventOccured("RPG!");
        }
    }
}


/*
출력 결과

Listener1.SomethingHappened : You've got mail.
Listener2.SomethingHappened : You've got mail.
Listener3.SomethingHappened : You've got mail.

Listener1.SomethingHappened : Download complete.
Listener3.SomethingHappened : Download complete.

Listener2.SomethingHappened : Nuclear launch detected.
Listener3.SomethingHappened : Nuclear launch detected.

Listener1.SomethingHappened : Fire!!
Listener2.SomethingHappened : Fire!!

Listener1.SomethingHappened : RPG!
*/