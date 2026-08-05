using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LordOfDreams;

public class UI_MyDamageSlot : GButton
{
	public Controller button;

	public Controller NumberController;

	public GGraph n3;

	public GImage n4;

	public UI_Avatar Avatar;

	public GTextField n7;

	public GTextField DamageText;

	public GLoader n9;

	public const string URL = "ui://0i520nzm121eo2n";

	public static string Name = "UI_MyDamageSlot";

	public static string GetURL()
	{
		return "ui://0i520nzm121eo2n";
	}

	public static UI_MyDamageSlot CreateInstance()
	{
		return (UI_MyDamageSlot)(object)UIPackage.CreateObject("LordOfDreams", "MyDamageSlot");
	}

	public static UI_MyDamageSlot CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_MyDamageSlot).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzm121eo2n", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		NumberController = ((GComponent)this).GetController("NumberController");
		n3 = (GGraph)((GComponent)this).GetChild("n3");
		n4 = (GImage)((GComponent)this).GetChild("n4");
		Avatar = (UI_Avatar)(object)((GComponent)this).GetChild("Avatar");
		n7 = (GTextField)((GComponent)this).GetChild("n7");
		string id = "ui://0i520nzm121eo2n".Replace("ui://", "") + "-" + ((GObject)n7).id;
		((GObject)n7).text = LanguagesManager.GetDesc(id);
		DamageText = (GTextField)((GComponent)this).GetChild("DamageText");
		string id2 = "ui://0i520nzm121eo2n".Replace("ui://", "") + "-" + ((GObject)DamageText).id;
		((GObject)DamageText).text = LanguagesManager.GetDesc(id2);
		n9 = (GLoader)((GComponent)this).GetChild("n9");
	}
}
