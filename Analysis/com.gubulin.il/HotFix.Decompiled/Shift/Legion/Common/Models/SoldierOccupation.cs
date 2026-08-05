namespace Shift.Legion.Common.Models;

public class SoldierOccupation
{
	public static SoldierOccupation Tank = new SoldierOccupation("坦克", 5);

	public static SoldierOccupation Warrior = new SoldierOccupation("战士", 6);

	public static SoldierOccupation Knight = new SoldierOccupation("骑士", 4);

	public static SoldierOccupation Support = new SoldierOccupation("辅助", 2);

	public static SoldierOccupation Assassin = new SoldierOccupation("刺客", 0);

	public static SoldierOccupation Mage = new SoldierOccupation("法师", 1);

	public static SoldierOccupation Archer = new SoldierOccupation("射手", 3);

	public readonly string Tag;

	public readonly int Index;

	public static SoldierOccupation[] All = new SoldierOccupation[7] { Tank, Warrior, Knight, Support, Assassin, Mage, Archer };

	private SoldierOccupation(string tag, int index)
	{
		Tag = tag;
		Index = index;
	}
}
