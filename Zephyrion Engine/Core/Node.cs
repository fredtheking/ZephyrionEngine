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

  public override void Setup(ZephyrionGame game)
  {
    throw new NotImplementedException();
  }
  public override void Initialisation(ZephyrionGame game)
  {
    throw new NotImplementedException();
  }
  public override void Start(ZephyrionGame game)
  {
    throw new NotImplementedException();
  }
  public override void Update(ZephyrionGame game)
  {
    throw new NotImplementedException();
  }
  public override void Render(ZephyrionGame game)
  {
    throw new NotImplementedException();
  }

  public override void Enter(ZephyrionGame game)
  {
    throw new NotImplementedException();
  }
  public override void Leave(ZephyrionGame game)
  {
    throw new NotImplementedException();
  }
}