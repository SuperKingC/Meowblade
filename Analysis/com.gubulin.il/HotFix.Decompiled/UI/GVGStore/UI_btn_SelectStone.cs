using FairyGUI;
using FairyGUI.Utils;

namespace UI.GVGStore;

public class UI_btn_SelectStone : GButton
{
	public Controller button;

	public GImage n12;

	public GImage n13;

	public GImage n14;

	public GImage shenJiEntranceNote;

	public const string URL = "ui://fvc33k3gfkbp3i";

	public static string Name = "UI_btn_SelectStone";

	public static string GetURL()
	{
		return "ui://fvc33k3gfkbp3i";
	}

	public static UI_btn_SelectStone CreateInstance()
	{
		return (UI_btn_SelectStone)(object)UIPackage.CreateObject("GVGStore", "btn_SelectStone");
	}

	public static UI_btn_SelectStone CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_SelectStone).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fvc33k3gfkbp3i", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		shenJiEntranceNote = (GImage)((GComponent)this).GetChild("shenJiEntranceNote");
	}
}
