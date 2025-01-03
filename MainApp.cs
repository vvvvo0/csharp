using System;
using System.Windows.Forms;


/*
Application 클래스를 이용하여, 윈도우 메시지를 직접 다룰 수 있지만,
Form 클래스나  WinForm의 윈도우와 컨트롤 클래스들이 윈도우 메시지를 포장하여 미리 이벤트로 구현해놨기 때문에,
응용 프로그램을 만드는 동안 직접 윈도우 메시지를 요리하게 될 경우는 거의 없고,
미리 정의된 이벤트에 이벤트 처리기 메서드를 선언하여 등록해주기만 하면 됩니다.

Form 클래스:
운영체제가 보내는 메시지 중 일부에 대해 이벤트를 구현하고 있습니다.
(예를 들어, 윈도우 위에서 마우스 왼쪽 버튼을 누르면, 
WM_LBUTTONDOWN 메시지가 Form 객체로 전달되고, 
Form 객체는 이에 대해 MouseDown 이벤트를 발생시킵니다.)
 */


// 윈도우 폼에서 마우스 이벤트를 처리하는 방법
// Form 클래스를 상속받아 MainApp이라는 폼을 만들고,
// 마우스 클릭 이벤트가 발생했을 때 MyMouseHandler 메서드를 통해 이벤트 정보를 출력합니다.
namespace FormEvent
{
    class MainApp : Form
    {

        // 이벤틑 처리기 선언
        public void MyMouseHandler(object sender, MouseEventArgs e)
        // 마우스 이벤트 핸들러입니다.
        // 마우스 이벤트가 발생하면 이 메서드가 호출됩니다.
        // sender: 이벤트를 발생시킨 객체입니다. 여기서는 Form 객체입니다.
        // e: 마우스 이벤트에 대한 정보를 담고 있는 MouseEventArgs 객체입니다.
        {
            Console.WriteLine($"Sender : {((Form)sender).Text}"); // 이벤트를 발생시킨 From의 제목을 출력합니다.
            Console.WriteLine($"X:{e.X}, Y:{e.Y}"); // 마우스 클릭 위치의 X, Y 좌표를 출력합니다.
            Console.WriteLine($"Button:{e.Button}, Clicks:{e.Clicks}"); // 클릭한 마우스 버튼과 클릭 횟수를 출력합니다.
            Console.WriteLine();
        }

        public MainApp(string title) // MainApp 클래스의 생성자입니다.
                                     // Form의 제목을 설정하고, MouseDown 이벤트에 MyMouseHandler 메서드를 연결합니다.
        {
            // 이벤트 처리기를 이벤트에 연결
            this.Text = title; // 폼의 제목을 title 매개변수 값으로 설정합니다.
            this.MouseDown +=
                new MouseEventHandler(MyMouseHandler); //  MouseDown 이벤트가 발생하면 MyMouseHandler 메서드를 호출하도록 등록합니다.
        }

        static void Main(string[] args)
        {
            Application.Run(new MainApp("Mouse Event Test")); // MainApp 폼의 인스턴스를 생성하고,
                                                              // 폼의 제목을 "Mouse Event Test"로 설정합니다.
                                                              // pplication.Run() 메서드는 폼을 표시하고 메시지 루프를 시작합니다.
        }
    }
}


/*
출력 결과

Sender : Mouse Event Test
X:104, Y:109
Button:Left, Clicks:1

Sender : Mouse Event Test
X:134, Y:95
Button:Left, Clicks:1

Sender : Mouse Event Test
X:179, Y:163
Button:Left, Clicks:1

Sender : Mouse Event Test
X:206, Y:175
Button:Left, Clicks:1

Sender : Mouse Event Test
X:180, Y:90
Button:Left, Clicks:1

Sender : Mouse Event Test
X:58, Y:62
Button:Left, Clicks:1
 */