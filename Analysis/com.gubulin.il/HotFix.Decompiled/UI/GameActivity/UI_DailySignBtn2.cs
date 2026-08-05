using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_DailySignBtn2 : GButton
{
	public Controller button;

	public GImage iconBack;

	public GGraph squareSfxBack;

	public GGraph activatedSfxBack;

	public GLoader icon;

	public GTextField num;

	public UI_DailySignMask Mask;

	public GButton ReceivedBtn;

	public const string URL = "ui://29q48tv6koyg3a";

	public static string Name = "UI_DailySignBtn2";

	public static string GetURL()
	{
		return "ui://29q48tv6koyg3a";
	}

	public static UI_DailySignBtn2 CreateInstance()
	{
		return (UI_DailySignBtn2)(object)UIPackage.CreateObject("GameActivity", "DailySignBtn2");
	}

	public static UI_DailySignBtn2 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_DailySignBtn2).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6koyg3a", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		iconBack = (GImage)((GComponent)this).GetChild("iconBack");
		squareSfxBack = (GGraph)((GComponent)this).GetChild("squareSfxBack");
		activatedSfxBack = (GGraph)((GComponent)this).GetChild("activatedSfxBack");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		num = (GTextField)((GComponent)this).GetChild("num");
		string id = "ui://29q48tv6koyg3a".Replace("ui://", "") + "-" + ((GObject)num).id;
		((GObject)num).text = LanguagesManager.GetDesc(id);
		Mask = (UI_DailySignMask)(object)((GComponent)this).GetChild("Mask");
		ReceivedBtn = (GButton)((GComponent)this).GetChild("ReceivedBtn");
	}
}
