using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_PreparationTime : GButton
{
	public Controller button;

	public GGraph n9;

	public GGraph n7;

	public GTextField Time;

	public GImage n8;

	public GTextField n6;

	public const string URL = "ui://82mo10n5wmk56n";

	public static string Name = "UI_PreparationTime";

	public static string GetURL()
	{
		return "ui://82mo10n5wmk56n";
	}

	public static UI_PreparationTime CreateInstance()
	{
		return (UI_PreparationTime)(object)UIPackage.CreateObject("PvpSelectSoldiers", "PreparationTime");
	}

	public static UI_PreparationTime CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_PreparationTime).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5wmk56n", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		n9 = (GGraph)((GComponent)this).GetChild("n9");
		n7 = (GGraph)((GComponent)this).GetChild("n7");
		Time = (GTextField)((GComponent)this).GetChild("Time");
		string id = "ui://82mo10n5wmk56n".Replace("ui://", "") + "-" + ((GObject)Time).id;
		((GObject)Time).text = LanguagesManager.GetDesc(id);
		n8 = (GImage)((GComponent)this).GetChild("n8");
		n6 = (GTextField)((GComponent)this).GetChild("n6");
		string id2 = "ui://82mo10n5wmk56n".Replace("ui://", "") + "-" + ((GObject)n6).id;
		((GObject)n6).text = LanguagesManager.GetDesc(id2);
	}
}
