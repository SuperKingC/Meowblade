using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;

namespace UI.Playback;

public class UI_armItem1 : GButton
{
	public Controller button;

	public Controller RedPointController;

	public Controller Status;

	public Controller Level;

	public Controller LegendItemNum;

	public GLoader iconFrame;

	public GImage n44;

	public GLoader icon;

	public GLoader lvFrame;

	public GRichTextField lv;

	public GComponent SoulStoneLevel;

	public const string URL = "ui://9u6qpm6phqom1e";

	public static string Name = "UI_armItem1";

	public static string GetURL()
	{
		return "ui://9u6qpm6phqom1e";
	}

	public static UI_armItem1 CreateInstance()
	{
		return (UI_armItem1)(object)UIPackage.CreateObject("Playback", "armItem1");
	}

	public static UI_armItem1 CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_armItem1).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://9u6qpm6phqom1e", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected O, but got Unknown
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected O, but got Unknown
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Expected O, but got Unknown
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		RedPointController = ((GComponent)this).GetController("RedPointController");
		Status = ((GComponent)this).GetController("Status");
		Level = ((GComponent)this).GetController("Level");
		LegendItemNum = ((GComponent)this).GetController("LegendItemNum");
		iconFrame = (GLoader)((GComponent)this).GetChild("iconFrame");
		n44 = (GImage)((GComponent)this).GetChild("n44");
		icon = (GLoader)((GComponent)this).GetChild("icon");
		lvFrame = (GLoader)((GComponent)this).GetChild("lvFrame");
		lv = (GRichTextField)((GComponent)this).GetChild("lv");
		string id = "ui://9u6qpm6phqom1e".Replace("ui://", "") + "-" + ((GObject)lv).id;
		((GObject)lv).text = LanguagesManager.GetDesc(id);
		SoulStoneLevel = (GComponent)((GComponent)this).GetChild("SoulStoneLevel");
	}
}
