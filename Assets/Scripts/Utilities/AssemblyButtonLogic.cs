using UnityEngine;
using UnityEngine.UI;

public class AssemblyButtonLogic : MonoBehaviour
{
    [SerializeField]
    private Button button;
    [SerializeField]
    private Text text;

    public void Deactivate()
    {  
        button.enabled = false;
    }

    public void Reactivate(int i)
    {
        button.enabled = true;
        text.text = "Assembly Item";
    }
}

