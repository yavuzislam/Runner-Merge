using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Control : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    public bool gameStart = false;
    public Transform[] player;
    public float smoothx = 0.02f;
    public void OnDrag(PointerEventData eventData)
    {
        Vector3 temPosition = player[0].position;
        Vector3 temPos= player[1].position;
        temPosition.x = Mathf.Clamp(temPosition.x + eventData.delta.x * smoothx, -3f, 0);
        temPos.x= Mathf.Clamp(temPos.x - eventData.delta.x * smoothx, 0, 3f);
        player[0].position = temPosition;
        player[1].position = temPos;

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        gameStart = true;
    }
}
