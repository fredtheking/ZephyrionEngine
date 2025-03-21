using ZephyrionEngine.Utils.Enums;
using ZephyrionEngine.Utils.Templates;

namespace ZephyrionEngine.Core;

public class Node : NodeTemplate
{
  public List<Node> Parents { get; } = [];
  public NodeFlags Flags { get; set; }

  public Node(string name, Node[] children)
  {
    Name = name;
    Children = children.ToList();
    
    foreach (Node child in Children)
      child.Parents.Add(this);
  }
}