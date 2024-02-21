using System.Collections.Generic;

namespace BemIt;

public interface IBem
{
    /// <summary>
    /// The name of the block or element
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Adds original class names
    /// </summary>
    /// <param name="classNames">a single or a list of class names</param>
    /// <returns></returns>
    IBem AddClass(params string?[] classNames);

    /// <summary>
    /// Adds original class name if condition is true
    /// </summary>
    /// <param name="classNames">a single or a list of class names</param>
    /// <param name="condition"></param>
    /// <returns></returns>
    IBem AddClass(string classNames, bool condition);

    IEnumerable<string> BuildAsEnumerable();

    /// <summary>
    /// Builds the css class
    /// </summary>
    /// <returns></returns>
    string Build();
}