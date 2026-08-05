using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvG3Video;

public class UI_com_VideoInfo : GComponent
{
	public Controller State;

	public GImage n11;

	public GLoader PreviewIcon;

	public GImage n14;

	public GTextField PlayTip;

	public GTextField n7;

	public GTextField UnlockTip;

	public GImage n12;

	public GTextField VideoTitle;

	public GImage n15;

	public GLoader RewardIcon;

	public GTextField RewardCount;

	public const string URL = "ui://2itu6489fuvq9";

	public static string Name = "UI_com_VideoInfo";

	public static string GetURL()
	{
		return "ui://2itu6489fuvq9";
	}

	public static UI_com_VideoInfo CreateInstance()
	{
		return (UI_com_VideoInfo)(object)UIPackage.CreateObject("GvG3Video", "com_VideoInfo");
	}

	public static UI_com_VideoInfo CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_VideoInfo).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://2itu6489fuvq9", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		State = ((GComponent)this).GetController("State");
		n11 = (GImage)((GComponent)this).GetChild("n11");
		PreviewIcon = (GLoader)((GComponent)this).GetChild("PreviewIcon");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		PlayTip = (GTextField)((GComponent)this).GetChild("PlayTip");
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		string id = "ui://2itu6489fuvq9".Replace("ui://", "") + "-" + ((GObject)n7).id;
		((GObject)n7).text = LanguagesManager.GetDesc(id);
		UnlockTip = (GTextField)((GComponent)this).GetChild("UnlockTip");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		VideoTitle = (GTextField)((GComponent)this).GetChild("VideoTitle");
		string id2 = "ui://2itu6489fuvq9".Replace("ui://", "") + "-" + ((GObject)VideoTitle).id;
		((GObject)VideoTitle).text = LanguagesManager.GetDesc(id2);
		n15 = (GImage)((GComponent)this).GetChild("n15");
		RewardIcon = (GLoader)((GComponent)this).GetChild("RewardIcon");
		RewardCount = (GTextField)((GComponent)this).GetChild("RewardCount");
	}
}
