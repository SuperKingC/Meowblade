using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.MainCity;

public class UI_ProgressionMissionBtn : GButton
{
	public Controller isShowCountDown;

	public GImage n3;

	public GImage n6;

	public GImage n10;

	public GTextField countDown;

	public GMovieClip n11;

	public GImage n8;

	public const string URL = "ui://j611zmym7wjav44t";

	public static string Name = "UI_ProgressionMissionBtn";

	public static string GetURL()
	{
		return "ui://j611zmym7wjav44t";
	}

	public static UI_ProgressionMissionBtn CreateInstance()
	{
		return (UI_ProgressionMissionBtn)(object)UIPackage.CreateObject("MainCity", "ProgressionMissionBtn");
	}

	public static UI_ProgressionMissionBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ProgressionMissionBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://j611zmym7wjav44t", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		isShowCountDown = ((GComponent)this).GetController("isShowCountDown");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		countDown = (GTextField)((GComponent)this).GetChild("countDown");
		string id = "ui://j611zmym7wjav44t".Replace("ui://", "") + "-" + ((GObject)countDown).id;
		((GObject)countDown).text = LanguagesManager.GetDesc(id);
		n11 = (GMovieClip)((GComponent)this).GetChild("n11");
		n8 = (GImage)((GComponent)this).GetChild("n8");
	}
}
