using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IT481_Unit6_CSharp
{
    class DressingRooms
    {

        int rooms;
        Semaphore semaphore;
        long waitTimer;
        long runTimer;

        
        public DressingRooms()
        {
            rooms = 3;
            semaphore = new Semaphore(rooms, rooms);
        }

        public DressingRooms(int r)
        {

            rooms = r;
            //Set the semaphore object
            semaphore = new Semaphore(rooms, rooms);

        }

        public async Task RequestRoom(Customer c)
        {
            Stopwatch stopwatch = new Stopwatch();
            //Waiting thread
            Console.WriteLine("Customer is waiting");

            //Start the timer
            stopwatch.Start();
            semaphore.WaitOne();
            //Stop the wait timer
            stopwatch.Stop();
            //Get the time elapsed for waiting
            waitTimer += stopwatch.ElapsedTicks;

            int roomWaitTime = GetRandomNumber(1, 3);
            //Start the timer
            stopwatch.Start();
            Thread.Sleep((roomWaitTime * c.getNumberOfItems()));
            //Stop the wait timer
            stopwatch.Stop();
            //Get the elapsed run time
            runTimer += stopwatch.ElapsedTicks;

            Console.WriteLine("Customer finished trying on items in room");
            semaphore.Release();


        }

        public long getWaitTime()
        {
            return waitTimer;
        }

        public long getRunTime()
        {
            return runTimer;
        }

        //Random number methods
        private static readonly Random getrandom = new Random();

        public static int GetRandomNumber(int min, int max)
        {

            lock (getrandom)
            {
                return getrandom.Next(min, max);

            }
        }
       
        }
    }

