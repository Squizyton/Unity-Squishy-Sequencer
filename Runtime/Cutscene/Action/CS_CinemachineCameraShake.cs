using Sirenix.OdinInspector;
using Unity.Cinemachine;
using UnityEngine;

namespace Squizyton.Cutscene
{
    public class CS_CinemachineCameraShake : CutsceneAction
    {
        [VerticalGroup("Special Parameters"),OnValueChanged("CheckForMultiChannelPerlin")] 
        public CinemachineCamera camera;
        private CinemachineBasicMultiChannelPerlin _perlin;
        public float amplitude;
        public float frequency;
        private float _duration = 0f;
        private  float _currentAmplitude = 0f;
        private  float _actualTimer = 0f;
        
        
        public CS_CinemachineCameraShake()
        {
            name = "Camera Shake";
            description = "Shakes a camera";
        }


        public void CheckForMultiChannelPerlin()
        {
            if (!camera.GetComponent<CinemachineBasicMultiChannelPerlin>())
            {
                Debug.LogError("The camera doesn't have CinemachineBasicMultiChannelPerlin component.");
            }
        }

        public override void OnStart()
        {
            _perlin = camera.GetComponent<CinemachineBasicMultiChannelPerlin>();
            
            _currentAmplitude = amplitude;
            _perlin.FrequencyGain = frequency;
            _actualTimer = amplitude / _duration;
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
