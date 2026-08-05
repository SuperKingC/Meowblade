using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_mc_ShelfAnimation : GComponent
{
	public UI_mc_Shelf Content;

	public GImage n23;

	public GImage n22;

	public GImage n24;

	public GImage n25;

	public Transition ToNextPool;

	public Transition ToLastPool;

	public const string URL = "ui://k2sprg26laau4j";

	public static string Name = "UI_mc_ShelfAnimation";

	public static string GetURL()
	{
		return "ui://k2sprg26laau4j";
	}

	public static UI_mc_ShelfAnimation CreateInstance()
	{
		return (UI_mc_ShelfAnimation)(object)UIPackage.CreateObject("IslandComeAgain", "mc_ShelfAnimation");
	}

	public static UI_mc_ShelfAnimation CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_mc_ShelfAnimation).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26laau4j", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Content = (UI_mc_Shelf)(object)((GComponent)this).GetChild("Content");
		n23 = (GImage)((GComponent)this).GetChild("n23");
		n22 = (GImage)((GComponent)this).GetChild("n22");
		n24 = (GImage)((GComponent)this).GetChild("n24");
		n25 = (GImage)((GComponent)this).GetChild("n25");
		ToNextPool = ((GComponent)this).GetTransition("ToNextPool");
		ToLastPool = ((GComponent)this).GetTransition("ToLastPool");
	}
}
