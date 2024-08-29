#pragma once

namespace Backends
{
	enum BackendType
	{
		BackendType_None,
		BackendType_DX9,
		BackendType_DX10,
		BackendType_DX11,
		BackendType_DX12,
		BackendType_OpenGL,
		BackendType_Overlay
	};

	class Backend
	{
	public:
		virtual BackendType GetType();

		void Initialize();
		bool IsInitialized();

		void Shutdown();

		virtual void SetHandleInput(bool handleInput) {}
		virtual bool GetHandleInput();

		virtual void SetBlockInput(bool blockInput) {}
		virtual bool GetBlockInput();
	protected:
		virtual void InitializeBackend() {}
		virtual void ShutdownBackend() {}

		bool initialized;

		bool handleInput;
		bool blockInput;
	};

	extern Backend* currentBackend;

	void InitImGui();
	void ShutdownImGui();

	void RenderGUI();
}