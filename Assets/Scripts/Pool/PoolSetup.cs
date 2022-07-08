namespace pool
{
	[System.Serializable]
	public class PoolSetup
	{
		public PoolObject Prefab;
		public int Id;
		public bool DisableOnReturn;

		public PoolSetup(PoolObject prefab, int id)
		{
			Prefab = prefab;
			Id = id;
		}

		public PoolSetup(PoolObject prefab, int id, bool disableOnReturn)
		{
			Prefab = prefab;
			Id = id;
			DisableOnReturn = disableOnReturn;
		}
	}
}
