using System.Security.Cryptography;
using System.Text;

namespace Login.Login
{
    public class EncriptarDesencriptar
    {
        public static string Encriptar(string texto, byte[] clavePublica)
        {
            using (RSA rsa = RSA.Create())
            {
                rsa.ImportRSAPublicKey(clavePublica, out _);
                byte[] bytesTexto = Encoding.UTF8.GetBytes(texto);
                byte[] bytesEncriptados = rsa.Encrypt(bytesTexto, RSAEncryptionPadding.Pkcs1);
                return Convert.ToBase64String(bytesEncriptados);
            }
        }

        public static string Desencriptar(string textoEncriptado, byte[] clavePrivada)
        {
            using (RSA rsa = RSA.Create())
            {
                rsa.ImportRSAPrivateKey(clavePrivada, out _);
                byte[] bytesTextoEncriptado = Convert.FromBase64String(textoEncriptado);
                byte[] bytesDesencriptados = rsa.Decrypt(bytesTextoEncriptado, RSAEncryptionPadding.Pkcs1);
                return Encoding.UTF8.GetString(bytesDesencriptados);
            }
        }
    }

}

