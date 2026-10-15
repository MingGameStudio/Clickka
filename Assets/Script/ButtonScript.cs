using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] MoneyManager moneyManager;
    public int moneyPerClick = 1;
    public float moneyPerClickMultiplier = 1;
    public void OnButtonClick()
    {
        if (moneyManager == null)
        {
            Debug.Log("WHERE THE FUCK DID YOU PUT THE " +
            "MONEY MANAGER? ARE YOU FUCKING STUPID");
        }
        else
        {
            Debug.Log("Cligger");
            moneyManager.IncreaseMoney(moneyPerClick * moneyPerClickMultiplier);
            // this, ok i don't need a fucking explanation on this
        }
    }
}
