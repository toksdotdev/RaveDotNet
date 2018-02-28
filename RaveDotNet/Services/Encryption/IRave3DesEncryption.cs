using System;

namespace RaveDotNet.Services.Encryption
{
    internal interface IRave3DesEncryption
    {
        string GetEncryptionKey(string secretKey);
        string EncryptData(string encryptionKey, String data);
        string DecryptData(string encryptedData, string encryptionKey);
    }
}
