using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioMixer : MonoBehaviour
{
    private const string MasterVolume = "MasterVolume";
    private const string BackgroundVolume = "BackgroundVolume";

    [SerializeField] private AudioMixerGroup _audioMixerGroup;
    [SerializeField] private Toggle _toggleOnOff;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Slider _slider;

    private float _currentVolume;

    private float _muteSound = -80;
    private float _normalSound = 0;

    private void Awake()
    {
        _currentVolume = _audioSource.volume;

        _slider.value = _currentVolume;

        _audioMixerGroup.audioMixer.SetFloat(BackgroundVolume,
            Mathf.Log10(_currentVolume) * 20);
    }

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
