using FairyGUI;
using UnityEngine;

namespace UI.GvGBrawlFight;

public interface IShipPosition
{
	int Index { get; set; }

	Vector2 Position { get; }

	Vector2 Size { get; }

	Controller GetState { get; }

	Controller GetIsShowCancelBtn { get; }

	Controller GetIsSelect { get; }

	Controller GetIsDark { get; }

	Controller GetIsWaitConfirm { get; }

	IIslandAvatar GetAvatar { get; }

	UI_com_IslandAvatarSelf GetAvatarSelf { get; }

	GTextField GetSlotName { get; }

	UI_btn_03 GetCancelEnroll { get; }

	GObject GetThis { get; }
}
