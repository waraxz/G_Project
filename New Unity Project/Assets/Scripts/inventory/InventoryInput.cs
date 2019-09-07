using UnityEngine;

public class InventoryInput : MonoBehaviour
{
    [SerializeField] GameObject inventoryPanelObject;
    [SerializeField] GameObject shortCutPanelObject;
    [SerializeField] KeyCode[] toggleInventoryKeys;
    [SerializeField] bool showAndHideMouse = true;

    public PlayerController player;


    private void Start()
    {
        shortCutPanelObject.SetActive(true);
        inventoryPanelObject.SetActive(false);
        ShowMouseCursor();
    }
    void Update()
    {

        ToggleInventory();
    }


    private void ToggleInventory()
    {
        for (int i = 0; i < toggleInventoryKeys.Length; i++)
        {
            if (Input.GetKeyDown(toggleInventoryKeys[i]))
            {
                if (shortCutPanelObject.activeSelf)
                {
                   
                    shortCutPanelObject.SetActive(false);
                    inventoryPanelObject.SetActive(true);                   
                    ShowMouseCursor();
                    player.gameObject.SetActive(false);
                }
                else
                {
                    inventoryPanelObject.SetActive(false);
                    shortCutPanelObject.SetActive(true);
                    ShowMouseCursor();
                    player.gameObject.SetActive(true);
                }
        
            }
         
        }
    }

    public void ShowMouseCursor()
    {
        if (showAndHideMouse)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void HideMouseCursor()
    {
        if (showAndHideMouse)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }


}
