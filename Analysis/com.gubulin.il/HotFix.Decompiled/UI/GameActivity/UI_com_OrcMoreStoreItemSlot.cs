using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_com_OrcMoreStoreItemSlot : GComponent
{
	public Controller unlocked;

	public GImage n4;

	public GList storeItemList;

	public GImage n5;

	public GImage n6;

	public GTextField n7;

	public GImage cardMask;

	public const string URL = "ui://29q48tv6hwkc5f8k";

	public static string Name = "UI_com_OrcMoreStoreItemSlot";

	public static string GetURL()
	{
		return "ui://29q48tv6hwkc5f8k";
	}

	public static UI_com_OrcMoreStoreItemSlot CreateInstance()
	{
		return (UI_com_OrcMoreStoreItemSlot)(object)UIPackage.CreateObject("GameActivity", "com_OrcMoreStoreItemSlot");
	}

	public static UI_com_OrcMoreStoreItemSlot CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_OrcMoreStoreItemSlot).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6hwkc5f8k", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		unlocked = ((GComponent)this).GetController("unlocked");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		storeItemList = (GList)((GComponent)this).GetChild("storeItemList");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		string id = "ui://29q48tv6hwkc5f8k".Replace("ui://", "") + "-" + ((GObject)n7).id;
		((GObject)n7).text = LanguagesManager.GetDesc(id);
		cardMask = (GImage)((GComponent)this).GetChild("cardMask");
	}
}
