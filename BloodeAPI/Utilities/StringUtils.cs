using System;
namespace BloodeAPI.Utilities
{
    public static class StringUtils
    {            
        public static string Concatenate(this string s1, string s2)
        {
            return s1 + " " + s2;
        }
        public static string ToCamelCase(this string s1)
        {
            return Char.ToLowerInvariant(s1[0]) + s1.Substring(1);
        }
        public static string GetStatesJsonFilePath()
        {
            return "/Users/harshavardhangangineni/Documents/Projects/Visual Studio Projects/BloodeAPI/BloodeAPI/Utilities/Places.json"; ;
        }
    }
}

