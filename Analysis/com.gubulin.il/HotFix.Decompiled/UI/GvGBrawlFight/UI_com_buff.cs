using Assets.Scripts.Managers;
using FairyGUI;
using FairyGUI.Utils;
using GameDataEditor;
using HotFix.Sources.Base.Scripts.Helper;
using Shift.Legion.GvG.Common.Models;

namespace UI.GvGBrawlFight;

public class UI_com_buff : GComponent
{
	public enum ShowMode
	{
		UpArrow,
		Level,
		None
	}

	public Controller effectRange;

	public Controller showMode;

	public Controller isDeactivate;

	public GImage n99;

	public GLoader itemIcon;

	public GImage n97;

	public GImage n102;

	public GImage n103;

	public UI_dec_LevelupEff n107;

	public GTextField rewardCount;

	public GImage n105;

	public GMovieClip n106;

	public Transition Unlock;

	public Transition Levelup;

	public const string URL = "ui://hozu168ro7e45x";

	public static string Name = "UI_com_buff";

	public static string GetURL()
	{
		return "ui://hozu168ro7e45x";
	}

	public static UI_com_buff CreateInstance()
	{
		return (UI_com_buff)(object)UIPackage.CreateObject("GvGBrawlFight", "com_buff");
	}

	public static UI_com_buff CreateInstance_ILRuntime()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		string full_name = typeof(UI_com_buff).FullName;
		UIObjectFactory.SetPackageItemExtension("ui://hozu168ro7e45x", (GComponentCreator)(() => HotFixManager.Instance.appdomain.Instantiate<GComponent>(full_name, (object[])null)));
		return CreateInstance();
	}

	public override void ConstructFromXML(XML xml)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Expected O, but got Unknown
		((GComponent)this).ConstructFromXML(xml);
		effectRange = ((GComponent)this).GetController("effectRange");
		showMode = ((GComponent)this).GetController("showMode");
		isDeactivate = ((GComponent)this).GetController("isDeactivate");
		n99 = (GImage)((GComponent)this).GetChild("n99");
		itemIcon = (GLoader)((GComponent)this).GetChild("itemIcon");
		n97 = (GImage)((GComponent)this).GetChild("n97");
		n102 = (GImage)((GComponent)this).GetChild("n102");
		n103 = (GImage)((GComponent)this).GetChild("n103");
		n107 = (UI_dec_LevelupEff)(object)((GComponent)this).GetChild("n107");
		rewardCount = (GTextField)((GComponent)this).GetChild("rewardCount");
		string id = "ui://hozu168ro7e45x".Replace("ui://", "") + "-" + ((GObject)rewardCount).id;
		((GObject)rewardCount).text = LanguagesManager.GetDesc(id);
		n105 = (GImage)((GComponent)this).GetChild("n105");
		n106 = (GMovieClip)((GComponent)this).GetChild("n106");
		Unlock = ((GComponent)this).GetTransition("Unlock");
		Levelup = ((GComponent)this).GetTransition("Levelup");
	}

	public void Render(GDEItemData itemConfig, int reward, ShowMode mode = ShowMode.Level)
	{
		((GObject)rewardCount).text = $"Lv{reward}";
		itemIcon.url = itemConfig.Icon.ToPublicResourcesRgbIcon();
		bool flag = itemConfig.GetMultiBattleBuffType() == eMultiBattleBuffType.AbilityOnCampBonus;
		showMode.SetSelectedIndex((int)mode);
		effectRange.SetSelectedIndex(flag ? 1 : 0);
	}

	public static bool IsSpecialBuff(GDEItemData itemConfig)
	{
		if (itemConfig.Key == "I68219")
		{
			return false;
		}
		return itemConfig.ItemType == 51;
	}
}
