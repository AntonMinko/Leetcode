using System;
using System.Collections.Generic;
using System.Linq;

namespace vscode
{
    public class AddUniqueNumbers 
    {
        public int FindAllUniqueNumbers()
        {
            // Console.WriteLine($"Number {1236780} is unique: {IsUniqueDigits(1236780, new HashSet<int>())}" );
            // Console.WriteLine($"Number {1236180} is unique: {IsUniqueDigits(1236180, new HashSet<int>())}" );
            // Console.WriteLine($"Number {1236780} is unique: {IsUniqueDigits(1236780, new HashSet<int>(new[] {5, 8}))}" );
        int count = 0;
            for(int i=100; i < 1000; i++)
            //int i = 432;
            {
                var uniqueDigits = new HashSet<int>();
                if (!IsUniqueDigits(i, uniqueDigits))
                {
                    continue;
                    //return count;
                }
                for(int j=100; j<1000; j++)
                //int j = 657;
                {
                    var uniqueDigits2 = new HashSet<int>(uniqueDigits);
                    if (!IsUniqueDigits(j, uniqueDigits2))
                    {
                        continue;
                        //return count;
                    }

                    int sum = i+j;

                    //++count;
                    //Console.WriteLine($"{count}. {i}+{j}={sum} is not unique");
                    if (sum > 1000 && IsUniqueDigits(sum, uniqueDigits2))
                    {
                        ++count;
                        Console.WriteLine($"{count}. {i}+{j}={sum}");
                    }
                }
            }

            return count;
        }

        private bool IsUniqueDigits(int number, HashSet<int> usedDigits)
        {
            var usedDigitsCopy = new HashSet<int>(usedDigits.ToArray());

            var digits = Split(number);
            foreach(int digit in digits)
            {
                if (usedDigitsCopy.Contains(digit))
                {
                    return false;
                }
                usedDigitsCopy.Add(digit);
            }

            foreach(int digit in digits)
            {
                usedDigits.Add(digit);
            }
            return true;
        }
        private IEnumerable<int> Split(int number)
        {
            //Console.WriteLine($"Splitting {number}");
            List<int> digits = new List<int>();
            while(number > 0)
            {
                int digit = number % 10;
                //Console.WriteLine($"Digit = {digit}");
                digits.Insert(0, digit);
                number = number / 10;
            }

            return digits;
        }
    }

}