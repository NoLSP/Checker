using TaskChecker.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace TaskChecker.Helpers
{
    public static class CryptoHelper
    {
        private static byte[] key;
        private static string initVec = "a8doSuDitOz1hZe#";
        private static string cryptographicAlgorithm = "SHA1";
        private static int passIter = 2;
        private static int keySize = 256;
        private static string sol = "doberman";
        private static string pass = "nedbhg";

        public static bool TryEncrypt(string textToEnrypt, out string encryptedText)
        {
            encryptedText = null;

            if (string.IsNullOrEmpty(textToEnrypt))
                return false;

            try
            {
                byte[] initVecB = Encoding.ASCII.GetBytes(initVec);
                byte[] solB = Encoding.ASCII.GetBytes(sol);
                byte[] ishTextB = Encoding.UTF8.GetBytes(textToEnrypt);

                PasswordDeriveBytes derivPass = new PasswordDeriveBytes(pass, solB, cryptographicAlgorithm, passIter);
                byte[] keyBytes = derivPass.GetBytes(keySize / 8);
                RijndaelManaged symmK = new RijndaelManaged();
                symmK.Mode = CipherMode.CBC;

                byte[] cipherTextBytes = null;

                using (ICryptoTransform encryptor = symmK.CreateEncryptor(keyBytes, initVecB))
                {
                    using (MemoryStream memStream = new MemoryStream())
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(memStream, encryptor, CryptoStreamMode.Write))
                        {
                            cryptoStream.Write(ishTextB, 0, ishTextB.Length);
                            cryptoStream.FlushFinalBlock();
                            cipherTextBytes = memStream.ToArray();
                            memStream.Close();
                            cryptoStream.Close();
                        }
                    }
                }

                symmK.Clear();
                encryptedText = Convert.ToBase64String(cipherTextBytes);
            }
            catch(Exception e)
            {
                return false;
            }

            return true;
        }

        public static bool TryDecrypt(string textToDecrypt, out string decryptedText)
        {
            decryptedText = null;

            if (string.IsNullOrEmpty(textToDecrypt))
            {
                return false;
            }

            try
            {
                byte[] initVecB = Encoding.ASCII.GetBytes(initVec);
                byte[] solB = Encoding.ASCII.GetBytes(sol);
                byte[] cipherTextBytes = Convert.FromBase64String(textToDecrypt);

                PasswordDeriveBytes derivPass = new PasswordDeriveBytes(pass, solB, cryptographicAlgorithm, passIter);
                byte[] keyBytes = derivPass.GetBytes(keySize / 8);

                RijndaelManaged symmK = new RijndaelManaged();
                symmK.Mode = CipherMode.CBC;

                byte[] plainTextBytes = new byte[cipherTextBytes.Length];
                int byteCount = 0;

                using (ICryptoTransform decryptor = symmK.CreateDecryptor(keyBytes, initVecB))
                {
                    using (MemoryStream mSt = new MemoryStream(cipherTextBytes))
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(mSt, decryptor, CryptoStreamMode.Read))
                        {
                            byteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                            mSt.Close();
                            cryptoStream.Close();
                        }
                    }
                }

                symmK.Clear();
                decryptedText = Encoding.UTF8.GetString(plainTextBytes, 0, byteCount);

                if (DateTime.TryParse(decryptedText.Split("_actualDateTime=")[1], out var actualDateTime) && actualDateTime < DateTime.UtcNow)
                {
                    decryptedText = null;
                    return false;
                }
                else
                    decryptedText = decryptedText.Split("_actualDateTime=")[0];

            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }
    }
}
