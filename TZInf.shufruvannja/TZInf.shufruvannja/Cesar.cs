using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TZInf.shufruvannja
{
    class Cesar
    {
        private char[] alpha = " .,;-ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
       
        private int key;
        public Cesar(int KEY) { key = (KEY > alpha.Length) ? KEY % alpha.Length : KEY; }
        public char chifer(char c) 
        {
            
            for (int i = 0; i < alpha.Length; i++)
            {
                if (c==alpha[i])
                {
                    int n = (i + key >= alpha.Length) ? i + key - alpha.Length : i + key;
                    return alpha[n];
                }
            }
            
            return c;
        }
    }
}
