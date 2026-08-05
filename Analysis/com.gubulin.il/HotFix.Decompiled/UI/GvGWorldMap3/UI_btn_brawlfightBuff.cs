using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_btn_brawlfightBuff : GButton
{
	public Controller button;

	public GImage n30;

	public GImage n26;

	public GImage n31;

	public const string URL = "ui://4eq8fgd210ihqb6se8";

	public static string Name = "UI_btn_brawlfightBuff";

	public static string GetURL()
	{
		return "ui://4eq8fgd210ihqb6se8";
	}

	public static UI_btn_brawlfightBuff CreateInstance()
	{
		return (UI_btn_brawlfightBuff)(object)UIPackage.CreateObject("GvGWorldMap3", "btn_brawlfightBuff");
	}

	public static UI_btn_brawlfightBuff CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_brawlfightBuff).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd210ihqb6se8", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n30 = (GImage)((GComponent)this).GetChild("n30");
		n26 = (GImage)((GComponent)this).GetChild("n26");
		n31 = (GImage)((GComponent)this).GetChild("n31");
	}
}
