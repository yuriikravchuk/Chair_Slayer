using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace enemy
{
	[CreateAssetMenu(fileName = "BossConfig")]
	public class BossConfig : ScriptableObject, IBossProvider
	{
		[SerializeField] private List<Boss> _bosses = new List<Boss>();

        public Boss GetBoss(int level) 
			=> _bosses.First(x => x.Level == level);
    }

	public interface IBossProvider
    {
		Boss GetBoss(int level);
    }
}