using System;
using System.Windows.Forms; // 윈도우 폼 애플리케이션을 만들기 위한 네임스페이스


// 윈도우 창을
namespace FormSize
{
    class MainApp : Form // Form 클래스를 상속받는 MainApp 클래스 정의
    {
        static void Main(string[] args)
        {

            MainApp form = new MainApp(); // MainApp의 새 인스턴스를 생성합니다.
            form.Width = 300; // 폼의 너비를 300으로 설정합니다.
            form.Height = 200; // 폼의 높이를 200으로 설정합니다.


            form.MouseDown += new MouseEventHandler(form_MouseDown); // 폼의 MouseDown 이벤트에,
                                                                     // form_MouseDown 메서드(이벤트 처리기 메서드)를 연결(등록)합니다.
                                                                     
                                                                     // MouseDown:
                                                                     // MouseDown 이벤트로서,
                                                                     // Form 클래스에 미리 선언되어 있습니다.
                                                                     // MouseEventHandler:
                                                                     // MouseDown 이벤트의 대리자로서,
                                                                     // Form 클래스에 미리 정의되어 있습니다.


            Application.Run(form); // 폼을 표시하고 메시지 루프를 시작합니다.
        }


        static void form_MouseDown(object sender, MouseEventArgs e) 
            // 마우스 버튼을 누를 때 발생하는 이벤트를 처리하는 메서드(이벤트 처리기 메서드) 선언
        {
            Form form = (Form)sender; // 이벤트를 발생시킨 객체를 Form 타입으로 변환합니다.
            int oldWidth = form.Width; // 폼의 현재 너비를 oldWidth 변수에 저장합니다.
            int oldHeight = form.Height; // 폼의 현재 높이를 oldHeight 변수에 저장합니다.


            if (e.Button == MouseButtons.Left) // 마우스 왼쪽 버튼을 누르면
            {
                if (oldWidth < oldHeight) // 현재 너비가 높이보다 작으면
                {
                    form.Width = oldHeight; // 너비를 높이 값으로 변경합니다.
                    form.Height = oldWidth; // 높이를 너비 값으로 변경합니다.
                }
            }

            else if (e.Button == MouseButtons.Right) // 마우스 오른쪽 버튼을 누르면
            {
                if (oldHeight < oldWidth) // 현재 높이가 너비보다 작으면
                {
                    form.Width = oldHeight; // 너비를 높이 값으로 변경합니다.
                    form.Height = oldWidth; // 높이를 너비 값으로 변경합니다.
                }
            }
            Console.WriteLine("윈도우의 크기가 변경되었습니다"); // "윈도우의 크기가 변경되었습니다" 메시지를 출력합니다.
            Console.WriteLine($"Width: {form.Width}, Height: {form.Height}"); // 변경된 폼의 너비와 높이를 출력합니다.
        }
    }
}

/*
출력 결과

윈도우의 크기가 변경되었습니다
Width: 200, Height: 300
윈도우의 크기가 변경되었습니다
Width: 300, Height: 200
윈도우의 크기가 변경되었습니다
Width: 200, Height: 300
윈도우의 크기가 변경되었습니다
Width: 300, Height: 200
 */