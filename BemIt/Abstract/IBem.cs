namespace BemIt;

public interface IBem
{
    IBem AddClassNames(params string?[] classNames);

    string Build();
}
