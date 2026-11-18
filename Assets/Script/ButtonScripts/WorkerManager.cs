using UnityEngine;
using TMPro;
using System.Collections;
public class WorkerManager : MonoBehaviour
{
    // ok, so this worker basically just uses the same clicking 
    // as the player except its automated
    [Header("References")]
    [SerializeField] MoneyManager moneyManager;
    [SerializeField] ButtonScript button;
    [SerializeField] TextMeshProUGUI WorkerCostText;
    [SerializeField] TextMeshProUGUI WorkerLevelText;
    

    [Header("Worker Details")]
    [SerializeField] float WorkerCost;
    [SerializeField] float WorkerCostMultiplier = 1.5f;
    [SerializeField] float WorkerIncome = 1f;
    [SerializeField] float WorkerSpeed = 1f;
    private float workerLevel = 0;
    private float maxWorkerLevel = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        WorkerCostText.text = "$ " + WorkerCost;
        WorkerLevelText.text = "Workers: " + workerLevel;

        StartCoroutine(WorkerCoroutine());
    }

    public void BuyWorker()
    {
        if (workerLevel >= maxWorkerLevel)
        {
            Debug.Log("No more workers will work for you you lazy bum");
            return;
        }
        if (moneyManager.money >= WorkerCost)
        {
            workerLevel++;
            moneyManager.money -= WorkerCost;
            WorkerCost *= Mathf.Round(WorkerCostMultiplier * 100)/100;
            WorkerCostText.text = "$ " + WorkerCost;
            WorkerLevelText.text = "Workers: " + workerLevel;
        }
    }

    IEnumerator WorkerCoroutine()
    {
        while (true)
        {
            for (int i = 0; i < workerLevel; i++)
            {
                button.OnButtonClick();
            }
            yield return new WaitForSeconds(WorkerSpeed);
            // StartCoroutine(WorkerCoroutine()); // This line is unnecessary and causes multiple coroutines to start
        }
    }
    
}
