using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TrashBin : MonoBehaviour, IDropHandler
{

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.transform.CompareTag("File"))
        {
            GameObject draggable = eventData.pointerDrag.gameObject;
            if (draggable != null)
            {
                Destroy(draggable);
                Win95Manager.Instance.CheckForWin(false);
            }
            
        }
        else if (eventData.pointerDrag.transform.CompareTag("sys32"))
        {
            GameObject draggable = eventData.pointerDrag.gameObject;
            if (draggable != null)
            {
                Destroy(draggable);
                Win95Manager.Instance.CheckForWin(true);
            }
        }
    }
}