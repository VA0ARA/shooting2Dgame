using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private Vector3 temScale;
    private int curentAnimation;
    private void Awake()
    {
        anim = GetComponent<Animator>();

    }

    public void PlayAnimation(string animationName)
    {
        if (curentAnimation == Animator.StringToHash(animationName))
            return;

        anim.Play(animationName);

        curentAnimation = Animator.StringToHash(animationName);
    }
    public void SetFacingDirection(bool faceRight)
    {
        temScale = transform.localScale;
        if (faceRight)
            temScale.x = 1f;
        else
            temScale.x = -1f;
        transform.localScale = temScale;

    }
  

}
