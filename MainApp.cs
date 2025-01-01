using System;
using System.IO; // 파일 입출력을 위한 네임스페이스


/*
.NET은 텍스트 파일을 쓰고 읽을 수 있도록 StreamWriter/StreamReader 클래스를 제공합니다.

바이너리 파일을 쓰고 읽을 수 있도록 BinaryWriter/BinaryReader 클래스를 제공한 것과 같음.
 */


// StreamWriter/StreamReader 클래스를 사용하여,
// 다양한 데이터 타입의 값을 텍스트 파일("a.txt")에 쓰고 읽는 프로그램
namespace TextFile
{
    class MainApp
    {
        static void Main(string[] args)
        {
            using (StreamWriter sw = 
                new StreamWriter( // FileStream 객체를 사용하여 StreamWriter 객체를 생성합니다.
                                  // StreamWriter는 FileStream을 통해 파일에 접근하고 데이터를 씁니다.
                    new FileStream("a.txt", FileMode.Create))) // "a.txt"라는 텍스트 파일을 생성하고,
                                                               // 쓰기 모드로 여는 FileStream 객체(스트림)를 생성합니다.
                                                               // 이 객체는 StreamReader 객체에 전달되어,
                                                               // StreamReader가 파일에 텍스트를 쓸 수 있도록 합니다.
                                                               // 만약 파일이 이미 존재하면 기존 내용을 덮어씁니다.
            {
               // Write() 메서드와 WriteLine() 메서드는 C#이 제공하는 모든 기본 데이터 형식에 대해 오버로딩되어 있습니다.
                sw.WriteLine(int.MaxValue); // int 최댓값을 파일에 씀
                sw.WriteLine("Good morning!"); // 문자열 "Good morning!"을 파일에 씀
                sw.WriteLine(uint.MaxValue); // uint 최댓값을 파일에 씀
                sw.WriteLine("안녕하세요!"); // 문자열 "안녕하세요!"를 파일에 씀
                sw.WriteLine(double.MaxValue); // double 최댓값을 파일에 씀
            } // using 블록 종료 시 sw.Close() 자동 호출


            using (StreamReader sr =
                new StreamReader( 
                    new FileStream("a.txt", FileMode.Open))) // "a.txt" 파일을 열고 StreamReader 객체 sr를 사용하여 파일에서 읽을 수 있도록 합니다.
                                                             // using 문을 사용하면 sr 객체를 사용한 후 자동으로 Close() 메서드가 호출되어 파일이 닫힙니다.
            {
                Console.WriteLine($"File size : {sr.BaseStream.Length} bytes");  // 파일 크기 출력

                while (sr.EndOfStream == false) // 파일의 끝에 도달할 때까지 반복
                {
                    Console.WriteLine(sr.ReadLine()); // 파일에서 한 줄씩 읽어서 출력
                }
            } // using 블록 종료 시 sr.Close() 자동 호출
        }
    }
}


/*
출력 결과

File size : 82 bytes
2147483647
Good morning!
4294967295
안녕하세요!
1.7976931348623157E+308
 */