using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.UnlockSoldierInfo;

public class UI_UnlockStone : GComponent
{
	public Controller Status;

	public GImage icon;

	public GTextField num;

	public GImage n2;

	public GImage n3;

	public GGroup n4;

	public GImage n5;

	public GImage n6;

	public GGroup n7;

	public const string URL = "ui://jctgkd2udqft8";

	public static string Name = "UI_UnlockStone";

	public static string GetURL()
	{
		return "ui://jctgkd2udqft8";
	}

	public static UI_UnlockStone CreateInstance()
	{
		return (UI_UnlockStone)(object)UIPackage.CreateObject("UnlockSoldierInfo", "UnlockStone");
	}

	public static UI_UnlockStone CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_UnlockStone).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://jctgkd2udqft8", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		icon = (GImage)((GComponent)this).GetChild("icon");
		num = (GTextField)((GComponent)this).GetChild("num");
		string id = "ui://jctgkd2udqft8".Replace("ui://", "") + "-" + ((GObject)num).id;
		((GObject)num).text = LanguagesManager.GetDesc(id);
		n2 = (GImage)((GComponent)this).GetChild("n2");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n4 = (GGroup)((GComponent)this).GetChild("n4");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n7 = (GGroup)((GComponent)this).GetChild("n7");
	}
}
