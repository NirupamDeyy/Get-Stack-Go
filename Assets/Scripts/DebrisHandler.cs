using UnityEngine;

public class DebrisHandler : MonoBehaviour
{
    [SerializeField] 
    private Transform debrisPrefab;

    [SerializeField]
    private Transform debrisParent;

    [SerializeField]
    private int maxDebrisCapacity, currentDebrisCount = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
