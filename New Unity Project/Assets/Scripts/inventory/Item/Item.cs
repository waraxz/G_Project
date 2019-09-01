using System.Text;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(menuName = "Items/Item")]
public class Item : ScriptableObject
{
    [SerializeField] string id;
    public string ID { get { return id; } }
    public string itemName;
    public Sprite icon;
    [Range(1, 999)]
    public int MaxStacks = 1;
    public bool IsConsumable;




    public virtual Item GetCopy()
    {
        return this;
    }

    public virtual void Destroy()
    {

    }

}

