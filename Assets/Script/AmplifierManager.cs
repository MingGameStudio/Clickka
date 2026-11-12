using UnityEngine;
using TMPro;

public class AmplifierManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] ButtonScript button;
    [SerializeField] MoneyManager moneyManager;
    [SerializeField] TextMeshProUGUI IncomeAmplifierCostText;
    // the UI text element that displays the current level of the income amplifier.
    [SerializeField] TextMeshProUGUI IncomeAmplifierLevelText;
    // the UI text element that displays the current cost of the income amplifier.

    [Header("Amplifier Settings")]
    [SerializeField] float AmplifierPrice;
    [SerializeField] float InitAmplifierPrice;
    [SerializeField] float CostMultiplier = 2f;
    [SerializeField] float IncomeAmplifierMultiplier = 1.1f;
    private float incomeAmplifierLevel = 1;
    private float maxIncomeAmplifierLevel = 10;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InitAmplifierPrice = AmplifierPrice;
        IncomeAmplifierCostText.text = "Cost: $" + AmplifierPrice;
        // the previous line sets the text of the AmplifierText UI element to display 
        // the price of the amplifier, prefixed with a dollar sign.

        // the amplified amount is calculated by multiplying the current income by the IncomeAmplifierMultiplier.
        IncomeAmplifierLevelText.text = "Level: " + incomeAmplifierLevel;
    }

    public void BuyIncomeAmplifier()
    {
        if (incomeAmplifierLevel >= maxIncomeAmplifierLevel)
        {
            Debug.Log("You have reached the maximum level for this amplifier.");
            return;
            
        }
        else if (moneyManager.money >= AmplifierPrice)
        {
            moneyManager.IncreaseMoney(-AmplifierPrice);
            // this line deducts the cost of the amplifier from the player's current money 
            // by calling the IncreaseMoney method with a negative value.
            AmplifierPrice = Mathf.Pow(CostMultiplier, incomeAmplifierLevel) * InitAmplifierPrice;
            // this line increases the price of the amplifier for the 
            // next purchase by multiplying the current price by the priceMultiplier.
            AmplifierPrice = Mathf.Round(AmplifierPrice * 100)/100;
            // this line rounds the new price to two decimal places.
            IncomeAmplifierCostText.text = "Cost: $" + AmplifierPrice;
            // this line updates the UI text to display the new cost of the amplifier.
            button.moneyPerClickMultiplier *= IncomeAmplifierMultiplier;
            incomeAmplifierLevel++;
            // this line updates the UI text to display the new level of the amplifier.
            IncomeAmplifierLevelText.text = "Level: " + incomeAmplifierLevel;
            // this line updates the UI text to display the new level of the amplifier.
        }
        else
        {
            Debug.Log("Fucking broke ass bitch, you can't afford this shit");
        }
    
    }
}
