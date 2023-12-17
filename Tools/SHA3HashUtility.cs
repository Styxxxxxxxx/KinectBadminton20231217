/*
using System;
using System.Security.Cryptography;
using System.Text;
using Konscious.Security.Cryptography;
*/

/*public static class Blake2HashUtility
{
    public static string GetBlake2Hash(string input, byte[] key)
    {
        using (var hmac = new HMACBlake2B(key, 64))
        {
            byte[] data = Encoding.UTF8.GetBytes(input);
            byte[] hash = hmac.ComputeHash(data);

            StringBuilder sBuilder = new StringBuilder();

            foreach (byte b in hash)
            {
                sBuilder.Append(b.ToString("x2")); // 将每个字节的哈希值转换为两位的十六进制表示
            }

            return sBuilder.ToString();
        }
    }

    public static bool VerifyBlake2Hash(string input, string storedHash, byte[] key)
    {
        string hashOfInput = GetBlake2Hash(input, key);

        StringComparer comparer = StringComparer.OrdinalIgnoreCase;

        return comparer.Compare(hashOfInput, storedHash) == 0;
    }
}*/

/*class Program
{
    static void Main()
    {
        // 生成一个密钥，用于哈希
        byte[] key = Encoding.UTF8.GetBytes("your_secret_key");

        // 示例：注册时哈希密码并存储
        string passwordToHash = "user_password";
        string hashedPassword = Blake2HashUtility.GetBlake2Hash(passwordToHash, key);

        // 存储 hashedPassword 到数据库或其他地方

        // 示例：验证登录时的密码
        string loginAttempt = "user_password"; // 用户输入的密码
        bool isPasswordCorrect = Blake2HashUtility.VerifyBlake2Hash(loginAttempt, hashedPassword, key);

        if (isPasswordCorrect)
        {
            Console.WriteLine("Password is correct. Login successful!");
        }
        else
        {
            Console.WriteLine("Password is incorrect. Login failed!");
        }
    }
}*/