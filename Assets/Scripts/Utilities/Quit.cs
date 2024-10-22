using UnityEngine;

public class Quit : MonoBehaviour
{
    
    public void QuitButton()
    {
        Application.Quit();
    }

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}
