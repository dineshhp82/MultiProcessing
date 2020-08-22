using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MultiProcessing.Basic
{
    public class ThreadingBasic
    {
        //Get undertermistic result
        public void ThreadCreate()
        {
            //Un-stared state
            Thread workerThread = new Thread(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("worker thread :" + i);
                }
            });

            //schedule thread to OS 
            //start state
            workerThread.Start();

            for (int j = 0; j < 10; j++)
            {
                Console.WriteLine("main thread :" + j);
            }

        }

        //SingleParma
        public void ThreadSingleParam()
        {
            Thread workerThread = new Thread((index) =>
          {
              for (int i = 0; i < (int)index; i++)
              {
                  Console.WriteLine("worker thread :" + i);
              }
          });

            workerThread.Start(10);

            for (int j = 0; j < 10; j++)
            {
                Console.WriteLine("main thread :" + j);
            }
        }

        //Multiple params
        //Thread take only one param b'casue thread ParameterizedThreadStart delegate
        // has one object type param and also Start method has one object parma.
        // but with the help of lambada we can pass method of multiple parma that is hard codes
        // in side the lambada exp. not from out side.
        public void ThreadMultipleParam()
        {
            void Work(int start, int end)
            {
                for (int i = start; i < end; i++)
                {
                    Console.WriteLine("worker thread :" + i);
                }
            }

            Thread workerThread = new Thread(() => { Work(0, 10); });

            workerThread.Start();

            for (int j = 0; j < 10; j++)
            {
                Console.WriteLine("main thread :" + j);
            }
        }

        //Thread does not return value b'casue start method of thread is VOID type
        //Exception throw by thread is also not captured but there are someway 
        // through which we capture the exception
        public void ThreadReturnValue()
        {
            int Work(int start, int end)
            {
                for (int i = start; i < end; i++)
                {
                    Console.WriteLine("worker thread :" + i);
                }

                return start + end;
            }

            Thread workerThread = new Thread(result => Work(0, 10));

            workerThread.Start();

            for (int j = 0; j < 10; j++)
            {
                Console.WriteLine("main thread :" + j);
            }

        }

        //Thread create own stack of memory for each local variable kept separate
        //Result order of print varies what count always same
        public void CheckThreadMemory()
        {
            void Work()
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.Write(i);
                }
            }

            Thread workerThread = new Thread(Work);
            workerThread.Start();
            //main thread.
            Work();
        }

        //Every run we got different results
        public void ShareVariable()
        {
            int sum = 0;

            void Work()
            {
                for (int i = 0; i < 5; i++)
                {
                    sum += i;
                }
                Console.WriteLine(sum);
            }
            //main thread.
            Work();
            Thread workerThread = new Thread(Work);
            workerThread.Start();

        }

        //Thread exception



    }

    public class TheadingBasicDemo
    {
        public static void Demo()
        {
            ThreadingBasic threadingBasic = new ThreadingBasic();
            //threadingBasic.ThreadCreate();
            //threadingBasic.ThreadSingleParam();
            //threadingBasic.ThreadMultipleParam();

            //threadingBasic.CheckThreadMemory();
            threadingBasic.ShareVariable();
        }
    }
}
