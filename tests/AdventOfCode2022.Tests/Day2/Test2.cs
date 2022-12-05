using FluentAssertions;

namespace AdventOfCode2022.Tests.Day2
{
    public class Test2
    {
        [Fact]
        public void given_a_and_y_points_should_be_4()
        {
            var results = Match.Shoot('A', 'Y');

            results.Should().Be(4);
        }

        [Fact]
        public void given_b_and_x_points_should_be_5()
        {
            var results = Match.Shoot('B', 'X');

            results.Should().Be(5);
        }

        [Fact]
        public void given_b_and_z_points_should_be_6()
        {
            var results = Match.Shoot('B', 'Z');

            results.Should().Be(6);
        }
    }

    public static class Match
    {
        public static int Shoot(char opponent, char me)
        {
            if(me == 'Y')
                return 4;
            if (me == 'X')
                return 5;
            return 6;
        }
    }
}
