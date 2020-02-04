using System;
using System.Threading;


namespace PessoaAPI.utils
{
    public sealed class SingletonSample
    {
        static SingletonSample()
        {
        }

        private SingletonSample()
        {
        }

        private static bool isRunning = false;

        private static readonly SingletonSample _instance = new SingletonSample();

        public static SingletonSample Instance
        {
            get{ return _instance;}
        }

        public void processing()
        {

            if (isRunning == false)
            {

                try
                {
                    changeRunStatus();
                    Thread.Sleep(15000);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error -> " + e.Message);
                }
                finally
                {
                    changeRunStatus();
                }

            }

        }

        public void changeRunStatus()
        {
            isRunning = !isRunning;
        }

        public bool isWorkInProgress() => isRunning;

    }

}