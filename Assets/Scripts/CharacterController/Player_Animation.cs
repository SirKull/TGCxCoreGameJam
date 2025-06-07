using UnityEngine;
using Animancer;

public class Player_Animation : MonoBehaviour
{
    private Player_Move playerMove;

    [SerializeField] private AnimancerComponent animancer;

    [SerializeField] private AnimationClip idle;
    [SerializeField] private AnimationClip running;
    [SerializeField] private ClipTransition jump;
    [SerializeField] private ClipTransition land;
    [SerializeField] private AnimationClip midAir;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(playerMove != null)
        {
            playerMove = GetComponentInParent<Player_Move>();

            playerMove.jumpEvent.AddListener(Jump);
            playerMove.landEvent.AddListener(Land);
        }

        jump.Events.OnEnd = MidAir;
        land.Events.OnEnd = OnLand;
    }

    private void Update()
    {
        if(playerMove != null)
        {
            Move();
        }
    }

    public void Move()
    {
        if (playerMove.isMoving)
        {
            animancer.Layers[1].Play(running);
        }
        else
        {
            animancer.Layers[1].Play(idle);
        }
    }
    public void Jump()
    {
        animancer.Layers[2].Play(jump, 0.25f);
    }
    public void MidAir()
    {
        animancer.Layers[2].Play(midAir);
    }

    public void Land()
    {
        animancer.Layers[2].Play(land, 0.1f);
    }

    public void OnLand()
    {
        animancer.Layers[2].Stop();
    }
}
