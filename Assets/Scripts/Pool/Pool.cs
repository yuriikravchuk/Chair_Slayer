using System.Collections.Generic;
using UnityEngine;

namespace pool
{
	public class Pool
	{
		public PoolSetup setup { get; private set; }

		public int id { get { return setup.id; } }

		public List<PoolObject> spawnedObj = new List<PoolObject>();

		public void ReturnAll()
		{
			for (int i = 0; i < spawnedObj.Count; i++)
			{
				if (spawnedObj[i] != null && !spawnedObj[i].Free)
					spawnedObj[i].Return();
			}
		}

		public Pool(PoolSetup setup)
		{
			this.setup = setup;
		}


		PoolObject Create(int index = -1)
		{
			PoolObject poolObject = Object.Instantiate(setup.prefab.gameObject).GetComponent<PoolObject>();
			if (poolObject != null)
			{
				poolObject.Init(this);
				if (index == -1)
					spawnedObj.Add(poolObject);
				else
					spawnedObj[index] = poolObject;
			}
			else
				Object.Destroy(poolObject.gameObject);
			return poolObject;
		}

		public PoolObject Get()
		{
			for (int i = 0; i < spawnedObj.Count; i++)
			{
				if (spawnedObj[i] == null)
				{
					Create(i);
					spawnedObj[i].Push();
					return spawnedObj[i];
				}
				if (spawnedObj[i].Free)
				{
					spawnedObj[i].Push();
					return spawnedObj[i];
				}
			}
			PoolObject poolObject = Create(-1);
			poolObject.Push();
			return poolObject;
		}
	}
}
