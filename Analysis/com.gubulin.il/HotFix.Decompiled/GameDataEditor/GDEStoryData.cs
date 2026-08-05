using ProtoBuf;

namespace GameDataEditor;

[ProtoContract]
public class GDEStoryData
{
	[ProtoMember(1)]
	public string Key;

	[ProtoMember(2)]
	public string StoryId;

	[ProtoMember(3)]
	public string StartTrigger;

	[ProtoMember(4)]
	public string Action;

	[ProtoMember(5)]
	public string Payload;

	[ProtoMember(6)]
	public string NextTrigger;

	[ProtoMember(7)]
	public bool CheckPoint;

	[ProtoMember(8)]
	public string OpenScene;

	[ProtoMember(9)]
	public string OpenUI;

	[ProtoMember(10)]
	public string ReviewStory;

	[ProtoMember(11)]
	public bool CanSkip;

	[ProtoMember(12)]
	public bool ServerSave;

	[ProtoMember(13)]
	public bool IsNewGuide;

	[ProtoMember(14)]
	public bool IsMilitaryIntelligence;
}
