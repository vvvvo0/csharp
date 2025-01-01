using System;
using System.IO; // 파일 입출력을 위한 네임스페이스
using FS = System.IO.FileStream; // FileStream 클래스에 FS라는 별칭을 지정.
                                 // System.IO.FileStream과 같이 긴 이름의 클래스를,
                                 // FS라는 간단한 별칭으로 사용할 수 있도록 합니다.


/*
using 선언:
스트림 열기, 기록하기, 닫기 과정에서 프로그래머가 가장 잘 놓치는 부분이 '스트림 닫기' 과정입니다.
파일을 다룰 때, 파일을 열어서 실컷 이용한 다음 자원을 해제하지 않는 것이 프로그래머가 흔히 하는 실수입니다.
using 선언을 통해 생성도니 객체는, 코드 블록이 끝나면서 outStream.Dispose() 메서드를 호출하여,
자동으로 '스트림 닫기'가 이루어지도록 합니다.
using 선언은 Stream 객체뿐 아니라 IDispose를 상속해서 Dispose() 메서드를 구현하는 모든 객체에 대해 사용할 수 있습니다.


using은 네임스페이스를 참조하기 위해서도 사용하지만,
파일이나 소켓을 비롯한 자원을 다룰 때도 요긴합니다.

 */

// System.IO 네임스페이스의 FileStream 클래스와 BitConverter 클래스를 사용하여
// long 형식의 데이터를 파일에 쓰고 읽는 방법.
// using 문을 사용하여 FileStream 객체를 사용한 후 자동으로 닫도록 만듦.
namespace UsingDeclaration
{
    class MainApp
    {
        static void Main(string[] args)
        {
            long someValue = 0x123456789ABCDEF0; // long 형식의 someValue 변수 선언 및 16진수 값으로 초기화
            Console.WriteLine("{0,-1} : 0x{1:X16}", "Original Data", someValue); // someValue 값을 16진수 형식으로 출력

            // 1) 파일 스트림 열기
            using (Stream outStream = new FS("a.dat", FileMode.Create)) // "a.dat" 파일을 쓰기 모드로 열거나 생성,
                                                                        // using 구문 사용
            {
                // 2) someValue(long 형식)을 byte 배열로 변환
                byte[] wBytes = BitConverter.GetBytes(someValue); // someValue 값을 바이트 배열로 변환

                Console.Write("{0,-13} : ", "Byte array"); // "Byte array" 출력

                foreach (byte b in wBytes) // wBytes 배열의 각 바이트를 16진수 형식으로 출력
                    Console.Write("{0:X2} ", b);
                Console.WriteLine();

                // 3) 변환한 byte 배열을 파일 스트림을 통해 파일에 기록
                outStream.Write(wBytes, 0, wBytes.Length); // wBytes 배열의 내용을 outStream에 씀

            } // using 구문 종료 시 outStream 자동으로 닫힘

            using Stream inStream = new FS("a.dat", FileMode.Open); // "a.dat" 파일을 읽기 모드로 열고 using 구문 사용
            byte[] rbytes = new byte[8]; // 읽어온 데이터를 저장할 바이트 배열 rbytes 선언

            int i = 0;
            while (inStream.Position < inStream.Length) // inStream의 현재 위치가 파일의 끝에 도달할 때까지 반복
                rbytes[i++] = (byte)inStream.ReadByte(); // inStream에서 한 바이트씩 읽어와 rbytes 배열에 저장

            long readValue = BitConverter.ToInt64(rbytes, 0); // rbytes 배열을 long 형식으로 변환

            Console.WriteLine("{0,-13} : 0x{1:X16} ", "Read Data", readValue); // readValue 값을 16진수 형식으로 출력
        } // using 구문 종료 시 inStream 자동으로 닫힘
    }
}


/*
출력 결과

Original Data : 0x123456789ABCDEF0
Byte array    : F0 DE BC 9A 78 56 34 12
Read Data     : 0x123456789ABCDEF0
*/