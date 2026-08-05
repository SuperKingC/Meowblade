using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Tips;

public class UI_LegendItemBoxDialog : GComponent
{
	public Controller Type;

	public GImage OfflineEarningWindow;

	public GTextField Title;

	public GList Items;

	public GList BlueprintList;

	public UI_confirmBtn confirmBtn;

	public const string URL = "ui://47lbpgx9rv9z55";

	public static string Name = "UI_LegendItemBoxDialog";

	public static string GetURL()
	{
		return "ui://47lbpgx9rv9z55";
	}

	public static UI_LegendItemBoxDialog CreateInstance()
	{
		return (UI_LegendItemBoxDialog)(object)UIPackage.CreateObject("Tips", "LegendItemBoxDialog");
	}

	public static UI_LegendItemBoxDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_LegendItemBoxDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://47lbpgx9rv9z55", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		OfflineEarningWindow = (GImage)((GComponent)this).GetChild("OfflineEarningWindow");
		Title = (GTextField)((GComponent)this).GetChild("Title");
		string id = "ui://47lbpgx9rv9z55".Replace("ui://", "") + "-" + ((GObject)Title).id;
		((GObject)Title).text = LanguagesManager.GetDesc(id);
		Items = (GList)((GComponent)this).GetChild("Items");
		BlueprintList = (GList)((GComponent)this).GetChild("BlueprintList");
		confirmBtn = (UI_confirmBtn)(object)((GComponent)this).GetChild("confirmBtn");
	}
}
