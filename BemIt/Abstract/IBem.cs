namespace BemIt;

public interface IBem
{
    IBem Add(params string?[] classNames);

    string Build();
}
