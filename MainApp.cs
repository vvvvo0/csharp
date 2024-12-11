using System; 

namespace Hello 
{
    class Product
    {
        public int price = 100;

        public ref int Getprice() // GetPrice() 메서드는 ref 키워드를 사용하여 price 필드의 참조를 반환합니다.
        {
            return ref price;
        }

        public void printprice()
        {
            Console.WriteLine($"Price : {price}");
        }
     
    class MainApp
        {
            static void Main(string[] args)
            {
                Product carrot = new Product();
                ref int ref_local_price=ref carrot.Getprice();
                int normal_local_price=carrot.Getprice();

                carrot.printprice();
                Console.WriteLine($"Ref Local Price : {ref_local_price}");
                Console.WriteLine($"Normal Local Price : {normal_local_price}");



                ref_local_price = 200;
                
                carrot.printprice();
                Console.WriteLine($"Ref Local Price : {ref_local_price}");
                Console.WriteLine($"Normal Local Price : {normal_local_price}");
            }

        }
       
            
        
    }
}

/*
 class Product  // Product라는 이름의 클래스를 정의합니다.
{
    public int price = 100;  // public 접근 제한자를 가진 정수형 필드 price를 선언하고 100으로 초기화합니다.

    public ref int GetPrice()  // GetPrice라는 이름의 메서드를 정의합니다. ref 키워드를 사용하여 price 필드의 참조를 반환합니다.
    {
        return ref price;  // price 필드의 참조를 반환합니다.
    }

    public void PrintPrice()  // PrintPrice라는 이름의 메서드를 정의합니다.
    {
        Console.WriteLine($"Price : {price}");  // price 필드의 값을 출력합니다.
    }

    class MainApp  // MainApp이라는 이름의 클래스를 정의합니다.
    {
        static void Main(string[] args)  // 프로그램의 진입점인 Main 메서드를 정의합니다.
        {
            Product carrot = new Product();  // Product 클래스의 인스턴스 carrot을 생성합니다.
            ref int ref_local_price = ref carrot.GetPrice();  // ref_local_price 변수에 carrot.price 필드의 참조를 저장합니다.
            int normal_local_price = carrot.GetPrice();  // normal_local_price 변수에 carrot.price 필드의 값을 저장합니다.

            carrot.PrintPrice();  // carrot.price 필드의 값을 출력합니다. (Price : 100)
            Console.WriteLine($"Ref Local Price : {ref_local_price}");  // ref_local_price 변수의 값을 출력합니다. (Ref Local Price : 100)
            Console.WriteLine($"Normal Local Price : {normal_local_price}");  // normal_local_price 변수의 값을 출력합니다. (Normal Local Price : 100)

            ref_local_price = 200;  // ref_local_price 변수를 통해 carrot.price 필드의 값을 200으로 변경합니다.

            carrot.PrintPrice();  // carrot.price 필드의 값을 출력합니다. (Price : 200)
            Console.WriteLine($"Ref Local Price : {ref_local_price}");  // ref_local_price 변수의 값을 출력합니다. (Ref Local Price : 200)
            Console.WriteLine($"Normal Local Price : {normal_local_price}");  // normal_local_price 변수의 값을 출력합니다. (Normal Local Price : 100)
        }
    }
}

코드 분석

Product 클래스는 price라는 정수형 필드와 GetPrice(), PrintPrice() 메서드를 가지고 있습니다.
GetPrice() 메서드는 ref 키워드를 사용하여 price 필드의 참조를 반환합니다.
MainApp 클래스의 Main 메서드에서는 Product 클래스의 인스턴스 carrot을 생성하고, GetPrice() 메서드를 사용하여 price 필드의 참조와 값을 각각 ref_local_price 변수와 normal_local_price 변수에 저장합니다.
ref_local_price는 price 필드의 참조를 저장하기 때문에, ref_local_price 값을 변경하면 price 필드의 값도 변경됩니다.
normal_local_price는 price 필드의 값을 복사하여 저장하기 때문에, normal_local_price 값을 변경해도 price 필드의 값은 변경되지 않습니다.
이 코드는 ref 키워드를 사용하여 참조를 반환하는 방법과 참조를 통해 변수의 값을 변경하는 방법을 보여줍니다.

 */
















/*Q1.
public static void Swap(ref int a, ref int b)

A1.
public: 접근 제한자로, 어디서든 이 메서드에 접근할 수 있도록 합니다.
static: 이 메서드가 클래스의 인스턴스를 생성하지 않고도 호출될 수 있음을 의미합니다.
void: 이 메서드가 값을 반환하지 않음을 나타냅니다.
Swap: 메서드의 이름입니다.
ref int a, ref int b: 메서드의 매개변수로, 정수형 변수 a와 b를 참조로 전달받습니다. ref 키워드를 사용하면 메서드 내부에서 변수의 값을 변경했을 때, 원래 변수의 값도 변경됩니다.

Q2.
코드 분석

A2.
이 코드는 Swap 메서드를 사용하여 두 변수 x와 y의 값을 바꿉니다. ref 키워드를 사용하여 변수를 참조로 전달했기 때문에, Swap 메서드 내부에서 a와 b의 값을 바꾸면 Main 메서드의 x와 y 값도 변경됩니다.

따라서 Swap 메서드를 호출한 후 x와 y의 값은 4와 3으로 바뀌어 출력됩니다.

ref 키워드를 사용하면 메서드 내부에서 외부 변수의 값을 변경할 수 있으므로, 변수의 값을 교환하는 것처럼 메서드 외부에 영향을 주는 작업을 수행할 때 유용하게 사용할 수 있습니다.
*/