using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Services
{
    public class IdConverter
    {
        public int GetIntID(string stringID)
        {
            int sum = 0;
            for(int i=0;i<stringID.Length;i++)
            {
                //we add ascii value to the sum
                sum += stringID.ElementAt<char>(i).GetHashCode();
            }
            return sum%Int32.MaxValue;
        }

        /*public string GetStringID(int intID)
        {
            int primeNumber = 1, divideResult = 0 ;
            int ID = intID;
            string stringID = new("");
            while (primeNumber < intID)
            {
                primeNumber *= 23;
            }
            while(ID > 0)
            {
                divideResult = ID / primeNumber;
                ID /= primeNumber;
                stringID.Append<char>((char)divideResult);
            }
            return stringID;
        }*/
    }
}
