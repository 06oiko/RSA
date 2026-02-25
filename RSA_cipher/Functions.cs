using System;
using System.Numerics;
using System.Text;
using static RSA_cipher.GlobalVariables;

namespace RSA_cipher
{
    internal class Functions
    {
        private static readonly Random random = new Random();

        private static BigInteger GenerateRandom13DigitNumber()
        {
            BigInteger minValue = BigInteger.Pow(10, 12);
            BigInteger maxValue = BigInteger.Pow(10, 13) - 1;

            byte[] buffer = new byte[13];
            lock (random)
            {
                random.NextBytes(buffer); // generate random 13 bytes for number
            }

            BigInteger result = new BigInteger(buffer);

            result = BigInteger.Abs(result % (maxValue - minValue + 1)) + minValue; // range of numbers: (maxValue - minValue + 1), (+min value) for back to range if % will 0

            if (result % 2 == 0)
            {
                result += 1;
                if (result > maxValue)
                {
                    result -= 2;
                }
            }

            return result;
        }

        internal static bool CheckPrimary(BigInteger test_number, int k)
        {
            if (test_number < 2) return false;
            if (test_number == 2 || test_number == 3) return true;
            if (test_number % 2 == 0) return false;

            BigInteger d = test_number - 1;

            int pow = 0;

            while (d % 2 == 0)
            {
                d /= 2;
                pow++;
            }

            for (int i = 0; i < k; i++)
            {
                byte[] buffer = new byte[test_number.ToByteArray().Length]; // generate bytes in max_range

                BigInteger random_number_for_test;

                do
                {
                    lock (random)
                    {
                        random.NextBytes(buffer);
                    }

                    random_number_for_test = BigInteger.Abs(new BigInteger(buffer));
                }
                while (random_number_for_test < 2 || random_number_for_test > test_number - 2);

                BigInteger x = BigInteger.ModPow(random_number_for_test, d, test_number);

                if (x == 1 || x == test_number - 1) continue;

                bool passedRound = false;

                for (int r = 1; r < pow; r++)
                {
                    x = BigInteger.ModPow(x, 2, test_number);

                    if (x == test_number - 1)
                    {
                        passedRound = true;
                        break;
                    }
                }

                if (!passedRound) return false;
            }

            return true;
        }

        public static BigInteger GeneratePrimeRandomNumber()
        {
            BigInteger a = new BigInteger();

            do
            {
                a = GenerateRandom13DigitNumber();
            }
            while (CheckPrimary(a, 4) != true);

            return a;
        }

        public static void CalculateEiler(BigInteger p, BigInteger q)
        {
            eiler = (p - 1) * (q - 1);
        }

        public static void OpenExponent()
        {
            enc_exp = 65537;
            if (BigInteger.GreatestCommonDivisor(enc_exp, eiler) != 1)
            {
                enc_exp = 257;
                if (BigInteger.GreatestCommonDivisor(enc_exp, eiler) != 1)
                {
                    enc_exp = 17;
                    if (BigInteger.GreatestCommonDivisor(enc_exp, eiler) != 1)
                    {
                        throw new Exception("enc_exp none");
                    }
                }
            }
        }

        public static void DecipherExponent(BigInteger baseValue, BigInteger modulus)
        {
            BigInteger originalModulus = modulus;
            BigInteger temp;
            BigInteger quotient;
            BigInteger previousCoefficient = 0;
            BigInteger currentCoefficient = 1;

            while (baseValue > 1)
            {
                quotient = baseValue / modulus;

                temp = modulus;
                modulus = baseValue % modulus;
                baseValue = temp;

                temp = previousCoefficient;
                previousCoefficient = currentCoefficient - quotient * previousCoefficient;
                currentCoefficient = temp;
            }

            if (currentCoefficient < 0) currentCoefficient += originalModulus;

            dec_exp = currentCoefficient;
        }

        internal static void InitConstant(BigInteger a, BigInteger b)
        {
            mod = a * b;
            CalculateEiler(a, b);
            OpenExponent();
            DecipherExponent(enc_exp, eiler);
        }

        internal static string Encrypt(BigInteger m)
        {
            return BigInteger.ModPow(m, enc_exp, mod).ToString();
        }

        internal static BigInteger Decrypt(BigInteger c)
        {
            return BigInteger.ModPow(c, dec_exp, mod);
        }

        internal static BigInteger StringToBigInteger(string input)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(input);


            byte[] unsignedByteArray = new byte[byteArray.Length + 1];
            Array.Copy(byteArray, 0, unsignedByteArray, 1, byteArray.Length);

            Array.Reverse(unsignedByteArray);

            return new BigInteger(unsignedByteArray);
        }

        internal static string BigIntegerToString(BigInteger bigInt)
        {
            byte[] byteArray = bigInt.ToByteArray();
            Array.Reverse(byteArray);
            return Encoding.UTF8.GetString(byteArray).Replace("\0", "").TrimEnd('\0');
        }

        internal static string[] DivideString(string str, int chunkSize)
        {
            int numberOfChunks = (str.Length + chunkSize - 1) / chunkSize;
            string[] result = new string[numberOfChunks];

            for (int i = 0; i < numberOfChunks; i++)
            {
                int startIndex = i * chunkSize;
                int length = Math.Min(chunkSize, str.Length - startIndex);
                result[i] = str.Substring(startIndex, length);
            }

            return result;
        }
    }
}
