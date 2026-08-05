using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExpeditionHall;

public class UI_com_SpecialItemList : GComponent
{
	public GImage n51;

	public GTextField n49;

	public GList SpecialList1;

	public GImage n52;

	public GTextField n50;

	public GList SpecialList2;

	public GTextField n53;

	public GTextField CountDown;

	public GGroup RemainingTime;

	public const string URL = "ui://k19peou7qix93k";

	public static string Name = "UI_com_SpecialItemList";

	public static string GetURL()
	{
		return "ui://k19peou7qix93k";
	}

	public static UI_com_SpecialItemList CreateInstance()
	{
		return (UI_com_SpecialItemList)(object)UIPackage.CreateObject("GvGExpeditionHall", "com_SpecialItemList");
	}

	public static UI_com_SpecialItemList CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_SpecialItemList).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k19peou7qix93k", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n51 = (GImage)((GComponent)this).GetChild("n51");
		n49 = (GTextField)((GComponent)this).GetChild("n49");
		string id = "ui://k19peou7qix93k".Replace("ui://", "") + "-" + ((GObject)n49).id;
		((GObject)n49).text = LanguagesManager.GetDesc(id);
		SpecialList1 = (GList)((GComponent)this).GetChild("SpecialList1");
		n52 = (GImage)((GComponent)this).GetChild("n52");
		n50 = (GTextField)((GComponent)this).GetChild("n50");
		string id2 = "ui://k19peou7qix93k".Replace("ui://", "") + "-" + ((GObject)n50).id;
		((GObject)n50).text = LanguagesManager.GetDesc(id2);
		SpecialList2 = (GList)((GComponent)this).GetChild("SpecialList2");
		n53 = (GTextField)((GComponent)this).GetChild("n53");
		string id3 = "ui://k19peou7qix93k".Replace("ui://", "") + "-" + ((GObject)n53).id;
		((GObject)n53).text = LanguagesManager.GetDesc(id3);
		CountDown = (GTextField)((GComponent)this).GetChild("CountDown");
		string id4 = "ui://k19peou7qix93k".Replace("ui://", "") + "-" + ((GObject)CountDown).id;
		((GObject)CountDown).text = LanguagesManager.GetDesc(id4);
		RemainingTime = (GGroup)((GComponent)this).GetChild("RemainingTime");
	}
}
