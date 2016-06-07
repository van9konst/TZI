using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TZInf.analiz.finaly
{
    class AnalizMain
    {
        public    char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ .',;-".ToCharArray();
        //public    int[] alphaFreak = new int[31];
        private   string path = @"L1.txt";
        public List<Grams> onegrams;
        public List<Grams> bigrams;
        public List<Grams> trigrams;
        public List<Grams> repitgrams;
        public void NewPath(string newpath) 
        {
            path = newpath;
        }


        public void CountBigrams()
        {
            if (File.Exists(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string s = "";
                    
                    while ((s = sr.ReadLine()) != null)
                    {
                        for (int i = 0; i < s.Length-1; i++)
                        {
                            bool bexist = false;
                            string somevalue;

                            somevalue = s.Substring(i, 2);
                            for (int ibigram = 0; ibigram < bigrams.Count; ibigram++)
                            {
                                if (bigrams[ibigram].Name == somevalue)
                                {
                                    bexist = true;
                                    if (!bigrams[ibigram].addStatus)
                                    {
                                        bigrams[ibigram].Counted +=  Regex.Matches(s, somevalue).Count;
                                    }
                                    break;
                                }
                            }
                            if (!bexist)
                            {
                                Grams gr = new Grams(somevalue, 1);
                                bigrams.Add(gr);
                                int j=bigrams.Count-1;
                                bigrams[j].Counted = Regex.Matches(s, somevalue).Count;
                                bigrams[j].addStatus = true;
                            }
                        }
                    }
                
                }
            }
        }
       
        public void CountTrigrams()
        {
            if (File.Exists(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string s = "";

                    while ((s = sr.ReadLine()) != null)
                    {
                        for (int i = 0; i < s.Length - 2; i++)
                        {
                            bool bexist = false;
                            string somevalue;
                            somevalue = s.Substring(i, 3);
                            for (int itrigram = 0; itrigram < trigrams.Count; itrigram++)
                            {
                                if (trigrams[itrigram].Name == somevalue)
                                {
                                    bexist = true;
                                    if (!trigrams[itrigram].addStatus)
                                    {
                                        trigrams[itrigram].Counted += Regex.Matches(s, somevalue).Count;
                                    }
                                    break;
                                }
                            }
                            if (!bexist)
                            {
                                Grams gr = new Grams(somevalue, 1);
                                trigrams.Add(gr);
                                int j = trigrams.Count - 1;
                                trigrams[j].Counted = Regex.Matches(s, somevalue).Count;
                                trigrams[j].addStatus = true;
                            }
                        }
                    }

                }
            }
        }

        public void OneSimbolAnalys()
        {
            if (File.Exists(path))
                {
                    using (StreamReader sr = File.OpenText(path))
                    {
                        string s = "";
                        while ((s = sr.ReadLine()) != null)
                        {
                            for (int i = 0; i < onegrams.Count; i++)
                            {
                                onegrams[i].Counted += s.Split(alpha[i]).Length - 1;
                                //alphaFreak[i] += s.Split(alpha[i]).Length - 1 ;
                            }
                        }
                      /*  for (int i = 0; i < alphaFreak.Length; i++)
                        {
                            Console.WriteLine("{0}    {1}", alpha[i], alphaFreak[i]);
                        }
                        Console.ReadKey();*/
                    }
                }
        }

        public void CountRepitgrams()
        {
            if (File.Exists(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string s = "";

                    while ((s = sr.ReadLine()) != null)
                    {
                        for (int i = 0; i < s.Length - 1; i++)
                        {
                            bool bexist = false;
                            string somevalue;
                                    if (s[i]==s[i+1])
                                    {
                                        somevalue = s.Substring(i, 2);
                                    }
                                    else
                                    {
                                        continue;
                                    }

                            for (int irepitgram = 0; irepitgram < repitgrams.Count; irepitgram++)
                            {
                                if (repitgrams[irepitgram].Name == somevalue)
                                {
                                    bexist = true;
                                    if (!repitgrams[irepitgram].addStatus)
                                    {
                                        repitgrams[irepitgram].Counted += Regex.Matches(s, somevalue).Count;
                                    }
                                    break;
                                }
                            }
                            if (!bexist)
                            {
                                Grams gr = new Grams(somevalue, 1);
                                repitgrams.Add(gr);
                                int j = repitgrams.Count - 1;
                                repitgrams[j].Counted = Regex.Matches(s, somevalue).Count;
                                repitgrams[j].addStatus = true;
                            }
                        }
                    }

                }
            }
        }

        public AnalizMain()
        {
            bigrams = new List<Grams>();
            repitgrams = new List<Grams>();
            trigrams = new List<Grams>();
            onegrams = new List<Grams>();
            for (int i = 0; i < 31; i++)
            {
                Grams g=new Grams(Convert.ToString(alpha[i]),0);
                onegrams.Add(g);
            }
        }

        public List<Grams> SortGrams(List<Grams> listG)
        { 
        return listG.OrderByDescending(y => y.Counted).ToList();
        }

    }
}
