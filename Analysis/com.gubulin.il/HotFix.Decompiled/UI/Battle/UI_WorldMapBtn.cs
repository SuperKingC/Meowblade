using FairyGUI;
using FairyGUI.Utils;

namespace UI.Battle;

public class UI_WorldMapBtn : GButton
{
	public Controller button;

	public GImage n16;

	public GImage n18;

	public GImage n17;

	public GImage note;

	public const string URL = "ui://twlbabictny727";

	public static string Name = "UI_WorldMapBtn";

	public static string GetURL()
	{
		return "ui://twlbabictny727";
	}

	public static UI_WorldMapBtn CreateInstance()
	{
		return (UI_WorldMapBtn)(object)UIPackage.CreateObject("Battle", "WorldMapBtn");
	}

	public static UI_WorldMapBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_WorldMapBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://twlbabictny727", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n16 = (GImage)((GComponent)this).GetChild("n16");
		n18 = (GImage)((GComponent)this).GetChild("n18");
		n17 = (GImage)((GComponent)this).GetChild("n17");
		note = (GImage)((GComponent)this).GetChild("note");
	}
}
