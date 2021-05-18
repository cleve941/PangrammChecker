using Pangramm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Pangramm
{
    public class PangrammChecker
    {
        private string input { get; set; }

        private static readonly Regex onlyLetters = new Regex("[^a-zA-Z]");

        private List<CharCounter> currentCharCounters = new List<CharCounter>();

        public PangrammChecker()
        {

        }
        public PangrammChecker(string input)
        {
            this.input = input.ToLower();
            this.currentCharCounters = this.countInputString();
        }


        public void setInputString(string input)
        {
            this.input = input.ToLower();
            this.currentCharCounters = this.countInputString();
        }

        private List<CharCounter> countInputString()
        {
            List<CharCounter> lstCharCounter = new List<CharCounter>();

            string stringInput = onlyLetters.Replace(input, String.Empty);
            foreach (char element in stringInput)
            {
                if (lstCharCounter.Where(_ => _.character == element).Any())
                {
                    lstCharCounter.Where(_ => _.character == element).FirstOrDefault().amount += 1;
                }
                else
                {
                    lstCharCounter.Add(new CharCounter { character = element, amount = 1 });
                }
            }
            return lstCharCounter;
        }

        public bool containsAllLettersExactlyOnce
        {
            get
            {
                // A letter exists more than once or there are not 26 letters
                if (currentCharCounters.Where(_ => _.amount > 1).Count() > 0 || currentCharCounters.Count() != 26)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public bool containsAllAlphabetLettersMoreThanOnce
        {
            get
            {
                // A letter exists more than once or there are not 26 letters
                if (currentCharCounters.Count() != 26)
                {
                    return false;

                }
                //Check for Elements Amount > 1
                else if (currentCharCounters.Where(_ => _.amount > 1).Count() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        public bool doesNotContainAllAlphabetLettersOnce
        {
            get
            {
                if (currentCharCounters.Count() != 26)
                {
                    return true;

                }
                else
                {
                    return false;
                }
            }
            
        }

    }
}
