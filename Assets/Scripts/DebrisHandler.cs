using System.Collections.Generic;
using UnityEngine;

public class DebrisHandler : MonoBehaviour
{
    [SerializeField]
    private Transform debrisToPickupPrefab;

    [SerializeField]
    private Transform origin;

    [SerializeField]
    private int maxDebrisCapacity;

    [SerializeField]
    private int xArea, yArea;

    public List<Transform> debrisList = new();

    void Awake()
    {
        int cache = maxDebrisCapacity;

        for (int i = 0; i < maxDebrisCapacity; i++)
        {
            if (cache > 0)
            {
                int a = Random.Range(-xArea / 2, xArea / 2);
                int b = Random.Range(-yArea / 2, yArea / 2);
                Transform debris = InstantiateDebris(a, b);
                debris.name = "fallen debris:" + i.ToString();  
                debrisList.Add(debris);
                cache--;
            }
            else
            {
                break;
            }
        }
    }

    Transform InstantiateDebris(int ver, int hor)
    {

        Transform debris = Instantiate(debrisToPickupPrefab, origin);
        debris.position = origin.position + new Vector3(ver, 0, hor);
        debris.rotation = Quaternion.Euler(0,Random.Range(-90, 90) , 0);
        return debris;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
