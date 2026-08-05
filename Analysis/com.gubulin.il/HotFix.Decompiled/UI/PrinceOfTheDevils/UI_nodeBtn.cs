using FairyGUI;
using FairyGUI.Utils;

namespace UI.PrinceOfTheDevils;

public class UI_nodeBtn : GComponent
{
	public Controller button;

	public Controller Status;

	public GImage back2;

	public GGraph sfxBack;

	public UI_nodeRewardIcon middleIcon;

	public GImage n20;

	public const string URL = "ui://zko5n3veme5j15";

	public static string Name = "UI_nodeBtn";

	public static string GetURL()
	{
		return "ui://zko5n3veme5j15";
	}

	public static UI_nodeBtn CreateInstance()
	{
		return (UI_nodeBtn)(object)UIPackage.CreateObject("PrinceOfTheDevils", "nodeBtn");
	}

	public static UI_nodeBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_nodeBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://zko5n3veme5j15", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Status = ((GComponent)this).GetController("Status");
		back2 = (GImage)((GComponent)this).GetChild("back2");
		sfxBack = (GGraph)((GComponent)this).GetChild("sfxBack");
		middleIcon = (UI_nodeRewardIcon)(object)((GComponent)this).GetChild("middleIcon");
		n20 = (GImage)((GComponent)this).GetChild("n20");
	}
}
