using FairyGUI;
using FairyGUI.Utils;

namespace UI.LegendItemBlueprint;

public class UI_com_ForgeConfirmCostItem : GComponent
{
	public Controller Type;

	public UI_com_LegendItem Item;

	public GLoader BlueprintIcon;

	public UI_com_SelectForgeUniversalLegendItem UniversalLegendItem;

	public const string URL = "ui://h09dvkcgpqzh34";

	public static string Name = "UI_com_ForgeConfirmCostItem";

	public static string GetURL()
	{
		return "ui://h09dvkcgpqzh34";
	}

	public static UI_com_ForgeConfirmCostItem CreateInstance()
	{
		return (UI_com_ForgeConfirmCostItem)(object)UIPackage.CreateObject("LegendItemBlueprint", "com_ForgeConfirmCostItem");
	}

	public static UI_com_ForgeConfirmCostItem CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_ForgeConfirmCostItem).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://h09dvkcgpqzh34", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Type = ((GComponent)this).GetController("Type");
		Item = (UI_com_LegendItem)(object)((GComponent)this).GetChild("Item");
		BlueprintIcon = (GLoader)((GComponent)this).GetChild("BlueprintIcon");
		UniversalLegendItem = (UI_com_SelectForgeUniversalLegendItem)(object)((GComponent)this).GetChild("UniversalLegendItem");
	}
}
