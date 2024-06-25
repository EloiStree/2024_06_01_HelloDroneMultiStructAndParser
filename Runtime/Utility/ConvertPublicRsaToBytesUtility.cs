using System;
using System.Security.Cryptography;
using System.Text;

public class ConvertPublicRsaToBytesUtility {




    public static void ParsePublicRsaKeyToBytesWithModule(string publicRsaKey, out byte[] publicKeyBytes)
    {
        RSAParameters rsaParams;
        using (var rsa = RSA.Create())
        {
            rsa.FromXmlString(publicRsaKey);
            rsaParams = rsa.ExportParameters(false);
        }

        byte[] modulus = rsaParams.Modulus;
        byte[] exponent = rsaParams.Exponent;
        publicKeyBytes = new byte[modulus.Length + exponent.Length];
        Buffer.BlockCopy(modulus, 0, publicKeyBytes, 0, modulus.Length);
        Buffer.BlockCopy(exponent, 0, publicKeyBytes, modulus.Length, exponent.Length);
    }
    public static void ParsePublicRsaKeyToBytesWithoutModule(string publicRsaKey, out byte[] publicKeyBytes)
    {
        try { 
        if(string.IsNullOrWhiteSpace(publicRsaKey)){
            publicKeyBytes = new byte[128];
            return;
        }
        
        RSAParameters rsaParams;
        using (var rsa = RSA.Create(1024))
        {
            rsa.FromXmlString(publicRsaKey);
            rsaParams = rsa.ExportParameters(false);
        }
        byte[] module = rsaParams.Modulus;
        publicKeyBytes = new byte[ module.Length];
        Buffer.BlockCopy(module, 0, publicKeyBytes, 0, module.Length);
        }catch(Exception e){
            publicKeyBytes = new byte[128];
        }

    }


    public static void ParseBytesToPublicRsaKey(byte[] publicKeyBytes, out string publicRsaKey)
    {
        RSA rsa = RSA.Create();
        RSAParameters rsaKeyInfo = new RSAParameters
        {
            Modulus = publicKeyBytes,
            Exponent = new byte[] { 1, 0, 1 }
        };
        rsa.ImportParameters(rsaKeyInfo);
        publicRsaKey = rsa.ToXmlString(false);   
    }

    public static string GetRandomPublicRsaKey()
    {
        byte[] publicKeyBytes = new byte[128];
        for (int i = 0; i < publicKeyBytes.Length; i++)
        {
            publicKeyBytes[i] = (byte)UnityEngine.Random.Range(0, 255);
        }
        ParseBytesToPublicRsaKey(publicKeyBytes, out string publicRsaKey);
        return publicRsaKey;

    }
}
