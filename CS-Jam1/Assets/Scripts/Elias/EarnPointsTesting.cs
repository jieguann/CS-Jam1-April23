using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarnPointsTesting : MonoBehaviour
{
    [SerializeField] public int pointsAssigned;

    public ParticleSystem m_explosionParticle;

    Ray ray;
    RaycastHit hit;

    // Update is called once per frame
   

    public void OnClick()
    {
        GameManager.s_instance.AddScore(pointsAssigned);
        Instantiate(m_explosionParticle, transform.position, m_explosionParticle.transform.rotation);
        Destroy(gameObject);
        //Debug.Log("points granted" + pointsAssigned);
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


