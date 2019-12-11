using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using Xunit.Categories;

namespace Schedulerer.Domain.Core.Tests
{
    [UnitTest]
    public class EntityTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void Compare_GivenTestEntitiesWithSameIdentity_Equal(Guid id, string title, decimal price)
        {
            var one = new TestEntity(id, title, price);
            var two = new TestEntity(id, $"{title}2", price * 20);

            one.Should().BeEquivalentTo(two);
            one.Should().Be(two);
            one.Equals(two).Should().BeTrue();
            one.GetHashCode().Should().Be(two.GetHashCode());
            (one == two).Should().BeTrue();
            (one != two).Should().BeFalse();
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Compare_GivenSameReferences_Equal(Guid id, string title, decimal price)
        {
            var one = new TestEntity(id, title, price);
            var two = one;

            one.Should().BeEquivalentTo(two);
            one.Should().BeSameAs(two);
            one.Should().Be(two);
            one.Equals(two).Should().BeTrue();
            one.GetHashCode().Should().Be(two.GetHashCode());
            (one == two).Should().BeTrue();
            (one != two).Should().BeFalse();
        }

        [Fact]
        public void Compare_GivenBothNullEntities_Equal()
        {
            TestEntity one = null;
            TestEntity two = null;

            one.Should().BeEquivalentTo(two);
            one.Should().Be(two);
            (one == two).Should().BeTrue();
            (one != two).Should().BeFalse();
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Compare_GivenFirstNullEntity_NotEqual(Guid id, string title, decimal price)
        {
            TestEntity one = null;
            var two = new TestEntity(id, title, price);

            one.Should().NotBeEquivalentTo(two);
            one.Should().NotBeSameAs(two);
            one.Should().NotBe(two);
            (one == two).Should().BeFalse();
            (one != two).Should().BeTrue();
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Compare_GivenSecondNullEntity_NotEqual(Guid id, string title, decimal price)
        {
            var one = new TestEntity(id, title, price);
            TestEntity two = null;

            one.Should().NotBeEquivalentTo(two);
            one.Should().NotBeSameAs(two);
            one.Should().NotBe(two);
            one.Should().NotBe(null);
            one.Equals(null).Should().BeFalse();
            (one == two).Should().BeFalse();
            (one != two).Should().BeTrue();
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Compare_GivenObjectWithSameIdentity_NotEqual(Guid id, string title, decimal price)
        {
            var one = new { Id = id };
            var two = new TestEntity(id, title, price);

            one.Should().NotBeEquivalentTo(two);
            one.Should().NotBe(two);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Compare_GivenDefaultIdentities_NotEqual(Guid id, string title, decimal price)
        {
            var one = new TestEntity(default, title, price);
            var two = new TestEntity(default, title, price);

            one.Should().NotBeEquivalentTo(two);
            one.Should().NotBe(two);
            (one == two).Should().BeFalse();
            (one != two).Should().BeTrue();
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Compare_GivenDifferentClassWithSameIdentity_NotEqual(Guid id, string title, decimal price)
        {
            var one = new TestEntity(id, title, price);
            var two = new DifferentTestEntity(id, title, price);

            one.Should().NotBeEquivalentTo(two);
            one.Should().NotBeSameAs(two);
            one.Should().NotBe(two);
            one.Equals(two).Should().BeFalse();
            (one == two).Should().BeFalse();
            (one != two).Should().BeTrue();
        }

        public static IEnumerable<object[]> Data => new List<object[]>
        {
            new object[] { Guid.NewGuid(), $"title-{Guid.NewGuid().ToString()}", new Random().NextDouble() * 1000 }
        };

        private class TestEntity : Entity
        {
            public string EntityTitle { get; set; }
            public decimal EntityPrice { get; set; }

            public TestEntity(Guid id, string title, decimal price)
            {
                Id = id;
                EntityTitle = title;
                EntityPrice = price;
            }
        }

        private class DifferentTestEntity : Entity
        {
            public string EntityTitle { get; set; }
            public decimal EntityPrice { get; set; }

            public DifferentTestEntity(Guid id, string title, decimal price)
            {
                Id = id;
                EntityTitle = title;
                EntityPrice = price;
            }
        }
    }
}
