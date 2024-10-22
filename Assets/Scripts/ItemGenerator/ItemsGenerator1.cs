using Unity.VisualScripting;
using UnityEngine;

public class ItemsGenerator2 : MonoBehaviour
{
    [SerializeField]
    private Sockets[] itemsToGenerate;
    [SerializeField]
    private Transform itemParent;
    [SerializeField]
    private int numberOfSockets;
    private Sockets[] sockets;

    public void Start()
    {
        sockets = new Sockets[numberOfSockets];
    }
    private void DestroyAllChildren(Transform item)
    {
        if (item.childCount > 0)
        {
            for (int i = 0; i < itemParent.childCount; i++)
            {
                Destroy(item.GetChild(i).gameObject);
            }
        }
        return;
    }
    public void GenerateFirstItem(int index)
    {
        if (index == 0)
        {
            DestroyAllChildren(itemParent);
            return;
        }

        if (sockets[0] == null)
        {
            sockets[0] = Instantiate(itemsToGenerate[index - 1], itemParent.transform);
            return;
        }
        if (sockets[1] != null) {
            sockets[1].transform.SetParent(null);
            DestroyAllChildren(itemParent);
            sockets[0] = Instantiate(itemsToGenerate[index - 1], itemParent.transform);
            sockets[1].transform.SetParent(sockets[0].GetOuterSocket);
            return;
        }
        DestroyAllChildren(itemParent);
        sockets[0] = Instantiate(itemsToGenerate[index - 1], itemParent.transform);
    }
    public void GenerateSecondItem(int index)
    {
        if (index == 0)
        {
            DestroyAllChildren(sockets[1].transform);
            return;
        }

        if (sockets[1] == null)
        {
            sockets[1] = Instantiate(itemsToGenerate[index - 1], sockets[0].GetOuterSocket);
            return;
        }
        if (sockets[2] != null)
        {
            sockets[2].transform.SetParent(null);
            DestroyAllChildren(sockets[0].transform);
            sockets[1] = Instantiate(itemsToGenerate[index - 1], sockets[0].GetOuterSocket);
            sockets[2].transform.SetParent(sockets[1].GetOuterSocket);
            return;
        }
        DestroyAllChildren(sockets[0].transform);
        sockets[1] = Instantiate(itemsToGenerate[index - 1], sockets[0].GetOuterSocket);
    }
    public void GenerateThirdItem(int index) {
        if (index == 0)
        {
            DestroyAllChildren(sockets[2].transform);
            return;
        }

        if (sockets[2] == null)
        {
            sockets[2] = Instantiate(itemsToGenerate[index - 1], sockets[1].GetOuterSocket);
            return;
        }
        DestroyAllChildren(sockets[1].transform);
        sockets[2] = Instantiate(itemsToGenerate[index - 1], sockets[1].GetOuterSocket);
    }

}
