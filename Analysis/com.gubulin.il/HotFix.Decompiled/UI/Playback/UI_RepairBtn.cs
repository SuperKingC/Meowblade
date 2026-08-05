using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Playback;

public class UI_RepairBtn : GButton
{
	public Controller button;

	public Controller Type;

	public GImage n10;

	public GTextField countDown;

	public GTextField tip1;

	public GTextField tip2;

	public GTextField title;

	public const string URL = "ui://9u6qpm6plze0i";

	public static string Name = "UI_RepairBtn";

	public static string GetURL()
	{
		return "ui://9u6qpm6plze0i";
	}

	public static UI_RepairBtn CreateInstance()
	{
		return (UI_RepairBtn)(object)UIPackage.CreateObject("Playback", "RepairBtn");
	}

	public static UI_RepairBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_RepairBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://9u6qpm6plze0i", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected O, but got Unknown
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Type = ((GComponent)this).GetController("Type");
		n10 = (GImage)((GComponent)this).GetChild("n10");
		countDown = (GTextField)((GComponent)this).GetChild("countDown");
		string id = "ui://9u6qpm6plze0i".Replace("ui://", "") + "-" + ((GObject)countDown).id;
		((GObject)countDown).text = LanguagesManager.GetDesc(id);
		tip1 = (GTextField)((GComponent)this).GetChild("tip1");
		string id2 = "ui://9u6qpm6plze0i".Replace("ui://", "") + "-" + ((GObject)tip1).id;
		((GObject)tip1).text = LanguagesManager.GetDesc(id2);
		tip2 = (GTextField)((GComponent)this).GetChild("tip2");
		string id3 = "ui://9u6qpm6plze0i".Replace("ui://", "") + "-" + ((GObject)tip2).id;
		((GObject)tip2).text = LanguagesManager.GetDesc(id3);
		title = (GTextField)((GComponent)this).GetChild("title");
		string id4 = "ui://9u6qpm6plze0i".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id4);
	}
}
