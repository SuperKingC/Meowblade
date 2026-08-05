using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemBlueprint;

public class UI_com_Entry : GComponent
{
	public GTextField n1;

	public GImage n0;

	public GTextField UnlockTip;

	public const string URL = "ui://h09dvkcgjpqa1a";

	public static string Name = "UI_com_Entry";

	public static string GetURL()
	{
		return "ui://h09dvkcgjpqa1a";
	}

	public static UI_com_Entry CreateInstance()
	{
		return (UI_com_Entry)(object)UIPackage.CreateObject("LegendItemBlueprint", "com_Entry");
	}

	public static UI_com_Entry CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Entry).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcgjpqa1a", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n1 = (GTextField)((GComponent)this).GetChild("n1");
		string id = "ui://h09dvkcgjpqa1a".Replace("ui://", "") + "-" + ((GObject)n1).id;
		((GObject)n1).text = LanguagesManager.GetDesc(id);
		n0 = (GImage)((GComponent)this).GetChild("n0");
		UnlockTip = (GTextField)((GComponent)this).GetChild("UnlockTip");
	}
}
