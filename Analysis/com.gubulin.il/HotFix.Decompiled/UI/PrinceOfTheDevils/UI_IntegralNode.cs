using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PrinceOfTheDevils;

public class UI_IntegralNode : GButton
{
	public Controller button;

	public Controller BonusStatus;

	public GImage arrow;

	public GTextField AchievementCount;

	public UI_nodeBtn nodeBtn;

	public const string URL = "ui://zko5n3veme5j14";

	public static string Name = "UI_IntegralNode";

	public static string GetURL()
	{
		return "ui://zko5n3veme5j14";
	}

	public static UI_IntegralNode CreateInstance()
	{
		return (UI_IntegralNode)(object)UIPackage.CreateObject("PrinceOfTheDevils", "IntegralNode");
	}

	public static UI_IntegralNode CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_IntegralNode).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://zko5n3veme5j14", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		BonusStatus = ((GComponent)this).GetController("BonusStatus");
		arrow = (GImage)((GComponent)this).GetChild("arrow");
		AchievementCount = (GTextField)((GComponent)this).GetChild("AchievementCount");
		string id = "ui://zko5n3veme5j14".Replace("ui://", "") + "-" + ((GObject)AchievementCount).id;
		((GObject)AchievementCount).text = LanguagesManager.GetDesc(id);
		nodeBtn = (UI_nodeBtn)(object)((GComponent)this).GetChild("nodeBtn");
	}
}
