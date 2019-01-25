public static class Functions
{
    public static Dictionary<int, string> GetEnumList(Type enumType)
    {
        if (enumType.BaseType != typeof(Enum))
        {
            return null;
        }
        var enumValues = enumType.GetEnumValues();
        Dictionary<int, string> result = new Dictionary<int, string>();
        foreach (var val in enumValues)
        {
            result[(int)(Enum.Parse(enumType, val.ToString()))] = SplitWordsByCapitalLetters(val.ToString());
        }
        return result;
    }
    public static string SplitWordsByCapitalLetters(string words)
    {
        words = words.Replace("_", "");
        return words.Aggregate(string.Empty, (result, next) =>
        {
            if (char.IsUpper(next) && result.Length > 1)
            {
                result += ' ';
            }
            return result + next;
        });
    }
}