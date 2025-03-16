using ZephyrionEngine.Utils.Etc;
using ZephyrionEngine.Utils.Interfaces;

namespace ZephyrionEngine.Core;

public class NodeObject : UuidIdentifier, IInitialised
{
  public bool Initialised { get; set; }
  public RefString Name { get; set; }
  public List<NodeObject> Parents { get; set; }
  public List<NodeObject> Children { get; set; }
}