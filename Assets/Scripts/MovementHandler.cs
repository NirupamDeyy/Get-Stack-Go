using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;

public class MovementHandler : MonoBehaviour
{
    public DebrisHandler debrisHandler;
    public UIHandler uIHandler;
    TruckDebrisHandler truckDebrisHandler;
    public float velocity = 10f;
    public Transform dropLoadArea, dropPathTransform;

    List<Transform> dropPoint = new();
    public List<Transform> debrisToDropList = new();
    Vector3[] wayPointsPos = new Vector3[5] ;

    int onTruck = 0;
    int x = 0;

    Vector3 extraHeight = new Vector3(0, 0.4f, 0);
    void Start()
    {
        truckDebrisHandler = GetComponent<TruckDebrisHandler>();
        if (truckDebrisHandler == null)
            Debug.Log("bhai ruk");
        foreach(Transform t in dropLoadArea)
        {
            dropPoint.Add(t);
        }

        
    }

    public void Move()
    {
        (Transform closestDebris, int closestIndex) = GetClosestObject.DebrisTranform(debrisHandler.debrisList, transform);
       
        transform.LookAt(closestDebris);
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        float dist = (transform.position  - closestDebris.position).magnitude;
        transform.DOMove(closestDebris.position + extraHeight, dist/velocity).OnComplete(() =>
        {
            onTruck++;
            truckDebrisHandler.PickUp();
            debrisHandler.debrisList.RemoveAt(closestIndex);
            closestDebris.gameObject.SetActive(false);
            debrisToDropList.Add(closestDebris);
            if (x < debrisHandler.debrisList.Count && onTruck < truckDebrisHandler.maxDebrisCapacity)
            {
                Move();
            }
            else
            {
                MoveToDrop();
            }
                
        });
       // 
    }

    void MoveToDrop()
    {
        Transform nearestDrop = NearestDropPoint();
        transform.LookAt(nearestDrop);
        float dist = (transform.position - nearestDrop.position).magnitude;
        transform.DOMove(nearestDrop.position, dist / velocity).OnComplete(() => 
        {
            onTruck = 0;
            
            DropLoop();
        });
    }


    void DropLoop()
    {
        if (debrisToDropList.Count > 0)
        {
            truckDebrisHandler.Drop();
            DropAnimation(debrisToDropList[debrisToDropList.Count - 1]);         
            debrisToDropList.Remove(debrisToDropList[debrisToDropList.Count - 1]);
        }
        else
        {
            Move();
        }
    }

    void DropAnimation(Transform debris)
    {
        CorrectDirection();
        debris.position = wayPointsPos[0];
        debris.gameObject.SetActive(true);
        debris.DOLocalPath(wayPointsPos,1f, PathType.CatmullRom).SetOptions(false, AxisConstraint.None).SetEase(Ease.InSine).OnComplete(() => 
        {
            DropLoop();
        });
    }

    void CorrectDirection()
    {
        dropPathTransform.LookAt(transform);

        for (int i = 0; i < wayPointsPos.Length; i++)
        {
            wayPointsPos[i] = dropPathTransform.GetChild(i).position;
        }
        Debug.Log(dropPathTransform.rotation);
    }

    Transform NearestDropPoint()
    {
        (Transform closestDropPoint, int closestIndex) = GetClosestObject.DebrisTranform(dropPoint, transform);

        return closestDropPoint;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //truckDebrisHandler.PickUp();
            Move();
        }
    }
}
