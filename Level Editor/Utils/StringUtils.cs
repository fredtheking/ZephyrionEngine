using System.Runtime.InteropServices;

namespace Level_Editor.Utils;

public static class StringUtils
{
  public static unsafe sbyte* ToSbytePtr(this string text)
  {
    IntPtr ptr = Marshal.StringToHGlobalAnsi(text);
    return (sbyte*)ptr;
  }
}