using Entitas;

public sealed class UiMatcher
{
	private static IMatcher<UiEntity> _matcherNewMsgIncoming;

	public static IMatcher<UiEntity> NewMsgIncoming
	{
		get
		{
			if (_matcherNewMsgIncoming == null)
			{
				Matcher<UiEntity> val = (Matcher<UiEntity>)(object)Matcher<UiEntity>.AllOf(new int[1]);
				val.componentNames = UiComponentsLookup.componentNames;
				_matcherNewMsgIncoming = (IMatcher<UiEntity>)(object)val;
			}
			return _matcherNewMsgIncoming;
		}
	}

	public static IAllOfMatcher<UiEntity> AllOf(params int[] indices)
	{
		return Matcher<UiEntity>.AllOf(indices);
	}

	public static IAllOfMatcher<UiEntity> AllOf(params IMatcher<UiEntity>[] matchers)
	{
		return Matcher<UiEntity>.AllOf(matchers);
	}

	public static IAnyOfMatcher<UiEntity> AnyOf(params int[] indices)
	{
		return Matcher<UiEntity>.AnyOf(indices);
	}

	public static IAnyOfMatcher<UiEntity> AnyOf(params IMatcher<UiEntity>[] matchers)
	{
		return Matcher<UiEntity>.AnyOf(matchers);
	}
}
