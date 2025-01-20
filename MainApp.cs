using System;  // 기본적인 C# 기능을 사용하기 위해 필요한 네임스페이스
using System.IO; // 파일 입출력을 위한 FileStream 클래스를 사용하기 위해 필요한 네임스페이스
using System.Threading.Tasks;  // 비동기 작업을 위한 Task 클래스를 사용하기 위해 필요한 네임스페이스

namespace AsyncFileIO  // AsyncFileIO라는 이름의 네임스페이스를 정의한다
{
    class MainApp  // MainApp이라는 이름의 클래스를 정의한다
    {
        // 파일 복사 후 복사한 파일 용량을 반환하는 비동기 메서드이다.
        static async Task<long> CopyAsync(string FromPath, string ToPath)
        {
            using (var fromStream = new FileStream(FromPath, FileMode.Open))  // FromPath 경로의 파일을 읽기 모드로 연다. using 구문을 사용하여 스트림을 자동으로 닫는다.
            {
                long totalCopied = 0;  // 복사된 바이트 수를 저장할 변수를 0으로 초기화한다.

                using (var toStream = new FileStream(ToPath, FileMode.Create))  // ToPath 경로의 파일을 쓰기 모드로 연다. 만약 파일이 없으면 새로 생성한다. using 구문을 사용하여 스트림을 자동으로 닫는다.
                {
                    byte[] buffer = new byte[1024];  // 1024 바이트 크기의 버퍼를 생성한다. 파일 데이터를 버퍼 단위로 읽고 쓴다.
                    int nRead = 0;  // 읽어온 바이트 수를 저장할 변수를 선언한다.

                    // fromStream에서 데이터를 읽어와 toStream에 쓸 때까지 반복한다.
                    while ((nRead = await fromStream.ReadAsync(buffer, 0, buffer.Length)) != 0)  // fromStream에서 buffer 크기만큼 데이터를 비동기적으로 읽어온다. 읽어온 바이트 수를 nRead에 저장한다.
                    {
                        await toStream.WriteAsync(buffer, 0, nRead);  // toStream에 buffer의 내용을 비동기적으로 쓴다.
                        totalCopied += nRead;  // 복사된 바이트 수를 누적한다.
                    }
                }  // toStream을 닫는다.

                return totalCopied;  // 복사된 바이트 수를 반환한다.
            }  // fromStream을 닫는다.
        }

        static async void DoCopy(string FromPath, string ToPath)  // 파일 복사를 수행하는 비동기 메서드이다.
        {
            long totalCopied = await CopyAsync(FromPath, ToPath);  // CopyAsync 메서드를 호출하여 파일을 복사하고, 복사된 바이트 수를 totalCopied에 저장한다.
            Console.WriteLine($"Copied Total {totalCopied} Bytes.");  // 복사된 바이트 수를 출력한다.
        }

        static void Main(string[] args)  // 프로그램의 진입점이다.
        {
            if (args.Length < 2)  // 명령줄 인수가 2개 미만이면
            {
                Console.WriteLine("Usage : AsyncFileIO <Source> <Destination>");  // 사용법을 출력하고
                return;  // 프로그램을 종료한다.
            }

            DoCopy(args[0], args[1]);  // DoCopy 메서드를 호출하여 파일을 복사한다.

            Console.ReadLine();  // 사용자 입력을 기다린다.
        }
    }
}