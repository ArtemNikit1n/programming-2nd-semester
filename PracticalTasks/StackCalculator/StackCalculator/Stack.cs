namespace StackCalculator;

public interface IStack
{
    /// <summary>
    /// Добавляет элемент в стек.
    /// </summary>
    /// <param name="value">Устанавливаемое значение.</param>
    public void Push(double value);

    /// <summary>
    /// Убирает элемент из стека.
    /// </summary>
    /// <returns>Удалённый элемент и код ошибки.</returns>
    public (double Value, bool IsError) Pop();

    /// <summary>
    /// Проверка на наличие элементов.
    /// </summary>
    /// <returns>true = стек пуст.</returns>
    public bool IsEmpty();
}