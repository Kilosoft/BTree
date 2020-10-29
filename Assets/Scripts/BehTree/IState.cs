using System;

/// <summary>
/// Интерфейс для состояния
/// </summary>
public interface IState
{
    string Name { get;}
    IState CurrentState { get; set; }
    /// <summary>
    /// Вызывается когда стейт закончился
    /// </summary>
    Action OnExitState { get; set; }

    /// <summary>
    /// Для инициализации
    /// </summary>
    void Start();
    /// <summary>
    /// Обноление надо делать каждый кадр
    /// </summary>
    EnumState Execute();

    /// <summary>
    /// Отмена стейта
    /// </summary>
    void Stop();
}