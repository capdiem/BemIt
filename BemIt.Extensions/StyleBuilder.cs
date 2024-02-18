namespace BemIt.Extensions;

public class StyleBuilder
{
    private readonly Dictionary<string, string?> _styles = new();

    public StyleBuilder Add(string key, string? value)
    {
        _styles.Add(key, value);
        return this;
    }

    public string Build()
    {
        return string.Join(";",
            _styles.Where(u => !string.IsNullOrWhiteSpace(u.Value))
                .Select(x => $"{x.Key}:{x.Value}"));
    }
}