using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarnPoints : MonoBehaviour
{
    [SerializeField] public int pointsAssigned;


    // Update is called once per frame
    void PointsEarned()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameManager.s_instance.AddScore(pointsAssigned); ;
            Debug.Log("points granted" + pointsAssigned);
        }

    }

}
