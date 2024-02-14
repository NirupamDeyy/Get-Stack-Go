using System.Collections.Generic;
using UnityEngine;
using System;

public static class GetClosestObject
{
    public static int currentDebris = 0;

    public static Transform closestDebris;

    public static (Transform, int) DebrisTranform(List<Transform> fallenDebrisList, Transform truckPos)
    {
        List<float> distList = GetDistanceList(fallenDebrisList, truckPos);

        int closestIndex = GetClosestDebrisIndex(distList);

        return (fallenDebrisList[closestIndex], closestIndex); 
    }

    public static int GetClosestDebrisIndex(List<float> list)
    {
        if (list == null || list.Count == 0)
            throw new ArgumentException("List is empty");

        float minDistance = list[0];

        int index = 0;
        for (int i = 1; i < list.Count; i++)
        {
            if (list[i] < minDistance)
            {
                minDistance = list[i];
                index = i;
            }
        }

        return index;
    }

    static List<float> GetDistanceList(List<Transform> currentFallenDebrisList, Transform truckPos)
    {
        List<float> distancesList = new List<float>();

        foreach (Transform debris in currentFallenDebrisList)
        {
            float distance = Distance(truckPos, debris);
            distancesList.Add(distance);
        }

        return distancesList;
    }

    static float Distance(Transform truckPos, Transform debris)
    {
        float dist = (debris.position - truckPos.position).magnitude;
        return dist;
    }
}
