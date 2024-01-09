using System.Security.Cryptography;
using System.Text;

namespace WebDemo.Business.src.Shared
{
    public class PasswordService
    {
       public static void HashPasword(string originalPassword, out string hashedPassword, out byte[] salt)
       {
            var hmac = new HMACSHA256();
            salt = hmac.Key;
            hashedPassword = BitConverter.ToString(hmac.ComputeHash(Encoding.UTF8.GetBytes(originalPassword))) ;

            // in the application: know the algorithm
            // in the database: hashedpassword + salt
       } 

       public static bool VerifyPassword(string originalPassword, string hashedPassword, byte[] salt)
       {
            var hmac = new HMACSHA256(salt);
            return BitConverter.ToString(hmac.ComputeHash(Encoding.UTF8.GetBytes(originalPassword))) == hashedPassword;
       }
    }
}

/* 
2 common ways:
1. hash it with a algorithm and a key : every user uses same key
2. hash it with unique key stored in User database */