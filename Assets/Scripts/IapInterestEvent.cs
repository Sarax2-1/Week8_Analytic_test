using Unity.Services.Analytics;

public class IapInterestEvent : Event
{
    public IapInterestEvent() : base("iap_interest")
    {
    }

    public string item_code { set { SetParameter("item_code", value); } }
    public string interaction_result { set { SetParameter("interaction_result", value); } }
    public float hover_duration_sec { set { SetParameter("hover_duration_sec", value); } }
    public int price_coin { set { SetParameter("price_coin", value); } }
}