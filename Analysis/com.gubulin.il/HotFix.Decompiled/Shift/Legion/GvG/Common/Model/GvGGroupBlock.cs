using Shift.Legion.Common.Models;
using UnityEngine;

namespace Shift.Legion.GvG.Common.Model;

public class GvGGroupBlock
{
	public float unitWidthX;

	public float unitWidthZ;

	public float groupWidthX;

	public float groupWidthZ;

	public GvGRect bossRect;

	public GvGRect groupRect;

	public int teamCount;

	public int real_cnt;

	public int _x_cnt;

	public int _z_cnt;

	public void InitBossBlock(int _teamCount)
	{
		teamCount = _teamCount;
		string wBId = GvGWorldController.Instance.ProcessInfo.BossInfo.WBId;
		GvGWorldBossInfo gvGWorldBossInfoByWBId = GvGConfigHelper.GetGvGWorldBossInfoByWBId(wBId);
		int bossBlockSizeX = gvGWorldBossInfoByWBId.bossBlockSizeX;
		int bossBlockSizeZ = gvGWorldBossInfoByWBId.bossBlockSizeZ;
		unitWidthZ = 4f;
		unitWidthX = 4f;
		bossRect = new GvGRect
		{
			maxX = unitWidthX * (float)bossBlockSizeX / 2f,
			minX = unitWidthX * (float)bossBlockSizeX / -2f,
			maxZ = unitWidthZ * (float)bossBlockSizeZ / 2f - unitWidthZ,
			minZ = unitWidthZ * (float)bossBlockSizeZ / -2f - unitWidthZ
		};
		real_cnt = _teamCount;
		_x_cnt = Mathf.CeilToInt(Mathf.Sqrt((float)real_cnt));
		_z_cnt = Mathf.CeilToInt(1f * (float)real_cnt / (float)_x_cnt);
		groupWidthZ = unitWidthZ * (float)_z_cnt;
		groupWidthX = unitWidthX * (float)_x_cnt;
		groupRect = new GvGRect
		{
			maxX = groupWidthX / 2f,
			minX = (0f - groupWidthX) / 2f,
			maxZ = groupWidthZ / 2f,
			minZ = (0f - groupWidthZ) / 2f
		};
	}

	public void InitPlayerBlock(int _teamCount)
	{
		teamCount = _teamCount;
		real_cnt = _teamCount;
		_z_cnt = Mathf.CeilToInt(Mathf.Sqrt((float)real_cnt));
		_x_cnt = Mathf.CeilToInt(1f * (float)real_cnt / (float)_z_cnt);
		unitWidthZ = 4f;
		unitWidthX = 4f;
		groupWidthZ = unitWidthZ * (float)_z_cnt;
		groupWidthX = unitWidthX * (float)_x_cnt;
		groupRect = new GvGRect
		{
			maxX = groupWidthX / 2f,
			minX = (0f - groupWidthX) / 2f,
			maxZ = groupWidthZ / 2f,
			minZ = (0f - groupWidthZ) / 2f
		};
	}
}
