using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LordOfDreams;

public class UI_ReceiveBtn : GButton
{
	public Controller button;

	public Controller State;

	public GLoader icon;

	public GTextField title;

	public GImage note;

	public GImage n6;

	public const string URL = "ui://0i520nzmtajuo8z";

	public static string Name = "UI_ReceiveBtn";

	public static string GetURL()
	{
		return "ui://0i520nzmtajuo8z";
	}

	public static UI_ReceiveBtn CreateInstance()
	{
		return (UI_ReceiveBtn)(object)UIPackage.CreateObject("LordOfDreams", "ReceiveBtn");
	}

	public static UI_ReceiveBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ReceiveBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzmtajuo8z", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		State = ((GComponent)this).GetController("State");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		title = (GTextField)((GComponent)this).GetChild("title");
		string id = "ui://0i520nzmtajuo8z".Replace("ui://", "") + "-" + ((GObject)title).id;
		((GObject)title).text = LanguagesManager.GetDesc(id);
		note = (GImage)((GComponent)this).GetChild("note");
		n6 = (GImage)((GComponent)this).GetChild("n6");
	}
}
