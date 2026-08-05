using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GVGStore;

public class UI_com_HelpTip1 : GComponent
{
	public Controller RewardType;

	public GImage n3;

	public GImage n4;

	public GImage n9;

	public GGroup n8;

	public GList DynamicRewards1;

	public GList DynamicRewards2;

	public GList DynamicRewards3;

	public GTextField n13;

	public GTextField CountDown;

	public GGroup DynamicContents;

	public const string URL = "ui://fvc33k3gdrjq2z";

	public static string Name = "UI_com_HelpTip1";

	public static string GetURL()
	{
		return "ui://fvc33k3gdrjq2z";
	}

	public static UI_com_HelpTip1 CreateInstance()
	{
		return (UI_com_HelpTip1)(object)UIPackage.CreateObject("GVGStore", "com_HelpTip1");
	}

	public static UI_com_HelpTip1 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_HelpTip1).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fvc33k3gdrjq2z", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n9 = (GImage)((GComponent)this).GetChild("n9");
		n8 = (GGroup)((GComponent)this).GetChild("n8");
		DynamicRewards1 = (GList)((GComponent)this).GetChild("DynamicRewards1");
		DynamicRewards2 = (GList)((GComponent)this).GetChild("DynamicRewards2");
		DynamicRewards3 = (GList)((GComponent)this).GetChild("DynamicRewards3");
		n13 = (GTextField)((GComponent)this).GetChild("n13");
		string id = "ui://fvc33k3gdrjq2z".Replace("ui://", "") + "-" + ((GObject)n13).id;
		((GObject)n13).text = LanguagesManager.GetDesc(id);
		CountDown = (GTextField)((GComponent)this).GetChild("CountDown");
		string id2 = "ui://fvc33k3gdrjq2z".Replace("ui://", "") + "-" + ((GObject)CountDown).id;
		((GObject)CountDown).text = LanguagesManager.GetDesc(id2);
		DynamicContents = (GGroup)((GComponent)this).GetChild("DynamicContents");
	}
}
