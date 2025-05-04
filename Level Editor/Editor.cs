using Level_Editor.Scenes;
using Level_Editor.Utils;

EditorWindow editor = new();

editor.Global += GlobalOverlay.Render;
editor.MainLoopEvents = new()
{
  { EditorSceneNames.Menu, MenuScene.Render }, 
  { EditorSceneNames.Editor, EditorScene.Render }
};

editor.Run();