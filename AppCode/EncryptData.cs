using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace RecommendationsPlatformsApp.AppCode {
  class EncryptData {
    private static readonly byte[] KeyBytes = Encoding.ASCII.GetBytes("FixedWWWFixedWWW"); // 16 байт для AES
    private static readonly byte[] IVBytes = Encoding.ASCII.GetBytes("1234567812345678"); // 16 байт для AES

    public string Encrypt(string originalString) {
      ValidateString(originalString, "The string which needs to be encrypted cannot be null or empty.");
      using (var cryptoProvider = new AesCryptoServiceProvider()) {
        cryptoProvider.Key = KeyBytes;
        cryptoProvider.IV = IVBytes;

        using (var memoryStream = new MemoryStream())
        using (var cryptoStream = new CryptoStream(memoryStream,
            cryptoProvider.CreateEncryptor(), CryptoStreamMode.Write))
        using (var writer = new StreamWriter(cryptoStream)) {
          writer.Write(originalString);
          writer.Flush();
          cryptoStream.FlushFinalBlock();
          return Convert.ToBase64String(memoryStream.ToArray());
        }
      }
    }

    public string Decrypt(string encryptedString) {
      ValidateString(encryptedString, "The string which needs to be decrypted cannot be null or empty.");
      using (var cryptoProvider = new AesCryptoServiceProvider()) {
        cryptoProvider.Key = KeyBytes;
        cryptoProvider.IV = IVBytes;

        using (var memoryStream = new MemoryStream(Convert.FromBase64String(encryptedString)))
        using (var cryptoStream = new CryptoStream(memoryStream,
            cryptoProvider.CreateDecryptor(), CryptoStreamMode.Read))
        using (var reader = new StreamReader(cryptoStream)) {
          return reader.ReadToEnd();
        }
      }
    }

    private void ValidateString(string input, string errorMessage) {
      if (string.IsNullOrEmpty(input)) {
        throw new ArgumentException(errorMessage);
      }
    }

  }
}
