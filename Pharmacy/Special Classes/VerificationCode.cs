using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy
{
    internal class VerificationCode
    {
        private Random obj1 = new Random();
        private string generatedCode = "";
        private string[] uppercaseCharcterCollections = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "G", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        private string[] lowercaseCharcterCollections = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "g", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
        private string[] numberCharacterCollections = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

        private void codeGenerator(Random obj1)
        {
            int countone = 0, counttwo = 0, countthree = 0;
            for (int i = 0; i < 12; i++)
            {

                int tempNum = obj1.Next(1, 4);
                if (tempNum == 1)
                    countone++;
                if (tempNum == 2)
                    counttwo++;
                if (tempNum == 3)
                    countthree++;
                while (countone > 4 && tempNum == 1)
                    tempNum = obj1.Next(1, 4);
                while (counttwo > 4 && tempNum == 2)
                    tempNum = obj1.Next(1, 4);
                while (countthree >= 4 && tempNum == 3)
                    tempNum = obj1.Next(1, 4);


                switch (tempNum)
                {
                    case 1:
                        tempNum = obj1.Next(0, 25);
                        generatedCode += uppercaseCharcterCollections[tempNum];
                        break;
                    case 2:
                        tempNum = obj1.Next(0, 25);
                        generatedCode += lowercaseCharcterCollections[tempNum];
                        break;
                    case 3:
                        tempNum = obj1.Next(0, 10);
                        generatedCode += numberCharacterCollections[tempNum];
                        break;
                }
            }

        }
        public string GeneratedCode
        {
            get { codeGenerator(obj1); return generatedCode; }
            set { generatedCode = value; }
        }
    }
}
