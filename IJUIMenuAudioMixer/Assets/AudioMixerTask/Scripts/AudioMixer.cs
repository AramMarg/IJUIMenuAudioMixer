using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioMixer : MonoBehaviour
{
    private const string MasterVolume = "MasterVolume";

    [SerializeField] private AudioMixerGroup _audioMixerGroup;
    [SerializeField] private Toggle _toggleOnOff;

    private float _muteSound = -80;
    private float _normalSound = 0;

    private void OnEnable()
    {
        _toggleOnOff.onValueChanged.AddListener(OnToggleOnOff);
    }

    private void OnDisable()
    {
        _toggleOnOff.onValueChanged.RemoveListener(OnToggleOnOff);
    }
    
    private void OnToggleOnOff(bool isOnSound)
    {
        if (isOnSound)
        {
            _audioMixerGroup.audioMixer.SetFloat(MasterVolume, _normalSound);
        }
        else
        {
            _audioMixerGroup.audioMixer.SetFloat(MasterVolume, _muteSound);

        }
    }
}
