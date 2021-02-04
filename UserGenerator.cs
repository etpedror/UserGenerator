using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace UserGenerator
{
    public static class UserGenerator
    {
        /// <summary>
        /// Random number generator holder
        /// </summary>
        private static RandomNumberGenerator _generator = null;

        /// <summary>
        /// Random number generator property
        /// </summary>
        private static RandomNumberGenerator Generator { get => _generator ?? (_generator = RandomNumberGenerator.Create()); }

        /// <summary>
        /// Returns a new random number between min and max
        /// </summary>
        /// <param name="min">the lower bound for the generated number</param>
        /// <param name="max">the upper bound for the generated number</param>
        /// <returns>a new random number between min and max</returns>
        private static int GetNewRandom(int min, int max)
        {
            var scale = uint.MaxValue;
            while (scale == uint.MaxValue)
            {
                var four_bytes = new byte[4];
                Generator.GetBytes(four_bytes);
                scale = BitConverter.ToUInt32(four_bytes, 0);
            }
            return (int)(min + (max - min) * (scale / (double)uint.MaxValue));
        }

        /// <summary>
        /// Returns a sequence of size "size" composed of characters in the array "chars"
        /// </summary>
        /// <param name="size">The size of the sequence</param>
        /// <param name="chars">The characters that may compose the sequence</param>
        /// <returns>a sequence of size "size" composed of characters in the array "chars"</returns>
        private static string GetMix(int size, char[] chars)
        {
            byte[] data = new byte[size];
            using (var crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetBytes(data);
            }
            var result = new StringBuilder(size);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }

        /// <summary>
        /// Returns a shuffled version of a given string
        /// </summary>
        /// <param name="source">The string to shuffle</param>
        /// <returns>a shuffled version of a given string</returns>
        private static string ShuffleString(string source)
        {
            if (string.IsNullOrEmpty(source))
            {
                return source;
            }
            var chars = source.ToCharArray();
            char c;
            int j;
            for (int i = chars.Length - 1; i > 0; i--)
            {
                j = GetNewRandom(0, i + 1);
                if (j != i)
                {
                    c = chars[j];
                    chars[j] = chars[i];
                    chars[i] = c;
                }
            }
            return new String(chars);
        }

        /// <summary>
        /// Returns a unique key with length "size"
        /// </summary>
        /// <param name="size">The size of the key</param>
        /// <returns>a unique key with length "size"</returns>
        private static string GetUniqueKey(int size)
        {
            var lower = GetMix(size - 3, "abcdefghijklmnopqrstuvwxyz".ToCharArray());
            var upper = GetMix(1, "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray());
            var digit = GetMix(1, "1234567890".ToCharArray());
            var symbl = GetMix(1, "!$%^&*(){}[],.".ToCharArray());

            var final = lower + upper + digit + symbl;
            return ShuffleString(final);
        }

        /// <summary>
        /// Returns a new randomly generated user
        /// </summary>
        /// <returns>a new randomly generated user</returns>
        public static User GenerateUser()
        {
            var result = new User();
            result.FirstName = First.Names[GetNewRandom(0, First.Names.Count - 1)];
            result.LastName = Last.Names[GetNewRandom(0, Last.Names.Count - 1)];
            result.Domain = Domain.Names[GetNewRandom(0, Domain.Names.Count - 1)];
            result.Password = new String(GetUniqueKey(10));
            return result;
        }

        /// <summary>
        /// Returns a list of distinct generated users
        /// </summary>
        /// <param name="numberOfUsers">The number of users to be generated</param>
        /// <returns>A list of distinct generated users</returns>
        public static List<User> GenerateUsers(int numberOfUsers)
        {
            var result = new Hashtable();
            while(result.Count < numberOfUsers)
            {
                var newUser = GenerateUser();
                if(!result.ContainsKey(newUser.Email))
                {
                    result.Add(newUser.Email, newUser);
                }
            }
            return result.Values.OfType<User>().ToList();
        }
    }
}