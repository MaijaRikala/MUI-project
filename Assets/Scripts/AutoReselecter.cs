using UnityEngine;
using UnityEngine.EventSystems;

public class AutoReselecter : MonoBehaviour
{
    [SerializeField] private EventSystem eventSystem;
    private GameObject lastSelectedObject;

    void Awake()
    {
        if (eventSystem == null)
            eventSystem = gameObject.GetComponent<EventSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (eventSystem.currentSelectedGameObject == null)
            eventSystem.SetSelectedGameObject(lastSelectedObject); // no current selection, go back to last selected
        else
            lastSelectedObject = eventSystem.currentSelectedGameObject; // keep setting current selected object
    }
}
