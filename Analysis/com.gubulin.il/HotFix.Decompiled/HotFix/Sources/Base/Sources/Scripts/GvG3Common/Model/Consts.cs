using UnityEngine;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;

public static class Consts
{
	public static Quaternion IconGlobalRotation = Quaternion.Euler(Vector3.zero);

	public const float DockAnimTime = 0.6f;

	public const int EOI_Width = 350000;

	public const int EOI_Height = 175000;

	public const int MapDistMultiplier = 1000;

	public const float EOILoadingWidth = 350f;

	public const float EOILoadingHeight = 175f;

	public const float ExtraLoadingWidth = 35f;

	public const float ExtraLoadingHeight = 25f;

	public const float SmallView_ScreenWidth = 32f;

	public const float SmallView_ScreenHeight = 18f;

	public const float SmallView_ScreenExtraWidthTimes = 0.2f;

	public const float SmallView_ScreenExtraHeightTimes = 0.2f;

	public const float SmallView_SyncingWidth = 44.8f;

	public const float SmallView_SyncingHeight = 25.199999f;

	public const float SmallView_NoResyncWidth = 6.4f;

	public const float SmallView_NoResyncHeight = 3.6000001f;

	public const float MIN_CAM_SIZE_LV1 = 17.5f;

	public const float MAX_CAM_SIZE_LV2 = 46f;

	public const float MIN_CAM_SIZE_LV4 = 6f;

	public const float MAX_CAM_SIZE_LV5 = 30f;

	public const float Thres_Lod1_Lod2 = 8.75f;

	public const float Thres_Lod0_Lod1 = 6.5f;

	public const float BrawlFightFinalCamSizeMax = 25f;

	public const float BrawlFightFinalCamSizeMin = 15f;

	public const float GVG_BOSS_HP_REFRESH_INTERVAL = 10f;

	public const float GVG_SOLDIER_BLOCK_SIZE = 1.3333334f;

	public const float GVG_BOSS_SOLDIER_BLOCK_SIZE = 6.4f;

	public const int MAX_ATTACK_SFX_COUNT = 50;

	public const int MAX_GROUP_COUNT = 30;

	public const float LOCAL_DATA_SAVING_INTERVAL = 5f;

	public const string GvG3CollectingChangeTip = "GvG3CollectingChangeTip";

	public const string GvG3CollectingStopTip = "GvG3CollectingStopTip";

	public const int BRAWL_EVENT_FINAL_ISLAND = 1450;
}
