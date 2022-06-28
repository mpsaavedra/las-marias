namespace Orun.Extensions;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

public static class StringExtensions
{
    /// <summary>
    /// generate a slug from a provided phrase
    /// https://adamhathcock.blog/2017/05/04/generating-url-slugs-in-net-core/
    /// </summary>
    /// <param name="phrase"></param>
    /// <returns></returns>
    public static string GenerateSlug(this string phrase)
    {
        string str = phrase.RemoveDiacritics().ToLower();
        // invalid chars           
        str = Regex.Replace(str, @"[^a-z0-9\s-]", "");
        // convert multiple spaces into one space   
        str = Regex.Replace(str, @"\s+", " ").Trim();
        // cut and trim 
        str = str.Substring(0, str.Length <= 45 ? str.Length : 45).Trim();
        str = Regex.Replace(str, @"\s", "-"); // hyphens   
        return str;
    }

    /// <summary>
    /// remove possible accent from the string
    /// https://stackoverflow.com/questions/249087/how-do-i-remove-diacritics-accents-from-a-string-in-net
    /// </summary>
    /// <param name="txt"></param>
    /// <returns></returns>
    public static string RemoveDiacritics(this string text)
    {
        var s = new string(text.Normalize(NormalizationForm.FormD)
            .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
            .ToArray());

        return s.Normalize(NormalizationForm.FormC);
    }


    /// <summary>
    /// replace all coincidences of the given original value with
    /// the provided value
    /// </summary>
    /// <param name="val">string to replace values from</param>
    /// <param name="original">value to be replace</param>
    /// <param name="replacement">value to replace with</param>
    /// <returns></returns>
    public static string ReplaceAll(this string val, string original, string replacement)
    {
        StringBuilder sb = new StringBuilder(val);
        sb.Replace(original, replacement);

        return sb.ToString();
    }

    /// <summary>
    /// Returns a Pascal representation of the provided string
    /// </summary>
    /// <param name="val"></param>
    /// <returns></returns>
    public static string Pascal(this string val) =>
        val.ToCharArray()[0].ToString().ToLowerInvariant() + val.Substring(1);

    /// <summary>
    /// hash a given text using <see cref="HMACSHA256"/> and returns the Base64
    /// representation of the hashed text.
    /// </summary>
    /// <param name="text"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    public static string HashHmac256(this string text, string key)
    {
        var encoding = new UTF8Encoding();
        Byte[] textBytes = encoding.GetBytes(text);
        Byte[] keyBytes = encoding.GetBytes(key);
        Byte[] hashBytes;

        using (var hash = new HMACSHA256(keyBytes))
            hashBytes = hash.ComputeHash(textBytes);

        return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
    }

    /// <summary>
    /// Hash a text using the <see cref="KeyDerivation.Pbkdf2"/> algorithm.
    /// </summary>
    /// <param name="text"></param>
    /// <param name="salt"></param>
    /// <param name="iterationCount"></param>
    /// <returns></returns>
    public static string HashPasswordPbdkf2(this string text, byte[] salt, int iterationCount)
    {
        return Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: text,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: iterationCount,
            numBytesRequested: 128 / 8));
    }

    /// <summary>
    /// <inheritdoc cref="HashPasswordPbdkf2"/> With 100 000 iterations.
    /// </summary>
    /// <param name="text"></param>
    /// <param name="salt"></param>
    /// <returns></returns>
    public static string HashPasswordPbkdf2(this string text, byte[] salt) =>
        HashPasswordPbdkf2(text, salt, 100000);

    /// <summary>
    /// <inheritdoc cref="HashPasswordPbdkf2"/>, generate a random 128 bytes salt
    /// </summary>
    /// <param name="text"></param>
    /// <param name="iterations"></param>
    /// <returns>tuple (string, byte[]) with the encrypted text and the salt used</returns>
    public static (string, byte[]) HashPasswordPbdkf2(this string text, int iterations)
    {
        byte[] salt = new byte[128 / 8];
        using (var rngCsp = new RNGCryptoServiceProvider())
            rngCsp.GetNonZeroBytes(salt);

        return (text.HashPasswordPbdkf2(salt, iterations), salt);
    }

    /// <summary>
    /// split a given pascal string and insert a separator between words
    /// </summary>
    /// <example>
    /// var result = "ThisIsAWord".SplitPascal("_");
    ///  // result now is this-is-a-word
    /// </example>
    public static string SplitPascal(this string source, string separator = "-")
    {
        Regex r = new Regex("([A-Z]+[a-z]+)");
        string result = r.Replace(source, m =>
            (m.Value.Length > 3 ? m.Value : m.Value.ToLower()) + separator);
        return result;
    }
}