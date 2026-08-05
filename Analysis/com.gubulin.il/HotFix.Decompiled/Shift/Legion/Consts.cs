using UnityEngine;

namespace Shift.Legion;

public static class Consts
{
	public const int DataTypeDefault = 0;

	public const int DataTypeJson = 1;

	public const float GVG_BOSS_HP_REFRESH_INTERVAL = 10f;

	public const float GVG_SOLDIER_BLOCK_SIZE = 1.3333334f;

	public const float GVG_BOSS_SOLDIER_BLOCK_SIZE = 6.4f;

	public const float GVG_MIN_CAM_SIZE = 17.5f;

	public const float GVG_MAX_CAM_SIZE = 25f;

	public const int GVG_MAX_SHIP_COUNT = 1;

	public const int MAX_ATTACK_SFX_COUNT = 50;

	public const int MAX_GROUP_COUNT = 30;

	public static float GVG2_CAM_HEIGHT = 100f;

	public const float GVG2_MIN_CAM_SIZE = 5.4f;

	public const float GVG2_MAX_CAM_SIZE = 8.64f;

	public const float GVG2_CAM_SIZE_LV2 = 57.5f;

	public const float GVG2_CAM_SIZE_LV1 = 17.5f;

	public const float GVG2_FLY_VELOVITY = 0.641f;

	public const int GVG3_BUILDING12_MAX_WORKBENCH_COUNT = 100;

	public static Vector3 GVG_START_CAM_POS => new Vector3(28.2f, 21.26f, 91.5f);

	public static Vector3 GVG2_START_CAM_POS => new Vector3(0f, 100f, 0f);

	internal static Vector3 GVG2_MAP_CENTER => new Vector3(0f, 0f, -0.3f);
}
