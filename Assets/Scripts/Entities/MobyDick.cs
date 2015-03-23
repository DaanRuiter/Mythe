using UnityEngine;
using System.Collections;

public class MobyDick : MonoBehaviour
{
    private float _blastTime;
    [SerializeField]
    private ParticleSystem _waterBlast;

    private Vector2 movement;
    private PlayerController _player;
    private AudioSource _sound;
    public AudioClip[] soundEffects;

    private float _x;
    private float _y;
    private float _timer;

    public bool despawning;
    public float blastWidth;
    private bool _negativeMovement;

    void Start()
    {
        _timer = Random.Range(4, 8);
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        _sound = GetComponent<AudioSource>();

        Invoke("Despawn", Random.Range(10, 15));

        _x = transform.position.x;
        _y = transform.position.y;

        _negativeMovement = false;
        despawning = false;
    }

    void FixedUpdate()
    {
        _timer -= Time.deltaTime;

        if (_timer <= 0)
        {
            WaterBlast();
        }
        if (_waterBlast.isPlaying == false && despawning == false)
        {
            SteeringBehaviour();
            _player.PushDown();
        }
        else
        {
            if(_waterBlast.isPlaying && !despawning)
            {
                if(IsPlayerAbove())
                {
                    _player.PushUp();
                }
            }
        }
        if (despawning == true)
        {
            Despawn();
        }
    }

    void SteeringBehaviour()
    {
        movement = new Vector2(_x, _y);

        float borderX = 20f;

        if (_x <= -borderX)
        {
            _negativeMovement = false;
        }
        else if (_x >= borderX)
        {
            _negativeMovement = true;
        }
        if (_negativeMovement)
        {
            _x -= 0.5f;
        }
        else if (!_negativeMovement)
        {
            _x += 0.5f;
        }

        transform.position = movement;
    }

    void WaterBlast()
    {
        _waterBlast.Play();
        IsPlayerAbove();
        _timer = Random.Range(4, 8);
        PlayRandomClip();
    }

    bool IsPlayerAbove()
    {
        if (_player.transform.position.x <= (_waterBlast.transform.position.x + blastWidth) && _player.transform.position.x >= (_waterBlast.transform.position.x - blastWidth))
        {
            return true;
        }
        return false;
    }

    public void Despawn()
    {
        movement = new Vector2(_x, _y);

        despawning = true;
        _waterBlast.Stop(true);

        _y -= 0.2f;

        if (_y <= -35)
        {
            Destroy(this.gameObject);
        }

        transform.position = movement;
    }

    private void PlayRandomClip()
    {
        int index = Random.Range(0, soundEffects.Length);
        _sound.clip = soundEffects[index];
        _sound.Play();
    }
}