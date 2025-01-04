using System;
using System.Windows.Forms; // 윈도우 폼 애플리케이션을 만들기 위한 네임스페이스


/*
MaximizeBox, MinimizeBox 프로퍼티:
boolean 형식,
버튼을 창에 표시하고자 할 때는 true를 입력하고,
버튼을 창에서 감추고자 할 때는 false를 입력합니다.


Text 프로퍼티:
창의 제목을 나타내는 프로퍼티로,
string 형식입니다.
표시하려는 제목을 문자열로 입력해주면 창의 제목이 변경됩니다.
 */


// 윈도우 폼 애플리케이션 창의 최소화/최대화 버튼을 마우스 클릭으로 활성화/비활성화
namespace FormStyle
{
    class MainApp : Form // Form 클래스를 상속받는 MainApp 클래스 정의
    {
        static void Main(string[] args)
        {
            MainApp form = new MainApp(); // MainApp의 새 인스턴스를 생성합니다.

            form.Width = 400; // 윈도우 창의 너비를 400으로 설정합니다.
            form.MouseDown += new MouseEventHandler(form_MouseDown); // 윈도우 창의 MouseDown 이벤트에 form_MouseDown 메서드를 연결합니다.

            Application.Run(form); // 윈도우 창을 표시하고 메시지 루프를 시작합니다.
        }

        static void form_MouseDown(object sender, MouseEventArgs e) // 마우스 버튼을 누를 때 발생하는 이벤트를 처리하는 메서드
        {
            Form form = (Form)sender; // 이벤트를 발생시킨 객체를 Form 타입으로 변환합니다.

            if (e.Button == MouseButtons.Left) // 마우스 왼쪽 버튼을 누르면
            {
                form.MaximizeBox = true; // 최대화 버튼을 활성화합니다.
                form.MinimizeBox = true; // 최소화 버튼을 활성화합니다.
                form.Text = "최소화/최대화 버튼이 활성화되었습니다."; // 폼의 제목을 변경합니다.
            }
            else if (e.Button == MouseButtons.Right) // 마우스 오른쪽 버튼을 누르면
            {
                form.MaximizeBox = false; // 최대화 버튼을 비활성화합니다.
                form.MinimizeBox = false; // 최소화 버튼을 비활성화합니다.
                form.Text = "최소화/최대화 버튼이 비활성화되었습니다."; // 폼의 제목을 변경합니다.
            }
        }
    }
}