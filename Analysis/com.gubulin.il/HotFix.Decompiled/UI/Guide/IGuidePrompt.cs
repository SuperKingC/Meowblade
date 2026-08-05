using FairyGUI;

namespace UI.Guide;

public interface IGuidePrompt
{
	bool IsDispose();

	void SetVisible(bool changedVisible);

	void SetAlpha(float changedAlpha);

	Transition PlayTransition(GGraph graph);

	void RemoveSelf();
}
