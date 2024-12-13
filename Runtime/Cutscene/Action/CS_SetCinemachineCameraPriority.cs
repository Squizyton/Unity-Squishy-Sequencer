using Sirenix.OdinInspector;
using Unity.Cinemachine;
using UnityEngine;

namespace Squizyton.Cutscene
{
    public class CS_SetCinemachineCameraPriority : CutsceneAction
    {
        [VerticalGroup("Special Parameters")]
        [InfoBox("Line 48 will need to be changed based on project needs.")]
        public bool fromCameraIsPlayerCamera;
        [VerticalGroup("Special Parameters")]
        [ShowIf("@!fromCameraIsPlayerCamera")] 
        public CinemachineCamera FromCamera;
        [VerticalGroup("Special Parameters")]
        [InfoBox("Line 55 will need to be changed based on project needs.")]
        public bool toCameraIsPlayerCamera;
        [VerticalGroup("Special Parameters")]
        public CinemachineCamera toCamera;
        [VerticalGroup("Special Parameters")]
        public int CameraPriority;
        [VerticalGroup("Special Parameters")]
        public bool ChangeBlend;
        [VerticalGroup("Special Parameters")]
        [ShowIf("@ChangeBlend"),Title("Blend Settings")] public CinemachineBlendDefinition.Styles Blend;
        [VerticalGroup("Special Parameters")]
        [ShowIf("@ChangeBlend && Blend != CinemachineBlendDefinition.Styles.Cut")]
        public int blendTime;


        private float blendTimer;

        private CinemachineBlendDefinition customBlend;

        public CS_SetCinemachineCameraPriority()
        {
            name = "Camera Transition";
            description = "Transitions a Camera Priority from one Camera to Other. Can incorporate Custom Blending";
        }

        public override void OnStart()
        {
         
            if(ChangeBlend)
            {
                if (fromCameraIsPlayerCamera)
                    //This will need to be changed based on project needs
                    //FromCamera = ;
                
                //This will need to also be changed on project needs
                if(toCameraIsPlayerCamera)
                   // toCamera = 
         
                
                toCamera.Priority = CameraPriority;
                FromCamera.Priority = 0;
                
                customBlend = new CinemachineBlendDefinition
                {
                    
                    Time = blendTime,
                    Style = Blend
                };
            }
            
            CinemachineCore.GetBlendOverride += OnBlendOverride;
        }
        
        private CinemachineBlendDefinition OnBlendOverride(ICinemachineCamera fromvcam, ICinemachineCamera tovcam, CinemachineBlendDefinition defaultblend, Object owner)
        {
            Debug.Log("This is doing a custom blend override");
            
            
                if (((CinemachineCamera)fromvcam == FromCamera && (CinemachineCamera)tovcam == toCamera))
                {
                    Debug.Log("Doing custom blend");
                    return customBlend;
                }
                return defaultblend;
        }
        
        public override Status Executing()
        {
            if (ChangeBlend && blendTimer < blendTime)
            {
                blendTimer += Time.deltaTime;
                return Status.Running;
            }
            return Status.Finished;
        }

        public override void OnEnd()
        {
            CinemachineCore.GetBlendOverride -= OnBlendOverride;
        }

      
    }
}
