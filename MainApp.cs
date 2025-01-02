using System;
using System.Windows.Forms; // 윈도우 폼 애플리케이션을 만들기 위한 네임스페이스
                            // 윈도우 애플리케이션을 만드는 데 필요한 클래스를 제공합니다.


/*
Application.Run() 메서드: 응용 프로그램을 시작하는 메서드
Application.Exit() 메서드: 응용 프로그램을 종료하는 메서드,
어느 곳에서든 Application.Exit() 메서드를 호출하면 해당 응용 프로그램을 종료합니다.
단, Exit() 메서드가 호출된다고 해서 응용 프로그램이 바로 종료되는 것은 아닙니다.
응용 프로그램이 갖고 있는 모든 윈도우를 닫은 뒤 Run() 메서드가 반환되도록 합니다.
따라서 Run() 메서드 뒤에 자원을 정리하는 코드를 넣어두면 응용 프로그램을 깨끗하게 종료시킬 수 있습니다.
 */


// 윈도우 애플리케이션을 생성하고, 폼을 클릭했을 때 애플리케이션을 종료하는 이벤트 처리기를 추가하는 코드
namespace UsingApplication
{
    class MainApp : Form // MainApp 클래스는 Form 클래스를 상속받습니다.
    {
        static void Main(string[] args)
        {
            MainApp form = new MainApp(); // MainApp의 새 인스턴스인 form를 생성합니다.


            // form 객체의 Click 이벤트에 익명 메서드를 추가합니다.
            // 익명 메서드는 폼이 클릭될 때 "Closing Window..." 메시지를 출력하고 애플리케이션을 종료합니다.
            // Form 클래스:
            // 여러 이벤트를 정의하고 있는데, 그중 Click 이벤트는 윈도우를 클릭했을때 발생하는 이벤트입니다.
            // 따라서 이 코드는 윈도우를 클릭하면 "Closing Window..." 메시지를 출력하고 Application.Exit()를 호출합니다.
            form.Click += new EventHandler(
                (sender, eventArgs) =>
                {
                    Console.WriteLine("Closing Window..."); 
                    Application.Exit();
                });

            Console.WriteLine("Starting Window Application..."); // "Starting Window Application..." 메시지를 출력합니다.
            Application.Run(form); // 폼을 표시하고 메시지 루프를 시작합니다.

            Console.WriteLine("Exiting Window Application..."); // "Exiting Window Application..." 메시지를 출력합니다.
        }
    }
}


/*
출력 결과

Starting Window Application...

// 폼을 클릭하면 다음 메시지가 출력됩니다.
Closing Window...
Exiting Window Application...
 */