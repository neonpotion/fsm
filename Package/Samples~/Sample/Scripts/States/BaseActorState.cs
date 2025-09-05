/* 
 * Gab De Jesus aka neonpotion
 * https://twitter.com/gabottles
 * 06/16/2019
 */

using FSM;

/// <summary>
/// Character state base class.
/// </summary>

namespace FSM.Sample
{
	public abstract class BaseActorState : State<StateType>
	{

		public BaseActorState(
			StateType state,
			PlayerStateController controller) : base(state)
		{
			_assignedPlayerFSM = controller;
		}

		protected PlayerStateController _assignedPlayerFSM;

		protected virtual bool TransitionToIdle()
		{
			throw new System.NotImplementedException();
		}

		protected virtual bool TransitionToRagdollRecovery()
		{
			throw new System.NotImplementedException();
		}

		protected virtual bool TransitionToRagdoll()
		{
			throw new System.NotImplementedException();
		}
	}
}