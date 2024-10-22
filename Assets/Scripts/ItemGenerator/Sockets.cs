using UnityEngine;

public class Sockets : MonoBehaviour
{
    [SerializeField]
    private Transform innerSocket;
    [SerializeField]
    private Transform outerSocket;

    public Transform GetInnerSocket {  get { return innerSocket; } }
    public Transform GetOuterSocket { get {return outerSocket; } }
}
