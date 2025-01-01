using System;
using System.IO; // 파일 입출력을 위한 네임스페이스
using System.Collections.Generic; // List<T>를 사용하기 위한 네임스페이스
using System.Text.Json; // JSON 직렬화 및 역직렬화를 위한 네임스페이스
// using System.Text.Json.Serialization;: 
// 상태를 저장(직렬화/역직렬화)하고 싶지 않은 프로퍼티가 있다면,
// 직렬화/역직렬화 하지 않도록 [JsonIgnore] 애트리뷰트로 해당 프로퍼티 앞에서 수식하면 되는데,
// [JsonIgnore] 애트리뷰트를 사용하기 위해서 필요한 네임스페이스입니다.


/*
List를 비롯한 컬렉션들도 직렬화를 지원합니다.
예를 들어 List<NameCard> 형식의 객체도 직렬화를 통해 파일에 저장해뒀다가,
이를 역직렬화를 통해 메모리 내 컬렉션으로 불러들일 수 있습니다.
 */


namespace Serialization
{

    class NameCard // NameCard 클래스 정의
    {
        public string Name { get; set; } // 이름을 저장할 Name 프로퍼티
        public string Phone { get; set; } // 전화번호를 저장할 Phone 프로퍼티
        public int Age { get; set; } // 나이를 저장할 Age 프로퍼티
    }


    class MainApp
    {
        static void Main(string[] args)
        {
            var fileName = "a.json"; // 파일 이름을 "a.json"으로 설정

            using (Stream ws = new FileStream(fileName, FileMode.Create))
            {
                var list = new List<NameCard>(); // NameCard 객체를 저장할 List 생성
                list.Add(new NameCard() { Name = "박상현", Phone = "010-123-4567", Age = 33 });
                // NameCard 객체를 생성하고 list에 추가
                list.Add(new NameCard() { Name = "김연아", Phone = "010-323-1111", Age = 22 });
                // NameCard 객체를 생성하고 list에 추가
                list.Add(new NameCard() { Name = "장미란", Phone = "010-555-5555", Age = 26 });
                // NameCard 객체를 생성하고 list에 추가

                string jsonString = JsonSerializer.Serialize<List<NameCard>>(list); // list 객체를 JSON 문자열로 '직렬화'
                
                byte[] jsonBytes = System.Text.Encoding.UTF8.GetBytes(jsonString); // JSON 문자열을 UTF-8 인코딩으로 바이트 배열로 변환

                ws.Write(jsonBytes, 0, jsonBytes.Length); // 바이트 배열을 파일에 씀

            } // using 블록 종료 시 ws.Close() 자동 호출


            using (Stream rs = new FileStream(fileName, FileMode.Open)) // "a.json" 파일을 읽기 모드로 염
            {
                byte[] jsonBytes = new byte[rs.Length]; // 파일에서 읽어온 데이터를 저장할 바이트 배열 jsonBytes 선언

                rs.Read(jsonBytes, 0, jsonBytes.Length); // 파일에서 바이트 배열을 읽어옴

                string jsonString = System.Text.Encoding.UTF8.GetString(jsonBytes); // 바이트 배열을 UTF-8 인코딩으로 문자열로 변환

                var list2 = JsonSerializer.Deserialize<List<NameCard>>(jsonString); // JSON 문자열을 List<NameCard> 객체로 '역직렬화'

                foreach (NameCard nc in list2) // list2의 각 NameCard 객체를 순회하며 출력
                {
                    Console.WriteLine(
                        $"Name: {nc.Name}, Phone: {nc.Phone}, Age: {nc.Age}");
                }
            } // using 블록 종료 시 rs.Close() 자동 호출
        }
    }
}