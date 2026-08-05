using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGOnIsland3;

public class UI_com_BestKillNumber : GComponent
{
	public GTextField Num;

	public GImage n13;

	public GGroup n14;

	public const string URL = "ui://ebc4ciwrl44l1h";

	public static string Name = "UI_com_BestKillNumber";

	public static string GetURL()
	{
		return "ui://ebc4ciwrl44l1h";
	}

	public static UI_com_BestKillNumber CreateInstance()
	{
		return (UI_com_BestKillNumber)(object)UIPackage.CreateObject("GvGOnIsland3", "com_BestKillNumber");
	}

	public static UI_com_BestKillNumber CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_BestKillNumber).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://ebc4ciwrl44l1h", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		string id = "ui://ebc4ciwrl44l1h".Replace("ui://", "") + "-" + ((GObject)Num).id;
		((GObject)Num).text = LanguagesManager.GetDesc(id);
		n13 = (GImage)((GComponent)this).GetChild("n13");
		n14 = (GGroup)((GComponent)this).GetChild("n14");
	}
}
