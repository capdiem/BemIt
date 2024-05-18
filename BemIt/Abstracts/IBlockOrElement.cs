namespace BemIt.Abstracts;

public interface IBlockOrElement
{
    string Name { get; }

    ModifierBuilder CreateModifierBuilder();
}