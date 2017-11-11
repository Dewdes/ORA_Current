using System.Security.Cryptography;

public class Salt
{
    public static byte[] GenerateSalt()
    {
        RNGCryptoServiceProvider rncCsp = new RNGCryptoServiceProvider();
        byte[] salt = new byte[32];
        rncCsp.GetBytes(salt);

        return salt;
    }
}