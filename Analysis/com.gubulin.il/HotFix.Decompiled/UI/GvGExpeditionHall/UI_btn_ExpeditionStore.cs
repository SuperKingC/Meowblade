using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExpeditionHall;

public class UI_btn_ExpeditionStore : GButton
{
	public Controller button;

	public GImage n8;

	public GImage n9;

	public GImage n10;

	public GImage RedDot;

	public UI_com_StoreEntryTip NewHiddenStoreTip;

	public const string URL = "ui://k19peou7fmirp5w";

	public static string Name = "UI_btn_ExpeditionStore";

	public static string GetURL()
	{
		return "ui://k19peou7fmirp5w";
	}

	public static UI_btn_ExpeditionStore CreateInstance()
	{
		return (UI_btn_ExpeditionStore)(object)UIPackage.CreateObject("GvGExpeditionHall", "btn_ExpeditionStore");
	}

	public static UI_btn_ExpeditionStore CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_btn_ExpeditionStore).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k19peou7fmirp5w", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		RedDot = (GImage)((GComponent)this).GetChild("RedDot");
		NewHiddenStoreTip = (UI_com_StoreEntryTip)(object)((GComponent)this).GetChild("NewHiddenStoreTip");
	}
}
