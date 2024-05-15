namespace BemIt;

public struct Modifier
{
    private static readonly Modifier _empty = new() { Name = string.Empty };

    public string Name { get; init; }

    public Modifier(string blockOrElement, string modifier)
    {
        Name = $"{blockOrElement}--{modifier}";
    }

    public override string ToString()
    {
        return Name.ToLowerInvariant();
    }

    public static Modifier Empty => _empty;
}