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

    public class HandSignFactory
    {
        private static IDictionary<char, IHandSign> _signDictionary = new Dictionary<char, IHandSign>();

        public HandSignFactory()
        {
            _signDictionary.Add('A', new Rock());
            _signDictionary.Add('B', new Paper());
            _signDictionary.Add('C', new Scissors());
            _signDictionary.Add('X', new Rock());
            _signDictionary.Add('Y', new Paper());
            _signDictionary.Add('Z', new Scissors());
        }

        public IHandSign GetSign(char sign)
        {
            return _signDictionary[sign];
        }
    }

    public class Rock : IHandSign, IComparable<IHandSign>
    {
        public int Points => 1;

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
    }
}
