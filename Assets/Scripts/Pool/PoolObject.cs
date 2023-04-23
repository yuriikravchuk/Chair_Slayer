using UnityEngine;
namespace pool
{
	public class PoolObject : MonoBehaviour
	{
		public bool Free { get; private set; } = true;

		private bool _isSpawned = false;
		private bool _disableObject = true;

		public void Init(Pool pool)
		{
			if (!_isSpawned)
			{
				_isSpawned = true;
				_disableObject = pool.Setup.DisableOnReturn;
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
				transform.SetParent(PoolsContainer.Parent);
				if (_disableObject)
					gameObject.SetActive(false);
			}
			else
				Destroy(gameObject);
		}
	}
}
