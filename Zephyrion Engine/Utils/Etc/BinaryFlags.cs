namespace ZephyrionEngine.Utils.Etc;

/// <summary>
/// Adds binary flags implementation for enum
/// </summary>
/// <typeparam name="T"></typeparam>
public class BinaryFlags<T> where T : Enum
{
  private T Flags { get; set; }
  
  public BinaryFlags(T flags) => Flags = flags;

  public bool Has(T flag) =>
    (Convert.ToUInt64(Flags) & Convert.ToUInt64(flag)) != 0;
  public void Add(T flag) =>
    ZE.M.PND.Add(() => Flags = (T)Enum.ToObject(typeof(T), Convert.ToUInt64(Flags) | Convert.ToUInt64(flag)));
  public void Remove(T flag) =>
    ZE.M.PND.Add(() => Flags = (T)Enum.ToObject(typeof(T), Convert.ToUInt64(Flags) & ~Convert.ToUInt64(flag)));
  public T Get() => Flags;
}