﻿using UnityEngine;
namespace pool
{
	public class PoolObject : MonoBehaviour
	{
		private bool _isSpawned = false;
		private bool _disableObject = true;
		public bool Free { get; private set; } = true;

		public void Init(Pool pool)
		{
			if (!_isSpawned)
			{
				_isSpawned = true;
				_disableObject = pool.setup.switchGameObject;
				if (_disableObject)
					gameObject.SetActive(false);
			}
		}

		public void Push()
		{
			Free = false;
			if (_disableObject)
				gameObject.SetActive(true);
		}

		public void Return()
		{
			if (_isSpawned)
			{
				Free = true;
				transform.SetParent(PoolManager.Parent);
				if (_disableObject)
					gameObject.SetActive(false);
			}
			else
			{
				Destroy(gameObject);
			}
		}
	}
}
