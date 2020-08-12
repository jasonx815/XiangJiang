using System.Security.Cryptography;
using System.Text;
using XiangJiang.Core;

namespace XiangJiang.Encryptor
{
    /// <summary>
    /// SHA256 加密
    /// </summary>
    /// 时间：2016/9/22 10:08
    /// 备注：
    public static class Sha256Encryptor
    {
        #region Methods

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="secretKey">加密密钥</param>
        /// <param name="encryptString">需要加密的字符串</param>
        /// <returns></returns>
        /// 时间：2016/9/22 10:13
        /// 备注：
        public static string Encrypt(string secretKey, string encryptString)
        {
            Checker.Begin().NotNullOrEmpty(secretKey)
                           .NotNullOrEmpty(encryptString);
            var keyData = Encoding.UTF8.GetBytes(secretKey);
            var plainData = Encoding.UTF8.GetBytes(encryptString);
            using (var sha256 = new HMACSHA256(keyData))
            {
                var builder = new StringBuilder();
                foreach (var item in sha256.ComputeHash(plainData))
                {
                    builder.Append($"{item:x2}");
                }

                return builder.ToString();
            }
        }

        #endregion Methods
    }
}