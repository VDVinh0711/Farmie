
using UnityEngine;

public class AnimationAnimal : MonoBehaviour
{
    [SerializeField] private Animator animatorAnimal;
    public void OnAnimationMove(Vector2 direction)
    {
        animatorAnimal.Play("Run");
        animatorAnimal.SetFloat("horizontal",direction.x);
        animatorAnimal.SetFloat("vertical",direction.y);
    }
    public void OnAnimationIdle()
    {
        animatorAnimal.Play("Idle");
    }
}
