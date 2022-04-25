using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace enemy
{
    [System.Serializable]
    public class Boss : Enemy
    {
        public override void Die()
        {
            throw new System.NotImplementedException();
        }
    }
}