using System;


// WinForm 클래스를 이용한 윈도우(앱의 창) 생성
namespace SimpleWindow
{
    // (1) System.Windows.Forms.Form 클래스에서 파생된 윈도우 폼 클래스를 선언합니다.
    class MainApp : System.Windows.Forms.Form // MainApp이 System.Windows.Forms.Form 클래스로부터
                                              // 상속받도록 선언합니다.
    {
        static void Main(string[] args)
        {
            // (2) (1)에서 만든 클래스의 인스턴스를 System.Windows.Forms.Form.Applivation.Run() 메서드에
            // 인수로 넘겨 호출합니다.
            System.Windows.Forms.Application.Run(new MainApp()); // Applivation.Run() 메서드에 MainApp의
                                                                 // 인스턴스를 인수로 넘겨 호출합니다.
        }
    }
}

/*
출력 결과

! [1](https://github.com/user-attachments/assets/4c7d39e7-e66d-45ef-9de2-63cc2cf59429)
*/