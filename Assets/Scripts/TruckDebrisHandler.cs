using System.Collections.Generic;
using UnityEngine;

public class TruckDebrisHandler : MonoBehaviour
{
    [SerializeField]
    private Transform debrisPrefab;

    [SerializeField]
    private Transform debrisParent;

    [SerializeField]
    private int maxHorizontalCapacity = 6, maxDebrisCapacity;

    [SerializeField]
    private List<Transform> debrisList = new();

    public MovementHandler mh;
    void Start()
    {
        int cache = maxDebrisCapacity;
        int maxVerticalCapacity = maxDebrisCapacity / maxHorizontalCapacity;
        for(int i = 0; i <= maxVerticalCapacity; i++)// vert
        {
            for (int j = 0; j < maxHorizontalCapacity; j++)//hor
            {
                if (cache > 0)
                {
                    Transform debris = InstantiateDebris(i, j);
                    debrisList.Add(debris);
                    //debris.gameObject.SetActive(false);
                    cache--;
                }
                else
                {
                    break;
                }
                
            }
        }
        

    }

    Transform InstantiateDebris( int ver, int hor)
    {
        Transform debris = Instantiate(debrisPrefab, debrisParent);
        debris.position = debrisParent.position + new Vector3(0, 0.22f * ver, 0.24f * - hor);
        return debris;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
