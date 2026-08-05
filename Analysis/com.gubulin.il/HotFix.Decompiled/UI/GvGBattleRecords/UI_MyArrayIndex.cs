using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGBattleRecords;

public class UI_MyArrayIndex : GButton
{
	public Controller button;

	public Controller btnaddd;

	public GImage n5;

	public GImage n6;

	public GTextField indexText;

	public Transition Shake;

	public const string URL = "ui://dxmilktydzlsq";

	public static string Name = "UI_MyArrayIndex";

	public static string GetURL()
	{
		return "ui://dxmilktydzlsq";
	}

	public static UI_MyArrayIndex CreateInstance()
	{
		return (UI_MyArrayIndex)(object)UIPackage.CreateObject("GvGBattleRecords", "MyArrayIndex");
	}

	public static UI_MyArrayIndex CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_MyArrayIndex).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://dxmilktydzlsq", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		btnaddd = ((GComponent)this).GetController("btnaddd");
		n5 = (GImage)((GComponent)this).GetChild("n5");
		n6 = (GImage)((GComponent)this).GetChild("n6");
		indexText = (GTextField)((GComponent)this).GetChild("indexText");
		string id = "ui://dxmilktydzlsq".Replace("ui://", "") + "-" + ((GObject)indexText).id;
		((GObject)indexText).text = LanguagesManager.GetDesc(id);
		Shake = ((GComponent)this).GetTransition("Shake");
	}
}
