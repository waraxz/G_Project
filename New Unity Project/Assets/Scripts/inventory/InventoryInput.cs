using UnityEngine;

public class InventoryInput : MonoBehaviour
{
    [SerializeField] GameObject inventoryPanelObject;
    [SerializeField] GameObject shortCutPanelObject;
    [SerializeField] KeyCode[] toggleInventoryKeys;
    [SerializeField] bool showAndHideMouse = true;

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
                }
                else
                {
                    inventoryPanelObject.SetActive(false);
                    shortCutPanelObject.SetActive(true);
                    HideMouseCursor();
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
