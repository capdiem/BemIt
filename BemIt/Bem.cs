using System;

namespace BemIt;

public class Bem
{
    public Bem()
    {
    }

    public Bem(string root)
    {
        Root = root;
    }

    public string? Root { get; set; }

    public Block Block()
    {
        if (string.IsNullOrWhiteSpace(Root))
        {
            throw new InvalidOperationException("Root cannot be null or empty");
        }

        return new Block(Root);
    }

    public Block Block(string name)
    {
        Root = name;

        return Block();
    }
}
