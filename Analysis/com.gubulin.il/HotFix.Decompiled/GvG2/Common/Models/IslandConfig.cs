namespace GvG2.Common.Models;

public class IslandConfig
{
	public int Id { get; set; }

	public string Name { get; set; }

	public string MapId { get; set; }

	public int CampId { get; set; }

	public int X { get; set; }

	public int Z { get; set; }

	public int Scale { get; set; }

	public int Scale_Model { get; set; }

	public int Angle_Model { get; set; }

	public int Scale_CX { get; set; }

	public int Scale_CZ { get; set; }

	public string Connected { get; set; }
}
