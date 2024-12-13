
using Sirenix.OdinInspector;
using UnityEngine;

namespace Squizyton.Cutscene
{
    public class CS_MoveToPosition : CutsceneAction
    {

        [VerticalGroup("Special Parameters")] public Transform target;
        [VerticalGroup("Special Parameters")] public Transform positionToGoTo;
        [VerticalGroup("Special Parameters")] public float speedToTarget = 5f;
        [VerticalGroup("Special Parameters")] public float distanceToTarget = 1f;



        public CS_MoveToPosition()
        {
            name = "Move Object To Position";
            description = "Move's an Object to a position specified in `positionToGoTo`";
        }


        public override void OnStart()
        {

        }

        public override Status Executing()
        {
            float distance = (target.position - positionToGoTo.position).sqrMagnitude;

            if (!(distance > distanceToTarget)) return Status.Finished;



            target.position = Vector3.Lerp(target.position, positionToGoTo.position, Time.deltaTime * speedToTarget);

            return Status.Running;
        }

        public override void OnEnd()
        {
            //End 
        }
    }

}