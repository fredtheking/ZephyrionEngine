using System.Diagnostics;
using ZephyrionEngine.Core;
using ZephyrionEngine.Utils.Etc;

namespace ZephyrionEngine.Managers;

internal class PendingChangesManager
{
  #region Fields
  
  private List<Action> All { get; } = [];
  #if DEBUG
  private Dictionary<Action, string> Log = [];
  #endif
  
  #endregion Fields
  #region Methods
  
  public void Add(Action action)
  {
    All.Add(action);
    #if DEBUG
    var caller = new StackFrame(1, true);
    string parentInfo = $"{caller.GetMethod()?.DeclaringType?.FullName}.{caller.GetMethod()?.Name}";
    Log.Add(action, $"{action.Method.Name} FROM {parentInfo}");
    #endif
  }
  // string argument only for debug view

  public void Apply()
  {
    foreach (Action action in All)
    {
      action();
      #if DEBUG
      ZE.M.D.DebugLog($"APPLY PENDING: {Log[action]}");
      #endif
    }
    All.Clear();
  }
  
  #endregion Methods
}