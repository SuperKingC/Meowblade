using FairyGUI;
using FairyGUI.Utils;

namespace UI.GiftOfLord;

public class UI_com_Achievement : GComponent
{
	public Controller State;

	public GImage n0;

	public UI_receiveBtn Receive;

	public GImage n2;

	public GTextField Desc;

	public GTextField Value;

	public GLoader RewardIcon;

	public GTextField RewardNum;

	public GMovieClip n7;

	public GImage n8;

	public const string URL = "ui://nz2z1ab8t0xza";

	public static string Name = "UI_com_Achievement";

	public static string GetURL()
	{
		return "ui://nz2z1ab8t0xza";
	}

	public static UI_com_Achievement CreateInstance()
	{
		return (UI_com_Achievement)(object)UIPackage.CreateObject("GiftOfLord", "com_Achievement");
	}

	public static UI_com_Achievement CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_Achievement).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://nz2z1ab8t0xza", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		State = ((GComponent)this).GetController("State");
		n0 = (GImage)((GComponent)this).GetChild("n0");
		Receive = (UI_receiveBtn)(object)((GComponent)this).GetChild("Receive");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		Desc = (GTextField)((GComponent)this).GetChild("Desc");
		Value = (GTextField)((GComponent)this).GetChild("Value");
		RewardIcon = (GLoader)((GComponent)this).GetChild("RewardIcon");
		RewardNum = (GTextField)((GComponent)this).GetChild("RewardNum");
		n7 = (GMovieClip)((GComponent)this).GetChild("n7");
		n8 = (GImage)((GComponent)this).GetChild("n8");
	}
}
