using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace enemy
{
	[CreateAssetMenu(fileName = "BossConfig")]
	public class BossConfig : ScriptableObject
	{
		[SerializeField] List<Boss> _bosses = new List<Boss>();

		public static List<Boss> bosses
		{
			get
			{
				return instance._bosses;
			}
		}

		static BossConfig _instance;
		public static BossConfig instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = (BossConfig)Resources.Load("BossConfig");
					if (_instance == null)
					{
						_instance = BossConfig.CreateInstance<BossConfig>();
					}
				}
				return _instance;
			}
		}
	}
}

