using System.Collections.Generic;

namespace BemIt;

public class BemBase : IBem
{
    protected List<string?> ClassNames { get; } = new();

    public IBem Add(params string?[] classNames)
    {
        ClassNames.AddRange(classNames);
        return this;
    }

    public virtual string Build()
    {
        return string.Join(" ", ClassNames).Trim();
    }
}
