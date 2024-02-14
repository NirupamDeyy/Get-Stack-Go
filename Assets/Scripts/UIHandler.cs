using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text collectedDebris, onTruck;
    [SerializeField] private TMP_Text TIME,TDS, NC, MT, MD;// ignore
    [SerializeField]
    private Transform finalPanel;
    [SerializeField] private Button startButton;
    public MovementHandler movementHandler;

    private void Start()
    {
        startButton.onClick.AddListener(() => { movementHandler.Move(); });
    }
    public void UpdateCollectedUI(int cDebris, int maxDebris)
    {
        collectedDebris.text = "COLLECTED DEBRIS: " + cDebris + "/" + maxDebris;
    }

    public void UpdateOnTruckUI(int pickedDebris, int maxCapacity)
    {
        onTruck.text = "LOAD ON TRUCK: " + pickedDebris + "/" + maxCapacity;
    }

    public void UpdateMainText(float time,float distTraveled, int numCycles, int maxTruckCapacity, int maxDebris)
    {
        finalPanel.gameObject.SetActive(true);
        TIME.text = time.ToString("0.0") + "secs";
        TDS.text = distTraveled.ToString("0.0") + "units";
        NC.text = numCycles.ToString();
        MT.text = maxTruckCapacity.ToString();
        MD.text = maxDebris.ToString();
    }
}
