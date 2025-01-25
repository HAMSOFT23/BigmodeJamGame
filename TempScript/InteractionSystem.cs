#pragma warning disable
using UnityEngine;
using System.Collections.Generic;

public class InteractionSystem : MonoBehaviour {	
	[SerializeField]
	private Transform _camTransform;
	[SerializeField]
	private float _interactDistance = 1F;
	private IInteractable component;
	private RaycastHit hitInfo;
	
	private void FixedUpdate() {
		LookForInteractable();
	}
	
	public void LookForInteractable() {
		if((Physics.Raycast(_camTransform.position, _camTransform.forward, out hitInfo, _interactDistance) && hitInfo.collider.TryGetComponent<IInteractable>(out component))) {
			Debug.Log("I can interact with : " + component.ToString());
			Debug.DrawRay(_camTransform.position, (_camTransform.forward * _interactDistance), new Color() { r = 0.2054448F, g = 1F, a = 1F }, 0.1F, true);
		}
		 else {
			Debug.DrawRay(_camTransform.position, (_camTransform.forward * _interactDistance), Color.red, 0.1F, true);
		}
	}
}

