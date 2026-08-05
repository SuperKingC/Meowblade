using FairyGUI;
using FairyGUI.Utils;

namespace UI.SpecialActivity;

public class UI_SignInRewards : GComponent
{
	public Controller button;

	public GImage n10;

	public GLoader icon0;

	public GImage n13;

	public GLoader icon1;

	public GImage n16;

	public GLoader icon2;

	public GImage n19;

	public GLoader icon3;

	public const string URL = "ui://kozswd8hndjar";

	public static string Name = "UI_SignInRewards";

	public static string GetURL()
	{
		return "ui://kozswd8hndjar";
	}

	public static UI_SignInRewards CreateInstance()
	{
		return (UI_SignInRewards)(object)UIPackage.CreateObject("SpecialActivity", "SignInRewards");
	}

	public static UI_SignInRewards CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SignInRewards).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kozswd8hndjar", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		icon0 = (GLoader)((GComponent)this).GetChild("icon0");
		n13 = (GImage)((GComponent)this).GetChild("n13");
		icon1 = (GLoader)((GComponent)this).GetChild("icon1");
		n16 = (GImage)((GComponent)this).GetChild("n16");
		icon2 = (GLoader)((GComponent)this).GetChild("icon2");
		n19 = (GImage)((GComponent)this).GetChild("n19");
		icon3 = (GLoader)((GComponent)this).GetChild("icon3");
	}
}
