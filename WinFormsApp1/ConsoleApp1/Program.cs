using System;
using System.Text;

namespace ConsoleApp1
{
     class Program
    {
        private static string ones(String number)
        {
            int _number = Convert.ToInt32(number);
            String name = "";
            switch (_number)
            {
                case 1:
                    name = "Một";
                    break;
                case 2:
                    name = "Hai";
                    break;
                case 3:
                    name = "Ba";
                    break;
                case 4:
                    name = "Bốn";
                    break;
                case 5:
                    name = "Năm";
                    break;
                case 6:
                    name = "Sáu";
                    break;
                case 7:
                    name = "Bảy";
                    break;
                case 8:
                    name = "Tám";
                    break;
                case 9:
                    name = "Chín";
                    break;
            }
            return name;
        }
        private static String tens(String number)
        {
            int _number = Convert.ToInt32(number);
            String name = null;
            switch (_number)
            {
                case 10:
                    name = "Mười";
                    break;
                case 11:
                    name = "Mười Một";
                    break;
                case 12:
                    name = "Mười Hai";
                    break;
                case 13:
                    name = "Mười Ba";
                    break;
                case 14:
                    name = "Mười Bốn";
                    break;
                case 15:
                    name = "Mười Năm";
                    break;
                case 16:
                    name = "Mười Sáu";
                    break;
                case 17:
                    name = "Mười Bảy";
                    break;
                case 18:
                    name = "Mười Tám";
                    break;
                case 19:
                    name = "Mười Chín";
                    break;
                case 20:
                    name = "Hai Mươi";
                    break;
                case 30:
                    name = "Ba Mươi";
                    break;
                case 40:
                    name = "Bốn Mươi";
                    break;
                case 50:
                    name = "Năm Mươi";
                    break;
                case 60:
                    name = "Sáu Mươi";
                    break;
                case 70:
                    name = "Bảy Mươi";
                    break;
                case 80:
                    name = "Tám Mươi";
                    break;
                case 90:
                    name = "Chín Mươi";
                    break;
                default:
                    if(_number > 0)
                    {
                        Console.WriteLine(number.Substring(1));
                        name = tens(number.Substring(0, 1) + "0") + " " + ones(number.Substring(1));
                    }
                    break;
            }
            return name;    
        }
        private static String ConvertWholeNumber(String number)
        {
            string word = "";
            try
            {
                bool beginsZero = false;
                bool isDone = false;
                double dbtAmt = Convert.ToDouble(number);
                if(dbtAmt > 0)
                {
                    beginsZero = number.StartsWith("0");
                    int numDigits = number.Length;
                    int pos = 0;//store digit grouping    
                    String place = "";
                    switch (numDigits) {
                        case 1:
                        word = ones(number);
                    isDone = true;
                     break;
                        case 2:
                            word = tens(number);
                            isDone = true;
                            break;
                        case 3:
                            pos = (numDigits % 3) + 1;
                            place = " Trăm ";
                            break;
                        case 4:
                        case 5:
                        case 6:
                            pos = (numDigits % 4) + 1;
                            place = " Nghìn ";
                            break;
                        case 7:
                        case 8:
                        case 9:
                            pos = (numDigits % 7) + 1;
                            place = " Triệu ";
                            break;
                        case 10:
                        case 11:
                        case 12:
                            pos = (numDigits % 10) + 1;
                            place = " Tỉ ";
                            break;
                        default: 
                            isDone = true;
                            break;
                    }
                    if (!isDone)
                    {
                        if(number.Substring(0, pos) != "0" && number.Substring(pos) != "0")
                        {
                            try
                            {
                                word = ConvertWholeNumber(number.Substring(0, pos)) + place + ConvertWholeNumber(number.Substring(pos));
                            }
                            catch { }
                        }
                        else
                        {
                            word = ConvertWholeNumber(number.Substring(0, pos)) + ConvertWholeNumber(number.Substring(pos));
                        }

                    }
                    if(word.Trim().Equals(place.Trim())) word = "";
                }
            }
            catch { }
            return word.Trim();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //TestConCua00 tcc = new TestConCua00();
            //tcc.FunctionTestCua();
            //Test_Cua_11 tc1 = new Test_Cua_11();
            //tc1.FunctionTestCua();
            //HumanFriendlyInteger hfi = new HumanFriendlyInteger();
            ////hfi.IntegerToWritten(12243435);
            //Console.OutputEncoding = Encoding.Unicode;
            //Console.WriteLine("nhập số: "); int number =Convert.ToInt32( Console.ReadLine());
            //string Written = hfi.IntegerToWritten(number);
            //Console.WriteLine(Written);
            tens("27");
        }
    }
}
