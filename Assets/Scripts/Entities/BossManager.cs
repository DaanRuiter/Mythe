using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BossManager : MonoBehaviour {

    public GameObject mobyDick;
    public List<BossHitbox> hitBoxes;

    private MobyDick _mobyDickBehaviour;

    private void Start()
    {
        _mobyDickBehaviour = mobyDick.GetComponent<MobyDick>();

        for (int i = 0; i < hitBoxes.Count; i++)
        {
            hitBoxes[i].SetBossManager(this);
        }
    }

    public void TakeHit(BossHitbox hitBox)
    {
        hitBoxes.Remove(hitBox);
        Destroy(hitBox.gameObject);
        if (hitBoxes.Count <= 0)
        {
            //player wins
        }
    }

    private int HitPoints
    {
        get
        {
            return hitBoxes.Count;
        }
    }
}
