using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.SpecialActivity;

public class UI_PurchaseLimit : GComponent
{
	public GList cardList;

	public GImage n3;

	public GTextField ActivityTime;

	public GTextField n8;

	public GTextField n9;

	public const string URL = "ui://kozswd8hndja3";

	public static string Name = "UI_PurchaseLimit";

	public static string GetURL()
	{
		return "ui://kozswd8hndja3";
	}

	public static UI_PurchaseLimit CreateInstance()
	{
		return (UI_PurchaseLimit)(object)UIPackage.CreateObject("SpecialActivity", "PurchaseLimit");
	}

	public static UI_PurchaseLimit CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PurchaseLimit).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://kozswd8hndja3", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		cardList = (GList)((GComponent)this).GetChild("cardList");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		ActivityTime = (GTextField)((GComponent)this).GetChild("ActivityTime");
		n8 = (GTextField)((GComponent)this).GetChild("n8");
		string id = "ui://kozswd8hndja3".Replace("ui://", "") + "-" + ((GObject)n8).id;
		((GObject)n8).text = LanguagesManager.GetDesc(id);
		n9 = (GTextField)((GComponent)this).GetChild("n9");
		string id2 = "ui://kozswd8hndja3".Replace("ui://", "") + "-" + ((GObject)n9).id;
		((GObject)n9).text = LanguagesManager.GetDesc(id2);
	}
}
