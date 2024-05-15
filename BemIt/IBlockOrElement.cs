namespace BemIt;

public interface IBlockOrElement
{
    string Name { get; }
    
    ModifierBuilder CreateModifierBuilder();
}