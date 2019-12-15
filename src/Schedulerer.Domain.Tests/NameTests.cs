using FluentAssertions;
using LanguageExt.UnitTesting;
using Xunit;
using Xunit.Categories;

namespace Schedulerer.Domain.Tests
{
    [UnitTest]
    public class NameTests
    {
        [Theory]
        [InlineData("first", "last", "first last")]
        public void Create_WithoutMiddleName_Succeeds(string first, string last, string display)
        {
            var name = Name.Create(first, last);

            name.FirstName.Should().Be(first);
            name.MiddleName.ShouldBeNone();
            name.LastName.Should().Be(last);
            name.DisplayName.Should().Be(display);
        }

        [Theory]
        [InlineData("first", null, "last", "first last")]
        [InlineData("first", "", "last", "first last")]
        [InlineData("first", "  ", "last", "first last")]
        public void Create_WitEmptyMiddleName_Succeeds(string first, string middle, string last, string display)
        {
            var name = Name.Create(first, middle, last);

            name.FirstName.Should().Be(first);
            name.MiddleName.ShouldBeNone();
            name.LastName.Should().Be(last);
            name.DisplayName.Should().Be(display);
        }

        [Theory]
        [InlineData("first", "middle", "last", "first middle last")]
        public void Create_WithMiddleName_Succeeds(string first, string middle, string last, string display)
        {
            var name = Name.Create(first, middle, last);

            name.FirstName.Should().Be(first);
            name.MiddleName.ShouldBeSome(s => s.Should().Be(middle));
            name.LastName.Should().Be(last);
            name.DisplayName.Should().Be(display);
        }
    }
}