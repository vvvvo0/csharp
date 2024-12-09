using System; 

namespace Hello 
{
    class MainApp
    {
        static void Main(string[] args)
        {
            Console.Write("종료 조건(숫자)을 입력하세요． :");

            String input = Console.ReadLine();

            int input_number = Convert.ToInt32(input);

            int exit_number = 0;

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    for(int k = 0; k < 3; k++)
                    {
                        if (exit_number++ == input_number)
                            goto EXIT_FOR;

                        Console.WriteLine(exit_number);
                    }
                }

            }
            //세 개의 중첩된 for 문을 사용하고 있는데, 각 for 문의 반복 횟수는 2, 2, 3입니다.
            //따라서 가장 안쪽 for 문은 2 x 2 x 3 = 12번 반복됩니다.
            //exit_number 값은 안쪽 for 문이 실행될 때마다 1씩 증가하므로, 12번 반복 후에는 exit_number 값이 12가 됩니다.
            //if (exit_number == input_number) 조건문에서 input_number가 20일 경우, exit_number가 20이 될 때까지 반복하려고 하지만,
            //가장 안쪽 for 문이 12번만 실행되므로 exit_number는 최대 12까지만 증가합니다.
            //따라서 20을 입력하면 exit_number가 12가 되었을 때
            //if (exit_number == input_number) 조건문이 거짓이 되어 goto EXIT_FOR;가 실행되지 않고, 바깥쪽 for 문으로 이동합니다.
            //결과적으로 20을 입력하더라도 0부터 12까지만 출력됨.

            //goto문은 중첩된 반복문을 단번에 뚫고 나올 때 유용


            goto EXIT_PORGRAM;

        EXIT_FOR:
            Console.WriteLine("\nExit nested for...");

        EXIT_PORGRAM:
            Console.WriteLine("Exit program...");


        }
    }
}
