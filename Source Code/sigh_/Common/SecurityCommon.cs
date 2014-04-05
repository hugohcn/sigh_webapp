using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Common
{
    public class SecurityCommon
    {
        private byte[] IV = { 0x50, 0x08, 0xF1, 0xDD, 0xDE, 0x3C, 0xF2, 0x18, 0x44, 0x74, 0x19, 0x2C, 0x53, 0x49, 0xAB, 0xBC };
        private const string cryptoKey = "Q3JpcHRvZ3JhZmlhcyBjb20gUmluamRhZWwgLyBBRVM=";

        public string EncriptarObjeto(string strValor)
        {
            try
            {
                if (!string.IsNullOrEmpty(strValor))
                {
                    byte[] bText, bKey;
                    bKey = Convert.FromBase64String(cryptoKey);
                    bText = new UTF8Encoding().GetBytes(strValor);

                    // Instancia a classe de criptografia Rijndael
                    Rijndael rijndael = new RijndaelManaged();

                    // Define o tamanho da chave "256 = 8 * 32"
                    // Lembre-se: chaves possíves:
                    // 128 (16 caracteres), 192 (24 caracteres) e 256 (32 caracteres)
                    rijndael.KeySize = 256;

                    // Cria o espaço de memória para guardar o valor criptografado:
                    MemoryStream mStream = new MemoryStream();

                    // Instancia o encriptador 
                    CryptoStream encryptor = new CryptoStream(mStream, rijndael.CreateEncryptor(bKey, IV), CryptoStreamMode.Write);

                    // Faz a escrita dos dados criptografados no espaço de memória
                    encryptor.Write(bText, 0, bText.Length);

                    // Despeja toda a memória.
                    encryptor.FlushFinalBlock();

                    // Pega o vetor de bytes da memória e gera a string criptografada
                    return Convert.ToBase64String(mStream.ToArray());
                }
                else
                {
                    throw new Exception("Erro: Impossível criptografar objetos nulos ou vazios.");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string DesencriptarObjeto(string strValor)
        {
            try
            {
                if (!string.IsNullOrEmpty(strValor))
                {
                    //Replace para melhorar bug de input string na base 64 string.
                    strValor = strValor.Replace(" ", "+");

                    // Cria instancias de vetores de bytes com as chaves
                    byte[] bText, bKey;
                    bKey = Convert.FromBase64String(cryptoKey);
                    bText = Convert.FromBase64String(strValor);

                    // Instancia a classe de criptografia Rijndael
                    Rijndael rijndael = new RijndaelManaged();

                    // Define o tamanho da chave "256 = 8 * 32"
                    // Lembre-se: chaves possíves:
                    // 128 (16 caracteres), 192 (24 caracteres) e 256 (32 caracteres)
                    rijndael.KeySize = 256;

                    // Cria o espaço de memória para guardar o valor DEScriptografado:
                    MemoryStream mStream = new MemoryStream();

                    // Instancia o Decriptador 

                    CryptoStream decryptor = new CryptoStream(mStream, rijndael.CreateDecryptor(bKey, IV), CryptoStreamMode.Write);

                    // Faz a escrita dos dados criptografados no espaço de memória
                    decryptor.Write(bText, 0, bText.Length);

                    // Despeja toda a memória.
                    decryptor.FlushFinalBlock();

                    // Instancia a classe de codificação para que a string venha de forma correta
                    UTF8Encoding utf8 = new UTF8Encoding();

                    // Com o vetor de bytes da memória, gera a string descritografada em UTF8
                    return utf8.GetString(mStream.ToArray());
                }
                else
                {
                    throw new Exception("Erro: Impossível decriptar objetos nulos ou vazios.");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Método para tratamento de strings.
        /// </summary>
        /// <param name="strValor"></param>
        /// <returns></returns>
        public string TratarString(string strValor)
        {
            string aux = strValor;
            aux = aux.Replace("'", "");
            aux = aux.Replace("/", "");
            aux = aux.Replace("#", "");
            aux = aux.Replace("-", "");
            aux = aux.Replace("ç", "c");
            aux = aux.Replace("<", "");
            aux = aux.Replace(">", "");
            aux = aux.Replace("?", "");
            aux = aux.Replace("^", "");
            aux = aux.Replace("~", "");
            aux = aux.Replace("`", "");
            aux = aux.Replace("´", "");
            aux = aux.Replace("[", "");
            aux = aux.Replace("]", "");
            aux = aux.Replace("{", "");
            aux = aux.Replace("}", "");
            aux = aux.Replace("ã", "a");
            aux = aux.Replace("õ", "o");
            aux = aux.Replace("á", "a");
            aux = aux.Replace("à", "a");
            aux = aux.Replace("ó", "o");


            return aux;
        }

        /// <summary>
        /// Método de geração de senhas randômicas
        /// </summary>
        /// <returns>Senha contendo o número de caracteres exigidos</returns>
        public string GeraSenha(int tamanhoSenhac)
        {
            string senha = string.Empty;

            for (int i = 0; i < tamanhoSenhac; i++)
            {
                Random random = new Random();

                int codigo = Convert.ToInt32(random.Next(48, 122).ToString());

                if ((codigo >= 48 && codigo <= 57) || (codigo >= 97 && codigo <= 122))
                {
                    string _char = ((char)codigo).ToString();
                    if (!senha.Contains(_char))
                    {
                        senha += _char;
                    }
                    else
                    {
                        i--;
                    }
                }
                else
                {
                    i--;
                }
            }
            return senha;
        }
    }
}
