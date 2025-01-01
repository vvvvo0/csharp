using System;
using System.IO; // 파일 입출력을 위한 네임스페이스


/*
BinaryWriter 클래스, BinaryReader 클래스:
BinaryWriter 클래스는 스트림에 이진 데이터(Binary Data)를 기록하기 위한 목적으로,
그리고 BinaryReader 클래스는 스트림으로부터 이진 데이터를 읽어들이기 위한 목적으로 만들어진 클래스입니다.


BinaryWriter 클래스, BinaryReader 클래스 나온 배경?
FileStream 클래스는 파일 처리를 위한 모든 것을 갖고 있지만,
데이터를 저장할 때, 반드시 byte 형식 또는 byte의 배열 형식으로 변환해야 한다는 번거로움이 있습니다.
따라서 .NET은 이런 불편함을 해소하기 위해 이 두 클래스를 만든 것입니다.


BinaryWriter와 BinaryReader 클래스는 결국 파일 처리의 도우미 역할을 할 뿐이기 때문에,
이 클래스들을 이용하려면 Stream으로부터 파생된 클래스의 인스턴스가 있어야 합니다.
(예를 들어 BinaryWriter와 FileStream을 함께 사용하면 
BinaryWriter의 이진 데이터 쓰기 기능을 파일 기록에 사용할 수 있고,
NetworkStream과 함꼐 사용한다면 네트워크로 이진 데이터를 내보낼 수 있습니다.)
 */


// BinaryWriter와 BinaryReader를 사용하여 다양한 데이터 타입의 값을 파일에 쓰고 읽는 프로그램
namespace BinaryFile
{
    class MainApp
    {
        static void Main(string[] args)
        {
            using (BinaryWriter bw = new BinaryWriter(new FileStream("a.dat", FileMode.Create)))
            // "a.dat" 파일을 생성하고, BinaryWriter 객체 bw를 사용하여 파일에 쓸 수 있도록 합니다. 
            // using 문을 사용하였으므로, bw 객체를 사용한 후 자동으로 Close() 메서드가 호출되어 파일이 닫힙니다.
            {
                bw.Write(int.MaxValue); // int 타입의 최댓값을 파일에 씀
                bw.Write("Good morning!"); // 문자열 "Good morning!"을 파일에 씀
                bw.Write(uint.MaxValue); // uint 타입의 최댓값을 파일에 씀
                bw.Write("안녕하세요!"); // 문자열 "안녕하세요!"를 파일에 씀
                bw.Write(double.MaxValue); // double 타입의 최댓값을 파일에 씀
            } // using 블록 종료 시 bw.Close() 자동 호출
              // bw 스트림은 여기서 한 번 닫힙니다,
              // 이렇게 닫지 않고 이후에 같은 스타일의 using 선언을 이용했다면,
              // a.dat가 열려 있는 상태에서 같은 파일을 다시 열려고 하는 상황이 발생합니다.


            using BinaryReader br = new BinaryReader(new FileStream("a.dat", FileMode.Open));
            // "a.dat" 파일을 열고, BinaryReader로 연결
            // 1. `new FileStream("a.dat", FileMode.Open)`: "a.dat" 파일을 읽기 모드(`FileMode.Open`)로 엽니다.
            // `FileStream`은 파일을 읽고 쓰기 위한 스트림을 나타냅니다.
            // 즉, 파일과 프로그램 사이에 데이터가 흐를 수 있는 통로를 만드는 것이죠.
            // 2. `new BinaryReader(...)`: `BinaryReader` 객체를 생성합니다.
            // `BinaryReader`는 파일 스트림에서 데이터를 읽어오는 데 사용되는 클래스입니다. 
            // 3. `BinaryReader br = ...`: 생성된 `BinaryReader` 객체를 `br`이라는 변수에 저장합니다.
            // 이제 `br` 변수를 사용하여 파일에서 데이터를 읽어올 수 있습니다.
            // 4. `using`: `using` 문은 `BinaryReader` 객체를 사용한 후 자동으로 `Close()` 메서드를 호출하여 파일을 닫습니다.
            // 이는 파일을 안전하게 닫고 리소스를 해제하는 데 중요합니다.

            Console.WriteLine($"File size : {br.BaseStream.Length} bytes"); // 파일 크기 출력
            Console.WriteLine($"{br.ReadInt32()}"); // 파일에서 int 값 읽어서 출력
            Console.WriteLine($"{br.ReadString()}"); // 파일에서 문자열 읽어서 출력
            Console.WriteLine($"{br.ReadUInt32()}"); // 파일에서 uint 값 읽어서 출력
            Console.WriteLine($"{br.ReadString()}"); // 파일에서 문자열 읽어서 출력
            Console.WriteLine($"{br.ReadDouble()}"); // 파일에서 double 값 읽어서 출력
        } // using 블록 종료 시 br.Close() 자동 호출
    }
}


/*
출력 결과

File size : 47 bytes
2147483647
Good morning!
4294967295
안녕하세요!
1.7976931348623157E+308
*/