using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.RecyclingCenter;

public class UI_SwitchBtn : GButton
{
	public Controller button;

	public Controller Status;

	public Controller Type;

	public GImage n4;

	public GImage n5;

	public GImage n3;

	public GTextField n6;

	public GTextField n7;

	public GTextField n8;

	public const string URL = "ui://72poq8plkxix13";

	public static string Name = "UI_SwitchBtn";

	public static string GetURL()
	{
		return "ui://72poq8plkxix13";
	}

	public static UI_SwitchBtn CreateInstance()
	{
		return (UI_SwitchBtn)(object)UIPackage.CreateObject("RecyclingCenter", "SwitchBtn");
	}

	public static UI_SwitchBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SwitchBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://72poq8plkxix13", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		Status = ((GComponent)this).GetController("Status");
		Type = ((GComponent)this).GetController("Type");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n3 = (GImage)((GComponent)this).GetChild("n3");
		n6 = (GTextField)((GComponent)this).GetChild("n6");
		string id = "ui://72poq8plkxix13".Replace("ui://", "") + "-" + ((GObject)n6).id;
		((GObject)n6).text = LanguagesManager.GetDesc(id);
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		string id2 = "ui://72poq8plkxix13".Replace("ui://", "") + "-" + ((GObject)n7).id;
		((GObject)n7).text = LanguagesManager.GetDesc(id2);
		n8 = (GTextField)((GComponent)this).GetChild("n8");
		string id3 = "ui://72poq8plkxix13".Replace("ui://", "") + "-" + ((GObject)n8).id;
		((GObject)n8).text = LanguagesManager.GetDesc(id3);
	}
}
