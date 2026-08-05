namespace HotFix;

public class HotUpdateFileInfo
{
	public readonly string key;

	public readonly int size;

	public readonly string md5;

	private string _server_path;

	private string _backup_server_path;

	private string _local_path;

	public string server_path
	{
		get
		{
			if (string.IsNullOrEmpty(_server_path))
			{
				_server_path = AssetsHelper.GetServerPath(key);
			}
			return _server_path;
		}
	}

	public string backup_server_path
	{
		get
		{
			if (string.IsNullOrEmpty(_backup_server_path))
			{
				_backup_server_path = AssetsHelper.GetBackupServerPath(key);
			}
			return _backup_server_path;
		}
	}

	public string local_path
	{
		get
		{
			if (string.IsNullOrEmpty(_local_path))
			{
				_local_path = AssetsHelper.GetLocalPath(key);
			}
			return _local_path;
		}
	}

	public HotUpdateFileInfo(string _key, int _size, string _md5)
	{
		key = _key;
		size = _size;
		md5 = _md5.ToLower();
	}
}
