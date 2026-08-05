using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGExpeditionHall;

public class UI_com_SpecialBonusBtn : GComponent
{
	public Controller RewardType;

	public GImage n138;

	public GImage n140;

	public GImage n135;

	public GTextField n132;

	public GImage n136;

	public GLoader RewardDemo;

	public GImage n139;

	public Transition ShelveReward;

	public Transition UnshelveReward;

	public const string URL = "ui://k19peou7uwzh1p";

	public static string Name = "UI_com_SpecialBonusBtn";

	public static string GetURL()
	{
		return "ui://k19peou7uwzh1p";
	}

	public static UI_com_SpecialBonusBtn CreateInstance()
	{
		return (UI_com_SpecialBonusBtn)(object)UIPackage.CreateObject("GvGExpeditionHall", "com_SpecialBonusBtn");
	}

	public static UI_com_SpecialBonusBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_SpecialBonusBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k19peou7uwzh1p", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		RewardType = ((GComponent)this).GetController("RewardType");
		n138 = (GImage)((GComponent)this).GetChild("n138");
		n140 = (GImage)((GComponent)this).GetChild("n140");
		n135 = (GImage)((GComponent)this).GetChild("n135");
		n132 = (GTextField)((GComponent)this).GetChild("n132");
		string id = "ui://k19peou7uwzh1p".Replace("ui://", "") + "-" + ((GObject)n132).id;
		((GObject)n132).text = LanguagesManager.GetDesc(id);
		n136 = (GImage)((GComponent)this).GetChild("n136");
		RewardDemo = (GLoader)((GComponent)this).GetChild("RewardDemo");
		n139 = (GImage)((GComponent)this).GetChild("n139");
		ShelveReward = ((GComponent)this).GetTransition("ShelveReward");
		UnshelveReward = ((GComponent)this).GetTransition("UnshelveReward");
	}
}
