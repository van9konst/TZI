using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TZInf.shufruvannja
{
    class Vijiner
    {
        private char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();//"ABCDEFGHIJKLMNOPQRSTUVWXYZ .,;-ABCDEFGHIJKLMNOPQRSTUVWXYZ .,;-"
        private char[] keyword;
        private static int k;
        public Vijiner(string KEY) { keyword = KEY.ToCharArray(); k = -1; }
        private int findLetter(char c)
        {
            for (int i = 0; i < alpha.Length/2; i++)
            {
                if (c == alpha[i])
                {
                    return i;
                }
            }
            return -1;
        }
        public char chifer(char c) 
        {

            k++;

            int key = findLetter(keyword[k % keyword.Length]);
            if (!char.IsLetter(c))
            {
                k--;
               return c;
            }
            if (key>0)
            {
                return alpha[findLetter(c) + key];    
            }
            else
            {
                return c;
            }
            
        }
    }
}
