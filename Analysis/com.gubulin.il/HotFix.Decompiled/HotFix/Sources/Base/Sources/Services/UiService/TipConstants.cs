using System.Linq;

namespace HotFix.Sources.Base.Sources.Services.UiService;

public class TipConstants
{
	private readonly string[] _tipUiNames = new string[4] { "UI_SomeTipPanel", "UI_GvGTip", "UI_GvG2Tip", "UI_main_GvG3Tip" };

	public bool IsTipUi(string uiName)
	{
		return _tipUiNames.Contains(uiName);
	}
}
