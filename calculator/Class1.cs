using System;

namespace сalculator
{
    public class translator
    {
        private int ToInt(char c)                       // Переводит буквы в числа  //
        {
            if (c <= 57 && c >= 48)
            {
                return c - '0';
            }
            else if (c <= 90 && c >= 65)
            {
                return 10 + c - 'A';
            }
            else
            {
                return -1;
            }
        }

        private char ToChar(int n)                      // Переводит числа в буквы  //
        {
            if (n <= 9 && n >= 0)
            {
                return Convert.ToChar(n + '0');
            }
            else if (n >= 10 && n <= 35)
            {
                return Convert.ToChar(n + 'A' - 10);
            }
            else
            {
                return 'a';
            }
        }

        private double Poww(int x, int y)               // Кастомная функция        //
        {                                               // возведения в степень     //
            if (y >= 0)                                 // Возводит в отрицателную  //
            {                                           // степень                  //
                return Math.Pow(x, y);
            }
            if (y < 0)
            {
                return 1 / Math.Pow(x, -y);
            }
            else
            {
                return 1;
            }
        }

        public char[] translate(char[] s, int b1, int b2)
        {
            int f = 0;
            int k = 5;
            char[] ou = new char[20];
            double NN = 0.0;

            for (int i = 0; i < s.Length; i++)          // Поиск ','                //
            {
                if (s[i] == ',')
                {
                    f = i;                              // Запиываем ее положение   //
                    break;
                }
            }

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != ',')
                {
                    f--;
                    NN += ToInt(s[i]) * Poww(b1, f);    // переводим в десятичную   //
                }                                       //                  систему //
            }

            f = (int)NN;                                // Извлекаем целую часть    //
            NN = NN - f;                                // Отделяем остальное       //
            char[] temp = new char[20];
            int r1 = 1;

            while (f != 0)                               // Переводим целую часть    // 
            {
                temp[r1] = ToChar(f % b2);
                f /= b2;
                r1++;
            }

            int j = 0;

            for (int i = r1 - 1; i >= 1; i--, j++)      // Переварачиваем ее        //
            {
                ou[j] = temp[i];
            }
            ou[j++] += ',';

            r1 = 1;
            f = 0;

            for (; (NN != 0) && (r1 <= k); r1++, j++)   // Переводим остальное      //
            {
                f = (int)(NN * b2);
                NN *= b2;
                ou[j] = ToChar(f);
                NN -= f;
            }

            return ou;
        }
    }
}
