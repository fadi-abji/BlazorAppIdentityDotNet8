namespace BlazorWebApp
{
    public static class StringExtenstions
    {
        public static bool IsNullOrEmpty(this string s)
        {
            return string.IsNullOrEmpty(s);
        }
    }
}
