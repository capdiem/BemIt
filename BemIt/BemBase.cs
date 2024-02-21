using System.Collections.Generic;
using System.Linq;

namespace BemIt;

public abstract class BemBase : IBem
{
    public string Name { get; }

    protected BemBase(string blockOrElement)
    {
        Name = blockOrElement;
    }

    protected List<string?> ClassNames { get; } = new();

    // inherits
    public IBem AddClass(params string?[] classNames)
    {
        ClassNames.AddRange(classNames);
        return this;
    }

    // inherits
    public IBem AddClass(string? className, bool condition)
    {
        if (condition)
        {
            ClassNames.Add(className);
        }

        return this;
    }

    public virtual IEnumerable<string> BuildAsEnumerable()
    {
        yield return Name;

        foreach (var className in ClassNames.Where(className => !string.IsNullOrWhiteSpace(className)))
        {
            yield return className!;
        }
    }

    // inherits
    public virtual string Build()
    {
        return string.Join(" ", BuildAsEnumerable());
    }

    // inherits
    public override string ToString()
    {
        return Build();
    }
}