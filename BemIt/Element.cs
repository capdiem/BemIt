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
    public Element(string block, string element) : base($"{block}__{element}")
    {
    }
}