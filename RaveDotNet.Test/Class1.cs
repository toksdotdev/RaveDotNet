using System;
using RaveDotNet.Services.Encryption;

namespace RaveDotNet.Test
{
    public class Class1
    {
        public void TestEncryption ()
        {
            Rave3DesEncryption a = new Rave3DesEncryption();
            string key = a.GetEncryptionKey("FLWSECK-4127f15e63c9098402dcc7891798fb0f-X");
            string data = "{" +
                                                "\"PBFPubKey\":\"FLWPUBK-1cf610974690c2560cb4c36f4921244a-X\"," +
                                                "\"amount\":1000," +
                                                "\"device_fingerprint\":\"e42afa649d16fb67416186c6a3c942e9\"," +
                                                "\"txRef\":\"PAT-0.06208890843489279\"," +
                                                "\"IP\":\"197.210.173.93\"," +
                                                "\"email\":\"tdontop@qa.team\"," +
                                                "\"pin\":\"3310\"," +
                                                "\"suggested_auth\":\"PIN\"," +
                                                "\"expirymonth\":\"09\"," +
                                                "\"expiryyear\":\"19\"," +
                                                "\"cvv\":\"789\"," +
                                                "\"cardno\":\"5438898014560229\"" +
                                                "}";

            string cipher = a.EncryptData(key, data);

            string plaintext = a.DecryptData(cipher, key);
            Console.WriteLine(key);
            Console.ReadLine();
        }
    }
}
