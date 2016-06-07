using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TZInf.shufruvannja
{
    class ProstoiZaminu
    {
        private char[] alphaIN = " .,;-ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        private static char[] alphaOUT = " .,;-ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        public string GetAlphaIN()
        {
            return new string(alphaIN);
        }
        public string GetAlphaOUT()
        {
            return new string(alphaOUT);
        }
        public void alphaREplace(char a, char b)
        {
            for (int i = 0; i < alphaIN.Length; i++)
            {
                if (alphaIN[i]==a)
                {
                    alphaOUT[i] = b;
                    break;
                }
            }
           
        }
        private int findLetter(char c)
        {
            for (int i = 0; i < alphaIN.Length; i++)
            {
                if (c == alphaIN[i])
                {
                    return i;
                }
            }
            return -1;
        }
        public char chifer(char c)
        {
            int key = findLetter(c);
            return (key >= 0) ? alphaOUT[findLetter(c)] : c; 
            
        }
    }
}
