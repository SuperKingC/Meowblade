using FairyGUI;
using FairyGUI.Utils;

namespace UI.Battle;

public class UI_offensiveProgressItem : GButton
{
	public Controller button;

	public Controller Status;

	public Controller InitItem;

	public GImage n2;

	public GImage n4;

	public GGraph back;

	public GGraph bar;

	public GImage arrow;

	public UI_offensiveProgressInitItem InitItem_2;

	public const string URL = "ui://twlbabichbas3e";

	public static string Name = "UI_offensiveProgressItem";

	public static string GetURL()
	{
		return "ui://twlbabichbas3e";
	}

	public static UI_offensiveProgressItem CreateInstance()
	{
		return (UI_offensiveProgressItem)(object)UIPackage.CreateObject("Battle", "offensiveProgressItem");
	}

	public static UI_offensiveProgressItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_offensiveProgressItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://twlbabichbas3e", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Status = ((GComponent)this).GetController("Status");
		InitItem = ((GComponent)this).GetController("InitItem");
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		back = (GGraph)((GComponent)this).GetChild("back");
		bar = (GGraph)((GComponent)this).GetChild("bar");
		arrow = (GImage)((GComponent)this).GetChild("arrow");
		InitItem_2 = (UI_offensiveProgressInitItem)(object)((GComponent)this).GetChild("InitItem");
	}
}
