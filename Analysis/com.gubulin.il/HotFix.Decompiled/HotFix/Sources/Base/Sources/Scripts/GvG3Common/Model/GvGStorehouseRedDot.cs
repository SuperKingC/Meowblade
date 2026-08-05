namespace HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;

public class GvGStorehouseRedDot
{
	public bool NewTrophy = false;

	public bool Trophy = false;

	public bool Unpurified = false;

	public int[] SaveData = new int[3];

	public int IZId
	{
		get
		{
			return SaveData[0];
		}
		set
		{
			SaveData[0] = value;
		}
	}

	public int LastCheckedTrophyCount
	{
		get
		{
			return SaveData[1];
		}
		set
		{
			SaveData[1] = value;
		}
	}

	public int UnpurifiedRedDotShowTimestamp
	{
		get
		{
			return SaveData[2];
		}
		set
		{
			SaveData[2] = value;
		}
	}
}
