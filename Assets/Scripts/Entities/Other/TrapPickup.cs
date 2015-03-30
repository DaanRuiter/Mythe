using UnityEngine;
using System.Collections;

public class TrapPickup : MonoBehaviour 
{
	private bool _hasBeenHit;

	private float _bombRadius;

	private Vector2 _origin; 

	[SerializeField]
	private Collider2D[] _explodables;

	[SerializeField]
	private LayerMask _interactableLayer;

	[SerializeField]
	private ParticleSystem _explosionEffect;
	[SerializeField]
	private Material[] _exlosionMaterials;

	void Start () 
	{
		_hasBeenHit = false;
		
		_origin = new Vector2(transform.position.x, transform.position.y);
		_bombRadius = 10;
	}
	
	public void Explode () 
	{
		_explodables = Physics2D.OverlapCircleAll(_origin, _bombRadius, _interactableLayer);

		foreach (Collider2D cols in _explodables) 
		{
			Destroy(cols.gameObject);
		}
		_explosionEffect.Play();
        GetComponent<SpriteRenderer>().enabled = false;

		Destroy(this.gameObject, 1);
	}
	void Update()
	{
		if(_hasBeenHit)
		{
			Explode();
		}
	}
}
