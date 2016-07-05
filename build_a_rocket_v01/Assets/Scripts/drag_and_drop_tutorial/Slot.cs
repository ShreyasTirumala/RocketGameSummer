﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler{
	public GameObject item {
		get {
			if (transform.childCount > 0) {
				return transform.GetChild (0).gameObject;
			}
			return null;
		}
	}

	#region IDropHandler implementation
	public void OnDrop (PointerEventData eventData)
	{
		if (!item) {
			DragHandler.itemBeingDragged.transform.SetParent (transform);
			// calls it on everything above this one on the heirarchy until it is handled
			ExecuteEvents.ExecuteHierarchy<IHasChanged>(gameObject, null, (x,y) => x.HasChanged());
		}
	}
	#endregion
}
