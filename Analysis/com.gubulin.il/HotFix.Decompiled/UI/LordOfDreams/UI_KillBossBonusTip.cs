using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LordOfDreams;

public class UI_KillBossBonusTip : GButton
{
	public Controller button;

	public Controller Type;

	public GGraph n3;

	public GTextField n4;

	public GTextField n5;

	public UI_GvGBossIconSmall Avatar;

	public const string URL = "ui://0i520nzmbvziocf";

	public static string Name = "UI_KillBossBonusTip";

	public static string GetURL()
	{
		return "ui://0i520nzmbvziocf";
	}

	public static UI_KillBossBonusTip CreateInstance()
	{
		return (UI_KillBossBonusTip)(object)UIPackage.CreateObject("LordOfDreams", "KillBossBonusTip");
	}

	public static UI_KillBossBonusTip CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_KillBossBonusTip).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzmbvziocf", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Type = ((GComponent)this).GetController("Type");
		n3 = (GGraph)((GComponent)this).GetChild("n3");
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id = "ui://0i520nzmbvziocf".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id);
		n5 = (GTextField)((GComponent)this).GetChild("n5");
		string id2 = "ui://0i520nzmbvziocf".Replace("ui://", "") + "-" + ((GObject)n5).id;
		((GObject)n5).text = LanguagesManager.GetDesc(id2);
		Avatar = (UI_GvGBossIconSmall)(object)((GComponent)this).GetChild("Avatar");
	}
}
