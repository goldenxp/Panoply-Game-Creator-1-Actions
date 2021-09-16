namespace GameCreator.Core
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using Opertoon.Panoply;

    [AddComponentMenu("")]
    public class IgniterStepEnter : Igniter 
	{
		#if UNITY_EDITOR
		public new static string NAME = "Panoply/On Step Enter";
        #endif
        
		[Tooltip("Target step on the global timeline")]
		public int step;
		[Tooltip("Direction of the timeline to test against")]
		public PanoplyStepDirection direction = PanoplyStepDirection.BothDirections;

		private void Start()
		{
			PanoplyEventManager.OnTargetStepChanged += HandleTargetStepChange;
		}

		private void OnDestroy()
		{
			if (this.isExitingApplication) return;
			PanoplyEventManager.OnTargetStepChanged -= HandleTargetStepChange;
		}
		
		public void HandleTargetStepChange(int oldStep, int newStep)
		{
			if (step != newStep) return;
			
			switch (direction)
			{
			case PanoplyStepDirection.ForwardOnly:
				if (newStep > oldStep) this.ExecuteTrigger(gameObject);
				break;
			case PanoplyStepDirection.BackwardOnly:
				if (newStep < oldStep) this.ExecuteTrigger(gameObject);
				break;
			case PanoplyStepDirection.BothDirections:
			default:
				this.ExecuteTrigger(gameObject);
				break;
			}
		}
	}
}