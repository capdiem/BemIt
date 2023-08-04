using System.Collections.Generic;

namespace BemIt;

public class BemBase : IBem
{
    protected List<string?> ClassNames { get; } = new();

    // inherits
    public IBem AddClass(params string?[] classNames)
    {
        ClassNames.AddRange(classNames);
        return this;
    }

    // inherits
    public virtual string Build()
    {
        return string.Join(" ", ClassNames).Trim();
    }
}
