using UnityEngine;
using TMPro;
using System.Runtime.InteropServices;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text Identity;
    [DllImport("__Internal")]
    public static extern void LoginWithGoogle();

    void Start()
    {
        GameManager.OnDbConnected += HandleLoginSuccess;
    }

    void OnDestroy()
    {
        GameManager.OnDbConnected -= HandleLoginSuccess;
    }

    void HandleLoginSuccess(string identity)
    {
        Identity.text = identity;
    }
}
