using FairyGUI;
using FairyGUI.Utils;

namespace UI.PvpSelectSoldiers;

public class UI_BattleArray : GButton
{
	public Controller button;

	public GGraph SelectFormation;

	public GImage n14;

	public UI_CurFormation CurFormation;

	public GButton clearBtn;

	public UI_MyArrayIndex ArrayIndex;

	public GLoader formationIcon;

	public GList enemy;

	public Transition Shake;

	public const string URL = "ui://82mo10n5gox21";

	public static string Name = "UI_BattleArray";

	public static string GetURL()
	{
		return "ui://82mo10n5gox21";
	}

	public static UI_BattleArray CreateInstance()
	{
		return (UI_BattleArray)(object)UIPackage.CreateObject("PvpSelectSoldiers", "BattleArray");
	}

	public static UI_BattleArray CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_BattleArray).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5gox21", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		button = ((GComponent)this).GetController("button");
		SelectFormation = (GGraph)((GComponent)this).GetChild("SelectFormation");
		n14 = (GImage)((GComponent)this).GetChild("n14");
		CurFormation = (UI_CurFormation)(object)((GComponent)this).GetChild("CurFormation");
		clearBtn = (GButton)((GComponent)this).GetChild("clearBtn");
		ArrayIndex = (UI_MyArrayIndex)(object)((GComponent)this).GetChild("ArrayIndex");
		formationIcon = (GLoader)((GComponent)this).GetChild("formationIcon");
		enemy = (GList)((GComponent)this).GetChild("enemy");
		Shake = ((GComponent)this).GetTransition("Shake");
	}
}
