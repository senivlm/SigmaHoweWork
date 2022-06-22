using System;
using System.Collections.Generic;
using System.IO;

namespace HomeWork6
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region Task 7.1
            //Task1Program task = new Task1Program("data.txt");
            //task.InputData();
            //task.OutputAll();
            //task.OutputFlat(2);
            //task.OutputMostEnergyUsed();
            //task.OutputNoEnergyUsed();
            //task.OutputDataIntoFile("newData.txt");
            //task.NeedToPay();
            //task.daysFromLastData(3);
            #endregion
            #region Task 7.2
            //FileEditer fileEditer = new FileEditer("text.txt");
            //fileEditer.GetSentences();
            //fileEditer.PrintText();
            //fileEditer.PrintLongestShortest();
            //fileEditer.ChangeWord("Goog morning", 1, 1);
            //fileEditer.PrintTextIntoFile();
            #endregion
            #region Task 8.1
            //FlatData flat1 = new FlatData("Roma", 1);
            //FlatData flat2 = new FlatData("Papa", 2);
            //Task1Program task = new Task1Program(flat1, flat2);
            //Task1Program task2 = new Task1Program(flat2);
            //Task1Program task3 = task - task2;
            //Console.WriteLine(task3.FlatsCount);
            //task3 = task + task2;
            //Console.WriteLine(task3.FlatsCount); 
            #endregion
            #region Task 8.2
            IPScaner scaner = new IPScaner("ip.txt");
            scaner.ReadFife();
            scaner.MostPopularDay();
            #endregion
        }
    }
}
