namespace BemIt.Extensions;

internal static class ArgumentExceptionExtensions
{
#if NET6_0 || NET7_0
    public static class ArgumentException
    {
        public static void ThrowIfNullOrWhiteSpace(string argument,
            [CallerArgumentExpression("argument")] string? paramName = null)
        {
            if (!string.IsNullOrWhiteSpace(argument)) return;

            System.ArgumentNullException.ThrowIfNull(argument, paramName);
            throw new System.ArgumentException("The argument cannot be empty or white space.", paramName);
        }
    }
#endif
}