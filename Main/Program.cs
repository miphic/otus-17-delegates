﻿using Main;

internal class Program
{
    private static void Main(string[] args)
    {
        exercise_1();
        
    }

    private static void exercise_1()
    {
        var list1 = new List<SampleValuedClass> {
            new SampleValuedClass(1.0f),
            new SampleValuedClass(3.0f),
            new SampleValuedClass(4.2f),
            new SampleValuedClass(3.0f),
            new SampleValuedClass(-1.0f),
            new SampleValuedClass(9.0f),
            new SampleValuedClass(1.111f),
        };
        var list2 = new List<SampleValuedClass> {
            new SampleValuedClass(1.55f),
            new SampleValuedClass(3.12f),
            new SampleValuedClass(6.6f),
            new SampleValuedClass(-33.0f),
            new SampleValuedClass(-1.0f),
            new SampleValuedClass(5.0f),
            new SampleValuedClass(3.131f),
            new SampleValuedClass(4.131f),
            new SampleValuedClass(1.911f),
        };


        Console.WriteLine(list1.GetMax((SampleValuedClass fff) => fff.Value));
        Console.WriteLine(list2.GetMax(SampleValuedClass.GetValueFunc));

        
        
    }
}