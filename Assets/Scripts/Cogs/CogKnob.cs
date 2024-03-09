using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CogKnob : MonoBehaviour, IDropHandler
{

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.transform.CompareTag("Knob"))
        {
            Cog draggable = eventData.pointerDrag.GetComponent<Cog>();
            if (draggable != null)
            {
                draggable.startPosition = transform.position;
                draggable.thisImage.raycastTarget = false;
                GetComponent<Image>().raycastTarget = false;
                CogManager.Instance.CheckForWin();
            }
        }
    }
}