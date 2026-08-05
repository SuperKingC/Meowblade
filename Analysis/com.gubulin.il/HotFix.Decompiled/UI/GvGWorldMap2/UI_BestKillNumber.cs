using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap2;

public class UI_BestKillNumber : GComponent
{
	public GTextField Num;

	public GImage n13;

	public GGroup n14;

	public const string URL = "ui://hd2s9kukl5vu5v";

	public static string Name = "UI_BestKillNumber";

	public static string GetURL()
	{
		return "ui://hd2s9kukl5vu5v";
	}

	public static UI_BestKillNumber CreateInstance()
	{
		return (UI_BestKillNumber)(object)UIPackage.CreateObject("GvGWorldMap2", "BestKillNumber");
	}

	public static UI_BestKillNumber CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_BestKillNumber).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hd2s9kukl5vu5v", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Num = (GTextField)((GComponent)this).GetChild("Num");
		string id = "ui://hd2s9kukl5vu5v".Replace("ui://", "") + "-" + ((GObject)Num).id;
		((GObject)Num).text = LanguagesManager.GetDesc(id);
		n13 = (GImage)((GComponent)this).GetChild("n13");
		n14 = (GGroup)((GComponent)this).GetChild("n14");
	}
}
