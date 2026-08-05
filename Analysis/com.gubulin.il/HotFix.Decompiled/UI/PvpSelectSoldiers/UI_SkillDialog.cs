using Assets.Scripts.Managers;
using Assets.Scripts.UI;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using Shift.Legion.Common.Managers;
using UnityEngine;

namespace UI.PvpSelectSoldiers;

public class UI_SkillDialog : GComponent
{
	public GImage n94;

	public GTextField Name_t;

	public GTextField Describe_t;

	public GLoader FloorLoader;

	public GLoader SkillIconLoader;

	public GImage frameImage;

	public GTextField skillType;

	public GGraph line;

	public const string URL = "ui://82mo10n5lt7m8w";

	public static string Name = "UI_SkillDialog";

	public static string GetURL()
	{
		return "ui://82mo10n5lt7m8w";
	}

	public static UI_SkillDialog CreateInstance()
	{
		return (UI_SkillDialog)(object)UIPackage.CreateObject("PvpSelectSoldiers", "SkillDialog");
	}

	public static UI_SkillDialog CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_SkillDialog).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://82mo10n5lt7m8w", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Expected O, but got Unknown
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		n94 = (GImage)((GComponent)this).GetChild("n94");
		Name_t = (GTextField)((GComponent)this).GetChild("Name_t");
		string id = "ui://82mo10n5lt7m8w".Replace("ui://", "") + "-" + ((GObject)Name_t).id;
		((GObject)Name_t).text = LanguagesManager.GetDesc(id);
		Describe_t = (GTextField)((GComponent)this).GetChild("Describe_t");
		FloorLoader = (GLoader)((GComponent)this).GetChild("FloorLoader");
		SkillIconLoader = (GLoader)((GComponent)this).GetChild("SkillIconLoader");
		frameImage = (GImage)((GComponent)this).GetChild("frameImage");
		skillType = (GTextField)((GComponent)this).GetChild("skillType");
		string id2 = "ui://82mo10n5lt7m8w".Replace("ui://", "") + "-" + ((GObject)skillType).id;
		((GObject)skillType).text = LanguagesManager.GetDesc(id2);
		line = (GGraph)((GComponent)this).GetChild("line");
	}

	public void RenderDialog(string buffId, Vector2 pos)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		GDEAbilityData gDEAbilityData = GDMgr.TryGetWithErrorHandling<GDEAbilityData>(buffId);
		((GObject)Name_t).text = gDEAbilityData.Name;
		SkillIconLoader.LoadAbilityIcon(gDEAbilityData.Icon);
		((GObject)Describe_t).text = gDEAbilityData.Description;
		((GObject)this).visible = true;
		((GObject)this).xy = pos;
	}
}
