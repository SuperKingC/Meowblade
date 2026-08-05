using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_com_SpinItemGroup : GComponent
{
	public Controller rotateState;

	public GImage n12;

	public GImage n15;

	public GImage n16;

	public GLoader item0;

	public GLoader item1;

	public GLoader item2;

	public GLoader item3;

	public GLoader item4;

	public GLoader item5;

	public GLoader item6;

	public GLoader item7;

	public GGroup itemsGroup;

	public GImage rollingMask;

	public Transition t1;

	public const string URL = "ui://29q48tv6v0i9f57";

	public static string Name = "UI_com_SpinItemGroup";

	public static string GetURL()
	{
		return "ui://29q48tv6v0i9f57";
	}

	public static UI_com_SpinItemGroup CreateInstance()
	{
		return (UI_com_SpinItemGroup)(object)UIPackage.CreateObject("GameActivity", "com_SpinItemGroup");
	}

	public static UI_com_SpinItemGroup CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_SpinItemGroup).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6v0i9f57", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Expected O, but got Unknown
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		rotateState = ((GComponent)this).GetController("rotateState");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		n16 = (GImage)((GComponent)this).GetChild("n16");
		item0 = (GLoader)((GComponent)this).GetChild("item0");
		item1 = (GLoader)((GComponent)this).GetChild("item1");
		item2 = (GLoader)((GComponent)this).GetChild("item2");
		item3 = (GLoader)((GComponent)this).GetChild("item3");
		item4 = (GLoader)((GComponent)this).GetChild("item4");
		item5 = (GLoader)((GComponent)this).GetChild("item5");
		item6 = (GLoader)((GComponent)this).GetChild("item6");
		item7 = (GLoader)((GComponent)this).GetChild("item7");
		itemsGroup = (GGroup)((GComponent)this).GetChild("itemsGroup");
		rollingMask = (GImage)((GComponent)this).GetChild("rollingMask");
		t1 = ((GComponent)this).GetTransition("t1");
	}
}
