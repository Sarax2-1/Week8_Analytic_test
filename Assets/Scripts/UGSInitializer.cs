using Unity.Services.Core;
using UnityEngine;

public class UGSInitializer : MonoBehaviour
{
    public static bool IsReady = false;

    async void Awake()
    {
        await UnityServices.InitializeAsync();
        IsReady = true;
        Debug.Log("UGS READY");
    }
}
