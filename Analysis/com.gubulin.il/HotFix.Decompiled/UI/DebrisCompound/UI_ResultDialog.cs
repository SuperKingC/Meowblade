using FairyGUI;
using FairyGUI.Utils;

namespace UI.DebrisCompound;

public class UI_ResultDialog : GComponent
{
	public GImage back;

	public GTextField title;

	public GList resultList;

	public UI_ConfirmBtn ConfirmBtn;

	public const string URL = "ui://6n2woz97o4kt6";

	public static string Name = "UI_ResultDialog";

	public static string GetURL()
	{
		return "ui://6n2woz97o4kt6";
	}

	public static UI_ResultDialog CreateInstance()
	{
		return (UI_ResultDialog)(object)UIPackage.CreateObject("DebrisCompound", "ResultDialog");
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GImage)((GComponent)this).GetChild("back");
		title = (GTextField)((GComponent)this).GetChild("title");
		resultList = (GList)((GComponent)this).GetChild("resultList");
		ConfirmBtn = (UI_ConfirmBtn)(object)((GComponent)this).GetChild("ConfirmBtn");
	}
}
