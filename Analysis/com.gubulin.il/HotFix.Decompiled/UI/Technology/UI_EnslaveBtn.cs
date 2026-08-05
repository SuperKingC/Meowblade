using FairyGUI;
using FairyGUI.Utils;

namespace UI.Technology;

public class UI_EnslaveBtn : GButton
{
	public Controller button;

	public GImage selectBack;

	public GImage noSelectBack;

	public GImage selectNote;

	public GImage noSelectNote;

	public GImage n12;

	public GImage n13;

	public const string URL = "ui://7ca77a3fty9r2";

	public static string Name = "UI_EnslaveBtn";

	public static string GetURL()
	{
		return "ui://7ca77a3fty9r2";
	}

	public static UI_EnslaveBtn CreateInstance()
	{
		return (UI_EnslaveBtn)(object)UIPackage.CreateObject("Technology", "EnslaveBtn");
	}

	public static UI_EnslaveBtn CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_EnslaveBtn).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://7ca77a3fty9r2", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		selectBack = (GImage)((GComponent)this).GetChild("selectBack");
		noSelectBack = (GImage)((GComponent)this).GetChild("noSelectBack");
		selectNote = (GImage)((GComponent)this).GetChild("selectNote");
		noSelectNote = (GImage)((GComponent)this).GetChild("noSelectNote");
		n12 = (GImage)((GComponent)this).GetChild("n12");
		n13 = (GImage)((GComponent)this).GetChild("n13");
	}
}
