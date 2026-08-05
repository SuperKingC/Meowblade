using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.AccountInfo;

public class UI_BackUpData : GButton
{
	public Controller button;

	public Controller Type;

	public GImage n27;

	public GGraph n3;

	public GImage n4;

	public UI_DeleteUserDataBtn DeleteData;

	public UI_RankingListAvatar Avatar;

	public GTextField UserName;

	public GTextField UserId;

	public GTextField UserLevel;

	public GTextField UserTotalCombatPower;

	public GTextField UserWorkerNum;

	public GTextField UserGemNum;

	public GTextField UserMtgNum;

	public GTextField UserLevelTitle;

	public GTextField UserTotalCombatPowerTitle;

	public GTextField UserWorkerNumTitle;

	public GTextField UserGemNumTitle;

	public GTextField UserMtgNumTitle;

	public GGroup n20;

	public const string URL = "ui://b9yxt7u0k3894e";

	public static string Name = "UI_BackUpData";

	public static string GetURL()
	{
		return "ui://b9yxt7u0k3894e";
	}

	public static UI_BackUpData CreateInstance()
	{
		return (UI_BackUpData)(object)UIPackage.CreateObject("AccountInfo", "BackUpData");
	}

	public static UI_BackUpData CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_BackUpData).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://b9yxt7u0k3894e", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
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
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Expected O, but got Unknown
		//IL_0238: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Expected O, but got Unknown
		//IL_028b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0295: Expected O, but got Unknown
		//IL_02e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ea: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Type = ((GComponent)this).GetController("Type");
		n27 = (GImage)((GComponent)this).GetChild("n27");
		n3 = (GGraph)((GComponent)this).GetChild("n3");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		DeleteData = (UI_DeleteUserDataBtn)(object)((GComponent)this).GetChild("DeleteData");
		Avatar = (UI_RankingListAvatar)(object)((GComponent)this).GetChild("Avatar");
		UserName = (GTextField)((GComponent)this).GetChild("UserName");
		UserId = (GTextField)((GComponent)this).GetChild("UserId");
		UserLevel = (GTextField)((GComponent)this).GetChild("UserLevel");
		UserTotalCombatPower = (GTextField)((GComponent)this).GetChild("UserTotalCombatPower");
		UserWorkerNum = (GTextField)((GComponent)this).GetChild("UserWorkerNum");
		UserGemNum = (GTextField)((GComponent)this).GetChild("UserGemNum");
		UserMtgNum = (GTextField)((GComponent)this).GetChild("UserMtgNum");
		UserLevelTitle = (GTextField)((GComponent)this).GetChild("UserLevelTitle");
		string id = "ui://b9yxt7u0k3894e".Replace("ui://", "") + "-" + ((GObject)UserLevelTitle).id;
		((GObject)UserLevelTitle).text = LanguagesManager.GetDesc(id);
		UserTotalCombatPowerTitle = (GTextField)((GComponent)this).GetChild("UserTotalCombatPowerTitle");
		string id2 = "ui://b9yxt7u0k3894e".Replace("ui://", "") + "-" + ((GObject)UserTotalCombatPowerTitle).id;
		((GObject)UserTotalCombatPowerTitle).text = LanguagesManager.GetDesc(id2);
		UserWorkerNumTitle = (GTextField)((GComponent)this).GetChild("UserWorkerNumTitle");
		string id3 = "ui://b9yxt7u0k3894e".Replace("ui://", "") + "-" + ((GObject)UserWorkerNumTitle).id;
		((GObject)UserWorkerNumTitle).text = LanguagesManager.GetDesc(id3);
		UserGemNumTitle = (GTextField)((GComponent)this).GetChild("UserGemNumTitle");
		string id4 = "ui://b9yxt7u0k3894e".Replace("ui://", "") + "-" + ((GObject)UserGemNumTitle).id;
		((GObject)UserGemNumTitle).text = LanguagesManager.GetDesc(id4);
		UserMtgNumTitle = (GTextField)((GComponent)this).GetChild("UserMtgNumTitle");
		string id5 = "ui://b9yxt7u0k3894e".Replace("ui://", "") + "-" + ((GObject)UserMtgNumTitle).id;
		((GObject)UserMtgNumTitle).text = LanguagesManager.GetDesc(id5);
		n20 = (GGroup)((GComponent)this).GetChild("n20");
	}
}
