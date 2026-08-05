using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExchange3;

public class UI_btn_FlagshipRequirement : GButton
{
	public Controller button;

	public GImage n5;

	public GTextField n3;

	public GImage n6;

	public const string URL = "ui://tt2iq07odwxt4";

	public static string Name = "UI_btn_FlagshipRequirement";

	public static string GetURL()
	{
		return "ui://tt2iq07odwxt4";
	}

	public static UI_btn_FlagshipRequirement CreateInstance()
	{
		return (UI_btn_FlagshipRequirement)(object)UIPackage.CreateObject("GvGExchange3", "btn_FlagshipRequirement");
	}

	public static UI_btn_FlagshipRequirement CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_FlagshipRequirement).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://tt2iq07odwxt4", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n3 = (GTextField)((GComponent)this).GetChild("n3");
		string id = "ui://tt2iq07odwxt4".Replace("ui://", "") + "-" + ((GObject)n3).id;
		((GObject)n3).text = LanguagesManager.GetDesc(id);
		n6 = (GImage)((GComponent)this).GetChild("n6");
	}
}
