using BepInEx;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using ImGuiNET;

namespace SharpGUI.BepInExPlugin.Il2Cpp;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class SharpGUIPlugin : BasePlugin
{
	internal static new ManualLogSource Log;

	public override void Load()
	{
		// Plugin startup logic
		Log = base.Log;

		//AddComponent<SharpGUIBehaviour>();

		Log.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");

		SharpGUI.GUI.OnRender += GUI_OnRender;
		SharpGUI.GUI.Initialize();
	}

	private void GUI_OnRender()
	{
		ImGui.ShowDemoWindow();
	}
}