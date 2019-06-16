/* 
 * Gab De Jesus aka neonpotion
 * https://twitter.com/gabottles
 * 06/16/2019
 */

using UnityEngine;

/// <summary>
/// This state makes the character enter recovery state after the ragdoll timer expires.
/// </summary>
public class RagdollState : BaseActorState {

	const float RAGDOLL_DURATION = 3f;
	float _ragdollTimer = 0f;

	public RagdollState(PlayerStateController controller) : base(StateType.RAGDOLL, controller) {
	}

	public override void OnStateEnter() {
		Debug.Log("Entered ragdoll state.");
		_ragdollTimer = RAGDOLL_DURATION;
	}

	public override void OnStateExit() {
	}

	protected override void Action() {
		_ragdollTimer -= _assignedPlayerFSM.deltaTime;

	}

	protected override void InitializeTransitionRules() {
		AddTransitionRule(new FSM.Transition<StateType>(TransitionToRagdollRecovery, StateType.RECOVERY));
	}

	protected override bool TransitionToRagdollRecovery() {
		return _ragdollTimer <= 0;
	}

}
