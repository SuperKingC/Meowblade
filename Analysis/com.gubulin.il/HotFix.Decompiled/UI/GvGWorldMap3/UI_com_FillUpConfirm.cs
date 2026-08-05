using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_FillUpConfirm : GComponent
{
	public GImage back;

	public GTextField n10;

	public UI_btn_FillUp FillUp;

	public UI_btn_Leave Leave;

	public const string URL = "ui://4eq8fgd2k85c6b";

	public static string Name = "UI_com_FillUpConfirm";

	public static string GetURL()
	{
		return "ui://4eq8fgd2k85c6b";
	}

	public static UI_com_FillUpConfirm CreateInstance()
	{
		return (UI_com_FillUpConfirm)(object)UIPackage.CreateObject("GvGWorldMap3", "com_FillUpConfirm");
	}

	public static UI_com_FillUpConfirm CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_FillUpConfirm).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2k85c6b", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GImage)((GComponent)this).GetChild("back");
		n10 = (GTextField)((GComponent)this).GetChild("n10");
		string id = "ui://4eq8fgd2k85c6b".Replace("ui://", "") + "-" + ((GObject)n10).id;
		((GObject)n10).text = LanguagesManager.GetDesc(id);
		FillUp = (UI_btn_FillUp)(object)((GComponent)this).GetChild("FillUp");
		Leave = (UI_btn_Leave)(object)((GComponent)this).GetChild("Leave");
	}
}
