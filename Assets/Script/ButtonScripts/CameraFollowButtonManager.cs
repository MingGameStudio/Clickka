using UnityEngine;
using TMPro;
public class CameraFollowButtonScript : MonoBehaviour
{
    [Header("References")]
    [SerializeField] ButtonScript button;
    [SerializeField] MoneyManager moneyManager;
    [SerializeField] CameraController camera;
    [SerializeField] TextMeshProUGUI CameraFollowCostText;
    [SerializeField] TextMeshProUGUI HasUnlockedCameraFollowText;
    // the UI text element that displays the current level of the income amplifier.

    [Header("Amplifier Settings")]
    [SerializeField] float Cost;

    void Start()
    {
        CameraFollowCostText.text = "Cost: $" + Cost;
        HasUnlockedCameraFollowText.text = "Not Purchased";
    }

    public void BuyCameraFollow()
    {
        if (HasUnlockedCameraFollowText.text == "Purchased")
        {
            Debug.Log("You cannot upgrade any further");
            return;
        } 
        else if (moneyManager.money >= Cost)
        {
            moneyManager.IncreaseMoney(-Cost);
            camera.playerCanFollow = true;
            HasUnlockedCameraFollowText.text = "Purchased";
        }
        else
        {
            Debug.Log("Bro can't even afford a basic feature");
            return;
        }
        
    }
}
