using System.Numerics;
using ImGuiNET;
using Level_Editor.Utils;
using Raylib_cs;
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
    
    ImGui.Begin("Viewport", ImGuiWindowFlags.DockNodeHost | ImGuiWindowFlags.MenuBar);
    rlImGui.ImageRenderTextureFit(editor.renderTexture);
    
    if (ImGui.BeginMenuBar())
    {
      if (ImGui.BeginMenu("Game"))
      {
        if (ImGui.BeginMenu("Resolutions"))
        {
          bool IsCurrent(int width, int height) => 
            editor.renderTexture.Texture.Width == width && editor.renderTexture.Texture.Height == height;

          void DrawMenuItem(int width, int height)
          {
            if (IsCurrent(width, height)) ImGui.Bullet();
            else ImGui.Text("  ");

            ImGui.SameLine();
            if (ImGui.MenuItem($"{width}x{height}"))
              editor.ResizeRenderTexture(new Vector2(width, height));
          }

          DrawMenuItem(800, 600);
          DrawMenuItem(1280, 720);
          DrawMenuItem(1920, 1080);

          ImGui.EndMenu();
        }

        ImGui.MenuItem("Close");
        ImGui.EndMenu();
      }
      ImGui.Separator();
      ImGui.MenuItem("Play");
      ImGui.MenuItem("Pause");
      ImGui.MenuItem("Stop");
      ImGui.EndMenuBar();
    }
    ImGui.End();
    
    ImGui.Begin("Console", ImGuiWindowFlags.DockNodeHost);
    ImGui.End();
  }
}