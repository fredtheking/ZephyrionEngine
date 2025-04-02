using ImGuiNET;
using Level_Editor.Utils;
using rlImGui_cs;

namespace Level_Editor.Scenes;

public static class EditorScene
{
  public static void Render(EditorWindow editor)
  {
    ImGui.DockSpaceOverViewport(ImGui.GetMainViewport().ID, ImGui.GetMainViewport());
    
    ImGui.Begin("Hierarchy", ImGuiWindowFlags.DockNodeHost);
    ImGui.End();
    
    ImGui.Begin("Inspector", ImGuiWindowFlags.DockNodeHost);
    ImGui.End();
    
    ImGui.Begin("Viewport", ImGuiWindowFlags.DockNodeHost);
    ImGui.End();
    
    ImGui.Begin("Console", ImGuiWindowFlags.DockNodeHost);
    ImGui.End();
  }
}