using AdventOfCode2022.Day1;

namespace AdventOfCode2022.Day4
{
    public class Elf
    {
        public int Begin { get; private set; }
        public int End { get; private set; }

        public int AssignmentValue { get; private set; }

        public void SetAssignments(int begin, int end)
        {
            Begin = begin;
            End = end;
            if (begin == end)
                AssignmentValue = begin;
            else
                AssignmentValue = begin + end;
        }
    }

    public static class CompareThings
    {
        public static bool FullyContained(Elf elf1, Elf elf2)
        {
            if (elf1.Begin >= elf2.Begin
                && elf1.End <= elf2.End)
            {
                return true;
            }
            if (elf1.Begin <= elf2.Begin
                && elf1.End >= elf2.End)
            {
                return true;
            }
            return false;
        }

        public static bool Overlapping(Elf elf1, Elf elf2)
        {
            if (elf1.Begin <= elf2.Begin && elf2.Begin <= elf1.End)
            {
                return true;
            }
            if (elf2.Begin <= elf1.Begin && elf1.Begin <= elf2.End)
            {
                return true;
            }
            return false;
        }
    }
}
