using AdventOfCode2022.Day4;
using FluentAssertions;

namespace AdventOfCode2022.Tests.Day4
{
    public class Test4
    {
        [Fact]
        public void given_assignments_then_AssignmentValue_should_be()
        {
            var sut = new Elf();

            sut.SetAssignments(2, 4);

            sut.AssignmentValue.Should().Be(6);
        }

        [Fact]
        public void given_same_assignmente_then_AssignmentValue_should_be()
        {
            var sut = new Elf();

            sut.SetAssignments(4, 4);

            sut.AssignmentValue.Should().Be(4);
        }
    }

    public class MoreTest4
    {
        [Fact]
        public void elf1_smaller_and_non_intersecting()
        {
            var elf1 = new Elf();
            elf1.SetAssignments(4, 4);
            
            var elf2 = new Elf();
            elf2.SetAssignments(6, 10);

            var result = CompareThings.FullyContained(elf1, elf2);

            result.Should().BeFalse();
        }

        [Fact]
        public void elf1_small_and_intersecting()
        {
            var elf1 = new Elf();
            elf1.SetAssignments(4, 8);

            var elf2 = new Elf();
            elf2.SetAssignments(6, 10);

            var result = CompareThings.FullyContained(elf1, elf2);

            result.Should().BeFalse();
        }

        [Fact]
        public void elf1_fully_contained()
        {
            var elf1 = new Elf();
            elf1.SetAssignments(6, 10);

            var elf2 = new Elf();
            elf2.SetAssignments(6, 10);

            var result = CompareThings.FullyContained(elf1, elf2);

            result.Should().BeTrue();
        }

        [Fact]
        public void elf1_smaller_and_non_intersecting_reversed()
        {
            var elf1 = new Elf();
            elf1.SetAssignments(4, 4);

            var elf2 = new Elf();
            elf2.SetAssignments(6, 10);

            var result = CompareThings.FullyContained(elf2, elf1);

            result.Should().BeFalse();
        }

        [Fact]
        public void elf1_small_and_intersecting_reversed()
        {
            var elf1 = new Elf();
            elf1.SetAssignments(4, 8);

            var elf2 = new Elf();
            elf2.SetAssignments(6, 10);

            var result = CompareThings.FullyContained(elf2, elf1);

            result.Should().BeFalse();
        }

        [Fact]
        public void elf1_fully_contained_reversed()
        {
            var elf1 = new Elf();
            elf1.SetAssignments(6, 10);

            var elf2 = new Elf();
            elf2.SetAssignments(6, 10);

            var result = CompareThings.FullyContained(elf2, elf1);

            result.Should().BeTrue();
        }

        [Theory]
        [InlineData(19, 47, 18, 99)]
        [InlineData(5, 47, 5, 99)]
        [InlineData(5, 5, 5, 99)]
        [InlineData(5, 5, 4, 78)]
        public void elf_lots_of_things_fully_contained(int begin1, int end1, int begin2, int end2)
        {
            var elf1 = new Elf();
            elf1.SetAssignments(begin1, end1);

            var elf2 = new Elf();
            elf2.SetAssignments(begin2, end2);

            var result = CompareThings.FullyContained(elf2, elf1);

            result.Should().BeTrue();
        }

        [Theory]
        [InlineData(77, 78, 4, 78)]
        public void moreThings(int begin1, int end1, int begin2, int end2)
        {
            var elf1 = new Elf();
            elf1.SetAssignments(begin1, end1);

            var elf2 = new Elf();
            elf2.SetAssignments(begin2, end2);

            var result = CompareThings.FullyContained(elf2, elf1);

            result.Should().BeTrue();
        }


        [Theory]
        [InlineData(4, 8, 7, 98)]
        public void elf_lots_of_things_not_contained(int begin1, int end1, int begin2, int end2)
        {
            var elf1 = new Elf();
            elf1.SetAssignments(begin1, end1);

            var elf2 = new Elf();
            elf2.SetAssignments(begin2, end2);

            var result = CompareThings.FullyContained(elf2, elf1);

            result.Should().BeFalse();
        }
    }

    public class EvenMoreTests
    {
        [Fact]
        public void elf1_smaller_and_non_intersecting()
        {
            var elf1 = new Elf();
            elf1.SetAssignments(4, 4);

            var elf2 = new Elf();
            elf2.SetAssignments(6, 10);

            var result = CompareThings.Overlapping(elf1, elf2);

            result.Should().BeFalse();
        }

        [Fact]
        public void elf1_small_and_intersecting()
        {
            var elf1 = new Elf();
            elf1.SetAssignments(4, 8);

            var elf2 = new Elf();
            elf2.SetAssignments(6, 10);

            var result = CompareThings.Overlapping(elf1, elf2);

            result.Should().BeTrue();
        }

        [Fact]
        public void elf1_fully_contained()
        {
            var elf1 = new Elf();
            elf1.SetAssignments(6, 10);

            var elf2 = new Elf();
            elf2.SetAssignments(6, 10);

            var result = CompareThings.Overlapping(elf1, elf2);

            result.Should().BeTrue();
        }

        [Fact]
        public void elf1_smaller_and_non_intersecting_reversed()
        {
            var elf1 = new Elf();
            elf1.SetAssignments(4, 4);

            var elf2 = new Elf();
            elf2.SetAssignments(6, 10);

            var result = CompareThings.Overlapping(elf2, elf1);

            result.Should().BeFalse();
        }

        [Fact]
        public void elf1_small_and_intersecting_reversed()
        {
            var elf1 = new Elf();
            elf1.SetAssignments(4, 8);

            var elf2 = new Elf();
            elf2.SetAssignments(6, 10);

            var result = CompareThings.Overlapping(elf2, elf1);

            result.Should().BeTrue();
        }

        [Fact]
        public void elf1_fully_contained_reversed()
        {
            var elf1 = new Elf();
            elf1.SetAssignments(6, 10);

            var elf2 = new Elf();
            elf2.SetAssignments(6, 10);

            var result = CompareThings.Overlapping(elf2, elf1);

            result.Should().BeTrue();
        }

        [Theory]
        [InlineData(19, 47, 18, 99)]
        [InlineData(5, 47, 5, 99)]
        [InlineData(5, 5, 5, 99)]
        [InlineData(5, 5, 4, 78)]
        public void elf_lots_of_things_fully_contained(int begin1, int end1, int begin2, int end2)
        {
            var elf1 = new Elf();
            elf1.SetAssignments(begin1, end1);

            var elf2 = new Elf();
            elf2.SetAssignments(begin2, end2);

            var result = CompareThings.Overlapping(elf2, elf1);

            result.Should().BeTrue();
        }

        [Theory]
        [InlineData(77, 78, 4, 78)]
        public void moreThings(int begin1, int end1, int begin2, int end2)
        {
            var elf1 = new Elf();
            elf1.SetAssignments(begin1, end1);

            var elf2 = new Elf();
            elf2.SetAssignments(begin2, end2);

            var result = CompareThings.Overlapping(elf2, elf1);

            result.Should().BeTrue();
        }


        [Theory]
        [InlineData(4, 8, 7, 98)]
        public void elf_lots_of_things_not_contained(int begin1, int end1, int begin2, int end2)
        {
            var elf1 = new Elf();
            elf1.SetAssignments(begin1, end1);

            var elf2 = new Elf();
            elf2.SetAssignments(begin2, end2);

            var result = CompareThings.Overlapping(elf2, elf1);

            result.Should().BeTrue();
        }
    }
}
