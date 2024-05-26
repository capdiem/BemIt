namespace BemIt;

public static class ModifierBuilderExtensions
{
    /// <summary>
    /// Adds a modifier to the builder based on a boolean condition.
    /// </summary>
    /// <param name="builder">The builder to add the modifier to.</param>
    /// <param name="modifier">The boolean condition to check.</param>
    /// <param name="name">The name of the argument that provides the condition. This is optional, and the default value is the name of the modifier.</param>
    /// <returns>The builder with the added modifier if the condition is true.</returns>
    /// <remarks>
    /// This method appends the modifier to the builder if the condition is true.
    /// The modifier is appended as a string representation of the condition's argument name.
    /// </remarks>
    public static ModifierBuilder Add(this ModifierBuilder builder, bool modifier,
        [CallerArgumentExpression("modifier")] string name = "")
    {
        return builder.Add(name, modifier);
    }

    public static ModifierBuilder Add(this ModifierBuilder builder, bool modifier1, bool modifier2,
        [CallerArgumentExpression("modifier1")]
        string name1 = "",
        [CallerArgumentExpression("modifier2")]
        string name2 = "")
    {
        return builder
            .Add(name1, modifier1)
            .Add(name2, modifier2);
    }

    public static ModifierBuilder Add(this ModifierBuilder builder, bool modifier1, bool modifier2, bool modifier3,
        [CallerArgumentExpression("modifier1")]
        string name1 = "",
        [CallerArgumentExpression("modifier2")]
        string name2 = "",
        [CallerArgumentExpression("modifier3")]
        string name3 = "")
    {
        return builder
            .Add(name1, modifier1)
            .Add(name2, modifier2)
            .Add(name3, modifier3);
    }

    public static ModifierBuilder Add(this ModifierBuilder builder, bool modifier1, bool modifier2, bool modifier3,
        bool modifier4,
        [CallerArgumentExpression("modifier1")]
        string name1 = "",
        [CallerArgumentExpression("modifier2")]
        string name2 = "",
        [CallerArgumentExpression("modifier3")]
        string name3 = "",
        [CallerArgumentExpression("modifier4")]
        string name4 = "")
    {
        return builder
            .Add(name1, modifier1)
            .Add(name2, modifier2)
            .Add(name3, modifier3)
            .Add(name4, modifier4);
    }

    public static ModifierBuilder Add(this ModifierBuilder builder, bool modifier1, bool modifier2, bool modifier3,
        bool modifier4, bool modifier5,
        [CallerArgumentExpression("modifier1")]
        string name1 = "",
        [CallerArgumentExpression("modifier2")]
        string name2 = "",
        [CallerArgumentExpression("modifier3")]
        string name3 = "",
        [CallerArgumentExpression("modifier4")]
        string name4 = "",
        [CallerArgumentExpression("modifier5")]
        string name5 = "")
    {
        return builder
            .Add(name1, modifier1)
            .Add(name2, modifier2)
            .Add(name3, modifier3)
            .Add(name4, modifier4)
            .Add(name5, modifier5);
    }

    public static ModifierBuilder Add(this ModifierBuilder builder, bool modifier1, bool modifier2, bool modifier3,
        bool modifier4, bool modifier5, bool modifier6,
        [CallerArgumentExpression("modifier1")]
        string name1 = "",
        [CallerArgumentExpression("modifier2")]
        string name2 = "",
        [CallerArgumentExpression("modifier3")]
        string name3 = "",
        [CallerArgumentExpression("modifier4")]
        string name4 = "",
        [CallerArgumentExpression("modifier5")]
        string name5 = "",
        [CallerArgumentExpression("modifier6")]
        string name6 = "")
    {
        return builder
            .Add(name1, modifier1)
            .Add(name2, modifier2)
            .Add(name3, modifier3)
            .Add(name4, modifier4)
            .Add(name5, modifier5)
            .Add(name6, modifier6);
    }

    public static ModifierBuilder Add(this ModifierBuilder builder, bool modifier1, bool modifier2, bool modifier3,
        bool modifier4, bool modifier5, bool modifier6, bool modifier7,
        [CallerArgumentExpression("modifier1")]
        string name1 = "",
        [CallerArgumentExpression("modifier2")]
        string name2 = "",
        [CallerArgumentExpression("modifier3")]
        string name3 = "",
        [CallerArgumentExpression("modifier4")]
        string name4 = "",
        [CallerArgumentExpression("modifier5")]
        string name5 = "",
        [CallerArgumentExpression("modifier6")]
        string name6 = "",
        [CallerArgumentExpression("modifier7")]
        string name7 = "")
    {
        return builder
            .Add(name1, modifier1)
            .Add(name2, modifier2)
            .Add(name3, modifier3)
            .Add(name4, modifier4)
            .Add(name5, modifier5)
            .Add(name6, modifier6)
            .Add(name7, modifier7);
    }

    /// <summary>
    /// Adds a modifier to the builder, excluding a specific enum value.
    /// </summary>
    /// <typeparam name="TEnum">The type of the enum modifier.</typeparam>
    /// <param name="builder">The builder to add the modifier to.</param>
    /// <param name="modifier">The enum modifier to add.</param>
    /// <param name="exclude">The enum value to exclude.</param>
    /// <param name="name">The name of the argument that provides the modifier. This is optional, and the default value is the name of the modifier.</param>
    /// <returns>The builder with the added modifier, excluding the specified value.</returns>
    /// <remarks>
    /// This method appends the modifier to the builder if it is an enum type, and it is not equal to the excluded value.
    /// The modifier is appended as a string representation of the enum value.
    /// </remarks>
    public static ModifierBuilder Add<TEnum>(this ModifierBuilder builder, TEnum modifier, TEnum exclude, [CallerArgumentExpression("modifier")] string name = "")
        where TEnum : Enum
    {
        return modifier.Equals(exclude) ? builder : builder.Add(modifier, name);
    }
}