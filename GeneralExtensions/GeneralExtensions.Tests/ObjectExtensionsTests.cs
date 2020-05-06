using Xunit;

namespace GeneralExtensions.Tests
{
    public class ObjectExtensionsTests
    {
        [Fact]
        public void IsNull_NulableObject_IsTrue()
        {
            object value = default;

            Assert.True(value.IsNull());
        }

        [Theory]
        [InlineData("")]
        [InlineData(1)]
        public void IsNull_SampleObject_IsFalse(object value)
        {
            Assert.False(value.IsNull());
        }

        [Fact]
        public void IsNull_ComplexObect_IsFalse()
        {
            var value = new { Field = string.Empty };
            
            Assert.False(value.IsNull());
        }

        [Fact]
        public void IsNotNull_NulableObjectct_IsFalse()
        {
            object value = default;
            
            Assert.False(value.IsNotNull());
        }

        [Theory]
        [InlineData("")]
        [InlineData(1)]
        public void IsNotNull_SampleObject_IsTrue(object value)
        {
            Assert.True(value.IsNotNull());
        }

        [Fact]
        public void IsNotNull_ComplexObect_IsFalse()
        {
            var value = new { Field = string.Empty };
            
            Assert.True(value.IsNotNull());
        }


        [Fact]
        public void ConvertTo_IntToString_Success()
        {
            var value = 12345;
            
            var result = value.ConvertTo<string>();
            
            Assert.Equal(value.ToString(), result);
        }

        [Fact]
        public void ConvertTo_StringToInt_Success()
        {
            var value = "12345";

            var result = value.ConvertTo<int>();
            
            Assert.Equal(value, result.ToString());
        }
    }
}
