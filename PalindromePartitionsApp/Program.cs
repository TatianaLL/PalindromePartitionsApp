using System;

using System.Collections.Generic;
using System.Text;

namespace PalindromePartitionsApp
{
    class Pradiusesgram
    {
        static void Main(string[] args)
        {

            Console.Write("Enter String: ");

            string str = Console.ReadLine(); 

            //Create 
            StringBuilder builder = new StringBuilder("#");
            foreach (char c in str)
            {
                builder.Append(c);
                builder.Append('#');
            }

            ManakerAlgorithmRealisation(builder.ToString());             
        }

        public static void ManakerAlgorithmRealisation(string str)
        {

            Console.WriteLine(str);

            int n = str.Length;
            int[] radiuses = new int[n];

            for (int i = 0; i < n; i++)
            {
                radiuses[i] = 1;
            } 

            int left = 0;
            int right = 0;


            for (int i = 1; i < n; i++)
            {
                int l;
                int r;

                if (i > right)
                {
                    l = i;
                    r = i;
                }
                else
                {
                    int mirradiusesrPosition = right + left - i;

                    l = i - radiuses[mirradiusesrPosition] + 1;
                    r = i + radiuses[mirradiusesrPosition] - 1;

                    if (r > right)
                    {

                        int delta = r - right;
                        r -= delta;
                        l += delta;
                    }
                }

                while (l - 1 >= 0 && r + 1 < n && str[l - 1] == str[r + 1])
                {
                    l--;
                    r++;
                }
                radiuses[i] = r - i + 1;

                if (r < right)
                {
                    left = l;
                    right = r;

                }
            }


            for (int i = 0; i < n; i++)
            {
                ShowPalindrom(i, radiuses[i], str);
            }

        }
        public static void ShowPalindrom(int index, int radius, string str)
        {
            if (radius > 1)
            {
                int startPos = index - radius + 1;
                int endPos = index + radius - 1;
                string subStr = str.Substring(startPos, endPos - startPos);
                Console.WriteLine(subStr.Replace("#", ""));
            }
        }

    }
}
