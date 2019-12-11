using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using Xunit.Categories;

namespace Schedulerer.Domain.Core.Tests
{
    [UnitTest]
    public class ValueObjectTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void CompareTestValueObjects_GivenEqualValueObjects_Equals(int first, int second)
        {
            var one = new TestValueObject(first, second);
            var two = new TestValueObject(first, second);

            one.Should().BeEquivalentTo(two);
            one.Should().Be(two);
            one.GetHashCode().Should().Be(two.GetHashCode());
            (one == two).Should().BeTrue();
            (one != two).Should().BeFalse();
        }

        [Fact]
        public void CompareTestValueObjects_GivenTwoNullValueObjects_Equals()
        {
            TestValueObject one = null;
            TestValueObject two = null;

            one.Should().BeEquivalentTo(two);
            one.Should().Be(two);
            (one == two).Should().BeTrue();
            (one != two).Should().BeFalse();
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void CompareTestValueObjects_GivenUnequalValueObjects_NotEquals(int first, int second)
        {
            var one = new TestValueObject(first, second);
            var two = new TestValueObject(second, first);

            one.Should().NotBeEquivalentTo(two);
            one.Should().NotBe(two);
            (one == two).Should().BeFalse();
            (one != two).Should().BeTrue();
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void CompareTestValueObjects_GivenFirstNullValueObject_NotEquals(int first, int second)
        {
            TestValueObject one = null;
            var two = new TestValueObject(first, second);

            one.Should().NotBeEquivalentTo(two);
            one.Should().NotBe(two);
            (one == two).Should().BeFalse();
            (one != two).Should().BeTrue();
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void CompareTestValueObjects_GivenSecondNullValueObject_NotEquals(int first, int second)
        {
            var one = new TestValueObject(first, second);
            TestValueObject two = null;

            one.Should().NotBeEquivalentTo(two);
            one.Should().NotBe(two);
            one.Should().NotBe(null);
            one.Equals(null).Should().BeFalse();
            (one == two).Should().BeFalse();
            (one != two).Should().BeTrue();
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void CompareTestValueObjects_GivenDifferentType_NotEquals(int first, int second)
        {
            var one = new TestValueObject(first, second);
            var two = new { Id = 123 };

            one.Should().NotBeEquivalentTo(two);
            one.Should().NotBe(two);
        }

        public static IEnumerable<object[]> Data => new List<object[]>
        {
            new object[] { new Random().Next(), new Random().Next() }
        };

        private class TestValueObject : ValueObject
        {
            public int One { get; }
            public int Two { get; }

            public TestValueObject(int one, int two)
            {
                One = one;
                Two = two;
            }

            protected override IEnumerable<object> GetEqualityComponents()
            {
                yield return One;
                yield return Two;
            }
        }
    }
}