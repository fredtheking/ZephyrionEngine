using static ImGuiNET.ImGui;
using ImGuiNET;
using Level_Editor.Utils;
using Raylib_cs;

namespace Level_Editor.Scenes;

public static class GlobalOverlay
{
  public static void Render(EditorWindow editor)
  {
    if (BeginMainMenuBar())
    {
      if (BeginMenu("File"))
      {
        MenuItem("Open");
        MenuItem("Save");
        MenuItem("Save all");
        Separator();
        if (MenuItem("Quit")) editor.LateActions.Add(EditorWindow.Close);
        EndMenu();
      }
      EndMainMenuBar();
    }
  }
}