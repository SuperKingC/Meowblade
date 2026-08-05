using FairyGUI;
using FairyGUI.Utils;

namespace UI.GvGAmplifierStorage;

public class UI_AmplifierSlot2 : GComponent
{
	public Controller isSelected;

	public Controller Type;

	public GImage n157;

	public GImage n158;

	public GGroup n159;

	public GComponent AmplifierIcon;

	public GComponent AffectedRange;

	public GTextField Count;

	public GImage n160;

	public const string URL = "ui://fwpu3639gi5qz";

	public static string Name = "UI_AmplifierSlot2";

	public static string GetURL()
	{
		return "ui://fwpu3639gi5qz";
	}

	public static UI_AmplifierSlot2 CreateInstance()
	{
		return (UI_AmplifierSlot2)(object)UIPackage.CreateObject("GvGAmplifierStorage", "AmplifierSlot2");
	}

	public static UI_AmplifierSlot2 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_AmplifierSlot2).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://fwpu3639gi5qz", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
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
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		isSelected = ((GComponent)this).GetController("isSelected");
		Type = ((GComponent)this).GetController("Type");
		n157 = (GImage)((GComponent)this).GetChild("n157");
		n158 = (GImage)((GComponent)this).GetChild("n158");
		n159 = (GGroup)((GComponent)this).GetChild("n159");
		AmplifierIcon = (GComponent)((GComponent)this).GetChild("AmplifierIcon");
		AffectedRange = (GComponent)((GComponent)this).GetChild("AffectedRange");
		Count = (GTextField)((GComponent)this).GetChild("Count");
		n160 = (GImage)((GComponent)this).GetChild("n160");
	}
}
