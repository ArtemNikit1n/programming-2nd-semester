// <copyright file="MapFilterFold1.cs" company="ArtemNikit1n">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MapFilterFold;

/// <summary>
/// A common class for the Map, Filter and Fold functions.
/// </summary>
public static class MapFilterFold
{
    /// <summary>
    /// Accepts a list and a function that transforms the list item.
    /// The list obtained by applying the passed function to each element of the passed list is returned.
    /// </summary>
    /// <param name="list">The input list.</param>
    /// <param name="function">A function that needs to be applied to all the items in the list.</param>
    /// <typeparam name="T">The type of data in the list.</typeparam>
    /// <typeparam name="TResult">The type of data after applying the function.</typeparam>
    /// <returns>The list obtained by using the function.</returns>
    public static List<TResult> Map<T, TResult>(List<T> list, Func<T, TResult> function)
    {
        ArgumentNullException.ThrowIfNull(list);
        ArgumentNullException.ThrowIfNull(function);

        List<TResult> resultList = [];

        foreach (var element in list)
        {
            resultList.Add(function(element));
        }

        return resultList;
    }

    /// <summary>
    /// Accepts a list and a function that returns a Boolean value for an element of the list.
    /// A list is returned consisting of those elements of the passed list for which the passed function returned true.
    /// </summary>
    /// <param name="list">The input list.</param>
    /// <param name="function">The condition for selecting the elements.</param>
    /// <typeparam name="T">The type of data in the list.</typeparam>
    /// <returns>A list of the elements for which the function returned true.</returns>
    public static List<T> Filter<T>(List<T> list, Func<T, bool> function)
    {
        ArgumentNullException.ThrowIfNull(list);
        ArgumentNullException.ThrowIfNull(function);

        List<T> resultList = [];

        foreach (var element in list)
        {
            if (function(element))
            {
                resultList.Add(element);
            }
        }

        return resultList;
    }

    /// <summary>
    /// Accepts a list, an initial value, and a function that takes the current accumulated value and the current list item, and returns the next accumulated value.
    /// Fold itself returns the accumulated value obtained after the entire passage of the list.
    /// </summary>
    /// <param name="list">The input list.</param>
    /// <param name="startElement">The element that will be used by the function first.</param>
    /// <param name="function">A function that will be applied sequentially to all elements of the list.</param>
    /// <typeparam name="TResult">The type of data after applying the function.</typeparam>
    /// <typeparam name="T">The type of data in the list.</typeparam>
    /// <returns>The result of consistent application of the function.</returns>
    public static TResult Fold<TResult, T>(List<T> list, TResult startElement, Func<TResult, T, TResult> function)
    {
        ArgumentNullException.ThrowIfNull(list);
        ArgumentNullException.ThrowIfNull(startElement);
        ArgumentNullException.ThrowIfNull(function);

        var result = startElement;

        foreach (var element in list)
        {
            result = function(result, element);
        }

        return result;
    }
}