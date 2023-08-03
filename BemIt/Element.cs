namespace BemIt;

/// <summary>
/// Presents a element in BEM
/// </summary>
public class Element : BemBase, IBlockOrElement
{
    /// <summary>
    /// Creates a element
    /// </summary>
    /// <param name="block">From which block</param>
    /// <param name="element">The name of the element, appended to the block name with double underscore</param>
    public Element(string block, string element)
    {
        Name = $"{block}__{element}";
    }

    /// <summary>
    /// The name of the element
    /// </summary>
    /// <example>
    /// {block}__{element}
    /// </example>
    public string Name { get; }

    /// <summary>
    /// Builds the css class from a element
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
