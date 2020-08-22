using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
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
        //when no try catch  => application crash 
        public void UnhandledExceptionOccureInThread()
        {
            void Work()
            {
                int a = 0;
                int b = 10;
                int c = b / a;
            }

            Thread thWorker = new Thread(Work);
            thWorker.Start();

            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(i * 2);
                Console.WriteLine("Main thread is running" + i);
            }
        }

        //Display error message and application is not crash
        //Error is catch because catch block in worker thread where 
        // error occure.
        public void HandleExceptionOccureInThread()
        {
            void Work()
            {
                try
                {
                    int a = 0;
                    int b = 10;
                    int c = b / a;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            Thread thWorker = new Thread(Work);
            thWorker.Start();

            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(i * 2);
                Console.WriteLine("Main thread is running" + i);
            }

        }

        //Application crash and unhandled exception
        // becuase you try to catch the exception in main thread and expection occure
        // at  worker thread.
        public void HandleExceptionInThread()
        {
            void Work()
            {
                int a = 0;
                int b = 10;
                int c = b / a;
            }

            try
            {
                Thread thWorker = new Thread(Work);
                thWorker.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(i * 2);
                Console.WriteLine("Main thread is running" + i);
            }
        }

        //Closure  : related to scope 
        //Whenever we've a fn defined inside another fn, the inner fn has access to the variable 
        //declared in the outer fn

        //Side effect of Closure : each time thread number result diff b'casuse i used by all thread

        public void ClosureInThread()
        {
            void Work(int threadNumber)
            {
                Console.WriteLine("Thread Number" + threadNumber);
            }

            for (int i = 0; i < 5; i++)
            {
                Thread th = new Thread(() => Work(i));
                th.Start();
            }

            Console.WriteLine("Main Thread say: Hi");
        }

        public void RidOfClosureInThread()
        {
            void Work(int threadNumber)
            {
                Console.WriteLine("Thread Number" + threadNumber);
            }

            for (int i = 0; i < 5; i++)
            {
                //create variable closure to get rid off now create separate i value for eacj
                int index = i;
                Thread th = new Thread(() => Work(index));
                th.Start();
            }

            Console.WriteLine("Main Thread say: Hi");
        }

        //For debugging
        public void ThreadName()
        {
            void Work(int threadindex)
            {
                try
                {
                    if (threadindex > 5)
                    {
                        throw new Exception("Value no expacted");
                    }

                    Console.WriteLine(threadindex);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    Console.WriteLine(Thread.CurrentThread.Name);
                }
            }


            for (int i = 0; i < 8; i++)
            {
                int temp = i;
                Thread th = new Thread(() => Work(temp));
                th.Name = "Thread" + temp;
                th.Start();
            }

            Console.WriteLine("Main Thread say: Hi");
        }

        //By default all thread are forground
        //But can create background (daemon thread)
        //main thread can be background thead

        //Forground thread make the application alive as long as run while background thread does not.
        //Once all the foreground threads finish the app is end any background thread running is terminated

        //background priority is low.
        //background task like GC.
        public void BackgroundThread()
        {
            Thread thBack = new Thread(() => { Console.WriteLine("Hi I'm background"); });
            thBack.IsBackground = true;
            thBack.Start();

            Console.WriteLine("I'm main thread and forground thread");
            Thread.CurrentThread.IsBackground = true;
            Console.WriteLine("Thread name :" + Thread.CurrentThread.Name);
            Console.WriteLine("Main thread is background :" + Thread.CurrentThread.IsBackground);
        }

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
            //threadingBasic.ShareVariable();
            threadingBasic.BackgroundThread();
        }
    }
}
