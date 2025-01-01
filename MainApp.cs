using System;
using System.IO; // 파일 입출력을 위한 네임스페이스
using System.Text.Json; // JSON 직렬화 및 역직렬화를 위한 네임스페이스
                        // JsonSerializer 클래스가 소속되어 있는 네임스페이스


/*
직렬화(Serialization):
객체의 상태(여기서는 객체의 상태란 객체의 필드에 저장된 값을 말함)를 
메모리나 영구 저장 장치에 저장이 가능한 0과 1의 순서로 바꾸는 것.


직렬화(Serialization) 매커니즘 나온 배경:
BinaryWriter/BinaryReader 클래스와 StreamWriter/StreamReader 클래스는 
기본 데이터 형식을 스트림에 쓰고 읽을 수 있도록 메서드를 제공하지만, 
프로그래머가 직접 정의한 클래스나 복합 데이터 형식(예를 들어 구조체)은 지원하지 않습니다.
따라서 BinaryWriter/BinaryReader나 StreamWriter/StreamReader로 복합 데이터 형식을 쓰고 읽으려면,
그 형식이 가진 필드의 값을 저장할 순서를 정한 후에, 이 '순서대로' 저장하고 읽는 코드를 작성해야 하는 문제가 발생합니다.
C#은 이를 '한 번에' 저장할 수 있도록 복합 데이터 형식을 스트림에 쉽게 쓰고 읽을 수 있게 하는 '직렬화'라는 매커니즘을 제공합니다.

BinaryWriter/BinaryReader나 StreamWriter/StreamReader를 사용하면 데이터를 파일에 저장하고 읽을 수 있지만, 
복잡한 데이터를 다룰 때는 불편한 점이 있습니다. 예를 들어, 사람의 정보를 저장하려면 이름, 나이, 주소 등 
여러 개의 데이터를 저장해야 하는데, 이러한 데이터를 파일에 저장하려면 각 데이터를 어떤 순서로 저장할지, 
어떤 형식으로 저장할지 등을 일일이 지정해야 합니다.
직렬화는 이러한 복잡한 과정을 단순화해줍니다. 직렬화를 사용하면 객체를 통째로 파일에 저장하고, 다시 읽어올 수 있습니다. 
마치 냉장고에 음식을 보관하는 것과 같습니다. 음식을 냉장고에 넣으면, 음식의 모양, 맛, 영양 성분 등 모든 정보가 그대로 보존됩니다.
마찬가지로 객체를 직렬화하면 객체의 모든 데이터가 그대로 보존됩니다.

JsonSerializer 클래스:
System.Text.Json 네임스페이스에 소속되어 있고,
객체를 JSON 형식으로 직렬화하거나 역직렬화합니다.
클래스 안에 어떤 프로퍼티들이 어떻게 선언되어있는지 고민할 필요 없이,
JsonSerializer에게 맡기면 객체의 직렬화든 역질화든 알아서 해줍니다.
 */


// System.Text.Json 네임스페이스의 JsonSerializer 클래스를 사용하여,
// NameCard 객체를 JSON 형식으로 파일에 쓰고 읽는 예제입니다.
namespace Serialization
{
    class NameCard // NameCard 클래스 정의
    {
        public string Name { get; set; } // 이름을 저장할 Name 프로퍼티 선언
        public string Phone { get; set; } // 전화번호를 저장할 Phone 프로퍼티 선언
        public int Age { get; set; } // 나이를 저장할 Age 프로퍼티 선언
    }


    class MainApp
    {
        static void Main(string[] args)
        {
            var fileName = "a.json"; // 파일 이름을 "a.json"으로 설정

            using (Stream ws = new FileStream(fileName, FileMode.Create)) // "a.json" 파일을 쓰기 모드로 열거나 생성.
                                                                          // using 문을 사용하여 ws 객체를 사용한 후
                                                                          // 자동으로 Close() 메서드가 호출되어 파일이 닫힙니다.
            {

                NameCard nc = new NameCard() // NameCard 객체를 생성하고, 프로퍼티 값을 설정합니다.
                {
                    Name = "박상현", // Name 프로퍼티에 "박상현" 저장
                    Phone = "010-123-4567", // Phone 프로퍼티에 "010-123-4567" 저장
                    Age = 33 // Age 프로퍼티에 33 저장
                };

                string jsonString = JsonSerializer.Serialize<NameCard>(nc); // NameCard 객체를 JSON 문자열로 '직렬화'

                byte[] jsonBytes = System.Text.Encoding.UTF8.GetBytes(jsonString); // JSON 문자열을 UTF-8 인코딩으로 바이트 배열로 변환
                
                ws.Write(jsonBytes, 0, jsonBytes.Length); // 바이트 배열을 파일에 씀

            } // using 블록 종료 시 ws.Close() 자동 호출


            using (Stream rs = new FileStream(fileName, FileMode.Open)) // "a.json" 파일을 읽기 모드로 염
            {
                byte[] jsonBytes = new byte[rs.Length]; // 파일에서 읽어온 데이터를 저장할 바이트 배열 jsonBytes 선언
                rs.Read(jsonBytes, 0, jsonBytes.Length);  // 파일에서 바이트 배열을 읽어옴
                string jsonString = System.Text.Encoding.UTF8.GetString(jsonBytes); // 바이트 배열을 UTF-8 인코딩으로 문자열로 변환

                NameCard nc2 = JsonSerializer.Deserialize<NameCard>(jsonString); // JSON 문자열을 NameCard 객체로 '역직렬화'

                Console.WriteLine($"Name:  {nc2.Name}"); // NameCard 객체의 Name 프로퍼티 값 출력
                Console.WriteLine($"Phone: {nc2.Phone}"); // NameCard 객체의 Phone 프로퍼티 값 출력
                Console.WriteLine($"Age:   {nc2.Age}"); // NameCard 객체의 Age 프로퍼티 값 출력
            } // using 블록 종료 시 rs.Close() 자동 호출
        }
    }
}


/*
출력 결과

Name:  박상현
Phone: 010-123-4567
Age:   33
*/