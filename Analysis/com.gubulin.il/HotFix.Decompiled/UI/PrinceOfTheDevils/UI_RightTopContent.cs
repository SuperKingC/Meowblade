using FairyGUI;
using FairyGUI.Utils;

namespace UI.PrinceOfTheDevils;

public class UI_RightTopContent : GComponent
{
	public GImage n14;

	public UI_aimLogo aimLogoBtn;

	public UI_Progress Progress;

	public UI_com_UnderWayNode UnderWayProgress;

	public UI_BigPrize BigPrize;

	public UI_IntegralNode node2;

	public UI_IntegralNode node1;

	public UI_IntegralNode node0;

	public const string URL = "ui://zko5n3velkzg7";

	public static string Name = "UI_RightTopContent";

	public static string GetURL()
	{
		return "ui://zko5n3velkzg7";
	}

	public static UI_RightTopContent CreateInstance()
	{
		return (UI_RightTopContent)(object)UIPackage.CreateObject("PrinceOfTheDevils", "RightTopContent");
	}

	public static UI_RightTopContent CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RightTopContent).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://zko5n3velkzg7", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n14 = (GImage)((GComponent)this).GetChild("n14");
		aimLogoBtn = (UI_aimLogo)(object)((GComponent)this).GetChild("aimLogoBtn");
		Progress = (UI_Progress)(object)((GComponent)this).GetChild("Progress");
		UnderWayProgress = (UI_com_UnderWayNode)(object)((GComponent)this).GetChild("UnderWayProgress");
		BigPrize = (UI_BigPrize)(object)((GComponent)this).GetChild("BigPrize");
		node2 = (UI_IntegralNode)(object)((GComponent)this).GetChild("node2");
		node1 = (UI_IntegralNode)(object)((GComponent)this).GetChild("node1");
		node0 = (UI_IntegralNode)(object)((GComponent)this).GetChild("node0");
	}
}
