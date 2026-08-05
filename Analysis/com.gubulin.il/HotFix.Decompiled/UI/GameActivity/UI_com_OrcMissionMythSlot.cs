using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_com_OrcMissionMythSlot : GComponent
{
	public Controller Type;

	public GList StoreItemList;

	public GImage n1;

	public GList ExtraList;

	public GList ExtraList2;

	public const string URL = "ui://29q48tv6pav9f4y";

	public static string Name = "UI_com_OrcMissionMythSlot";

	public static string GetURL()
	{
		return "ui://29q48tv6pav9f4y";
	}

	public static UI_com_OrcMissionMythSlot CreateInstance()
	{
		return (UI_com_OrcMissionMythSlot)(object)UIPackage.CreateObject("GameActivity", "com_OrcMissionMythSlot");
	}

	public static UI_com_OrcMissionMythSlot CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_OrcMissionMythSlot).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6pav9f4y", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		Type = ((GComponent)this).GetController("Type");
		StoreItemList = (GList)((GComponent)this).GetChild("StoreItemList");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		ExtraList = (GList)((GComponent)this).GetChild("ExtraList");
		ExtraList2 = (GList)((GComponent)this).GetChild("ExtraList2");
	}
}
