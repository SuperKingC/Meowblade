using FairyGUI;
using FairyGUI.Utils;

namespace UI.QQGameActivity;

public class UI_QQGameBigPlayerTips : GComponent
{
	public GGraph Mask;

	public UI_popup_01 n0;

	public const string URL = "ui://r1j1a2l0e3ph3";

	public static string Name = "UI_QQGameBigPlayerTips";

	public static string GetURL()
	{
		return "ui://r1j1a2l0e3ph3";
	}

	public static UI_QQGameBigPlayerTips CreateInstance()
	{
		return (UI_QQGameBigPlayerTips)(object)UIPackage.CreateObject("QQGameActivity", "QQGameBigPlayerTips");
	}

	public static UI_QQGameBigPlayerTips CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_QQGameBigPlayerTips).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://r1j1a2l0e3ph3", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		n0 = (UI_popup_01)(object)((GComponent)this).GetChild("n0");
	}
}
