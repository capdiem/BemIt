using System.Collections.Generic;

namespace BemIt;

public class Block : BemBase, IBlockOrElement
{
    private readonly Dictionary<string, Block> _extendBlocks = new();

    public Block(string name)
    {
        Name = name;
    }

    public string Name { get; }

    /// <summary>
    /// Create a block extends from current block
    /// </summary>
    /// <param name="section">The section appended to the current block name</param>
    /// <returns></returns>
    public Block Extend(string section)
    {
        if (_extendBlocks.TryGetValue(section, out var block))
        {
            return block;
        }

        block = new Block($"{Name}-{section}");

        _extendBlocks.Add(section, block);

        return block;
    }

    public Element Element(string element)
    {
        return new Element(Name, element);
    }

    public override string Build()
    {
        return (Name + " " + string.Join(" ", ClassNames)).Trim();
    }

    public override string ToString()
    {
        return Build();
    }
}
