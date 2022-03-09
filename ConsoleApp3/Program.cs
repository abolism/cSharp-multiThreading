using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            ThreadStart thS1 = new ThreadStart(thread1);
            Thread th1 = new Thread(thS1);
            ThreadStart thS2 = new ThreadStart(thread2);
            Thread th2 = new Thread(thS2);
            ThreadStart thS3 = new ThreadStart(thread3);
            Thread th3 = new Thread(thS3);
            th1.Start();
            th2.Start();
            th3.Start();
            th1.Join();
            try
            {
                th3.Interrupt();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);  
            }





        }
        public static void counter()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }
        }
        public void counterAsync()
        {
            lock (this) { counter(); }

        }
        public static void thread1()
        {
            Console.WriteLine("thread 1");
            counter();
        }
        public static  void thread2()
        {
            Console.WriteLine("thread 2");
            Thread.Sleep(5000);
            counter();
            //return "thread 2 done";
        }
        public static void thread3()
        {
            Console.WriteLine("thread 3");
            counter();
        }
    }
    public class SyncMethods
    {
        public void counter()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }
        }
        public void counterAsync()
        {
            lock (this) { counter(); }

        }
    }
}
