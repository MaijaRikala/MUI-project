using UnityEngine;
using UnityEngine.UI;

public class BoardNavigation : MonoBehaviour
{
    // Reference to a button that will have this navigation script
    public GameObject ThisButton;

    // Refences to surrounding buttons
    public GameObject ButtonLeft;
    public GameObject ButtonRight;
    public GameObject ButtonTop;
    public GameObject ButtonDown;

    // Create new navigation
    Navigation NewNav = new Navigation();
    //NewNav.mode = Navigation.Mode.Explicit;

    private void Awake()
    {
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
