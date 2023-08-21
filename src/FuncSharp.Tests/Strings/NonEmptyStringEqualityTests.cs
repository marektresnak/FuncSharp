﻿using Xunit;

namespace FuncSharp.Tests.Strings;

public class NonEmptyStringTests
{
    [Fact]
    public void OptionEqualityTest()
    {
        IOption<NonEmptyString> valued1 = Option.Valued(NonEmptyString.CreateUnsafe("ASDF123"));
        IOption<string> valued2 = Option.Valued("ASDF123");
        Assert.True(valued1.Equals(valued2));
        Assert.True(valued2.Equals(valued1));
        Assert.True(Equals(valued1, valued2));
        Assert.True(Equals(valued2, valued1));

        var differentStringOption = Option.Valued("Text14");
        var differentNonEmptyStringOption = Option.Valued(NonEmptyString.CreateUnsafe("Totally different text here."));
        Assert.False(differentNonEmptyStringOption.Equals(differentStringOption));
        Assert.False(differentStringOption.Equals(differentNonEmptyStringOption));
        Assert.False(Equals(differentNonEmptyStringOption, differentStringOption));
        Assert.False(Equals(differentStringOption, differentNonEmptyStringOption));

        IOption<NonEmptyString> empty1 = Option.Empty<NonEmptyString>();
        IOption<string> empty2 = Option.Empty<string>();
        Assert.True(empty1.Equals(empty2));
        Assert.True(empty2.Equals(empty1));
        Assert.True(Equals(empty1, empty2));
        Assert.True(Equals(empty2, empty1));

        IOption<NonEmptyString> valuedWithNull1 = Option.Valued<NonEmptyString>(null);
        IOption<string> valuedWithNull2 = Option.Valued<string>(null);
        Assert.True(valuedWithNull1.Equals(valuedWithNull2));
        Assert.True(valuedWithNull2.Equals(valuedWithNull1));
        Assert.True(Equals(valuedWithNull1, valuedWithNull2));
        Assert.True(Equals(valuedWithNull2, valuedWithNull1));
    }

    [Fact]
    public void EqualityTest()
    {
#pragma warning disable xUnit2010

        string text = "ASDF123";
        NonEmptyString nonEmptyString = NonEmptyString.CreateUnsafe("ASDF123");
        Assert.True(text == nonEmptyString);
        Assert.True(nonEmptyString == text);
        Assert.True(text.Equals(nonEmptyString));
        Assert.True(nonEmptyString.Equals(text));
        Assert.True(text.SafeEquals(nonEmptyString));
        Assert.True(nonEmptyString.SafeEquals(text));
        // Assert.True(Equals(text, nonEmptyString)); - Unfortunately this doesn't work because default string comparer doesn't check IEquateable<String> - https://stackoverflow.com/questions/76942352/iequatablestring-doesnt-work-with-static-equals-method.
        Assert.True(Equals(nonEmptyString, text));

        string differentString = "Text14";
        NonEmptyString differentNonEmptyString = NonEmptyString.CreateUnsafe("Totally different text here.");
        Assert.False(differentNonEmptyString.Equals(differentString));
        Assert.False(differentString.Equals(differentNonEmptyString));
        Assert.False(differentNonEmptyString == differentString);
        Assert.False(differentString == differentNonEmptyString);
        Assert.False(differentNonEmptyString.SafeEquals(differentString));
        Assert.False(differentString.SafeEquals(differentNonEmptyString));
        Assert.False(Equals(differentNonEmptyString, differentString));
        Assert.False(Equals(differentString, differentNonEmptyString));

        NonEmptyString null1 = null;
        string null2 = null;
        Assert.True(null1.SafeEquals(null2));
        Assert.True(null2.SafeEquals(null1));
        Assert.True(null1 == null2);
        Assert.True(null2 == null1);
        Assert.True(Equals(null1, null2));
        Assert.True(Equals(null2, null1));

#pragma warning restore xUnit2010
    }
}