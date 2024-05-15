namespace BemIt;

public struct Block : IBlockOrElement
{
    public Block(string name)
    {
        Name = name;
    }

    public string Name { get; init; } = string.Empty;

    public Element Element(string element)
    {
        if (Name == string.Empty)
        {
            return BemIt.Element.Empty;
        }

        return new Element(Name, element);
    }

    public ModifierBuilder CreateModifierBuilder()
    {
        return new ModifierBuilder(Name);
    }

    public override string ToString()
    {
        return Name.ToLowerInvariant();
    }
}