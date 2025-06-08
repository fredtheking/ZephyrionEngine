using ZephyrionEngine.Utils.Etc;

namespace ZephyrionEngine.Managers;

public class DebugManager
{
  #region Fields
  
  public bool ShowBorders { get; set; } = true;
  public bool TurnedOn { get; set; } = true;
  public bool Changed { get; set; } = true;
  private bool _consoleIsInvalid;
  
  #endregion Fields
  #region Constructors
  
  internal DebugManager() { }
  
  #endregion Constructors
  #region Methods
  
  public void Separator(string message, char sign = '=') => Separator(ConsoleColor.Magenta, message, sign);
  
  public void Separator(ConsoleColor fgColor = ConsoleColor.Magenta, string message = "", char sign = '=') {
    string space = " ";
    if (message is "") space = "";
    string prepostfix = new(sign, 3);
    try
    {
      if (!_consoleIsInvalid)
        prepostfix = new(sign, (Console.WindowWidth - message.Length - space.Length * 2) / 2);
    }
    catch (ArgumentException)
    {
      Warning("Your console/terminal is invalid. 'Separator' debug messages will look shorter as seen below.");
      _consoleIsInvalid = true;
    }
    
    Console.ForegroundColor = fgColor;
    Console.Write(prepostfix + space + message + space + prepostfix);
    Console.ResetColor();
    Console.WriteLine();
  }
  
  internal void Print(string prefix, string message, ConsoleColor foreColor, ConsoleColor? backColor = null, UuidIdentifier? speaker = null)
  {
    if (backColor is not null) Console.BackgroundColor = (ConsoleColor)backColor;
    Console.ForegroundColor = foreColor;
    Console.Write($"{prefix.ToUpper()}{(speaker is not null ? $" [{speaker.ShortUuid}]": "")}: {message}");
    Console.ResetColor();
    Console.WriteLine();
  }

  internal void DebugLog(string message) =>
    Print("debug", message, ConsoleColor.Cyan);
  
  public void Information(string message) =>
    Print("info", message, ConsoleColor.White);
 
  public void Warning(string message) =>
    Print("warn", message, ConsoleColor.Yellow);
 
  public void Error(string message) =>
    Print("error", message, ConsoleColor.Red);
 
  public void Critical(string message) =>
    Print("crit", message, ConsoleColor.Black, ConsoleColor.Red);
  
  public void Toggle() {
    TurnedOn = !TurnedOn;
    Changed = true;
  }
  
  #endregion Methods
}