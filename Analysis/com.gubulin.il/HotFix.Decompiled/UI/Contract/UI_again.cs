using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Contract;

public class UI_again : GButton
{
	public Controller button;

	public GButton n18;

	public GLoader ticketIcon;

	public GTextField cost;

	public const string URL = "ui://avplaivdmxsj1y";

	public static string Name = "UI_again";

	public static string GetURL()
	{
		return "ui://avplaivdmxsj1y";
	}

	public static UI_again CreateInstance()
	{
		return (UI_again)(object)UIPackage.CreateObject("Contract", "again");
	}

	public static UI_again CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_again).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://avplaivdmxsj1y", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n18 = (GButton)((GComponent)this).GetChild("n18");
		ticketIcon = (GLoader)((GComponent)this).GetChild("ticketIcon");
		cost = (GTextField)((GComponent)this).GetChild("cost");
		string id = "ui://avplaivdmxsj1y".Replace("ui://", "") + "-" + ((GObject)cost).id;
		((GObject)cost).text = LanguagesManager.GetDesc(id);
	}
}
