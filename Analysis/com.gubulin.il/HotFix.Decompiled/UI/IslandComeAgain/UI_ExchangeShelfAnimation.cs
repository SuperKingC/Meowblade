using FairyGUI;
using FairyGUI.Utils;

namespace UI.IslandComeAgain;

public class UI_ExchangeShelfAnimation : GComponent
{
	public UI_ExchangeShelf Content;

	public GImage n23;

	public GImage n22;

	public GImage n24;

	public GImage n25;

	public Transition t0;

	public Transition t1;

	public const string URL = "ui://k2sprg26laau6u";

	public static string Name = "UI_ExchangeShelfAnimation";

	public static string GetURL()
	{
		return "ui://k2sprg26laau6u";
	}

	public static UI_ExchangeShelfAnimation CreateInstance()
	{
		return (UI_ExchangeShelfAnimation)(object)UIPackage.CreateObject("IslandComeAgain", "ExchangeShelfAnimation");
	}

	public static UI_ExchangeShelfAnimation CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_ExchangeShelfAnimation).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://k2sprg26laau6u", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		Content = (UI_ExchangeShelf)(object)((GComponent)this).GetChild("Content");
		n23 = (GImage)((GComponent)this).GetChild("n23");
		n22 = (GImage)((GComponent)this).GetChild("n22");
		n24 = (GImage)((GComponent)this).GetChild("n24");
		n25 = (GImage)((GComponent)this).GetChild("n25");
		t0 = ((GComponent)this).GetTransition("t0");
		t1 = ((GComponent)this).GetTransition("t1");
	}
}
