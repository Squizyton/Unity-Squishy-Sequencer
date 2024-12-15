using Sirenix.OdinInspector;
using Unity.Cinemachine;
using UnityEngine;

namespace Squizyton.Cutscene
{
    public class CS_CinemachineCameraShake : CutsceneAction
    {
        [VerticalGroup("Special Parameters"),OnValueChanged("CheckForMultiChannelPerlin")] 
        public CinemachineCamera camera;
        [VerticalGroup("Special Parameters")]
        public float amplitude;
        [VerticalGroup("Special Parameters")]
        public float frequency;
        [VerticalGroup("Special Parameters")]
        public float shakeDuration = 0f;
        
        
        private CinemachineBasicMultiChannelPerlin _perlin;
        private  float _currentAmplitude = 0f;
        private  float _actualTimer = 0f;
        
        
        public CS_CinemachineCameraShake()
        {
            name = "Camera Shake";
            description = "Shakes a camera";
        }


        public void CheckForMultiChannelPerlin()
        {
            if (camera && !camera.GetComponent<CinemachineBasicMultiChannelPerlin>())
            {
                Debug.LogError("The camera doesn't have CinemachineBasicMultiChannelPerlin component.");
            }
        }

        public override void OnStart()
        {
            _perlin = camera.GetComponent<CinemachineBasicMultiChannelPerlin>();
            
            _currentAmplitude = amplitude;
            _perlin.FrequencyGain = frequency;
            _actualTimer = amplitude / shakeDuration;
        }

        public override Status Executing()
        {
            _perlin.AmplitudeGain = amplitude;

            if (_currentAmplitude > 0f)
            {
                _currentAmplitude -= _actualTimer * Time.deltaTime;
                return Status.Running;
            }
            else
            {
                _currentAmplitude = 0f;
                return Status.Finished;
            }
        }
        public override void OnEnd()
        {
        }
    }
}
