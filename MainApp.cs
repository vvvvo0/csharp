using System;
using System.IO; // 파일 및 디렉터리 작업을 위한 네임스페이스


// System.IO 네임스페이스의 File 클래스와 Directory 클래스를 사용하여,
// 파일 또는 디렉터리를 생성하거나 마지막 쓰기 시간을 변경하는 프로그램.
// (인수로 입력받은 경로에 새 파일이나 디렉터리를 만듭니다.
// 만약 사용자가 입력한 경로에 이미 만들어져 있는 파일이나 디렉터리가 존재한다면,
// 해당 파일이나 디렉터리의 최종 수정 시간만 갱신합니다.)
namespace Touch
{
    class MainApp
    {

        static void OnWrongPathType(string type) // 잘못된 경로 타입을 입력받았을 때 호출되는 메서드
        {
            Console.WriteLine($"{type} is wrong type"); // 오류 메시지 출력
            return; // 메서드 종료
        }


        static void Main(string[] args)
        {
            if (args.Length == 0) // 명령줄 인수가 없으면
            {
                Console.WriteLine( // 사용법 출력
                    "Usage : Touch.exe <Path> [Type:File/Directory]");
                return; // 프로그램 종료
            }

            string path = args[0]; // 첫 번째 명령줄 인수를 경로로 저장
            string type = "File"; // 기본 타입을 File로 설정
            if (args.Length > 1) // 명령줄 인수가 2개 이상이면
                type = args[1]; // 두 번째 명령줄 인수를 타입으로 저장

            if (File.Exists(path) || Directory.Exists(path)) // 경로가 이미 존재하고
            {
                if (type == "File") // 타입이 File이면
                    File.SetLastWriteTime(path, DateTime.Now); // 파일의 마지막 쓰기 시간을 현재 시간으로 변경
                else if (type == "Directory") // 타입이 Directory이면
                    Directory.SetLastWriteTime(path, DateTime.Now); // 디렉터리의 마지막 쓰기 시간을 현재 시간으로 변경
                else // 타입이 File 또는 Directory가 아니면
                {
                    OnWrongPathType(path); // OnWrongPathType 메서드 호출
                    return; // 프로그램 종료
                }
                Console.WriteLine($"Updated {path} {type}"); // 업데이트 메시지 출력
            }

            else // 경로가 존재하지 않고
            {
                if (type == "File") // 타입이 File이면
                    File.Create(path).Close(); // 파일 생성
                else if (type == "Directory") // 타입이 Directory이면
                    Directory.CreateDirectory(path); // 디렉터리 생성
                else // 타입이 File 또는 Directory가 아니면
                {
                    OnWrongPathType(path); // OnWrongPathType 메서드 호출
                    return; // 프로그램 종료
                }

                Console.WriteLine($"Created {path} {type}"); // 생성 메시지 출력
            }
        }
    }
}
