using AdventOfCode2022.Day2;
using AdventOfCode2022.Tests.Day1;
using FluentAssertions;
using System.ComponentModel;

namespace AdventOfCode2022.Tests.Day2
{
    public class MyTyingMoves
    {
        [Fact]
        public void given_Rock_and_Rock_points_should_be_4()
        {
            var sut = new Match(new Rock(), new Rock());

            var results = sut.Shoot();

            results.Should().Be(4);
        }

        [Fact]
        public void given_Paper_and_Paper_points_should_be_5()
        {
            var sut = new Match(new Paper(), new Paper());

            var results = sut.Shoot();

            results.Should().Be(5);
        }

        [Fact]
        public void given_Scissors_and_Scissors_points_should_be_6()
        {
            var sut = new Match(new Scissors(), new Scissors());

            var results = sut.Shoot();

            results.Should().Be(6);
        }
    }

    public class MyLosingMoves
    {
        [Fact]
        public void given_Paper_and_Rock_points_should_be_1()
        {
            var sut = new Match(new Paper(), new Rock());

            var results = sut.Shoot();

            results.Should().Be(1);
        }

        [Fact]
        public void given_Scissors_and_Paper_points_should_be_2()
        {
            var sut = new Match(new Scissors(), new Paper());

            var results = sut.Shoot();

            results.Should().Be(2);
        }

        [Fact]
        public void given_Rock_and_Scissors_points_should_be_3()
        {
            var sut = new Match(new Rock(), new Scissors());

            var results = sut.Shoot();

            results.Should().Be(3);
        }
    }

    public class MyWinningMoves
    {
        [Fact]
        public void given_Scissors_and_Rock_points_should_be_1()
        {
            var sut = new Match(new Scissors(), new Rock());

            var results = sut.Shoot();

            results.Should().Be(7);
        }

        [Fact]
        public void given_Rock_and_Paper_points_should_be_2()
        {
            var sut = new Match(new Rock(), new Paper());

            var results = sut.Shoot();

            results.Should().Be(8);
        }

        [Fact]
        public void given_Paper_and_Scissors_points_should_be_3()
        {
            var sut = new Match(new Paper(), new Scissors());

            var results = sut.Shoot();

            results.Should().Be(9);
        }
    }

    public class TestFully
    {
        [Fact]
        public void test()
        {
            var sut = new Tie();

            var result = sut.Sign(new Rock());

            result.Should().BeOfType<Rock>();
        }

        [Theory]
        [InlineData('A', 'B')]
        [InlineData('B', 'C')]
        [InlineData('C', 'A')]
        public void given_test_next_should_be(char given, char expected)
        {
            var handSign = HandSignFactory.GetSign(given);

            var result = handSign.Next();

            var expectedSign = HandSignFactory.GetSign(expected);
            result.Should().BeOfType(expectedSign.GetType());
        }

        [Theory]
        [InlineData('A', 'C')]
        [InlineData('B', 'A')]
        [InlineData('C', 'B')]
        public void given_test_previous_should_be(char given, char expected)
        {
            var handSign = HandSignFactory.GetSign(given);

            var result = handSign.Previous();

            var expectedSign = HandSignFactory.GetSign(expected);
            result.Should().BeOfType(expectedSign.GetType());
        }
    }
}
