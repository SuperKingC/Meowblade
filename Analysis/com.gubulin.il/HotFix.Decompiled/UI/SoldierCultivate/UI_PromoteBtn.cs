using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.SoldierCultivate;

public class UI_PromoteBtn : GButton
{
	public Controller button;

	public GImage n3;

	public GImage n4;

	public GTextField title;

	public GButton n6;

	public GImage note;

	public const string URL = "ui://7dantnbi108mt77";

	public static string Name = "UI_PromoteBtn";

	public static string GetURL()
	{
		return "ui://7dantnbi108mt77";
	}

	public static UI_PromoteBtn CreateInstance()
	{
		return (UI_PromoteBtn)(object)UIPackage.CreateObject("SoldierCultivate", "PromoteBtn");
	}

	public static UI_PromoteBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PromoteBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7dantnbi108mt77", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://7dantnbi108mt77".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		n6 = (GButton)((GComponent)this).GetChild("n6");
		note = (GImage)((GComponent)this).GetChild("note");
	}
}
