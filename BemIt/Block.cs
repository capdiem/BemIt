using System.Collections.Generic;

namespace BemIt;

/// <summary>
/// Represents a block in BEM
/// </summary>
public class Block : BemBase, IBlockOrElement
{
    private readonly Dictionary<string, Block> _extendBlocks = new();

    /// <summary>
    /// Creates a block
    /// </summary>
    /// <param name="name">The name of the block</param>
    public Block(string name)
    {
        Name = name;
    }

    /// <summary>
    /// The name of the block
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Creates a block extends from current block
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

    /// <summary>
    /// Creates a element of the block
    /// </summary>
    /// <param name="element"></param>
    /// <returns></returns>
    public BemCssBuilder Element(string element)
    {
        return new BemCssBuilder(Name, element);
    }

    /// <summary>
    /// Builds the css class from a block
    /// </summary>
    /// <returns></returns>
    public override string Build()
    {
        return (Name + " " + string.Join(" ", ClassNames)).Trim();
    }

    // inherit
    public override string ToString()
    {
        return Build();
    }
}
