using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_SuppressBonusLimitDialog : GComponent
{
	public GImage back;

	public GButton Exit;

	public GTextField n3;

	public UI_btn_alwaysDisplayBtn DoNotShowAgain;

	public GTextField n7;

	public const string URL = "ui://4eq8fgd2mutrqb6sf7";

	public static string Name = "UI_com_SuppressBonusLimitDialog";

	public static string GetURL()
	{
		return "ui://4eq8fgd2mutrqb6sf7";
	}

	public static UI_com_SuppressBonusLimitDialog CreateInstance()
	{
		return (UI_com_SuppressBonusLimitDialog)(object)UIPackage.CreateObject("GvGWorldMap3", "com_SuppressBonusLimitDialog");
	}

	public static UI_com_SuppressBonusLimitDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_SuppressBonusLimitDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2mutrqb6sf7", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		back = (GImage)((GComponent)this).GetChild("back");
		Exit = (GButton)((GComponent)this).GetChild("Exit");
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		DoNotShowAgain = (UI_btn_alwaysDisplayBtn)(object)((GComponent)this).GetChild("DoNotShowAgain");
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		string id = "ui://4eq8fgd2mutrqb6sf7".Replace("ui://", "") + "-" + ((GObject)n7).id;
		((GObject)n7).text = LanguagesManager.GetDesc(id);
	}
}
