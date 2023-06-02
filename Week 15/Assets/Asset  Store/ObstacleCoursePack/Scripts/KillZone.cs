using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillZone : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            var healthComponent = col.gameObject.GetComponent<Health>();
            if(healthComponent!= null)
            {
                Vector3 fallCoordinates = col.gameObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position);
                healthComponent.TakeDamage(1,fallCoordinates);
            }
            col.gameObject.GetComponent<Timer>().RestartTimer();
			col.gameObject.GetComponent<CharacterControls>().LoadCheckPoint();

            GameObject wood = GameObject.FindWithTag("Wood");
            wood.SetActive(true);
            
        }
	}
}
