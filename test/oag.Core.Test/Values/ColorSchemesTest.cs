using oag.Core.Values;
using System.Linq;
using System.Reflection;
using Xunit;

namespace oag.Core.Test
{
    public class ColorSchemesTest
    {
        [Fact]
        public void Should_BeUniqueValues_When_CheckAllVersionTypes()
        {
            // Arrange
            var values = typeof(ColorSchemes)
                .GetFields(BindingFlags.Static | BindingFlags.Public)
                .Select(f => f.GetValue(null).ToString())
                .ToList();

            // Act
            bool unique = values.Distinct().Count() == values.Count;

            // Assert
            Assert.True(unique);
        }
    }
}
