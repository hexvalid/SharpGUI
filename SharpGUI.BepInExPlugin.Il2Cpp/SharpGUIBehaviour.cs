﻿using ImGuiNET;
using System;
using UnityEngine;

using SGUI = SharpGUI.GUI;

namespace SharpGUI.BepInExPlugin.Il2Cpp;

public class SharpGUIBehaviour(IntPtr basePtr) : MonoBehaviour(basePtr)
{
	private int counter;
	private bool showGui;

	private bool showDemoWindow;

	private void Awake()
	{
		SGUI.OnRender += GUI_OnRender;
		SGUI.Initialize();
	}

	private void OnApplicationQuit()
	{
		SGUI.Shutdown();
	}

	void DrawIntro()
	{
		// NoNav so the window isnt affected by the keyboard
		if (!ImGui.Begin("Welcome to SharpGUI!", ImGuiWindowFlags.NoCollapse | ImGuiWindowFlags.NoNav | ImGuiWindowFlags.AlwaysAutoResize))
			return;

		ImGui.Text("Welcome to SharpGUI by JNNJ.");
		ImGui.Text("This is currently rendered without setting handleInput to true.");
		ImGui.Text("To open the SharpGUI demo press B");

		ImGui.End();
	}

	private void GUI_OnRender()
	{
		if (ImGui.IsKeyPressed(ImGuiKey.B, false))
		{
			showGui = !showGui;
			SGUI.HandleInput = showGui;
		}

		if (!showGui)
		{
			DrawIntro();
			return;
		}

		if (!ImGui.Begin("SharpGUI"))
			return;

		ImGui.Text("Count: " + counter.ToString());

		if (ImGui.Button("Up"))
		{
			counter++;
		}

		ImGui.SameLine();

		if (ImGui.Button("Down"))
		{
			counter--;
		}

		ImGui.Checkbox("ImGui demo window", ref showDemoWindow);

		ImGui.End();

		if (showDemoWindow)
		{
			ImGui.ShowDemoWindow();
		}
	}
}
