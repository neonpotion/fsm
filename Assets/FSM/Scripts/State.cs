/* 
 * Gab De Jesus aka neonpotion
 * https://twitter.com/gabottles
 * 06/16/2019
 */

using System.Collections.Generic;

namespace FSM {
	public abstract class State<stateID> {

		protected stateID _stateType;
		List<Transition<stateID>> transitions = new List<Transition<stateID>>();

		public stateID stateType {
			get {
				return _stateType;
			}
		}

		public State(stateID state) {
			_stateType = state;
			InitializeTransitionRules();
		}

		/// <summary>
		/// Ticks this state. State controller calls this
		/// </summary>
		/// <param name="controller"></param>
		public void UpdateState(StateMachine<stateID> controller) {
			//Does the action assigned for this state
			Action();
			//Checks whether there are valid transitions to do
			CheckTransitions(controller);
		}

		/// <summary>
		/// Adds a transition condition to the state. Transitions are checked every time the state is ticked
		/// </summary>
		/// <param name="condition"></param>
		/// <param name="trueState"></param>
		/// <param name="falseState"> if this statement is null, The state does not repeat on enter/exit states</param>
		public void AddTransitionRule(Transition<stateID> t) {
			transitions.Add(t);
		}

		/// <summary>
		/// Initializes the states transition conditions. Add your transition rules here. Transition priorities are based on order
		/// </summary>
		protected abstract void InitializeTransitionRules();

		/// <summary>
		/// The action to take during this state
		/// </summary>
		protected abstract void Action();

		public abstract void OnStateEnter();

		public abstract void OnStateExit();

		/// <summary>
		/// Checks if the state's transition conditions are fulfilled.
		/// Calls the state controller to change
		/// </summary>
		/// <param name="controller"></param>
		void CheckTransitions(StateMachine<stateID> controller) {
			for (int i = 0; i < transitions.Count; i++) {
				bool decisionSucceeded = transitions[i].decision();

				if (decisionSucceeded) {
					controller.ChangeState(transitions[i].toState);
					return; // This has return so that the first transition to become true is the priority
				}
			}
		}
	}

	[System.Serializable]
	public class Transition<nextStateID> {
		public nextStateID toState;
		public System.Func<bool> decision {
			get; set;
		}
		public Transition(System.Func<bool> d, nextStateID nextState) {
			decision = d;
			toState = nextState;
		}
	}
}