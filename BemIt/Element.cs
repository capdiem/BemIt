namespace BemIt;

public class Element : BemBase, IBlockOrElement
{
    public Element(string block, string e)
    {
        Name = $"{block}__{e}";
    }

    public string Name { get; }

    public override string Build()
    {
        return (Name + " " + string.Join(" ", ClassNames)).Trim();
    }

    public override string ToString()
    {
        return Build();
    }
}
