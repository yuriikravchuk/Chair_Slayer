using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace enemy
{
	[CreateAssetMenu(fileName = "BossConfig")]
	public class BossConfig : ScriptableObject, IBossProvider
	{
		[SerializeField] List<Boss> _bosses = new List<Boss>();
        private BossConfig _instance;

        private void Awake()
        {
            if (_instance == null)
                _instance = Resources.Load("BossConfig") as BossConfig;
        }

        public Boss GetBoss(int level) => _instance._bosses.First(boss => boss.Level == level);
    }
}