using FairyGUI;
using FairyGUI.Utils;

namespace UI.GVGStore;

public class UI_btn_ShenJiEntrance : GButton
{
	public Controller button;

	public GImage n13;

	public GImage n14;

	public GImage shenJiEntranceNote;

	public const string URL = "ui://fvc33k3gr57r3c";

	public static string Name = "UI_btn_ShenJiEntrance";

	public static string GetURL()
	{
		return "ui://fvc33k3gr57r3c";
	}

	public static UI_btn_ShenJiEntrance CreateInstance()
	{
		return (UI_btn_ShenJiEntrance)(object)UIPackage.CreateObject("GVGStore", "btn_ShenJiEntrance");
	}

	public static UI_btn_ShenJiEntrance CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_ShenJiEntrance).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fvc33k3gr57r3c", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n13 = (GImage)((GComponent)this).GetChild("n13");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		shenJiEntranceNote = (GImage)((GComponent)this).GetChild("shenJiEntranceNote");
	}
}
