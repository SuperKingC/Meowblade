using UnityEngine;

namespace HotFix.Base.Scripts.Chapter;

public interface IMapBackgroundController
{
	string Identifier { get; }

	void SetMapIdentifier(string id);

	void ClearBackgrounds();

	void SetScale(Vector3 scale);
}
