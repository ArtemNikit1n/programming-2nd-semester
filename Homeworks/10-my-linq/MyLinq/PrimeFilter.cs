// <copyright file="PrimeFilter.cs" company="ArtemNikit1n">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyLinq;

/// <summary>
/// The prime number filter (decorator for ISequence).
/// </summary>
/// <param name="sequence">The basic sequence for filtering.</param>
public class PrimeFilter(ISequence sequence) : ISequence
{
    /// <summary>
    /// Generates a sequence of prime numbers.
    /// </summary>
    /// <returns>A filtered sequence of prime numbers.</returns>
    public IEnumerable<int> GetNumbers()
    {
        foreach (var number in sequence.GetNumbers())
        {
            if (IsPrime(number))
            {
                yield return number;
            }
        }
    }

    private static bool IsPrime(int number)
    {
        switch (number)
        {
            case < 2:
                return false;
            case 2:
                return true;
        }

        if (number % 2 == 0)
        {
            return false;
        }

        for (var i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0)
            {
                return false;
            }
        }

        return true;
    }
}