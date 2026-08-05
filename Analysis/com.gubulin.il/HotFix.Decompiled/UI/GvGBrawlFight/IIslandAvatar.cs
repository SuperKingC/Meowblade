using FairyGUI;

namespace UI.GvGBrawlFight;

public interface IIslandAvatar
{
	Controller GetIsHide { get; }

	Controller GetStrategy { get; }

	UI_com_Avatar GetAvatar { get; }

	GLoader GetIcon { get; }
}
