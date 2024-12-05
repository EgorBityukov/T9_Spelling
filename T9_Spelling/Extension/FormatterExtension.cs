namespace T9_Spelling.Extension
{
    internal static class FormatterExtension
    {
        public static string CaseFormat(this string value, short caseNumber)
        {
            return $"Case #{caseNumber.ToString()}: " + value;
        }
    }
}
