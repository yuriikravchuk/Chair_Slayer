using System.Collections.Generic;
using UnityEngine;
using pool;
	public static class PoolManager
	{
		public static List<Pool> Pools = new List<Pool>();
		public static Transform Parent { get; private set; }

		private static bool _isCreated = false;
		//private List <PoolSetup> pools => 

        public static PoolObject Get(int key) 
		{
			Init();
			Pool p = Pools.Find(x => x.Id == key);
			if (p != null)
				return p.Get();
			return null;
		}

		static void Init() {
			if (!_isCreated) {
				Parent = (new GameObject ("Pools")).transform;
				Object.DontDestroyOnLoad (Parent.gameObject);
				for (int i = 0; i < PoolConfig.Pools.Count; i++) 
				{
					if (PoolConfig.Pools[i].Prefab != null) 
					{
						Pool p = new Pool(PoolConfig.Pools[i]);
						Pools.Add (p);
					}
				}
				_isCreated = true;
			}
		}

        public static void ReturnAllEnemies()
        {
            for(int i = 0; i < Pools.Count; i++)
            {
				Pools[i].ReturnAll();
            }
        }
    }