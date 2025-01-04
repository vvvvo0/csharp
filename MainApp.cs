using System;
using System.Windows.Forms; // 윈도우 폼 애플리케이션을 만들기 위한 네임스페이스


/*
컨트롤(Control):
윈도우 OS가 제공하는 UI 요소를 말합니다.
응용 프로그램을 제어(컨트롤)하는 데 사용하는 도구라는 의미에서 붙은 이름입니다.
(버튼, 텍스트 박스 등)

윈도우 OS는 UI를 위해 버튼, 텍스트박스, 메뉴, 콤보박스, 리스트뷰 등과 같은 '표준 컨트롤'을 제공합니다.
.NET의 WinForm은 이 '표준 컨트롤'을 간편하게 창 위에 올리 수 있도록 잘 포장해놨습니다.
이 컨트롤들을 제어하는 데 필요한 메서드와 프로퍼티, 이벤트 또한 잘 정리해 놨습니다.

GUI 플랫폼(자바의 스윙이나 유닉스의 모티브)에서는 컨트롤을 위젯(Widget: Window Gadget)이라고 부르고,
델파이에서는 컨트롤을 VCL(Visual Component Library)이라고 부릅니다.

UI(User Interface):
응용 프로그램과 사용자가 대화를 하는 창구입니다.
사용자와 컴퓨터 시스템 간의 상호 작용을 위한 접점을 의미합니다. 
쉽게 말해, 사용자가 컴퓨터나 프로그램을 사용할 때 보고 만지는 모든 것들이 UI에 속합니다.
웹사이트의 버튼, 메뉴, 입력 필드, 윈도우 프로그램의 창, 아이콘, 메뉴바 등이 모두 UI입니다.
스마트폰 앱의 터치스크린, 버튼, 화면 구성 요소들도 UI에 해당합니다.
 */


// System.Windows.Forms 네임스페이스를 사용하여, 버튼 컨트롤을 가진 윈도우 폼 애플리케이션을 만듦.
// (버튼을 가진 윈도우 창이 나타나고, 버튼을 사용자가 클릭할 때마다 '딸깍!'이라는 메시지를 출력하는
// 메시지 박스가 나타나도록 만들었습니다.)
namespace FormAndControl
{
    class MainApp : Form // Form 클래스를 상속받는 MainApp 클래스 정의
    {
        static void Main(string[] args)
        {
            // (1) 컨트롤의 인스턴스 생성(System.Windows.Forms.Button 클래스의 인스턴스를 생성)
            Button button = new Button(); // Button 컨트롤의 새 인스턴스를 생성합니다.


            // (2) 컨트롤의 프로퍼티에 값을 지정
            button.Text = "Click Me!"; // 버튼의 텍스트를 "Click Me!"로 설정합니다.
            button.Left = 100; // 버튼의 왼쪽 위치를 100으로 설정합니다.
            button.Top = 50; // 버튼의 위쪽 위치를 50으로 설정합니다.


            // (3) 컨트롤의 이벤트에 이벤트 처리기 등록
            // 버튼의 Click 이벤트에 익명 메서드를 추가합니다.
            // 익명 메서드는 버튼이 클릭될 때 "딸깍!" 메시지 박스를 표시합니다.
            // (이벤트 처리기를 따로 메서드로 선언하지 않고 람다식으로 구현해봄)
            button.Click += (object sender, EventArgs e) => { MessageBox.Show("딸깍!"); };


            // (4) 폼에 컨트롤 추가
            MainApp form = new MainApp(); // MainApp 윈도우 창의 새 인스턴스를 생성합니다.
                                          // (form의 인스턴스를 생성)
            form.Controls.Add(button); // 윈도우 창에 button 컨트롤을 추가합니다.
                                       // (form 인스턴스에서 Controls 프로퍼티의 add() 메서드를 호출하여,
                                       //  선언한 button 객체를 Form에 올립니다.)

            form.Text = "Form & Control"; // 윈도우 창의 제목을 "Form & Control"로 설정합니다.
            form.Height = 150; // 윈도우 창의 높이를 150으로 설정합니다.




            Application.Run(form); // 윈도우 창을 표시하고 메시지 루프를 시작합니다.
        }
    }
}