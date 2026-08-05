using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Battle;

public class UI_PreCardBtn : GButton
{
	public Controller button;

	public GGraph n0;

	public GGraph n1;

	public GGraph n2;

	public GTextField title;

	public const string URL = "ui://twlbabicr726l";

	public static string Name = "UI_PreCardBtn";

	public static string GetURL()
	{
		return "ui://twlbabicr726l";
	}

	public static UI_PreCardBtn CreateInstance()
	{
		return (UI_PreCardBtn)(object)UIPackage.CreateObject("Battle", "PreCardBtn");
	}

	public static UI_PreCardBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PreCardBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://twlbabicr726l", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		n0 = (GGraph)((GComponent)this).GetChild("n0");
		n1 = (GGraph)((GComponent)this).GetChild("n1");
		n2 = (GGraph)((GComponent)this).GetChild("n2");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://twlbabicr726l".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
	}
}
