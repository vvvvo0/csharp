using System;


/*
추상 클래스:
클래스처럼 구현된 프로퍼티를 가질 수 있는 한편,
인터페이스처럼 구현되지 않은 프로퍼티(추상 프로퍼티)도 가질 수 있음

추상 프로퍼티:
파생 클래스에서 반드시 구현(재정의)해야 함
abstract 한정자를 이용해서 선언
 */



// 추상 클래스와 프로퍼티를 사용하는 방법을 보여줌
namespace PropertiesInAbstractClass
{

    abstract class Product // 추상 클래스 Product
    {
        private static int serial = 0; // 정적 필드인 serial을 선언하고 0으로 초기화합니다.
                                       // 이 필드는 모든 Product 객체에서 공유됩니다.


        //추상 클래스는 구현을 가진 프로퍼티와 구현이 없는 추상 프로퍼티 모두를 가질 수 있음
        public string SerialID // 구현을 가진 프로퍼티
                               // 읽기 전용 프로퍼티 SerialID를 선언
        {
            get { return String.Format("{0:d5}", serial++); } // 일련번호를 생성하고 반환
                                                              // serial++는 serial 값을 1 증가시킴
        }

        abstract public DateTime ProductDate // 구현이 없는 추상 프로퍼티 ProductDate를 선언
                                             // 추상 프로퍼티는 파생 클래스에서 반드시 구현(재정의)해야 함
                                             // 추상 프로퍼티 ProductDate는 DateTime 타입으로 날짜를 나타냄
        {
            get; 
            set;
        }
    }


    class MyProduct : Product // 파생 클래스 MyProduct
    {
        public override DateTime ProductDate // Product 클래스의 ProductDate 프로퍼티(추상 프로퍼티)를 재정의(구현)함
                                             // 따라서 날짜를 가져오고 설정할 수 있도록 함
        {
            get;
            set;
        }
    }


    class MainApp
    {
        static void Main(string[] args)
        {
            Product product_1 = new MyProduct() // MyProduct 객체를 생성하고, ProductDate 프로퍼티를 초기화(즉, 날짜를 설정)
            { ProductDate = new DateTime(2010, 1, 10) };


            Console.WriteLine("Product:{0}, Product Date :{1}",
                product_1.SerialID,
                product_1.ProductDate); // SerialID 프로퍼티와 ProductDate 프로퍼티를 사용하여, 제품 정보를 출력합니다.


            Product product_2 = new MyProduct() // MyProduct 객체를 생성하고, ProductDate 프로퍼티를 초기화
            { ProductDate = new DateTime(2010, 2, 3) };


            Console.WriteLine("Product:{0}, Product Date :{1}",
                product_2.SerialID,
                product_2.ProductDate); // SerialID 프로퍼티와 ProductDate 프로퍼티를 사용하여, 제품 정보를 출력합니다.
        }
    }
}


/*
출력 결과

Product:00000, Product Date :2010-01-10 오전 12:00:00
Product:00001, Product Date :2010-02-03 오전 12:00:00
 */