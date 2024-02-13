using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovementHandler : MonoBehaviour
{
    public DebrisHandler debrisHandler;
    public float velocity = 10f;
    int currentDebris;
    void Start()
    {

    }

    public void Move()
    {
        (Transform closestDebris, int closestIndex) = GetClosestDebris.DebrisTranform(debrisHandler.debrisList, transform);
       
        transform.LookAt(closestDebris);
        float dist = (transform.position - closestDebris.position).magnitude;
        transform.DOMove(closestDebris.position, dist/velocity).OnComplete(() =>
        {
            debrisHandler.debrisList.RemoveAt(closestIndex);
            closestDebris.gameObject.SetActive(false);
            if (x < debrisHandler.debrisList.Count)
                Move();
        });
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("hey" + collision);
        if (collision.collider.CompareTag("Debris"))
        {
            Debug.Log("hey");
         
        }
    }

    int x = 0;
  
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Move();
        }
    }
}
