using FairyGUI;
using FairyGUI.Utils;

namespace UI.WeekActivity;

public class UI_currencyBtn : GButton
{
	public Controller button;

	public GImage background;

	public GGraph workerButtonSpine;

	public GButton addButton;

	public GTextField ticketCount;

	public GGroup n11;

	public GLoader ticketIcon;

	public const string URL = "ui://jl0c82y5i9x22a";

	public static string Name = "UI_currencyBtn";

	public static string GetURL()
	{
		return "ui://jl0c82y5i9x22a";
	}

	public static UI_currencyBtn CreateInstance()
	{
		return (UI_currencyBtn)(object)UIPackage.CreateObject("WeekActivity", "currencyBtn");
	}

	public static UI_currencyBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_currencyBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://jl0c82y5i9x22a", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		background = (GImage)((GComponent)this).GetChild("background");
		workerButtonSpine = (GGraph)((GComponent)this).GetChild("workerButtonSpine");
		addButton = (GButton)((GComponent)this).GetChild("addButton");
		ticketCount = (GTextField)((GComponent)this).GetChild("ticketCount");
		n11 = (GGroup)((GComponent)this).GetChild("n11");
		ticketIcon = (GLoader)((GComponent)this).GetChild("ticketIcon");
	}
}
