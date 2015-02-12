using UnityEngine;
using System.Collections;

public class Playzone : MonoBehaviour {

	private void OnTriggerExit2D(Collider2D coll)
    {
        if(coll.GetComponent<HarpoonController>())
        {
            coll.GetComponent<HarpoonController>().SwitchDirection();
        }
    }
}
