using System;
using System.Threading;

public class MyThread {

        public void Thread1() {
                for (int i = 0; i < 10; i++) {
                        Console.WriteLine("Thread1 {0}", i);
                }
        }

        public void Thread2() {
                for (int i = 0; i < 10; i++) {
                        Console.WriteLine("Thread2 {0}", i);
                }
        }
}

public class MyClass {

        public static void MainRun() {
                Console.WriteLine("Before start thread");

		MyThread thr = new MyThread();

                Thread tid1 = new Thread(new ThreadStart(thr.Thread1) );
                Thread tid2 = new Thread(new ThreadStart(thr.Thread2) );

                tid1.Start();
                tid2.Start();
        }
}