using System.Collections;

namespace StackCalculator.Tests;

public class StackTests
{
    private static readonly double[] TestData = [0, 1, 2, 3, 1000];

    private static IStack[] Stacks =>
    [
        new ArrayStack(),
        new LinkedStack()
    ];
    
    [Test]
    public void Stack_Pop_ShouldReturnPushedValue([ValueSource(nameof(Stacks))] IStack stack, [ValueSource(nameof(TestData))] double value)
    {
        stack.Push(value);
        Assert.That(stack.Pop(), Is.EqualTo((value, false)));
    }

    [Test]
    public void Stack_Pop_ShouldReturnPushedValues_Multiple([ValueSource(nameof(Stacks))] IStack stack)
    {
        foreach (var t in TestData)
        {
            stack.Push(t);
        }

        for (var i = 0; i < TestData.Length; i++)
        {
            Assert.That(stack.Pop(), Is.EqualTo((TestData[^(i + 1)], false)));
        }
    }

    [Test]
    public void Stack_IsEmpty_ForEmptyStack_ShouldReturnTrue([ValueSource(nameof(Stacks))] IStack stack) 
        => Assert.That(stack.IsEmpty, Is.True);

    [Test]
    public void Stack_IsEmpty_ForNonEmptyStack_ShouldReturnFalse([ValueSource(nameof(Stacks))] IStack stack)
    {
        stack.Push(1);
        Assert.That(stack.IsEmpty, Is.False);
    }
}