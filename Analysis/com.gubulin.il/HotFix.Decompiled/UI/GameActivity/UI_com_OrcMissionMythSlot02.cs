using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_com_OrcMissionMythSlot02 : GComponent
{
	public GList StoreItemList;

	public GImage n1;

	public GList ExtraList;

	public const string URL = "ui://29q48tv6i7wp5f8p";

	public static string Name = "UI_com_OrcMissionMythSlot02";

	public static string GetURL()
	{
		return "ui://29q48tv6i7wp5f8p";
	}

	public static UI_com_OrcMissionMythSlot02 CreateInstance()
	{
		return (UI_com_OrcMissionMythSlot02)(object)UIPackage.CreateObject("GameActivity", "com_OrcMissionMythSlot02");
	}

	public static UI_com_OrcMissionMythSlot02 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_OrcMissionMythSlot02).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6i7wp5f8p", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		StoreItemList = (GList)((GComponent)this).GetChild("StoreItemList");
		n1 = (GImage)((GComponent)this).GetChild("n1");
		ExtraList = (GList)((GComponent)this).GetChild("ExtraList");
	}
}
