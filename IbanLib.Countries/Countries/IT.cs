using System;
using System.Globalization;
using System.Linq;

namespace IbanLib.Countries.Countries
{
    public class IT : ACountry
    {
        public override string Name
        {
            get { return "Italy"; }
        }

        public override string Iso3166
        {
            get { return "IT"; }
        }

        public override string BankCodeStructure
        {
            get { return "[0-9]{5}"; }
        }

        public override string BranchCodeStructure
        {
            get { return "[0-9]{5}"; }
        }

        public override string AccountNumberStructure
        {
            get { return "[0-9A-Z]{12}"; }
        }

        public override string BbanStructure
        {
            get
            {
                return string.Format(
                    "{0}{1}{2}{3}",
                    "[A-Z]{1}",
                    BankCodeStructure,
                    BranchCodeStructure,
                    AccountNumberStructure);
            }
        }

        public override int BbanLength
        {
            get { return 23; }
        }

        public override int IbanLength
        {
            get { return 27; }
        }

        public override bool IsSepa
        {
            get { return true; }
        }

        public override int BankCodePosition
        {
            get { return 5; }
        }

        public override int BankCodeLength
        {
            get { return 5; }
        }

        public override int? BranchCodePosition
        {
            get { return 10; }
        }

        public override int BranchCodeLength
        {
            get { return 5; }
        }

        public override int SwiftAccountNumberPosition
        {
            get { return 15; }
        }

        public override int SwiftAccountNumberLength
        {
            get { return 12; }
        }

        public override int Check1Length
        {
            get { return 1; }
        }

        public override int? Check1Position
        {
            get { return 4; }
        }

        # region Calculate Check 1

        private static readonly string[] FromChar =
        {
            "0", "1", "2", "3", "4", "5", "6", "7", "8", "9",
            "A", "B", "C", "D", "E", "F", "G", "H", "I", "J",
            "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T",
            "U", "V", "W", "X", "Y", "Z", "-", ".", " "
        };

        private static readonly int[] ToEvenScore =
        {
            0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
            0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
            10, 11, 12, 13, 14, 15, 16, 17, 18, 19,
            20, 21, 22, 23, 24, 25, 26, 27, 28
        };

        private static readonly int[] ToOddScore =
        {
            1, 0, 5, 7, 9, 13, 15, 17, 19, 21,
            1, 0, 5, 7, 9, 13, 15, 17, 19, 21,
            2, 4, 18, 20, 11, 3, 6, 8, 12, 14,
            16, 10, 22, 25, 24, 23, 27, 28, 26
        };

        private static readonly int[] FromScoreValue =
        {
            0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
            10, 11, 12, 13, 14, 15, 16, 17, 18, 19,
            20, 21, 22, 23, 24, 25, 26, 27, 28
        };

        private static readonly string[] ToScoreChar =
        {
            "A", "B", "C", "D", "E", "F", "G", "H", "I", "J",
            "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T",
            "U", "V", "W", "X", "Y", "Z", "-", ".", " "
        };

        public override string CalculateCheck1(string bankCode, string branchCode, string accountNumber)
        {
            if (!IsValidInputToCalculateChekDigits(bankCode, branchCode, accountNumber))
            {
                return null;
            }

            var score = 0;
            var concat = string.Concat(bankCode, branchCode, accountNumber);
            while (concat.Length < 22)
            {
                concat = string.Concat(concat, " ");
            }

            var even = false;
            int position;
            foreach (var k in concat.Select(c => c.ToString(CultureInfo.InvariantCulture).ToUpper()))
            {
                position = Array.IndexOf(FromChar, k);
                if (even && (position >= 0 && position < ToEvenScore.Length))
                {
                    score += ToEvenScore.ElementAt(position);
                }
                else if (!even && (position >= 0 && position < ToOddScore.Length))
                {
                    score += ToOddScore.ElementAt(position);
                }

                even = !even;
            }

            score = score%26;
            position = Array.IndexOf(FromScoreValue, score);
            if (position >= 0 && position < ToScoreChar.Length)
            {
                return ToScoreChar.ElementAt(position);
            }

            return null;
        }

        # endregion
    }
}