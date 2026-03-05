using UnityEngine;
using UnityEngine.EventSystems;
using Unity.Services.Analytics;
using Unity.Services.Core;
using System.Collections.Generic;

public class ShopItemTracker : MonoBehaviour,
    IPointerEnterHandler,
    IPointerExitHandler
{
    [SerializeField] string itemCode;
    [SerializeField] int price;

    float hoverStart;
    bool wasClicked;

    public void OnPointerEnter(PointerEventData eventData)
    {
        hoverStart = Time.time;
        wasClicked = false;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!wasClicked)
        {
            float duration = Time.time - hoverStart;
            SendEvent("abandoned", duration);
        }
    }

    public void OnClickBuy()
    {
        wasClicked = true;
        float duration = Time.time - hoverStart;
        SendEvent("purchased", duration);
        Debug.Log("Clicked");
    }

    void SendEvent(string result, float duration)
    {
        if (!UGSInitializer.IsReady)
        {
            Debug.LogError("UGS NOT READY YET");
            return;
        }

        var e = new IapInterestEvent();

        e.item_code = itemCode;
        e.interaction_result = result;
        e.hover_duration_sec = duration;
        e.price_coin = price;

        AnalyticsService.Instance.RecordEvent(e);
        AnalyticsService.Instance.Flush();

        Debug.Log("EVENT SENT");
    }
}