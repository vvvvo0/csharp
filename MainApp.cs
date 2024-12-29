using System;
using System.Reflection; // 리플렉션에 필요한 네임스페이스


/*
Reflection을 이용해서 객체 생성하기

Activator.CreateInstance() 메서드:
Reflection을 이용해서 '동적으로 인스턴스를 만들기' 위해 필요함.
인스턴스를 만들려는 형식의 Type 객체를 이 메서드의 매개변수에 넘기면,
입력받은 형식의 인스턴스를 생성하여 반환함.

PropertyInfo.SetValue() 메서드, 
PropertyInfo.GetValue() 메서드:
'동적으로 프로퍼티에 값을 기록하고 읽는'데 필요함.
 PropertyInfo 클래스는 Type.GetProperties()의 반환 형식임.
 PropertyInfo 객체는 SetValue()와 GetValue()라는 메서드를 갖고 있는데,
 GetValue()를 호출하면 프로퍼티로부터 값을 읽을 수 있고,
 SetValue()를 호출하면 프로퍼티에 값을 할당할 수 있습니다.

PropertyInfo 클래스는 프로퍼티뿐만 아니라 인덱서의 정보도 담을 수 있는데,
 GetValue()와 SetValue()의 마지막 인수는 인덱서의 인덱스를 위해 사용됩니다.
따라서 프로퍼티는 인덱서가 필요 없으므로 아래 코드에서 null로 할당한 것을 확인할 수 있습니다.
 */

namespace DynamicInstance
{
    class Profile // Profile 클래스 정의
    {
        private string name; // name 필드 정의
        private string phone; // phone 필드 정의

        public Profile() // 기본 생성자
        {
            name = ""; phone = ""; // name과 phone 필드를 빈 문자열로 초기화
        }

        public Profile(string name, string phone) // name과 phone을 매개변수로 받는 생성자
        {
            this.name = name; // 전달받은 name을 name 필드에 저장
            this.phone = phone; // 전달받은 phone을 phone 필드에 저장
        }

        public void Print() // 이름과 전화번호를 출력하는 메서드
        {
            Console.WriteLine($"{name}, {phone}");
        }

        public string Name // name 필드에 접근하기 위한 프로퍼티
        {
            get { return name; }
            set { name = value; }
        }

        public string Phone // phone 필드에 접근하기 위한 프로퍼티
        {
            get { return phone; }
            set { phone = value; }
        }
    }


    class MainApp
    {
        static void Main(string[] args)
        {
            Type type = Type.GetType("DynamicInstance.Profile");
            // DynamicInstance.Profile 클래스(Profile 클래스)의 타입 정보를 가져와 type 변수에 저장합니다.

            MethodInfo methodInfo = type.GetMethod("Print");
            // Print() 메서드의 정보를 가져와 methodInfo 변수에 저장합니다.

            PropertyInfo nameProperty = type.GetProperty("Name");
            // Name 프로퍼티의 정보를 가져와 nameProperty 변수에 저장합니다.

            PropertyInfo phoneProperty = type.GetProperty("Phone");
            // Phone 프로퍼티의 정보를 가져와 phoneProperty 변수에 저장합니다.

            object profile = Activator.CreateInstance(type, "박상현", "512-1234");
            // 'Activator.CreateInstance() 메서드'를 사용하여 Profile 클래스의 객체를 생성하고,
            // 생성자에 "박상현"과 "512-1234"를 인자로 전달합니다.
            // 생성된 객체는 profile 변수에 저장됩니다.

            methodInfo.Invoke(profile, null); // methodInfo 변수에 저장된 Print 메서드를, profile 객체에서 호출합니다.



            profile = Activator.CreateInstance(type); // Activator.CreateInstance() 메서드를 사용하여,
                                                      // Profile 클래스의 객체를 생성합니다.
                                                      // 이번에는 생성자에 인자를 전달하지 않으므로
                                                      // 기본 생성자가 호출됩니다.
            nameProperty.SetValue(profile, "박찬호", null); // nameProperty 변수에 저장된 Name 프로퍼티에
                                                         // "박찬호" 값을 설정합니다.      
            phoneProperty.SetValue(profile, "997-5511", null); // phoneProperty 변수에 저장된 Phone 프로퍼티에
                                                               // "997-5511" 값을 설정합니다.

            Console.WriteLine("{0}, {1}", 
                nameProperty.GetValue(profile, null),
                phoneProperty.GetValue(profile, null)); // Name 프로퍼티와 Phone 프로퍼티의 값을 가져와서 출력합니다.
                                                        // PropertyInfo 클래스는 Type.GetProperties()의 반환 형식.
                                                        // PropertyInfo 객체는 SetValue()와 GetValue()라는 메서드를 갖고 있는데,
                                                        // GetValue()를 호출하면 프로퍼티로부터 값을 읽을 수 있고,
                                                        // SetValue()를 호출하면 프로퍼티에 값을 할당할 수 있습니다.
        }
    }
}


/*
출력 결과

박상현, 512-1234
박찬호, 997-5511
 */