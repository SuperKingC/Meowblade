namespace FairyGUI;

public interface IFairyComponent
{
	void Init();

	void Destroy();

	void RegisterUiEvent();

	void UnregisterUiEvent();
}
