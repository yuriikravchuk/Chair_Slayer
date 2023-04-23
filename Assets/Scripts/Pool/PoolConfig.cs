using pool;
using System.Collections.Generic;
using UnityEngine;

namespace pool
{
	[CreateAssetMenu(fileName = "PoolConfig")]
	public class PoolConfig : Config<PoolConfig>
	{
		[SerializeField]private List<PoolSetup> _pools = new List<PoolSetup>();

		public static List<PoolSetup> Pools => Instance._pools;
	}
}