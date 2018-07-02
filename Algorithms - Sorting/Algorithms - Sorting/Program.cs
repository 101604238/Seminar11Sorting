using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms___Sorting
{
    class Program
    {
        public static void Main(string[] args)
        {
            //List<int> sortedData = InsertionSort();
            //WriteToFile(sortedData);
            //LinearSearch();
            //Console.ReadKey();
            //BinarySearch();
            //Console.ReadKey();
            
            //Console.WriteLine("Would you like to run an insertion sort or a shell sort?");
            //string input = Console.ReadLine();


            List<int> sortedData = ReadFromFile();
            int interval = sortedData.Count;
            while (interval > -1)
            {
                BinarySearch(sortedData, interval);
                interval -= 1500;
            }
            Console.ReadKey();
            Console.WriteLine("Conclusion");
            Console.ReadKey();
        }

        public static void WriteToFile(List<int> sortedlist)
        {
            var filePath = (@"E:/Swinburne/Diploma/Programming Weekly Submittables/Week 14 - Unsorted Numbers/sorted_numbers.csv");
            using (var sw = new StreamWriter(filePath))
            {
                foreach (var value in sortedlist)
                {
                    sw.WriteLine(value);
                }
            }
        }

        public static List<int> ReadFromFile()
        {
            var filePath = (@"E:/Swinburne/Diploma/Programming Weekly Submittables/Week 14 - Unsorted Numbers/sorted_numbers.csv");
            List<string> dataString;
            List<int> dataInt = new List<int>();

            dataString = File.ReadAllLines(filePath).ToList();

            for (int i = 0; i < dataString.Count; i++)
            {
                dataInt.Add(int.Parse(dataString[i]));
            }

            return dataInt;

        }

        public static List<int> InsertionSort(List<string> data)
        {
            string[] stringNumbersArray = data.ToArray();
            int[] numbersArray = Array.ConvertAll(stringNumbersArray, s => int.Parse(s));

            for (int i = 0; i < numbersArray.Length - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (numbersArray[j - 1] > numbersArray[j])
                    {
                        int temp = numbersArray[j - 1];
                        numbersArray[j - 1] = numbersArray[j];
                        numbersArray[j] = temp;
                    }
                }
            }
            List<int> sortedList = new List<int>(numbersArray);
            return sortedList;
        }

        public static List<int> ShellSort()
        {
            var filePath = (@"H:/Swinburne/Diploma/Programming Weekly Submittables/Week 14 - Unsorted Numbers/unsorted_numbers.csv");
            var csv_numbers = File.ReadAllLines(filePath).ToList();

            string[] stringNumbersArray = csv_numbers.ToArray();
            int[] numbersArray = Array.ConvertAll(stringNumbersArray, s => int.Parse(s));

            int totalNums = numbersArray.Length;
            int gap = totalNums / 2;
            int temp;

            while (gap > 0)
            {
                for (int i = 0; i + gap < totalNums; i++)
                {
                    int j = i + gap;
                    temp = numbersArray[j];

                    while (j - gap >= 0 && temp < numbersArray[j - gap])
                    {
                        numbersArray[j] = numbersArray[j - gap];
                        j = j - gap;
                    }

                    numbersArray[j] = temp;
                }
                gap = gap / 2;
            }
            List<int> sortedList = new List<int>(numbersArray);
            return sortedList;
        }

        public static void LinearSearch()
        {
            var filePath = (@"E:/Swinburne/Diploma/Programming Weekly Submittables/Week 14 - Unsorted Numbers/sorted_numbers.csv");
            
            using (var sr = new StreamReader(filePath))
            {
                var data = File.ReadAllLines(filePath).ToList();

                for (int i = data.Count - 1; i > -1 ; i--)
                {
                    if ((i + 1) % 1500 == 0)
                    {
                        Console.WriteLine(data[i]);
                    } 
                }
            }
        }

        public static void BinarySearch(List<int> sortedData, int input)
        {
            int min = 0;
            int max = input;

            while (min <= max)
            {
                int mid = (min + max) / 2;

                if(mid == (input - 1))
                {
                    Console.WriteLine(sortedData[mid]);
                    return;
                }
                else if(mid > input)
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return;
        }
    }
}
