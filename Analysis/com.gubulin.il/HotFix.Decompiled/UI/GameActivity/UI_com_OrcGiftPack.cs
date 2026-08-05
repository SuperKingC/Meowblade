using FairyGUI;
using FairyGUI.Utils;

namespace UI.GameActivity;

public class UI_com_OrcGiftPack : GComponent
{
	public Controller Status;

	public UI_com_OrcStoreItemIcon ItemIcon;

	public GRichTextField Title;

	public UI_OrcBuyBtn BuyBtn;

	public const string URL = "ui://29q48tv6hwkc5f8l";

	public static string Name = "UI_com_OrcGiftPack";

	public static string GetURL()
	{
		return "ui://29q48tv6hwkc5f8l";
	}

	public static UI_com_OrcGiftPack CreateInstance()
	{
		return (UI_com_OrcGiftPack)(object)UIPackage.CreateObject("GameActivity", "com_OrcGiftPack");
	}

	public static UI_com_OrcGiftPack CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_OrcGiftPack).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://29q48tv6hwkc5f8l", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Status = ((GComponent)this).GetController("Status");
		ItemIcon = (UI_com_OrcStoreItemIcon)(object)((GComponent)this).GetChild("ItemIcon");
		Title = (GRichTextField)((GComponent)this).GetChild("Title");
		BuyBtn = (UI_OrcBuyBtn)(object)((GComponent)this).GetChild("BuyBtn");
	}
}
