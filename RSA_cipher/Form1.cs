using System;
using System.Text;
using System.Windows.Forms;
using System.Numerics;
using static RSA_cipher.Functions;
using static RSA_cipher.GlobalVariables;

namespace RSA_cipher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static bool IsRsaInitialized()
        {
            return mod > 0 && enc_exp > 0 && dec_exp > 0;
        }

        private bool TryReadPrimeInputs(out BigInteger a, out BigInteger b)
        {
            a = 0;
            b = 0;

            if (!BigInteger.TryParse(textBoxPrvocisloP.Text.Trim(), out a) || a <= 1)
            {
                MessageBox.Show("Prime P must be a valid integer greater than 1.");
                return false;
            }

            if (!BigInteger.TryParse(textBoxPrvocisloQ.Text.Trim(), out b) || b <= 1)
            {
                MessageBox.Show("Prime Q must be a valid integer greater than 1.");
                return false;
            }

            if (a == b)
            {
                MessageBox.Show("Prime P and Prime Q must be different values.");
                return false;
            }

            return true;
        }

        private void Random_button_Click(object sender, EventArgs e)
        {
            BigInteger a;
            BigInteger b;

            do
            {
                a = GeneratePrimeRandomNumber();
                b = GeneratePrimeRandomNumber();
            }
            while (a == b);

            InitConstant(a,b);

            textBoxPrvocisloP.Text = a.ToString();
            textBoxPrvocisloQ.Text = b.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!IsRsaInitialized())
            {
                MessageBox.Show("RSA parameters are not initialized yet.");
                return;
            }

            MessageBox.Show($"Module: {mod}\nEiler: {eiler}\nOpenExp: {enc_exp}\nDecExp: {dec_exp}");
        }

        private void Check_button_Click(object sender, EventArgs e)
        {
            if (!TryReadPrimeInputs(out BigInteger a, out BigInteger b))
            {
                return;
            }

            if (CheckPrimary(a, 4) && CheckPrimary(b, 4))
            {
                InitConstant(a, b);
                MessageBox.Show("Prime validation passed. RSA parameters initialized.");
            }
            else
            {
                MessageBox.Show("Prime validation failed. Please provide valid prime numbers.");
            }
        }

        private void Encrypt_button_Click(object sender, EventArgs e)
        {
            if (!IsRsaInitialized())
            {
                MessageBox.Show("Initialize RSA parameters first using Random or Check.");
                return;
            }

            if (string.IsNullOrEmpty(Open_textBox.Text))
            {
                MessageBox.Show("Plaintext is empty.");
                return;
            }

            StringBuilder cipher = new StringBuilder();
            int blockSize = 6;
            int encryptedBlockSize = 26;

            foreach (string block in DivideString(Open_textBox.Text, blockSize))
            {
                BigInteger m = StringToBigInteger(block);

                string encryptedBlock = Encrypt(m);

                encryptedBlock = encryptedBlock.PadLeft(encryptedBlockSize, '0');

                cipher.Append(encryptedBlock);
            }

            Cipher_textBox.Text = cipher.ToString();
        }

        private void Decrypt_button_Click(object sender, EventArgs e)
        {
            if (!IsRsaInitialized())
            {
                MessageBox.Show("Initialize RSA parameters first using Random or Check.");
                return;
            }

            if (string.IsNullOrWhiteSpace(Cipher_textBox.Text))
            {
                MessageBox.Show("Ciphertext is empty.");
                return;
            }

            StringBuilder message = new StringBuilder();
            int encryptedBlockSize = 26;
            string cipherInput = Cipher_textBox.Text.Trim();

            if (cipherInput.Length % encryptedBlockSize != 0)
            {
                MessageBox.Show("Ciphertext length is invalid for the current block size.");
                return;
            }

            for (int i = 0; i < cipherInput.Length; i += encryptedBlockSize)
            {
                string encryptedBlock = cipherInput.Substring(i, encryptedBlockSize);

                if (!BigInteger.TryParse(encryptedBlock, out BigInteger c))
                {
                    MessageBox.Show("Ciphertext contains non-numeric data.");
                    return;
                }

                BigInteger decryptedBlock = Decrypt(c);

                string decryptedString = BigIntegerToString(decryptedBlock);

                message.Append(decryptedString);
            }

            Open_textBox.Text = message.ToString();
        }
    }
}
