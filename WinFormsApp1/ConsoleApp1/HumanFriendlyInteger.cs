using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public  class HumanFriendlyInteger
    {
        
        static string[] ones = new string[] { " Không", "Một", "Hai", "Ba", "Bốn", "Năm", "Sáu", "Bảy", "Tám", "Chín" }; 
        static string[] teens = new string[] { "Mười", "Mười Một", "Mười Hai", "Mười Ba", "Mười Bốn", "Mười Năm", "Mười Sáu", "Mười Bảy", "Mười Tám", "Mười Chín" };
        static string[] tens = new string[] { "Hai Mươi", "Ba Mươi", "Bốn Mươi", "Năm Mươi", "Sáu Mươi", "Bảy Mươi", "Tám Mươi", "Chín Mươi" };
        static string[] thousandsGroups = { "", " Nghìn. ", " Triệu. ", " Tỉ. " };
        //tạo mảng biên string 
        private  string FriendlyInteger(int n, string leftDigits, int thousands)
        {
            
            if (n == 0)
            {
                return leftDigits; 
            }

            string friendlyInt = leftDigits;

            if (friendlyInt.Length > 0)
            {
                friendlyInt += " ";
            }

            if (n < 10)
            {
                friendlyInt += ones[n];
            }
            else if (n < 20)
            {
                friendlyInt += teens[n - 10];
            }
            else if (n < 100)
            {
                friendlyInt += FriendlyInteger(n % 10, tens[n / 10 - 2], 0);
            }
            else if (n < 1000)
            {
                friendlyInt += FriendlyInteger(n % 100, (ones[n / 100] + " Trăm"), 0);
            }
            else
            {
                friendlyInt += FriendlyInteger(n % 1000, FriendlyInteger(n / 1000, "", thousands + 1), 0);
                if (n % 1000 == 0)
                {
                    return friendlyInt;
                }
            }

            return friendlyInt + thousandsGroups[thousands];
        }

        public  string IntegerToWritten(int n)
        {
            if (n == 0)
            {
                return "Không";
            }
            else if (n < 0)
            {
                return "Âm " + IntegerToWritten(-n);
            }

            return FriendlyInteger(n, "", 0);
        }
    }
}
