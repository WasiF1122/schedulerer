using FluentAssertions;
using LanguageExt.Common;
using LanguageExt.UnitTesting;
using Xunit;
using Xunit.Categories;

namespace Schedulerer.Domain.Tests
{
    [UnitTest]
    public class AgeTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(15)]
        public void Create_GivenCorrectAge_CreatesWithCorrectValues(int value)
        {
            var age = Age.Create(value);

            age.ShouldBeSuccess(x => value.Should().Be(x));
        }

        [Theory]
        [InlineData(-1, "Age cannot be negative")]
        [InlineData(19, "Age cannot be greater than 18")]
        public void Create_GivenIncorrectAge_ReturnsError(int value, string errorMessage)
        {
            var age = Age.Create(value);
            var error = Error.New(errorMessage);

            age.ShouldBeFail(x => x.First().Should().Be(error));
        }

        [Fact]
        public void Compare_GivenEqualAges_Succeeds()
        {
            (Age.Create(5), Age.Create(5)).Sequence().ShouldBeSuccess(x =>
            {
                x.Item1.Should().Be(x.Item2);
                (x.Item1 == x.Item2).Should().BeTrue();
            });
        }

        [Fact]
        public void Compare_GivenDifferentAges_Succeeds()
        {
            (Age.Create(5), Age.Create(9)).Sequence().ShouldBeSuccess(x =>
            {
                var (five, nine) = x;

                (five < nine).Should().BeTrue();
                (nine > five).Should().BeTrue();
            });
        }
    }
}