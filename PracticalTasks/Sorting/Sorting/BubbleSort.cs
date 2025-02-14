var str = System.Console.ReadLine();
if (str is null)
{
    Console.WriteLine("\nВсё плохо:(");
    return -1;
}

var массив = str.Split(' ');

// ToArray() склавдывает всё что вернул Select в массив.
var array = массив.Select(x => int.Parse(x)).ToArray();

// for (var i = 0; i < array.Length; ++i)
// {
//     if (int.TryParse(массив[i], out int result))
//     {
//         array[i] = result;
//     }
// }

System.Console.WriteLine("\nИсходный массив: ");

array.ToList().ForEach(x => Console.Write(x + " "));

BubbleSort(array);

System.Console.WriteLine("\nОтсортированный массив: ");
foreach (var item in array)
{
    System.Console.Write($"{item} ");
}

void BubbleSort(int[] array)
{
    bool isArraySorted = false;
    while (!isArraySorted)
    {
        isArraySorted = true;
        for (int i = 0; i < array.Length - 1; i++)
        {
            if (array[i] > array[i + 1])
            {
                (array[i], array[i + 1]) = (array[i + 1], array[i]);
                isArraySorted = false;
            }
        }
    }
}

var (mean, dispersion) = Math(array);
System.Console.WriteLine($"\nМат ожидание: {mean}\nДисперсия: {dispersion}");

(double Mean, double Dispersion) Math(int[] array)
{
    var mean = CalcMean(array);
    var dispersion = 1.0;
    foreach (var t in array)
    {
        dispersion += System.Math.Pow(t - mean, 2.0);
    }
    dispersion /= array.Length - 1;
    return (mean, dispersion);
    
    double CalcMean(int[] array) => array.Sum() / (float)array.Length;
}

return 0;