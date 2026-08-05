using FairyGUI;
using FairyGUI.Utils;

namespace UI.Battle;

public class UI_Btn_02 : GButton
{
	public Controller button;

	public GGraph n7;

	public GImage background;

	public GLoader n10;

	public const string URL = "ui://twlbabicujdzp0";

	public static string Name = "UI_Btn_02";

	public static string GetURL()
	{
		return "ui://twlbabicujdzp0";
	}

	public static UI_Btn_02 CreateInstance()
	{
		return (UI_Btn_02)(object)UIPackage.CreateObject("Battle", "Btn_02");
	}

	public static UI_Btn_02 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_Btn_02).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://twlbabicujdzp0", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		background = (GImage)((GComponent)this).GetChild("background");
		n10 = (GLoader)((GComponent)this).GetChild("n10");
	}
}
