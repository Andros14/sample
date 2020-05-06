using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;

namespace GeneralExtensions.Tests
{
    public class CollectionExtensionsTests
    {
        [Fact]
        public void IsNullOrEmpty_EmptyCollection_IsTrue()
        {
            var value = new List<int>();

            Assert.True(value.IsNullOrEmpty());
        }

        [Fact]
        public void IsNullOrEmpty_NullableCollection_IsTrue()
        {
            List<int> value = null;

            Assert.True(value.IsNullOrEmpty());
        }

        [Fact]
        public void IsNullOrEmpty_NotEmptyCollection_IsFalse()
        {
            var value = new List<string>() { string.Empty };

            Assert.False(value.IsNullOrEmpty());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Split_IncorrectLength_ArgumentException(int length)
        {
            var value = new List<int>() { 1, 2, 3 };
            
            Assert.Throws<ArgumentException>(() => value.Split(length));
        }
        
        [Fact]
        public void Split_EmptyCollection_OneEmptyElement()
        {
            var value = new List<int>() { };
            
            var result = value.Split(2);
            
            Assert.True(result.Count() == 1);
            Assert.True(result.ElementAt(0).Count() == 0);
        }

        [Fact]
        public void Split_NullableCollection_OneNullableElement()
        {
            List<int> value = null;
            
            var result = value.Split(2);
            
            Assert.True(result.Count() == 1);
            Assert.Null(result.ElementAt(0));
        }

        [Theory]
        [InlineData(1, 3)]
        [InlineData(2, 2)]
        [InlineData(3, 1)]
        public void Split_CorrectArguments_CorrectCountParts(int length, int countparts)
        {
            var value = new List<int>() { 1, 2, 3 };
            
            Assert.Equal(countparts, value.Split(length).Count());
        }

        [Fact]
        public void Split_Values_CorrectValues()
        {
            var value = new List<int>() { 1, 2, 3, 4, 5 };
            var expectResult = new List<List<int>>()
            {
                new List<int>() { 1, 2 },
                new List<int>() { 3, 4 },
                new List<int>() { 5 }
            };
            
            var result = value.Split(2);
            
            for (var i = 0; i < expectResult.Count; i++)
            {
                var expectLine = expectResult.ElementAt(i);
                var line = result.ElementAt(i);
                for (var j = 0; j < expectLine.Count; j++)
                {
                    Assert.Equal(expectLine.ElementAt(j), line.ElementAt(j));
                }
            }
        }
    }
}
