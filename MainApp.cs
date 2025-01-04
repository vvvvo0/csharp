using System;
using System.Drawing; // Color, Image 클래스 등을 사용하기 위한 네임스페이스
using System.Windows.Forms; // 윈도우 폼 애플리케이션을 만들기 위한 네임스페이스


/*
BackColor 프로퍼티:
창의 배경색 변경.
System.Drawing.Color 형식이기 때문에, 
Color 클래스의 정적 메서드나 미리 정의된 상수값을 이용해서 값을 지정해야 합니다.
(Color 구조체에는 다양한 색상이 미리 정의되어 있습니다,
그러나 프로그래머의 입맛에 값을 지정하고 깊으면 FromArgb() 메서드를 이용하면 됩니다.)

FromArgb() 메서드
첫 번째 인수: 투명도를 나타내는 Alpha,
두 번째 인수: Red
세 번째 인수: Green,
네 번째 인수: Blue 값을 나타내며,
각 인수는 0부터 255 사이의 값을 가질 수 있습니다.


Opacity 프로퍼티: 
창의 투명도 조절.
double 형식으로 0.00부터 1.00 사이의 값을 가집니다.
0에 가까울수록 투명해지고, 1에 가까울수록 불투명해집니다.


BackgroundImage 프로퍼티:
창의 배경 이미지를 지정.
BackgroundImage 프로퍼티에 Image 형식의 인스턴스를 할당하면됩니다.
 */


// 윈도우 폼으로 만들어진 윈도우 창의 배경색과 투명도, 배경이미지를 변경
namespace FormBackground
{
    class MainApp : Form // Form 클래스를 상속받는 MainApp 클래스 정의
    {
        Random rand; // 랜덤 객체를 저장할 필드

        public MainApp() // 생성자
        {
            rand = new Random(); // 랜덤 객체 생성

            this.MouseWheel += new MouseEventHandler(MainApp_MouseWheel); // MouseWheel 이벤트에 MainApp_MouseWheel 메서드를 연결합니다.
            this.MouseDown += new MouseEventHandler(MainApp_MouseDown); // MouseDown 이벤트에 MainApp_MouseDown 메서드를 연결합니다.
        }

        void MainApp_MouseDown(object sender, MouseEventArgs e) // 마우스 버튼을 누를 때 발생하는 이벤트를 처리하는 메서드
        {
            if (e.Button == MouseButtons.Left) // 마우스 왼쪽 버튼을 누르면
            {
                Color oldColor = this.BackColor; // 현재 배경색을 oldColor 변수에 저장합니다.
                this.BackColor = Color.FromArgb(rand.Next(0, 255), // 랜덤한 RGB 값을 생성하여 배경색을 변경합니다.
                                                rand.Next(0, 255),
                                                rand.Next(0, 255));
            }
            else if (e.Button == MouseButtons.Right) // 마우스 오른쪽 버튼을 누르면
            {
                if (this.BackgroundImage != null) // 배경 이미지가 이미 설정되어 있으면
                {
                    this.BackgroundImage = null; // 배경 이미지를 제거합니다.
                    return; // 메서드를 종료합니다.
                }

                string file = "sample.jpg"; // 배경 이미지 파일 경로를 설정합니다.
                if (System.IO.File.Exists(file) == false) // 파일이 존재하지 않으면
                    MessageBox.Show("이미지 파일이 없습니다."); // 메시지 박스를 표시합니다.
                else
                    this.BackgroundImage = Image.FromFile(file); // 파일에서 이미지를 불러와 배경 이미지로 설정합니다.
            }
        }

        void MainApp_MouseWheel(object sender, MouseEventArgs e) // 마우스 휠을 움직일 때 발생하는 이벤트를 처리하는 메서드
        {
            this.Opacity = this.Opacity + (e.Delta > 0 ? 0.1 : -0.1); // 마우스 휠 방향에 따라 폼의 투명도를 조절합니다.
            Console.WriteLine($"Opacity: {this.Opacity}"); // 현재 투명도를 출력합니다.
        }

        static void Main(string[] args)
        {
            Application.Run(new MainApp()); // MainApp 폼의 인스턴스를 생성하고, 폼을 실행합니다.
        }
    }
}