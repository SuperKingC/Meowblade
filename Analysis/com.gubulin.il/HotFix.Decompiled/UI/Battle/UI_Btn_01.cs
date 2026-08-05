using FairyGUI;
using FairyGUI.Utils;

namespace UI.Battle;

public class UI_Btn_01 : GButton
{
	public Controller button;

	public GGraph n7;

	public GImage n10;

	public GImage n12;

	public const string URL = "ui://twlbabicujdzoz";

	public static string Name = "UI_Btn_01";

	public static string GetURL()
	{
		return "ui://twlbabicujdzoz";
	}

	public static UI_Btn_01 CreateInstance()
	{
		return (UI_Btn_01)(object)UIPackage.CreateObject("Battle", "Btn_01");
	}

	public static UI_Btn_01 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Btn_01).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://twlbabicujdzoz", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n7 = (GGraph)((GComponent)this).GetChild("n7");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		n12 = (GImage)((GComponent)this).GetChild("n12");
	}
}
