using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGWorldMap3;

public class UI_com_ShareInfoChecker : GComponent
{
	public Controller ShareType;

	public GImage n15;

	public GImage n27;

	public GTextField n17;

	public GTextField n16;

	public GTextField n23;

	public GTextField n22;

	public GTextField n24;

	public GTextField ContributionPoint;

	public GImage n19;

	public GLoader n20;

	public UI_btn_CheckBox CheckBox;

	public UI_com_ShipAvatarSmall SharedByUserAvatar;

	public GTextField SharedByUserName;

	public const string URL = "ui://4eq8fgd2yew4f9";

	public static string Name = "UI_com_ShareInfoChecker";

	public static string GetURL()
	{
		return "ui://4eq8fgd2yew4f9";
	}

	public static UI_com_ShareInfoChecker CreateInstance()
	{
		return (UI_com_ShareInfoChecker)(object)UIPackage.CreateObject("GvGWorldMap3", "com_ShareInfoChecker");
	}

	public static UI_com_ShareInfoChecker CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ShareInfoChecker).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://4eq8fgd2yew4f9", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Expected O, but got Unknown
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Expected O, but got Unknown
		//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fd: Expected O, but got Unknown
		//IL_0209: Unknown result type (might be due to invalid IL or missing references)
		//IL_0213: Expected O, but got Unknown
		//IL_021f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0229: Expected O, but got Unknown
		//IL_0261: Unknown result type (might be due to invalid IL or missing references)
		//IL_026b: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		ShareType = ((GComponent)this).GetController("ShareType");
		n15 = (GImage)((GComponent)this).GetChild("n15");
		n27 = (GImage)((GComponent)this).GetChild("n27");
		n17 = (GTextField)((GComponent)this).GetChild("n17");
		string id = "ui://4eq8fgd2yew4f9".Replace("ui://", "") + "-" + ((GObject)n17).id;
		((GObject)n17).text = LanguagesManager.GetDesc(id);
		n16 = (GTextField)((GComponent)this).GetChild("n16");
		string id2 = "ui://4eq8fgd2yew4f9".Replace("ui://", "") + "-" + ((GObject)n16).id;
		((GObject)n16).text = LanguagesManager.GetDesc(id2);
		n23 = (GTextField)((GComponent)this).GetChild("n23");
		string id3 = "ui://4eq8fgd2yew4f9".Replace("ui://", "") + "-" + ((GObject)n23).id;
		((GObject)n23).text = LanguagesManager.GetDesc(id3);
		n22 = (GTextField)((GComponent)this).GetChild("n22");
		string id4 = "ui://4eq8fgd2yew4f9".Replace("ui://", "") + "-" + ((GObject)n22).id;
		((GObject)n22).text = LanguagesManager.GetDesc(id4);
		n24 = (GTextField)((GComponent)this).GetChild("n24");
		string id5 = "ui://4eq8fgd2yew4f9".Replace("ui://", "") + "-" + ((GObject)n24).id;
		((GObject)n24).text = LanguagesManager.GetDesc(id5);
		ContributionPoint = (GTextField)((GComponent)this).GetChild("ContributionPoint");
		n19 = (GImage)((GComponent)this).GetChild("n19");
		n20 = (GLoader)((GComponent)this).GetChild("n20");
		CheckBox = (UI_btn_CheckBox)(object)((GComponent)this).GetChild("CheckBox");
		SharedByUserAvatar = (UI_com_ShipAvatarSmall)(object)((GComponent)this).GetChild("SharedByUserAvatar");
		SharedByUserName = (GTextField)((GComponent)this).GetChild("SharedByUserName");
	}
}
