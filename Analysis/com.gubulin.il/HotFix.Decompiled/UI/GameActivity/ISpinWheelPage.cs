using FairyGUI;

namespace UI.GameActivity;

public interface ISpinWheelPage
{
	UI_ActivityPanel Parent { get; set; }

	GGraph FlyAnim { get; }

	GLoader FlyAnimDest { get; }

	UI_skipBtn SkipBtn { get; }

	UI_storeBtn StoreBtn { get; }

	void RegisterUiEventListeners();

	void UnregisterUiEventListeners();

	void Init();

	void OnClickGiftPackBtn();
}
