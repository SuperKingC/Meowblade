using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExpeditionHall;

public class UI_com_DropDetailDialog : GComponent
{
	public Controller RewardType;

	public GGraph Mask;

	public GImage n51;

	public GImage n53;

	public GImage n68;

	public GList DynamicRewards1;

	public GList DynamicRewards2;

	public GList DynamicRewards3;

	public GTextField n59;

	public GTextField CountDown;

	public GGroup DynamicContents;

	public const string URL = "ui://k19peou7qix93m";

	public static string Name = "UI_com_DropDetailDialog";

	public static string GetURL()
	{
		return "ui://k19peou7qix93m";
	}

	public static UI_com_DropDetailDialog CreateInstance()
	{
		return (UI_com_DropDetailDialog)(object)UIPackage.CreateObject("GvGExpeditionHall", "com_DropDetailDialog");
	}

	public static UI_com_DropDetailDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_DropDetailDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k19peou7qix93m", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		RewardType = ((GComponent)this).GetController("RewardType");
		Mask = (GGraph)((GComponent)this).GetChild("Mask");
		n51 = (GImage)((GComponent)this).GetChild("n51");
		n53 = (GImage)((GComponent)this).GetChild("n53");
		n68 = (GImage)((GComponent)this).GetChild("n68");
		DynamicRewards1 = (GList)((GComponent)this).GetChild("DynamicRewards1");
		DynamicRewards2 = (GList)((GComponent)this).GetChild("DynamicRewards2");
		DynamicRewards3 = (GList)((GComponent)this).GetChild("DynamicRewards3");
		n59 = (GTextField)((GComponent)this).GetChild("n59");
		string id = "ui://k19peou7qix93m".Replace("ui://", "") + "-" + ((GObject)n59).id;
		((GObject)n59).text = LanguagesManager.GetDesc(id);
		CountDown = (GTextField)((GComponent)this).GetChild("CountDown");
		string id2 = "ui://k19peou7qix93m".Replace("ui://", "") + "-" + ((GObject)CountDown).id;
		((GObject)CountDown).text = LanguagesManager.GetDesc(id2);
		DynamicContents = (GGroup)((GComponent)this).GetChild("DynamicContents");
	}
}
