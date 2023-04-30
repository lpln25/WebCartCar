using System.Text.RegularExpressions;

namespace CartCar.App.Models
{
    public class IranNationalCode
    {
        /// <summary>
        /// چک کردن کد ملی
        /// </summary>
        /// <param name="val">کد ملی</param>
        /// <returns>true: اگر صحیح باشد </returns>
        public static bool validator(string val)
        {
            for (int i = 1; i < 10; i++)
            {
                if (val.Length < 10)
                {
                    val = "0" + val;
                }
                else if (val.Length == 10)
                {
                    break;
                }
            }
            List<string> allDigitEqual = new List<string> { "0000000000", "1111111111", "2222222222", "3333333333", "4444444444", "5555555555", "6666666666", "7777777777", "8888888888", "9999999999" };
            Regex codeMelliPattern = new Regex("^([0-9]{10})+$");

            if (allDigitEqual.IndexOf(val) != -1 || !codeMelliPattern.IsMatch(val))
            {
                return false;
            }


            char[] chArray = new char[val.Length];
            for (int i = 0; i < val.Length; i++)
            {
                chArray[i] = val[i];
            }


            try
            {
                var num0 = Int32.Parse(chArray[0].ToString()) * 10;
                var num2 = Int32.Parse(chArray[1].ToString()) * 9;
                var num3 = Int32.Parse(chArray[2].ToString()) * 8;
                var num4 = Int32.Parse(chArray[3].ToString()) * 7;
                var num5 = Int32.Parse(chArray[4].ToString()) * 6;
                var num6 = Int32.Parse(chArray[5].ToString()) * 5;
                var num7 = Int32.Parse(chArray[6].ToString()) * 4;
                var num8 = Int32.Parse(chArray[7].ToString()) * 3;
                var num9 = Int32.Parse(chArray[8].ToString()) * 2;
                var a = Int32.Parse(chArray[9].ToString());
                var b = (((((((num0 + num2) + num3) + num4) + num5) + num6) + num7) + num8) + num9;
                var c = b % 11;
                return (((c < 2) && (a == c)) || ((c >= 2) && ((11 - c) == a)));
            }
            catch (Exception ex)
            {

                throw;
            }
            //var chArray = Array.from(val);

        }
    }
}
