/* 
 * Gab De Jesus aka neonpotion
 * https://twitter.com/gabottles
 * 06/16/2019
 */

using UnityEngine;

/// <summary>
/// This state rotates makes the character stand by lerping between the starting and standing rotations
/// </summary>
namespace FSM.Sample
{
	public class RecoveryState : BaseActorState
	{

		const float RECOVERY_DURATION = 0.3f;
		float _recoveryTimer = 0f;
		Vector3 _startingRotation;

		public RecoveryState(PlayerStateController controller) : base(StateType.RECOVERY, controller)
		{
		}

		public override void OnStateEnter()
		{
			Debug.Log("Entered recovery state.");
			_startingRotation = _assignedPlayerFSM.transform.eulerAngles;
			_recoveryTimer = 0f;
		}

		public override void OnStateExit()
		{
			_assignedPlayerFSM.isRagdoll = false;
			_assignedPlayerFSM.transform.eulerAngles = Vector3.zero;
		}

		protected override void Action()
		{
			_recoveryTimer += _assignedPlayerFSM.deltaTime;
			_assignedPlayerFSM.transform.eulerAngles = Vector3.Lerp(_startingRotation, Vector3.zero,
				Mathf.InverseLerp(0, RECOVERY_DURATION, _recoveryTimer)
			);
		}

		protected override void InitializeTransitionRules()
		{
			AddTransitionRule(new FSM.Transition<StateType>(TransitionToIdle, StateType.IDLE));
		}

		/// <summary>
		/// Transition to idle if the recovery time has ended.
		/// </summary>
		/// <returns></returns>
		protected override bool TransitionToIdle()
		{
			return _recoveryTimer >= RECOVERY_DURATION;
		}

	}
}