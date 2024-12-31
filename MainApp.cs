using System;
using Excel = Microsoft.Office.Interop.Excel;


/*
 COM과 .NET 사이의 상호 운용성을 위한 dynamic 형식.
COM은 메서드가 결과를 반환할 때 실제 형식이 아닌 object 형식으로 반환합니다. 이 때문에 C# 코드에서는
이 결과를 실제 형식으로 변환해줘야 하는 번거로움이 있었습니다. 이를 C# 4.0에 dynamic 형식의 도입을 통해 해결했습니다.
dynamic 형식은 런타임에 타입 검사를 수행하는 형식입니다. 따라서 dynamic 형식의 변수에 COM 객체를 할당하면,
컴파일 시점에 COM 객체의 타입을 알 필요가 없습니다.

마이크로소프트는 워드, 엑셀, 파워포인트 등 오피스 제품들의 기능을 코드에서 이용할 수 있도록,
이들을 COM 컴포넌트로 구성해놨습니다.

C#을 비롯한 .NET 언어들은 RCW(Runtime Callable Wrapper)를 통해 COM 컴포넌트를 사용할 수 있습니다.

RCW(Runtime Callable Wrapper):
RCW는 COM에 대한 프록시 역할을 함으로써, C# 코드에서 .NET 클래스 라이브를 사용하듯 COM API를 사용할 수 있게 해줍니다.
(즉, 프로그래머는 RCW를 통해 C# 코드에서 COM 컴포넌트가 가지고 있는 API들을 호출할 수 있습니다.)
RCW(Runtime Callable Wrapper)는 .NET이 제공하는 Type Libraray Importer(tlbomp.exe)를 이용해서 만들 수 있는데,
비주얼 스튜디오를 사용해서 COM 객체를 프로젝트 참조에 추가하면 IDE가 자동으로 tlbomp.exe를 호출해서 RCW를 만들어줍니다.

COM:
COM은 COmponent Object Model의 약자로, 마이크로소프트의 소프트웨어 컴포넌트 규격을 말합니다.
OLE, ActiveX, COM+와 같은 파생 규격들이 모두 COM을 바탕으로 만들어졌습니다.
 */


// COM 인터페이스를 사용하여 Excel 파일을 생성하는 두 가지 방법
namespace COMInterop
{
    class MainApp
    {
        public static void OldWay(string[,] data, string savePath) // OldWay 메서드 정의

        {
            Excel.Application excelApp = new Excel.Application(); // Excel Application 객체 생성

            excelApp.Workbooks.Add(Type.Missing); // 새 워크북 추가, Type.Missing은 선택적 인수를 생략할 때 사용

            Excel.Worksheet workSheet = (Excel.Worksheet)excelApp.ActiveSheet; // 활성 시트를 Worksheet 객체로 가져오기

            for (int i = 0; i < data.GetLength(0); i++) // 데이터 배열의 행 개수만큼 반복
            {
                ((Excel.Range)workSheet.Cells[i + 1, 1]).Value2 = data[i, 0]; // 엑셀 셀에 값 할당
                ((Excel.Range)workSheet.Cells[i + 1, 2]).Value2 = data[i, 1]; // 엑셀 셀에 값 할당
            }

            workSheet.SaveAs(savePath + "\\shpark-book-old.xlsx", // 엑셀 파일 저장
                Type.Missing, // 파일 형식 지정 (생략)
                Type.Missing, // 암호 지정 (생략)
                Type.Missing, // 쓰기 보호 암호 지정 (생략)
                Type.Missing, // 읽기 전용으로 저장할지 여부 지정 (생략)
                Type.Missing, // 파일 형식에 대한 추가 정보 지정 (생략)
                Type.Missing, // 파일을 저장할 때 충돌을 처리하는 방법 지정 (생략)
                Type.Missing, // 파일을 저장할 때 파일 속성을 설정하는 방법 지정 (생략)
                Type.Missing); // 파일을 저장할 때 파일 속성을 설정하는 방법 지정 (생략)

            excelApp.Quit(); // 엑셀 종료
        }

        public static void NewWay(string[,] data, string savePath) // NewWay 메서드 정의
        {
            Excel.Application excelApp = new Excel.Application(); // Excel Application 객체 생성

            excelApp.Workbooks.Add(); // 새 워크북 추가

            Excel._Worksheet workSheet = (Excel._Worksheet)excelApp.ActiveSheet; // 활성 시트를 _Worksheet 객체로 가져오기

            for (int i = 0; i < data.GetLength(0); i++) // 데이터 배열의 행 개수만큼 반복
            {
                workSheet.Cells[i + 1, 1] = data[i, 0]; // 엑셀 셀에 값 할당
                workSheet.Cells[i + 1, 2] = data[i, 1]; // 엑셀 셀에 값 할당
            }

            workSheet.SaveAs(savePath + "\\shpark-book-dynamic.xlsx"); // 엑셀 파일 저장
            excelApp.Quit(); // 엑셀 종료
        }

        static void Main(string[] args)
        {
            string savePath = System.IO.Directory.GetCurrentDirectory(); // 현재 디렉토리 경로 가져오기
            string[,] array = new string[,] // 문자열 2차원 배열 선언 및 초기화
            {
                { "뇌를 자극하는 알고리즘",       "2009" },
                { "뇌를 자극하는 C# 4.0",         "2011" },
                { "뇌를 자극하는 C# 5.0",         "2013" },
                { "뇌를 자극하는 파이썬 3",       "2016" },
                { "그로킹 딥러닝",                "2019" },
                { "이것이 C#이다",                "2018" },
                { "이것이 C#이다 2E",             "2020" },
                { "이것이 자료구조+알고리즘이다", "2022" },
                { "이것이 C#이다 3E",             "2023" },
            };

            Console.WriteLine("Creating Excel document in old way...");
            OldWay(array, savePath); // OldWay 메서드 호출

            Console.WriteLine("Creating Excel document in new way...");
            NewWay(array, savePath); // NewWay 메서드 호출
        }
    }
}
