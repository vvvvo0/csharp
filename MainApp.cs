using System;
using System.IO; // 파일 입출력을 위한 네임스페이스


/*
Stream 클래스에는 Position 이라는 프로퍼티가 있습니다.
따라서 Stream 클래스를 상속하는 FileStream 클래스도 Position 프로퍼티를 갖고 있습니다.


Position 프로퍼티:
현재 스트림의 읽는 위치 또는 쓰는 위치를 나타냅니다.
예를 들어 Position이 3이라면 파일의 3번쨰 바이트에서 읽거나 쓸 준비가 되어 있는 상태입니다.


FileStream 객체를 생성할 떄 Position이 0이 되고,
Write(), WriteByte(), Read(), ReadByte() 메서드를 호출할 때마다 Position이 1씩 증가합니다.
단, Write(), ReadByte() 메서드는 쓰거나 읽은 바이트 수만큼 Position이 증가합니다.


여러 개의 데이터를 입력하는 방법?
(1) 순차 접근 방식: Write()나 WriteByte() 메서드를 차례차례 호출하기.
(2) 임의 접급 방식: Seek() 메서드를 호출하거나, Position 프로퍼티에 직접 원하는 값을 대입하기.
                   이렇게 하면 지정한 위치로 점프해 읽기/쓰기를 위한 준비를 할 수 있습니다.
 */


// FileStream을 사용하여 파일에 순차적으로 데이터를 쓰고,
// FileStream 클래스의 Seek() 메서드를 사용하여 파일 스트림의 위치를 이동하는 방법
namespace SeqNRand
{
    class MainApp
    {
        static void Main(string[] args)
        {
            Stream outStream = new FileStream("a.dat", FileMode.Create); // "a.dat" 파일을 쓰기 모드로 열거나 생성합니다.
            Console.WriteLine($"Position : {outStream.Position}"); // outStream의 현재 위치를 출력합니다.
                                                                   // Position 프로퍼티는 스트림의 현재 위치를 나타냅니다.
                                                                   // 파일을 처음 생성했으므로 초기 위치는 0입니다.

            outStream.WriteByte(0x01); // outStream에 1바이트 값 0x01을 씁니다.
                                       // WriteByte() 메서드는 스트림의 현재 위치에 바이트 값을 쓰고,
                                       // 현재 위치를 1 증가시킵니다.

            Console.WriteLine($"Position : {outStream.Position}"); // outStream의 현재 위치를 출력합니다.
                                                                   // WriteByte() 메서드를 통해 1바이트를 썼으므로,
                                                                   // 현재 위치는 1입니다.

            outStream.WriteByte(0x02); // outStream에 1바이트 값 0x02을 씁니다.
            Console.WriteLine($"Position : {outStream.Position}");

            outStream.WriteByte(0x03); 
            Console.WriteLine($"Position : {outStream.Position}");

            outStream.Seek(5, SeekOrigin.Current); //  outStream의 현재 위치를 기준으로 5바이트 앞으로 이동합니다.
                                                   // Seek() 메서드는 스트림의 위치를 이동하는 메서드입니다.
                                                   // 첫 번째 매개변수는 이동할 바이트 수를 나타내고, 두 번째 매개변수는 기준 위치를 나타냅니다.
                                                   // SeekOrigin.Current는 현재 위치를 기준으로 함을 의미합니다.
                                                   // 따라서 현재 위치 3에서 5바이트 앞으로 이동하면 현재 위치는 8이 됩니다.
            Console.WriteLine($"Position : {outStream.Position}");

            outStream.WriteByte(0x04); // outStream에 1바이트 값 0x04를 씁니다.
                                       // 현재 위치는 8이므로, 8번째 위치에 0x04가 쓰여지고 현재 위치는 9가 됩니다.
            Console.WriteLine($"Position : {outStream.Position}");

            outStream.Close(); // outStream을 닫습니다.
        }
    }
}


/*
출력 결과

Position : 0
Position : 1
Position : 2
Position : 3
Position : 8
Position : 9
*/


/*
파일 내용

01 02 03 00 00 00 00 00 04
*/