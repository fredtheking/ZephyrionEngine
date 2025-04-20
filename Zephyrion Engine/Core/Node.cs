using ZephyrionEngine.Utils.Enums;
using ZephyrionEngine.Utils.Templates;

namespace ZephyrionEngine.Core;

public class Node : NodeTemplate
{
  public List<Node> Parents { get; } = [];

  public Node(string name, Node[] children)
  {
    Name = name;
    Children = children.ToList();
    
    foreach (Node child in Children)
      child.Parents.Add(this);
  }

  public override void Setup()
  {
    
  }
  public override void Initialisation()
  {
    
  }
  public override void Begin()
  {
    
  }
  public override void Update()
  {
    
  }
  public override void Render()
  {
    
  }

  public override void Enter()
  {
    
  }
  public override void Leave()
  {
    
  }
}