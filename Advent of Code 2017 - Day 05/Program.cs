using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Advent_of_Code_2017___Day_05
{
    class Program
    {
        static void Main(string[] args)
        {
            //Import the text file into the input array and create a blank list
            //string[] input = File.ReadAllLines(@"C:\Users\ben.rendall\Drive Documents\Visual Studio\Projects\Advent of Code 2017\Day 05\input.txt");
            string[] input = File.ReadAllLines(@"E:\Benneh\Documents\Projects\Visual Studio\Advent of Code 2017\Day 05\input.txt");
            List<int> inputIntList = new List<int>();

            //Loop through the input array and convert each item to an interger then add it to the list
            foreach(string x in input)
            {
                inputIntList.Add(Convert.ToInt32(x));
            }

            //Add a couple new variables ready for the main function
            bool inSequence = true;
            int stepsTaken = 0;
            int sequencePlace = 0;
            int sequencePrev;

            //Begin the main loop of this function
            while(inSequence == true)
            {
                //Set the previous int to where we are now, before we make any changes
                sequencePrev = sequencePlace;

                //Escapsulate everything in a try/catch to identify the out of range error when we escape the instruction list
                try
                {
                    sequencePlace = sequencePlace + inputIntList[sequencePlace];
                    inputIntList[sequencePrev] = inputIntList[sequencePrev] + 1;
                    stepsTaken++;
                }
                catch(ArgumentOutOfRangeException)
                {
                    //Out of range was caught, sequence has escaped the list
                    inSequence = false;
                }
            }

            Console.WriteLine(string.Format("Section 1 - Number of steps taken to escape: {0}", stepsTaken));

            ////Section 2////

            //Reset all variables
            inSequence = true;
            stepsTaken = 0;
            sequencePlace = 0;
            sequencePrev = 0;
            inputIntList.Clear();

            //Refill the int list with original unaltered values
            foreach (string x in input)
            {
                inputIntList.Add(Convert.ToInt32(x));
            }

            //Begin the main loop of this function
            while (inSequence == true)
            {
                //Set the previous int to where we are now, before we make any changes
                sequencePrev = sequencePlace;

                //Escapsulate everything in a try/catch to identify the out of range error when we escape the instruction list
                try
                {
                    //Perform the jump
                    sequencePlace = sequencePlace + inputIntList[sequencePlace];


                    int seqPrevInt = inputIntList[sequencePrev];


                    //Check if the previous place is < / > 3
                    if (inputIntList[sequencePrev] >= 3)
                    {
                        //Decrease the previouse place by 1
                        inputIntList[sequencePrev] = inputIntList[sequencePrev] - 1;
                    }
                    else
                    {
                        //Increase the previous place by 1
                        inputIntList[sequencePrev] = inputIntList[sequencePrev] + 1;
                    }

                    stepsTaken++;
                }
                catch (ArgumentOutOfRangeException)
                {
                    //Out of range was caught, sequence has escaped the list
                    inSequence = false;
                }
            }

            Console.WriteLine(string.Format("Section 2 - Number of steps taken to escape: {0}", stepsTaken));

            Console.ReadKey();
        }
    }
}
