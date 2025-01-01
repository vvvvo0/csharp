using System;
using System.Linq;
using System.IO; // 파일 및 디렉터리 작업을 위한 네임스페이스


/*
파일 정보, 디렉터리 정보 다루는 방법.

파일(File): 
컴퓨터 저장 매체에 기록되는 데이터의 묶음.

디렉터리(Directory): 
파일이 위치하는 주소. 파일을 담는다는 의미에서 폴더(Folder)라고 부르기도 함.

.NET은 파일과 디렉터리 정보를 다룰 수 있도록 'System.IO 네임스페이스' 아래에 다음과 같은 클래스들을 제공함:
(1) File :'파일'의 생성, 복사, 삭제, 이동, 조회를 처리하는 '정적 메소드'를 제공함
(2) FileInfo: File 클래스와 하는 일은 동일하지만, 정적 메서드 대신 '인스턴스 메서드'를 제공함
(3) Directory: '디렉터리'의 생성, 삭제, 이동, 조회를 처리하는 '정적 메서드'를 제공함 
(4) DirectoryInfo: Directoty 클래스와 하는 일은 동일하지만, 정적 메서드 대신 '인스턴스 메서드'를 제공함

File 클래스 vs FileInfo 클래스?
하나의 파일에 대해 한 두가지 정도의 작업을 할 때는 File 클래스의 정적 메서드를 이용하고,
하나의 파일에 여러가지 작업을 할 때는 FileInfo 클래스의 인스턴스 메서드를 이용하는 편임
Directory 클래스와 DirectoryInfo 클래스도 동일.
 */


// 사용자가 인수를 입력하지 않으면 현재 디렉터리에 대해,
// 인수를 입력한 경우에는 입력한 디렉터리 경로에 대해
// 하위 디렉터리 목록과 파일 목록을 차례대로 출력하는 프로그램
// (System.IO 네임스페이스의 클래스들을 사용하여 특정 디렉터리의 하위 디렉터리와 파일 정보를 출력하는 프로그램)
namespace Dir
{
    class MainApp
    {
        static void Main(string[] args)
        {
            string directory; // 디렉터리 경로를 저장할 변수
            if (args.Length < 1) // 명령줄 인수가 없으면(사용자가 인수를 입력하지 않은 경우)
                directory = "."; // 현재 디렉터리(.)를 사용
            else
                directory = args[0]; // 명령줄 인수가 있으면(사용자가 인수를 입력한 경우)
                                     // 명령줄 인수를 디렉터리 경로로 사용

            Console.WriteLine($"{directory} directory Info"); // 디렉터리 정보 출력

            Console.WriteLine("- Directories :"); // 하위 디렉터리 목록 출력
            
            var directories = (from dir in Directory.GetDirectories(directory) 
                               let info = new DirectoryInfo(dir)
                               select new
                               {
                                   Name = info.Name,
                                   Attributes = info.Attributes
                               }).ToList();
            // Directory.GetDirectories() 메서드를 사용하여 directory 경로의 하위 디렉터리 목록을 가져옵니다.
            // 각 하위 디렉터리에 대해 DirectoryInfo 객체를 생성하고,
            // 익명 형식을 사용하여 Name과 Attributes 프로퍼티를 선택합니다.
            // ToList() 메서드를 사용하여 쿼리 결과를 List<T>로 변환합니다.


            foreach (var d in directories) // 각 하위 디렉터리의 이름과 속성을 출력합니다.
                Console.WriteLine($"{d.Name} : {d.Attributes}");


            Console.WriteLine("- Files :"); // 파일 목록 출력

            var files = (from file in Directory.GetFiles(directory)
                         let info = new FileInfo(file)
                         select new
                         {
                             Name = info.Name,
                             FileSize = info.Length,
                             Attributes = info.Attributes
                         }).ToList();
            // Directory.GetFiles() 메서드를 사용하여 directory 경로의 파일 목록을 가져옵니다.
            // 각 파일에 대해 FileInfo 객체를 생성하고,
            // 익명 형식을 사용하여 Name, FileSize, Attributes 프로퍼티를 선택합니다.
            // ToList() 메서드를 사용하여 쿼리 결과를 List<T>로 변환합니다.


            foreach (var f in files) // 각 파일의 이름, 크기, 속성을 출력합니다.
                Console.WriteLine(
                    $"{f.Name} : {f.FileSize}, {f.Attributes}");
        }
    }
}
