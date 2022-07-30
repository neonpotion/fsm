using UnityEngine;

/// <summary>
/// Simple component for look at a specified transform on update.
/// </summary>
namespace FSM.Sample
{
	public class CameraLookAt : MonoBehaviour
	{

		[SerializeField] Transform _lookTarget;

		void Update()
		{
			if (_lookTarget != null)
			{
				transform.LookAt(_lookTarget);
			}
		}
	}
}