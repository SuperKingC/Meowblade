namespace HotFix.Sources.Base.Sources.Scripts.GvG3Common.Model;

public static class eShipStateExtension
{
	public static bool IsInWorld(this eShipState state)
	{
		return state >= eShipState.Stay && state <= eShipState.SuppressRebellion;
	}
}
