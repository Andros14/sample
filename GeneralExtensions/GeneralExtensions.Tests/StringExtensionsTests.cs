using System;
using Xunit;
using System.Linq;
using System.Collections.Generic;

namespace GeneralExtensions.Tests
{
    public class StringExtensionsTests
    {
        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void IsNullOrWhiteSpace_EmpyString_IsTrue(string value)
        {
            Assert.True(value.IsNullOrWhiteSpace());
        }

        [Theory]
        [InlineData("_")]
        [InlineData("abc")]
        public void IsNullOrWhiteSpace_NotEmpyString_IsFalse(string value)
        {
            Assert.False(value.IsNullOrWhiteSpace());
        }

        [Theory]
        [InlineData("", "")]
        [InlineData(null, null)]
        [InlineData("abc", "abc")]
        public void IsEquals_EqualValues_IsTrue(string value, string comparable)
        {
            Assert.True(value.IsEquals(comparable));
        }

        [Theory]
        [InlineData("", " ")]
        [InlineData(" ", "")]
        [InlineData("", null)]
        [InlineData(null, "")]
        [InlineData("Abc", "abc")]
        [InlineData("abc", "aBc")]
        [InlineData("abc", "ab")]
        [InlineData("ab", "abc")]
        public void IsEquals_NotEqualValues_IsFalse(string value, string comparable)
        {
            Assert.False(value.IsEquals(comparable));
        }

        [Theory]
        [InlineData("", "")]
        [InlineData(null, null)]
        [InlineData("abc", "abc")]
        [InlineData("Abc", "abc")]
        [InlineData("abc", "aBc")]
        [InlineData("abc", "ABC")]
        [InlineData("ABC", "abc")]
        public void IsIgnoreCaseEquals_EqualValues_IsTrue(string value, string comparable)
        {
            Assert.True(value.IsIgnoreCaseEquals(comparable));
        }

        [Theory]
        [InlineData("", " ")]
        [InlineData(" ", "")]
        [InlineData("", null)]
        [InlineData(null, "")]
        [InlineData("abc", "ab")]
        [InlineData("ab", "abc")]
        public void IsIgnoreCaseEquals_NotEqualValues_IsFalse(string value, string comparable)
        {
            Assert.False(value.IsIgnoreCaseEquals(comparable));
        }

        [Theory]
        [InlineData("", "")]
        [InlineData(" ", "")]
        [InlineData(null, null)]
        [InlineData("abc", "a")]
        [InlineData("abc", "b")]
        [InlineData("abc", "c")]
        public void IsContains_Contains_IsTrue(string value, string comparable)
        {
            Assert.True(value.IsContains(comparable));
        }

        [Theory]
        [InlineData("", " ")]
        [InlineData(null, "")]
        [InlineData("abc", "d")]
        [InlineData("abc", "ac")]
        [InlineData("abc", "A")]
        public void IsContains_NotContains_IsFalse(string value, string comparable)
        {
            Assert.False(value.IsContains(comparable));
        }

        [Fact]
        public void IsContains_ComparableValueIsNull_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => "aba".IsContains(null));
        }

        [Theory]
        [InlineData("", "")]
        [InlineData(" ", "")]
        [InlineData(null, null)]
        [InlineData("abc", "A")]
        [InlineData("abc", "B")]
        [InlineData("abc", "C")]
        [InlineData("ABC", "a")]
        [InlineData("ABC", "b")]
        [InlineData("ABC", "c")]
        public void IsIgnoreCaseContains_Contains_IsTrue(string value, string comparable)
        {
            Assert.True(value.IsIgnoreCaseContains(comparable));
        }

        [Theory]
        [InlineData("", " ")]
        [InlineData(null, "")]
        [InlineData("abc", "d")]
        [InlineData("abc", "ac")]
        public void IsIgnoreCaseContains_NotContains_IsFalse(string value, string comparable)
        {
            Assert.False(value.IsIgnoreCaseContains(comparable));
        }

        [Fact]
        public void IsIgnoreCaseContains_ComparableValueIsNull_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => "aba".IsIgnoreCaseContains(null));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Split_IncorrectLength_ArgumentException(int length)
        {
            Assert.Throws<ArgumentException>(() => "abc".Split(length));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Split_EmptyString_OneEmptyElement(string value)
        {
            var result = value.Split(2);

            Assert.Single(result);
            Assert.True(result.First().IsNullOrWhiteSpace());
        }

        [Theory]
        [InlineData("abc", 1, 3)]
        [InlineData("abc", 2, 2)]
        [InlineData("abc", 3, 1)]
        public void Split_CorrectArguments_CorrectCountParts(string value, int length, int countparts)
        {
            var result = value.Split(length);
            
            Assert.True(countparts == result.Count);
        }

        [Fact]
        public void Split_Values_CorrectValues()
        {
            var value = "Qwerty123";
            var expectResult = new List<string>()
            {
                "Qwer",
                "ty12",
                "3"
            };

            var result = value.Split(4);

            for (var i = 0; i < expectResult.Count; i++)
            {
                Assert.Equal(expectResult.ElementAt(i), result.ElementAt(i));
            }
        }
    }
}
