namespace AdventOfCode2022.Day2
{
    public class Match
    {
        private readonly IHandSign opponent;
        private readonly IHandSign me;

        public Match(IHandSign opponent, IHandSign me)
        {
            this.opponent = opponent;
            this.me = me;
        }

        public Match(IHandSign opponent, IGameResult result)
        {
            this.opponent = opponent;
            this.me = result.Sign(opponent);
        }

        public int Shoot()
        {
            return DoResults(opponent, me) + me.Points;
        }

        private static int DoResults(IHandSign oppenent, IHandSign me)
        {
            switch (me.CompareTo(oppenent))
            {
                case -1:
                    return 0;
                case 0:
                    return 3;
                case 1:
                    return 6;
                default: return -1;
            }
        }
    }

    public static class HandSignFactory
    {
        private static IEnumerable<IHandSign> _signDictionary
            = new IHandSign[] { new Rock(), new Paper(), new Scissors() };
        private static IEnumerable<IGameResult> _conditionDictionary
            = new IGameResult[] { new Lose(), new Tie(), new Win() };

        public static IHandSign GetSign(char sign)
        {
            return _signDictionary.First(s => s.Id == sign);
        }

        public static IGameResult GetCondition(char sign)
        {
            return _conditionDictionary.First(s => s.Id == sign);
        }

        public static IHandSign Next(this IHandSign sign)
        {
            var next = sign.Id + 1;
            if (next > 'C')
                next -= 3;
            return GetSign((char)next);
        }

        public static IHandSign Previous(this IHandSign sign)
        {
            var next = sign.Id - 1;
            if (next < 'A')
                next += 3;
            return GetSign((char)next);
        }
    }

    public class Rock : IHandSign, IComparable<IHandSign>
    {
        public int Points => 1;
        public char Id => 'A';

        public int CompareTo(IHandSign? other)
        {
            if (other is Paper)
                return -1;
            if (other is Scissors)
                return 1;
            return 0;
        }
    }

    public class Paper : IHandSign, IComparable<IHandSign>
    {
        public int Points => 2;
        public char Id => 'B';

        public int CompareTo(IHandSign? other)
        {
            if (other is Scissors)
                return -1;
            if (other is Rock)
                return 1;
            return 0;
        }
    }

    public class Scissors : IHandSign, IComparable<IHandSign>
    {
        public int Points => 3;
        public char Id => 'C';

        public int CompareTo(IHandSign? other)
        {
            if (other is Rock)
                return -1;
            if (other is Paper)
                return 1;
            return 0;
        }
    }

    public interface IHandSign : IComparable<IHandSign>
    {
        int Points { get; }
        char Id { get; }
    }
    
    public interface IGameResult
    {
        char Id { get; }
        IHandSign Sign(IHandSign opponentsSign);
    }

    public class Lose : IGameResult
    {
        public char Id => 'X';
        public IHandSign Sign(IHandSign opponentsSign)
        {
            return opponentsSign.Previous();
        }
    }

    public class Tie : IGameResult
    {
        public char Id => 'Y';
        public IHandSign Sign(IHandSign opponentsSign)
        {
            return opponentsSign;
        }
    }

    public class Win : IGameResult
    {
        public char Id => 'Z';

        public IHandSign Sign(IHandSign opponentsSign)
        {
            return opponentsSign.Next();
        }
    }
}
