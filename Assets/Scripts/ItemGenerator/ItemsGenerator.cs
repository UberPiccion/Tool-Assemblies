using UnityEngine;

public class ItemsGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject[] itemsToGenerate;
    [SerializeField]
    private GameObject itemParent;
    public void GenerateItem(int index)
    {
        if (itemParent.transform.childCount > 0)
        {
            Destroy(itemParent.transform.GetChild(0).gameObject);
        }
        if(index == 0) {return;}
        Instantiate(itemsToGenerate[index-1],itemParent.transform);
    }
}
