namespace BemIt;

public interface IBem
{
    /// <summary>
    /// Adds original class names
    /// </summary>
    /// <param name="classNames">a single or a list of class names</param>
    /// <returns></returns>
    IBem AddClass(params string?[] classNames);

    /// <summary>
    /// Builds the css class
    /// </summary>
    /// <returns></returns>
    string Build();
}
