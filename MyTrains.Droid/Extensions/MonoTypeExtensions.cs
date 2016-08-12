//using System;
//using System.Collections.Generic;

//namespace MyTrains.Droid.Extensions
//{
//    static class MonoTypeExtensions
//    {
//        public static string TagName(this Type type)
//        {
//            var tokens = type.FullName.Split('.');
//            var convertedTokens = new List<string>(tokens.Length);
//            for (int idx = 0; idx < tokens.Length - 2; idx++)
//            {
//                convertedTokens.Add(tokens[idx].ToLowerInvariant());
//            }

//            convertedTokens.Add(tokens[tokens.Length - 1]);
//            return string.Join(".", convertedTokens);
//        }
//    }
//}