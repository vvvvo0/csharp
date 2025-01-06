using System;
using System.Diagnostics; // 현재 프로세스 정보를 얻기 위한 네임스페이스
using System.Net; // 네트워크 관련 클래스를 사용하기 위한 네임스페이스
using System.Net.Sockets; // 소켓 통신을 위한 네임스페이스
using System.Text; // 문자열 인코딩을 위한 네임스페이스



// TcpListener/ TcpClient 클래스를 활용한 '메아리 서버 구현'하기
// 클라이언트가 보낸 메시지를 서버가 그대로 돌려보내는 프로그램
namespace EchoServer
{
    class MainApp
    {
        static void Main(string[] args)
        {
            if (args.Length < 1) // 명령줄 인수가 1개 미만이면
            {
                Console.WriteLine("사용법 : {0} <Bind IP>", Process.GetCurrentProcess().ProcessName); // 사용법 출력
                return; // 프로그램 종료
            }

            string bindIp = args[0]; // 첫 번째 명령줄 인수를 bindIp에 저장
            const int bindPort = 5425; // 포트 번호 5425를 상수로 정의
            TcpListener server = null; // TcpListener 객체를 선언하고 null로 초기화

            try
            {
                IPEndPoint localAddress = new IPEndPoint(IPAddress.Parse(bindIp), bindPort);
                // IP 주소와 포트 번호를 사용하여 IPEndPoint 객체 생성
                // IPEndPoint: IP 통신에 필요한 'IP 주소'와 '포트 번호'를 나타냅니다.

                server = new TcpListener(localAddress); // TcpListener 객체 생성

                server.Start(); // 서버 시작
                                // server 객체는 클라이언트가 연결 요청해오기를 기다리기 '시작'합니다.

                Console.WriteLine("메아리 서버 시작... "); // "메아리 서버 시작... " 메시지 출력

                while (true) // 무한 루프
                {
                    TcpClient client = server.AcceptTcpClient(); // 클라이언트 접속 대기
                    Console.WriteLine("클라이언트 접속 : {0} ", ((IPEndPoint)client.Client.RemoteEndPoint).ToString()); // 클라이언트 접속 정보 출력

                    NetworkStream stream = client.GetStream(); // 클라이언트와 통신할 NetworkStream 객체 가져오기

                    int length; // 데이터 길이를 저장할 변수
                    string data = null; // 데이터를 저장할 변수
                    byte[] bytes = new byte[256]; // 데이터를 저장할 바이트 배열

                    while ((length = stream.Read(bytes, 0, bytes.Length)) != 0) // 클라이언트에서 데이터를 읽어옴
                    {
                        data = Encoding.Default.GetString(bytes, 0, length); // 바이트 배열을 문자열로 변환
                        Console.WriteLine(String.Format("수신: {0}", data)); // 수신 데이터 출력

                        byte[] msg = Encoding.Default.GetBytes(data); // 문자열을 바이트 배열로 변환

                        stream.Write(msg, 0, msg.Length); // 클라이언트에 데이터를 씀
                        Console.WriteLine(String.Format("송신: {0}", data)); // 송신 데이터 출력
                    }

                    stream.Close(); // NetworkStream 닫기
                    client.Close(); // TcpClient 닫기
                }
            }

            catch (SocketException e) // SocketException 예외 발생 시
            {
                Console.WriteLine(e); // 예외 정보 출력
            }

            finally // 예외 발생 여부와 관계없이 항상 실행
            {
                server.Stop(); // 서버 중지
            }


            Console.WriteLine("서버를 종료합니다."); // "서버를 종료합니다." 메시지 출력
        }
    }
}