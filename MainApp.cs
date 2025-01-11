using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace UsingTask
{
    class MainApp
    {
        static void Main(string[] args)
        {
            string srcFile = args[0]; // 첫 번째 명령줄 인수를 srcFile에 저장한다.

            // 파일 복사 작업을 수행하는 Action<object> 델리게이트를 생성한다.
            Action<object> FileCopyAction = (object state) =>
            {
                String[] paths = (String[])state; // state 객체를 string 배열로 변환한다.
                File.Copy(paths[0], paths[1]); // paths[0]에서 paths[1]로 파일을 복사한다.

                // Task ID, Thread ID, 소스 파일 경로, 대상 파일 경로를 출력한다.
                Console.WriteLine("TaskID:{0}, ThreadID:{1}, {2} was copied to {3}",
                    Task.CurrentId, Thread.CurrentThread.ManagedThreadId,
                    paths[0], paths[1]);
            };

            // FileCopyAction 델리게이트를 사용하여 Task 객체를 생성한다.
            Task t1 = new Task(FileCopyAction, new string[] { srcFile, srcFile + ".copy1" });

            // Task.Run() 메서드를 사용하여 Task 객체를 생성한다.
            // Task의 인스턴스 생성과 시작을 한 번에 한다. 
            Task t2 = Task.Run(() =>
            {
                FileCopyAction(new string[] { srcFile, srcFile + ".copy2" });
            });

            t1.Start(); // t1 Task를 시작한다.

            // FileCopyAction 델리게이트를 사용하여 Task 객체를 생성한다.
            Task t3 = new Task(FileCopyAction, new string[] { srcFile, srcFile + ".copy3" });

            t3.RunSynchronously(); // t3 Task를 동기적으로 실행한다.

            t1.Wait(); // t1 Task가 완료될 때까지 기다린다.
            t2.Wait(); // t2 Task가 완료될 때까지 기다린다.
            t3.Wait(); // t3 Task가 완료될 때까지 기다린다.

            // List<int>를 반환하는 Task<List<int>> 객체를 생성한다.
            var myTask = Task<List<int>>.Run(
                () =>
                {
                    Thread.Sleep(1000); // 1초 동안 스레드를 일시 중지한다.

                    List<int> list = new List<int>(); // List<int> 객체를 생성한다.
                    list.Add(3); // list에 3, 4, 5를 추가한다.
                    list.Add(4);
                    list.Add(5);

                    return list; // list를 반환한다.
                }
            );

            myTask.Wait(); // myTask가 완료될 때까지 기다린다.
        }
    }
}