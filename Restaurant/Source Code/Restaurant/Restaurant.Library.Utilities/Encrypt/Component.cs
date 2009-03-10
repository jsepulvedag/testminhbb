using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace Restaurant.Library.Utilities.Encrypt
{
    public class Component
    {
        public static string Encrypt(string source, Provider type)
        {
            ComponentBase alb = new ComponentBase(type);
            return alb.Encrypt(source, type);
        }
        public static string Decrypt(string soure, Provider type)
        {
            ComponentBase alb = new ComponentBase(type);
            return alb.Decrypt(soure, type);
        }
    }
    public enum Provider
    {
        Rijndael,
        RC2,
        DES,
        TripleDES
    }
    class ComponentBase
    {
        private string mKey = "*****";
        private string mSalt = "thusunautumnnhat";
        private Provider mAlgorithm;
        private SymmetricAlgorithm mCryptoService;
        private void SetLegalIV()
        {
            switch (mAlgorithm)
            {
                case Provider.Rijndael:
                    mCryptoService.IV = new byte[] { 0xf, 0x6f, 0x13, 0x2e, 0x35, 0xc2, 0xcd, 0xf9, 0x5, 0x46, 0x9c, 0xea, 0xa8, 0x4b, 0x73, 0xcc };
                    break;
                default:
                    mCryptoService.IV = new byte[] { 0xf, 0x6f, 0x13, 0x2e, 0x35, 0xc2, 0xcd, 0xf9 };
                    break;
            }
        }
        internal ComponentBase(Provider serviceProvider)
        {
            switch (serviceProvider)
            {
                case Provider.Rijndael:
                    mCryptoService = new RijndaelManaged();
                    mAlgorithm = serviceProvider;
                    break;
                case Provider.RC2:
                    mCryptoService = new RC2CryptoServiceProvider();
                    mAlgorithm = serviceProvider;
                    break;
                case Provider.DES:
                    mCryptoService = new DESCryptoServiceProvider();
                    mAlgorithm = serviceProvider;
                    break;
                case Provider.TripleDES:
                    mCryptoService = new TripleDESCryptoServiceProvider();
                    mAlgorithm = serviceProvider;
                    break;
            }
            mCryptoService.Mode = CipherMode.CBC;
        }

        internal virtual byte[] GetLegalKey()
        {
            if (mCryptoService.LegalKeySizes.Length > 0)
            {
                int keySize = mKey.Length * 8;
                int minSize = mCryptoService.LegalKeySizes[0].MinSize;
                int maxSize = mCryptoService.LegalKeySizes[0].MaxSize;
                int skipSize = mCryptoService.LegalKeySizes[0].SkipSize;

                if (keySize > maxSize)
                {
                    mKey = mKey.Substring(0, maxSize / 8);
                }
                else if (keySize < maxSize)
                {
                    int validSize = (keySize <= minSize) ? minSize : (keySize - keySize % skipSize) + skipSize;
                    if (keySize < validSize)
                    {
                        mKey = mKey.PadRight(validSize / 8, '*');
                    }
                }
            }
            PasswordDeriveBytes key = new PasswordDeriveBytes(mKey, ASCIIEncoding.ASCII.GetBytes(mSalt));
            return key.GetBytes(mKey.Length);
        }

        internal virtual string Encrypt(string plainText, Provider mAlgorithm)
        {
            byte[] plainByte = ASCIIEncoding.ASCII.GetBytes(plainText);
            byte[] keyByte = GetLegalKey();
            mCryptoService.Key = keyByte;
            SetLegalIV();
            ICryptoTransform cryptoTransform = mCryptoService.CreateEncryptor();
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, cryptoTransform, CryptoStreamMode.Write);
            cs.Write(plainByte, 0, plainByte.Length);
            cs.FlushFinalBlock();
            byte[] cryptoByte = ms.ToArray();
            return Convert.ToBase64String(cryptoByte, 0, cryptoByte.GetLength(0)).Replace("+", "PluzS");
        }

        internal virtual string Decrypt(string cryptoText, Provider mAlgorithm)
        {            
            try
            {
                byte[] cryptoByte = Convert.FromBase64String(cryptoText.Replace("PluzS", "+"));
                byte[] keyByte = GetLegalKey();
                mCryptoService.Key = keyByte;
                SetLegalIV();
                ICryptoTransform cryptoTransform = mCryptoService.CreateDecryptor();
                MemoryStream ms = new MemoryStream(cryptoByte, 0, cryptoByte.Length);
                CryptoStream cs = new CryptoStream(ms, cryptoTransform, CryptoStreamMode.Read);
                StreamReader sr = new StreamReader(cs);
                return sr.ReadToEnd();
            }
            catch
            {
                return null;
            }
        }

        internal string Key
        {
            get { return mKey; }
            set { mKey = value; }
        }

        internal string Salt
        {
            get { return mSalt; }
            set { mSalt = value; }
        }
    }
}
