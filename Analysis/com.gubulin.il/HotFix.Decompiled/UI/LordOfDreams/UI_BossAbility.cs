using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using UnityEngine;

namespace UI.LordOfDreams;

public class UI_BossAbility : GComponent
{
	public GImage Halo;

	public GLoader Icon;

	public GMovieClip EffFlash;

	public UI_eff_down_1 arrow1;

	public GTextField Title;

	public GTextField TitleLight;

	public GGraph SfxBack;

	public Transition NumberChange;

	public const string URL = "ui://0i520nzmdy01odb";

	public static string Name = "UI_BossAbility";

	private string LevelAndName;

	private string ActicityId;

	private string WBId;

	private int Level;

	public static string GetURL()
	{
		return "ui://0i520nzmdy01odb";
	}

	public static UI_BossAbility CreateInstance()
	{
		return (UI_BossAbility)(object)UIPackage.CreateObject("LordOfDreams", "BossAbility");
	}

	public static UI_BossAbility CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_BossAbility).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://0i520nzmdy01odb", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		Halo = (GImage)((GComponent)this).GetChild("Halo");
		Icon = (GLoader)((GComponent)this).GetChild("Icon");
		EffFlash = (GMovieClip)((GComponent)this).GetChild("EffFlash");
		arrow1 = (UI_eff_down_1)(object)((GComponent)this).GetChild("arrow1");
		Title = (GTextField)((GComponent)this).GetChild("Title");
		string id = "ui://0i520nzmdy01odb".Replace("ui://", "") + "-" + ((GObject)Title).id;
		((GObject)Title).text = LanguagesManager.GetDesc(id);
		TitleLight = (GTextField)((GComponent)this).GetChild("TitleLight");
		string id2 = "ui://0i520nzmdy01odb".Replace("ui://", "") + "-" + ((GObject)TitleLight).id;
		((GObject)TitleLight).text = LanguagesManager.GetDesc(id2);
		SfxBack = (GGraph)((GComponent)this).GetChild("SfxBack");
		NumberChange = ((GComponent)this).GetTransition("NumberChange");
	}

	public void SetText(string levelAndName, string wbId, string acticityId, int level)
	{
		LevelAndName = levelAndName;
		ActicityId = acticityId;
		WBId = wbId;
		Level = level;
		string someGvGAbilityInfo = GameLocalDataManager.GetSomeGvGAbilityInfo(wbId, acticityId, level, levelAndName);
		if (!string.IsNullOrEmpty(someGvGAbilityInfo))
		{
			if (NumberChange.playing)
			{
				NumberChange.Stop();
			}
			PlayNumberChange(someGvGAbilityInfo);
		}
		else
		{
			((GObject)Title).text = levelAndName;
			((GObject)TitleLight).text = levelAndName;
		}
	}

	private void PlayNumberChange(string text)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected O, but got Unknown
		((GObject)Title).text = text;
		((GObject)TitleLight).text = text;
		NumberChange.SetHook("NumberChange", (TransitionHook)delegate
		{
			((GObject)Title).text = LevelAndName;
			((GObject)TitleLight).text = LevelAndName;
		});
		NumberChange.Play();
	}

	public void PlayStage2To3()
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		((GObject)this).alpha = 0f;
		FGUIManager.Instance.AddTextSpecialEffects(SfxBack, "ui_gvg_debuff_explosion", new Vector3(100f, 100f, 100f));
	}
}
