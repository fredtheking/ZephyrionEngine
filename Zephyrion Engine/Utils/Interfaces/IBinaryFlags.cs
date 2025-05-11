using ZephyrionEngine.Utils.Etc;

namespace ZephyrionEngine.Utils.Interfaces;

public interface IBinaryFlags<T> where T : Enum
{
  public T Flags { get; set; }
  
  public bool HasFlag(T flag) =>
    (Convert.ToUInt64(Flags) & Convert.ToUInt64(flag)) != 0;
  public void AddFlag(T flag) =>
    ZE.M.PND.Add(() => Flags = (T)Enum.ToObject(typeof(T), Convert.ToUInt64(Flags) | Convert.ToUInt64(flag)));
  public void RemoveFlag(T flag) =>
    ZE.M.PND.Add(() => Flags = (T)Enum.ToObject(typeof(T), Convert.ToUInt64(Flags) & ~Convert.ToUInt64(flag)));
}