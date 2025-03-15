using System.Numerics;

namespace ZephyrionEngine.Utils.Etc;

public class RefUnit<T> where T : IAdditionOperators<T, T, T>, ISubtractionOperators<T, T, T>, IMultiplyOperators<T, T, T>, IDivisionOperators<T, T, T>
{
  public T Value { get; set; }

  public RefUnit(T value) => Value = value;

  public static implicit operator T(RefUnit<T> refUnit) => refUnit.Value;
  public static implicit operator RefUnit<T>(T value) => new(value);

  public static RefUnit<T> operator +(RefUnit<T> refUnit, T value)
  {
    refUnit.Value += value;
    return refUnit;
  }
  
  public static RefUnit<T> operator -(RefUnit<T> refUnit, T value)
  {
    refUnit.Value -= value;
    return refUnit;
  }
  
  public static RefUnit<T> operator *(RefUnit<T> refUnit, T value)
  {
    refUnit.Value *= value;
    return refUnit;
  }
  
  public static RefUnit<T> operator /(RefUnit<T> refUnit, T value)
  {
    if (EqualityComparer<T>.Default.Equals(value, default)) 
      throw new DivideByZeroException("Cannot divide by zero.");
    refUnit.Value /= value;
    return refUnit;
  }
}