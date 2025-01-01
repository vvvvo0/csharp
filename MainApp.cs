using System;
using System.IO; // 파일 입출력 작업을 위한 네임스페이스


/*
파일의 입력과 출력(파일의 '내용'을 읽고 쓰는 방법)

스트림(Stream):
데이터가 흐르는 통로.
메모리에서 저장매체로 데이터를 옮길 때(파일을 쓸 때)는 먼저 스트림을 만들어 둘 사이를 연결한 후,
메모리에 있는 데이터를 바이트 단위로 저장매체에 옮겨 넣습니다.
저장매체에서 메모리로 데이터를 옮길 때(파일을 읽을 때)는 먼저 스트림을 만들어 둘 사이를 연결한 후,
저장매체(파일)에 있는 데이터를 바이트 단위로 메모리에 차례차례 옮겨 옵니다.

순차 접근(Sequential Access)방식:
스트림은 데이터의 '흐름'이기 때문에, 
스트림을 이용하여 파일을 다룰 때는 처음부터 끝까지 순서대로 읽고 쓰는 것이 보통입니다.
이러한 스트림의 구조는 네트워크나 데이터 백업 장치의 데이터 입/출력 구조와도 통하기 때문에
스트림을 이용하면 파일이 아닌 네트워크를 향해 데이터를 흘려보낼 수 있고,
테이프 백업 장치를 통해 데이터를 기록하거나 읽을 수도 있습니다.

임의 접근(Random Access)방식:
임의의 주소에 있는 데이터에 바로 접근하는 것.

Stream 클래스(System.IO.Stream 클래스):
Stream 클래스 그 자체로 입력 스트림, 출력 스트림 역할을 모두 할 수 있으며,
파일을 읽고 쓰는 방식 역시 순차 접근 방식과 임의 접근 방식 모두를 지원합니다.
단, Stream 클래스는 '추상 클래스'이므로, 이 클래스의 인스턴스를 직접 만들어 사용할 수는 없고,
이 클래스로부터 파생된 클래스를 이용해야 합니다.

Stream 클래스가 '추상 클래스'로 만들어진 이유?
스트림이 다루는 다양한 매체나 장치들에 대한 파일 입출력을 스트림 모델 '하나'로 다룰 수 있도록 하기 위함입니다.
 */


// System.IO 네임스페이스의 FileStream 클래스와 BitConverter 클래스를 사용하여
// long 형식의 데이터를 파일에 쓰고 읽는 프로그램
namespace BasicIO
{
    class MainApp
    {
        static void Main(string[] args)
        {
            // (1) FileStream 클래스를 통해 파일에 데이터를 쓰기
            long someValue = 0x123456789ABCDEF0; // long 형식의 someValue 변수를 선언하고, 16진수 값으로 초기화
            Console.WriteLine("{0,-1} : 0x{1:X16}", "Original Data", someValue); // someValue 값을 16진수 형식으로 출력

            // 1) 파일 스트림 생성
            Stream outStream = new FileStream("a.dat", FileMode.Create); // "a.dat" 파일을 쓰기 모드(FileMode.Create)로 열거나 생성


            // 2) BitConverter 클래스를 사용하여, someValue(long 형식)를 byte 배열로 변환
            byte[] wBytes = BitConverter.GetBytes(someValue); // someValue 값을 바이트 배열로 변환

            Console.Write("{0,-13} : ", "Byte array"); // "Byte array" 출력

            foreach (byte b in wBytes) // wBytes 배열의 각 바이트를 16진수 형식으로 출력
                Console.Write("{0:X2} ", b);
            Console.WriteLine();


            // 3) 변환한 byte 배열을 파일 스트림을 통해 파일에 기록
            outStream.Write(wBytes, 0, wBytes.Length); // wBytes 배열의 내용을 outStream에 씀


            // 4) 파일 스트림 닫기
            outStream.Close(); // outStream 닫기



            // (2) FileStream 클래스를 통해 파일에서 데이터를 읽어오기
            byte[] rbytes = new byte[8]; // 읽어온 데이터를 저장할 바이트 배열 rbytes를 선언
            
            // 1) 파일 스트림 생성
            Stream inStream = new FileStream("a.dat", FileMode.Open); // "a.dat" 파일을 읽기 모드로 염

            int i = 0;
            while (inStream.Position < inStream.Length) // inStream의 현재 위치가 파일의 끝에 도달할 때까지 반복
                rbytes[i++] = (byte)inStream.ReadByte(); // inStream에서 한 바이트씩 읽어와 rbytes 배열에 저장

            // 2) BitConverter 클래스를 사용하여, rbytes 배열을 long 형식으로 변환
            long readValue = BitConverter.ToInt64(rbytes, 0); // rbytes 배열을 long 형식으로 변환


            Console.WriteLine("{0,-13} : 0x{1:X16} ", "Read Data", readValue); // readValue 값을 16진수 형식으로 출력
            inStream.Close(); // inStream 닫기
        }
    }
}


/*
출력 결과

Original Data : 0x123456789ABCDEF0
Byte array    : F0 DE BC 9A 78 56 34 12
Read Data     : 0x123456789ABCDEF0
 */