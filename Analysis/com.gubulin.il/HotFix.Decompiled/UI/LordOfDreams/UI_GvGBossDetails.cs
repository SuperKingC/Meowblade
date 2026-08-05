using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LordOfDreams;

public class UI_GvGBossDetails : GButton
{
	public Controller button;

	public GGraph n6;

	public GImage n4;

	public GTextField n5;

	public const string URL = "ui://0i520nzm9h45occ";

	public static string Name = "UI_GvGBossDetails";

	public static string GetURL()
	{
		return "ui://0i520nzm9h45occ";
	}

	public static UI_GvGBossDetails CreateInstance()
	{
		return (UI_GvGBossDetails)(object)UIPackage.CreateObject("LordOfDreams", "GvGBossDetails");
	}

	public static UI_GvGBossDetails CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_GvGBossDetails).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzm9h45occ", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n6 = (GGraph)((GComponent)this).GetChild("n6");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		string id = "ui://0i520nzm9h45occ".Replace("ui://", "") + "-" + ((GObject)n5).id;
		((GObject)n5).text = LanguagesManager.GetDesc(id);
	}
}
