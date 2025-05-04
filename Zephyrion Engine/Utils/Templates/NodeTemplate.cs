using ZephyrionEngine.Core;
using ZephyrionEngine.Utils.Enums;
using ZephyrionEngine.Utils.Etc;
using ZephyrionEngine.Utils.Interfaces;

namespace ZephyrionEngine.Utils.Templates;

public abstract class NodeTemplate : UuidIdentifier, IInitialised, ISetup, IUpdateable, IRenderable, ISceneable
{
  public bool Initialised { get; set; }
  public string Name;
  public NodeFlags Flags { get; set; }
  public List<Node> Parents { get; protected init; } = [];
  public List<Node> Children { get; protected init; } = [];

  public bool HasFlag(NodeFlags flags) => (this.Flags & flags) != 0;
  public void AddFlag(NodeFlags flags) => this.Flags |= flags;
  public void RemoveFlag(NodeFlags flags) => this.Flags &= ~flags;

  public abstract void Setup();
  public abstract void Initialisation();
  public abstract void Begin();
  public abstract void Update();
  public abstract void Render();
  
  public abstract void Enter();
  public abstract void Leave();
}