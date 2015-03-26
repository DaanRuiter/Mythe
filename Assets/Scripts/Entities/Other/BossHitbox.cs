using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class BossHitbox : MonoBehaviour {

    private BossManager _manager;

	private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.transform.tag == "Harpoon")
        {
            if(collider.GetComponent<HarpoonController>().GetDirection() == MovementDirection.Down)
            {
                _manager.TakeHit(this);
                collider.GetComponent<HarpoonController>().SwitchDirection();
            }
        }
    }

    public void SetBossManager(BossManager manager)
    {
        _manager = manager; 
    }
}
