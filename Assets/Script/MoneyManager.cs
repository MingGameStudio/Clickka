using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    public float money;
    [SerializeField] TextMeshProUGUI moneyText;

    void Start()
    {
        money = 0;
        moneyText.text = "$ " + money;
    }
    public void IncreaseMoney(float amount)
    {
        money += amount;
        moneyText.text = "$ " + money;
    }
}
