using Main;

internal class Program
{
    private static void Main(string[] args)
    {
        exercise_1();
        
    }

    private static void exercise_1()
    {
        var list = new List<ValuedClass> {
            new ValuedClass(1.0f),
            new ValuedClass(3.0f),
            new ValuedClass(4.2f),
            new ValuedClass(3.0f),
            new ValuedClass(-1.0f),
            new ValuedClass(9.0f),
            new ValuedClass(1.111f),
        };

        Console.WriteLine(list.GetMax((ValuedClass fff) => fff.Value));
    }
}