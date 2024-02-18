namespace BemIt.Extensions;

public class CssProvider
{
    private const string BlockKey = "__default";

    private readonly Stack<Block> _blockStack = new();
    private readonly Dictionary<string, Func<string>> _cssConfig = new();
    private readonly Dictionary<string, Action<StyleBuilder>> _styleConfig = new();

    private Block _currentBlock;

    public CssProvider(string block)
    {
        var b = new Block(block);
        _blockStack.Push(b);
        _currentBlock = b;
    }

    /// <summary>
    /// Build classes for block
    /// </summary>
    /// <param name="css"></param>
    /// <param name="style"></param>
    /// <returns></returns>
    public CssProvider Block(
        Func<IBlockOrElement, Modifier>? css = null,
        Action<StyleBuilder>? style = null)
    {
        var modifier = css?.Invoke(_currentBlock);
        _cssConfig.Add(BlockKey, () => modifier?.Build() ?? _currentBlock.Build());

        if (style != null)
        {
            _styleConfig.Add(BlockKey, style);
        }

        return this;
    }

    /// <summary>
    /// Build classes for element
    /// </summary>
    /// <param name="name"></param>
    /// <param name="css"></param>
    /// <param name="style"></param>
    /// <returns></returns>
    public CssProvider Element(string name,
        Func<IBlockOrElement, Modifier>? css = null,
        Action<StyleBuilder>? style = null)
    {
        var element = _currentBlock.Element(name);
        var modifier = css?.Invoke(element);
        _cssConfig.Add(name, () => modifier?.Build() ?? element.Build());

        if (style != null)
        {
            _styleConfig.Add(name, style);
        }

        return this;
    }

    /// <summary>
    /// Extend the current block to a new block and build classes for it
    /// </summary>
    /// <param name="name"></param>
    /// <param name="css"></param>
    /// <param name="style"></param>
    /// <returns></returns>
    public CssProvider Extend(string name,
        Func<IBlockOrElement, Modifier>? css = null,
        Action<StyleBuilder>? style = null)
    {
        var block = _currentBlock.Extend(name);
        _blockStack.Push(block);
        _currentBlock = block;

        var modifier = css?.Invoke(block);
        _cssConfig.Add(name, () => modifier?.Build() ?? block.Build());

        if (style != null)
        {
            _styleConfig.Add(name, style);
        }

        return this;
    }

    /// <summary>
    /// Revert to previous block.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public CssProvider Revert()
    {
        if (_blockStack.Count == 1)
        {
            throw new InvalidOperationException("Current block is the root block, cannot revert further.");
        }

        _blockStack.Pop();
        _currentBlock = _blockStack.Peek();
        return this;
    }

    /// <summary>
    /// Build classes for origin node
    /// </summary>
    /// <param name="name"></param>
    /// <param name="css"></param>
    /// <param name="style"></param>
    /// <returns></returns>
    public CssProvider Origin(string name,
        Func<IBlockOrElement, Modifier>? css = null,
        Action<StyleBuilder>? style = null)
    {
        var modifier = css?.Invoke(_currentBlock);
        _cssConfig.Add(name, () => modifier?.Build() ?? _currentBlock.Build());

        if (style != null)
        {
            _styleConfig.Add(name, style);
        }

        return this;
    }

    /// <summary>
    /// Get the class with specified name
    /// </summary>
    /// <param name="name">Name of element or extended block</param>
    /// <returns></returns>
    public string? GetClass(string name)
    {
        return _cssConfig.TryGetValue(name, out var modifier) ? modifier.Invoke() : null;
    }

    /// <summary>
    /// Get the class of block
    /// </summary>
    /// <returns></returns>
    public string? GetClass()
    {
        return GetClass(BlockKey);
    }

    public string? GetStyle(string name)
    {
        if (!_styleConfig.TryGetValue(name, out var action)) return null;

        var styleBuilder = new StyleBuilder();
        action.Invoke(styleBuilder);
        return styleBuilder.Build();
    }

    public string? GetStyle()
    {
        return GetStyle(BlockKey);
    }
}