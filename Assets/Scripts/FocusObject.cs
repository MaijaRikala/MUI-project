using UnityEngine;
using UnityEngine.EventSystems;

public class FocusObject : MonoBehaviour
{

    [SerializeField] private EventSystem eventSystem;
    [SerializeField] private GameObject firstSelected; // The first element to be selected, when (parent) GameObject is enabled
    [SerializeField] private GameObject lastSelected; //The last element to be selected, when (parent) GameObject is disabled

    private void OnEnable()
    {
        // When (parent) GameObject (i.e. panel) is enabled, set first selected element for keyboard navigation
        eventSystem.SetSelectedGameObject(firstSelected);
    }

    private void OnDisable()
    {
        // When (parent) GameObject (i.e. panel) is disabled, set last selected element for keyboard navigation
        // in the next panel (or panel hidden behind this one)
        eventSystem.SetSelectedGameObject(lastSelected);
    }
}
