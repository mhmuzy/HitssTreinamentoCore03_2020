using System;
using System.Security.Cryptography;
using System.Text;

namespace Projeto.CrossCutting.Cryptography
{
    public class MD5Service
    {

        //método para retornar um valor encriptado em MD5
        public static string Encrypt(string value)
        {
            //criptografar o valor recebido para MD5
            var hash = new MD5CryptoServiceProvider()
                .ComputeHash(Encoding.UTF8.GetBytes(value));

            var result = string.Empty;

            foreach (var item in hash)
            {
                result += item.ToString("x2"); //hexadecimal
            }

            return result;
        }
    }
}
