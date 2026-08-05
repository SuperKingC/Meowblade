using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGSettlement;

public class UI_com_AmpDetailSlot : GComponent
{
	public Controller Quatity;

	public GLoader n11;

	public GTextField Count;

	public GTextField Score;

	public GImage n17;

	public const string URL = "ui://91jxdrkacgcr35";

	public static string Name = "UI_com_AmpDetailSlot";

	public static string GetURL()
	{
		return "ui://91jxdrkacgcr35";
	}

	public static UI_com_AmpDetailSlot CreateInstance()
	{
		return (UI_com_AmpDetailSlot)(object)UIPackage.CreateObject("GvGSettlement", "com_AmpDetailSlot");
	}

	public static UI_com_AmpDetailSlot CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_AmpDetailSlot).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://91jxdrkacgcr35", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		Quatity = ((GComponent)this).GetController("Quatity");
		n11 = (GLoader)((GComponent)this).GetChild("n11");
		Count = (GTextField)((GComponent)this).GetChild("Count");
		Score = (GTextField)((GComponent)this).GetChild("Score");
		n17 = (GImage)((GComponent)this).GetChild("n17");
	}
}
