using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicThreading
{
    public partial class FrmBasicThread : Form
    {
        Thread threadA, threadB;

        private void button1_Click(object sender, EventArgs e)
        {
            StartThreads();
        }

        public FrmBasicThread()
        {
           
            InitializeComponent();
            label1.Text = "-Before starting thread-";
        }
       
        private void StartThreads()
        {
            Console.WriteLine("-Before starting thread-");
            threadA = new Thread(MyThreadClass.Thread1) { Name = "Thread A", Priority = ThreadPriority.Highest};
            threadB = new Thread(MyThreadClass.Thread1) { Name = "Thread B", Priority = ThreadPriority.Normal};
           

            threadA.Start();
            threadB.Start();
            
            threadA.Join();
            threadB.Join();

            Console.WriteLine("End Of Thread");
            label1.Text = "-End Of Thread-";
        }
    
    }
}


namespace BasicThreading
{
    public static class MyThreadClass
    {
        public static void Thread1()
        {
            for (int i = 0; i < 6; i++)
            {
                Thread.Sleep(1500); 
                Console.WriteLine("Name of Thread: " + Thread.CurrentThread.Name + " = " + i);


            }
        }
   
    }
}

    

