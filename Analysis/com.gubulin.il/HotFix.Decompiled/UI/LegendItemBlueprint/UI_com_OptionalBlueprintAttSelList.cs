using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemBlueprint;

public class UI_com_OptionalBlueprintAttSelList : GComponent
{
	public Controller Type;

	public GList setList;

	public GTextField n142;

	public GTextField n143;

	public GTextField n144;

	public GTextField n145;

	public const string URL = "ui://h09dvkcgb8pv5ltdz";

	public static string Name = "UI_com_OptionalBlueprintAttSelList";

	public static string GetURL()
	{
		return "ui://h09dvkcgb8pv5ltdz";
	}

	public static UI_com_OptionalBlueprintAttSelList CreateInstance()
	{
		return (UI_com_OptionalBlueprintAttSelList)(object)UIPackage.CreateObject("LegendItemBlueprint", "com_OptionalBlueprintAttSelList");
	}

	public static UI_com_OptionalBlueprintAttSelList CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_OptionalBlueprintAttSelList).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcgb8pv5ltdz", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		setList = (GList)((GComponent)this).GetChild("setList");
		n142 = (GTextField)((GComponent)this).GetChild("n142");
		string id = "ui://h09dvkcgb8pv5ltdz".Replace("ui://", "") + "-" + ((GObject)n142).id;
		((GObject)n142).text = LanguagesManager.GetDesc(id);
		n143 = (GTextField)((GComponent)this).GetChild("n143");
		string id2 = "ui://h09dvkcgb8pv5ltdz".Replace("ui://", "") + "-" + ((GObject)n143).id;
		((GObject)n143).text = LanguagesManager.GetDesc(id2);
		n144 = (GTextField)((GComponent)this).GetChild("n144");
		string id3 = "ui://h09dvkcgb8pv5ltdz".Replace("ui://", "") + "-" + ((GObject)n144).id;
		((GObject)n144).text = LanguagesManager.GetDesc(id3);
		n145 = (GTextField)((GComponent)this).GetChild("n145");
		string id4 = "ui://h09dvkcgb8pv5ltdz".Replace("ui://", "") + "-" + ((GObject)n145).id;
		((GObject)n145).text = LanguagesManager.GetDesc(id4);
	}
}
