namespace Biblioteca.Domain.Common.Criptografia
{
    public class PasswordService
    {
        public static string Criptografar(string senha)
        {
            Chilkat.Crypt2 crypt = new Chilkat.Crypt2();
            crypt.HashAlgorithm = "md5";
            crypt.EncodingMode = "hex";

            return crypt.HashStringENC(senha);
        }
    }
}
