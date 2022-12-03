namespace AdventOfCode2022.Day1
{
    public class Elf
    {
        private Elf() { }

        public static Elf Create()
        {
            return new Elf();
        }

        public int TotalCalories { get; protected set; }

        public void AddFood(Food food)
        {
            TotalCalories = food.Calories;
        }
    }
}
