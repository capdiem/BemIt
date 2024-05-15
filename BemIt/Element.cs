namespace BemIt;

public struct Element : IBlockOrElement
{
    public Element(string block, string element)
    {
        Name = $"{block}__{element}";
    }

    public string Name { get; init; } = string.Empty;

    public ModifierBuilder CreateModifierBuilder()
    {
        return new ModifierBuilder(Name);
    }

    public override string ToString()
    {
        return Name.ToLowerInvariant();
    }

    public static Element Empty => new();
}