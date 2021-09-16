namespace GameCreator.Core
{
	using UnityEngine;
	using Opertoon.Panoply;

	public class ActionGoToStep : IAction
	{
		public enum TargetType
		{
			First,
			Prev,
			Next,
			Last,
			Specific
		}
		
		[Tooltip("Where on the global timeline to go to")]
		public TargetType targetType;
		[Tooltip("Which specific step to go to. Only used if the Target Type is Specific.")]
		public int step;
		[Tooltip("Whether to transition to target instantly or not")]
		public bool instant;
		
		public override bool InstantExecute(GameObject target, IAction[] actions, int index)
		{
			if (PanoplyCore.scene == null) return true;
			
			switch (targetType)
			{
			case TargetType.First:
				PanoplyCore.GoToFirstStep();
				break;
			case TargetType.Prev:
				PanoplyCore.DecrementStep();
				break;
			case TargetType.Next:
				PanoplyCore.IncrementStep();
				break;
			case TargetType.Last:
				PanoplyCore.GoToLastStep();
				break;
			case TargetType.Specific:
				PanoplyCore.SetTargetStep(step);
				break;
			}
			
			if (instant)
				PanoplyCore.SetInterpolatedStep(PanoplyCore.targetStep);
				
			return true;
			
		}

		#if UNITY_EDITOR
		public static new string NAME = "Panoply/Go To Step";
		private const string NODE_TITLE = "Go To {0} Step{1}";
		public override string GetNodeTitle()
		{
			return string.Format(
				NODE_TITLE, 
				targetType.ToString(),
				((targetType == TargetType.Specific) ? (": " + step.ToString()) : "")
			);
		}
		#endif
	}
}
