
using Sirenix.OdinInspector;
using UnityEngine;


namespace Squizyton.Cutscene
{


    /// <summary>
    /// Plays animation via anim.CrossFade in the provided animator. Will only return Finished when animation is done playing based on ANIMATION TIME
    /// </summary>
    public class CS_PlayAnimation : CutsceneAction
    {
        [VerticalGroup("Special Parameters")] public Animator animator;
        [VerticalGroup("Special Parameters")] public string animationName;
        [VerticalGroup("Special Parameters")] public float normalizedTime;
        [VerticalGroup("Special Parameters")] public int layerInAnimator;


        private float _totalAnimationTime;

        public CS_PlayAnimation()
        {
            name = "Play Animation";
            description =
                "Plays animation via anim.CrossFade in the provided animator. Will only return Finished when animation is done playing based on ANIMATION TIME";
        }

        public override void OnStart()
        {
            animator.CrossFade(animationName, normalizedTime, layerInAnimator);
            _totalAnimationTime = animator.GetCurrentAnimatorStateInfo(0).length;

        }

        public override Status Executing()
        {
            if (_totalAnimationTime > 0)
            {
                _totalAnimationTime -= Time.deltaTime;
                return Status.Running;
            }


            return Status.Finished;
        }

        public override void OnEnd()
        {
        }
    }
}