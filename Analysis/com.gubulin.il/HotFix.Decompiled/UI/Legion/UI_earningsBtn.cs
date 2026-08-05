using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Legion;

public class UI_earningsBtn : GButton
{
	public Controller button;

	public Controller Status;

	public GTextField title;

	public GTextField n4;

	public const string URL = "ui://lrhs6zw7r46h44j";

	public static string Name = "UI_earningsBtn";

	public static string GetURL()
	{
		return "ui://lrhs6zw7r46h44j";
	}

	public static UI_earningsBtn CreateInstance()
	{
		return (UI_earningsBtn)(object)UIPackage.CreateObject("Legion", "earningsBtn");
	}

	public static UI_earningsBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_earningsBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://lrhs6zw7r46h44j", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Status = ((GComponent)this).GetController("Status");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://lrhs6zw7r46h44j".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		n4 = (GTextField)((GComponent)this).GetChild("n4");
		string id2 = "ui://lrhs6zw7r46h44j".Replace("ui://", "") + "-" + ((GObject)n4).id;
		((GObject)n4).text = LanguagesManager.GetDesc(id2);
	}
}
