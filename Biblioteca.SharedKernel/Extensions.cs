using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Aes = System.Security.Cryptography.Aes;

namespace Biblioteca.SharedKernel
{
    public static class Extensions
    {
        private const string Key = "CNS8U3RS99VC4ZLYUXAKHLO4YJQZ1ZGZWYOPQRSZGQHJKAZXQRYHASGHW";

        public static string Encrypt(string input)
        {
            var bytesBuff = Encoding.Unicode.GetBytes(input);
            using (var aes = Aes.Create())
            {
                using (var crypto = new Rfc2898DeriveBytes(Key, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 }))
                {
                    aes.Key = crypto.GetBytes(32);
                    aes.IV = crypto.GetBytes(16);
                    using (var mStream = new MemoryStream())
                    {
                        using (var cStream = new CryptoStream(mStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cStream.Write(bytesBuff, 0, bytesBuff.Length);
                            cStream.Dispose();
                        }
                        input = Convert.ToBase64String(mStream.ToArray());
                    }
                }
            }
            return input;
        }

        public static string Decrypt(string cryptoInput)
        {
            var bytesBuff = Convert.FromBase64String(cryptoInput);
            using (var aes = Aes.Create())
            {
                using (var crypto = new Rfc2898DeriveBytes(Key, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 }))
                {
                    aes.Key = crypto.GetBytes(32);
                    aes.IV = crypto.GetBytes(16);
                    using (var mStream = new MemoryStream())
                    {
                        using (var cStream = new CryptoStream(mStream, aes.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cStream.Write(bytesBuff, 0, bytesBuff.Length);
                            cStream.Dispose();
                        }
                        cryptoInput = Encoding.Unicode.GetString(mStream.ToArray());
                    }
                }

            }
            return cryptoInput;
        }

        public static bool IsCNPJ(this long cnpj)
        {
            var convertedInput = $"{cnpj}";
            convertedInput = convertedInput.PadLeft(14, '0');

            var first = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            var second = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            if (convertedInput.Length != 14)
                return false;
            var cnpjRange = convertedInput.Substring(0, 12);
            var sumValue = 0;
            for (var i = 0; i < 12; i++)
                sumValue += int.Parse(cnpjRange[i].ToString()) * first[i];
            var remnant = (sumValue % 11);
            if (remnant < 2)
                remnant = 0;
            else
                remnant = 11 - remnant;
            var digit = remnant.ToString();
            cnpjRange = cnpjRange + digit;
            sumValue = 0;
            for (var i = 0; i < 13; i++)
                sumValue += int.Parse(cnpjRange[i].ToString()) * second[i];
            remnant = (sumValue % 11);
            if (remnant < 2)
                remnant = 0;
            else
                remnant = 11 - remnant;
            digit += remnant;

            return convertedInput.EndsWith(digit);
        }

        public static bool IsCpf(this long cpf)
        {
            var convertedInput = $"{cpf}";

            convertedInput = convertedInput.PadLeft(11, '0');

            var multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            convertedInput = convertedInput.Trim();
            convertedInput = convertedInput.Replace(".", "").Replace("-", "");
            if (convertedInput.Length != 11)
                return false;
            tempCpf = convertedInput.Substring(0, 9);
            var soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            var resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto;
            return convertedInput.EndsWith(digito);
        }

        public static IEnumerable<T> Paginate<T>(this IEnumerable<T> elements, int? page, out int total)
        {
            total = elements.Count();
            return (IEnumerable<T>)(!page.HasValue ? elements.Take(total) : elements.Skip(10 * ((int)page - 1)).Take(10));
        }

        public static List<T> Paginate<T>(this List<T> elements, int? page, out int total)
        {
            total = elements.Count();
            return (List<T>)(!page.HasValue ? elements.Take(total) : elements.Skip(10 * ((int)page - 1)).Take(10));
        }

        public static IQueryable<T> Order<T>(this IEnumerable<T> source, string sortBy = null, string sortDirection = null)
        {
            try
            {
                if (!string.IsNullOrEmpty(sortBy))
                {
                    if (string.IsNullOrEmpty(sortDirection))
                        sortDirection = "asc";

                    var sort = new Sorter<T>();
                    return (IQueryable<T>)sort.Sort(source, sortBy, sortDirection);
                }

                return (IQueryable<T>)source;
            }
            catch (Exception)
            {
                return (IQueryable<T>)source;
            }
        }

        public static bool IsValidMail(this string mail)
            => !string.IsNullOrEmpty(mail) && new Regex(@"^([\w-\.]+)@((\[[\d]{1,3}\.[\d]{1,3}\.[\d]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[\d]{1,3})(\]?)$")
           .IsMatch(mail);

    }

    public class Sorter<T>
    {
        public IEnumerable<T> Sort(IEnumerable<T> source, string sortBy, string sortDirection)
        {
            var param = Expression.Parameter(typeof(T), "item");

            var sortExpression = Expression.Lambda<Func<T, object>>
                (Expression.Convert(Expression.Property(param, sortBy), typeof(object)), param);

            switch (sortDirection.ToLower())
            {
                case "asc":
                    return source.AsQueryable<T>().OrderBy<T, object>(sortExpression);
                default:
                    return source.AsQueryable<T>().OrderByDescending<T, object>(sortExpression);
            }
        }
    }
}
