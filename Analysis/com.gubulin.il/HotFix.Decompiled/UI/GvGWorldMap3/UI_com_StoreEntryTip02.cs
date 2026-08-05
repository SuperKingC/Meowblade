using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_StoreEntryTip02 : GComponent
{
	public GImage n7;

	public GTextField n8;

	public Transition t0;

	public const string URL = "ui://4eq8fgd2sxvrs8s";

	public static string Name = "UI_com_StoreEntryTip02";

	public static string GetURL()
	{
		return "ui://4eq8fgd2sxvrs8s";
	}

	public static UI_com_StoreEntryTip02 CreateInstance()
	{
		return (UI_com_StoreEntryTip02)(object)UIPackage.CreateObject("GvGWorldMap3", "com_StoreEntryTip02");
	}

	public static UI_com_StoreEntryTip02 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_StoreEntryTip02).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2sxvrs8s", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n7 = (GImage)((GComponent)this).GetChild("n7");
		n8 = (GTextField)((GComponent)this).GetChild("n8");
		string id = "ui://4eq8fgd2sxvrs8s".Replace("ui://", "") + "-" + ((GObject)n8).id;
		((GObject)n8).text = LanguagesManager.GetDesc(id);
		t0 = ((GComponent)this).GetTransition("t0");
	}
}
