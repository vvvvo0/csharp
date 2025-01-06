using System;
using System.Diagnostics; // 현재 프로세스 정보를 가져오기 위한 네임스페이스
using System.Net; // 네트워크 관련 클래스를 사용하기 위한 네임스페이스
using System.Net.Sockets; // 소켓 통신을 위한 네임스페이스
using System.Text; // 문자열 인코딩을 위한 네임스페이스


/*
주의:
직전 깃에 있는 [TcpListener/ TcpClient 클래스 (서버 구현)]에서 만든 EchoSetver 커맨드 창을 먼저 띄우고,
다른 창에서 아래 코드로 완성한 EchoClient 커맨드 창을 띄워서 테스트해야 합니다.
 */


// TcpListener/ TcpClient 클래스를 활용한 '메아리 클라이언트 구현'하기
// 클라이언트가 보낸 메시지를 서버가 그대로 돌려보내는 프로그램
namespace EchoClient
{
    class MainApp
    {
        static void Main(string[] args)
        {
            if (args.Length < 4) // 필요한 명령줄 인수가 제공되지 않으면 사용법을 출력하고 프로그램 종료
            {
                Console.WriteLine(
                    "사용법 : {0} <Bind IP> <Bind Port> <Server IP> <Message>",
                    Process.GetCurrentProcess().ProcessName);
                return;
            }

            string bindIp = args[0]; // 클라이언트가 바인딩할 IP 주소
            int bindPort = Convert.ToInt32(args[1]); // 클라이언트가 바인딩할 포트 번호
            string serverIp = args[2]; // 서버의 IP 주소
            const int serverPort = 5425; // 서버의 포트 번호
            string message = args[3]; // 서버에 보낼 메시지

            try
            {
                // 클라이언트와 서버의 IP 주소와 포트 번호를 사용하여 IPEndPoint 객체를 생성합니다.
                IPEndPoint clientAddress = new IPEndPoint(IPAddress.Parse(bindIp), bindPort);
                IPEndPoint serverAddress = new IPEndPoint(IPAddress.Parse(serverIp), serverPort);

                Console.WriteLine("클라이언트: {0}, 서버:{1}", clientAddress.ToString(), serverAddress.ToString()); // 클라이언트와 서버의 정보를 출력합니다.

                TcpClient client = new TcpClient(clientAddress); // TcpClient 객체를 생성하고 클라이언트 주소로 초기화합니다.

                client.Connect(serverAddress); // 서버에 연결합니다.

                byte[] data = System.Text.Encoding.Default.GetBytes(message); // 메시지를 바이트 배열로 변환합니다.

                NetworkStream stream = client.GetStream(); // 네트워크 스트림을 가져옵니다.

                stream.Write(data, 0, data.Length); // 스트림에 데이터를 씁니다.

                Console.WriteLine("송신: {0}", message); // 송신 메시지를 출력합니다.

                data = new byte[256]; // 수신 데이터를 저장할 바이트 배열을 생성합니다.

                string responseData = ""; // 수신 데이터를 저장할 문자열 변수를 선언합니다.

                int bytes = stream.Read(data, 0, data.Length); // 스트림에서 데이터를 읽습니다.
                responseData = Encoding.Default.GetString(data, 0, bytes); // 읽은 데이터를 문자열로 변환합니다.
                Console.WriteLine("수신: {0}", responseData); // 수신 메시지를 출력합니다.

                stream.Close(); // 스트림을 닫습니다.
                client.Close(); // 클라이언트를 닫습니다.
            }
            catch (SocketException e) // 소켓 예외 발생 시 처리
            {
                Console.WriteLine(e); // 예외 정보를 출력합니다.
            }

            Console.WriteLine("클라이언트를 종료합니다."); // 클라이언트 종료 메시지를 출력합니다.
        }
    }
}