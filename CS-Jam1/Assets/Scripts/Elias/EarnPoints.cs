using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarnPoints : MonoBehaviour
{
    [SerializeField] public int pointsAssigned;

    Ray ray;
    RaycastHit hit;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameManager.s_instance.AddScore(pointsAssigned); 
            Debug.Log("points granted" + pointsAssigned);
        }

    }

    /*void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "FireFly")
                print(hit.collider.name);

            GameManager.s_instance.AddScore(pointsAssigned);
            Debug.Log("points granted" + pointsAssigned);
        }
    }*/
}


