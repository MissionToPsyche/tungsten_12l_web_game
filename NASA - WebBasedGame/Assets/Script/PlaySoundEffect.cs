using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaySoundEffect : MonoBehaviour { 

    public AudioSource soundEffect;   // Create AudioSource object
    public Slider volumeSlider;     // Create Slider object

    // Play audio file method
    public void playSound() { 

       soundEffect.Play();
    }

    // Set volume at 100% at the begining method
    public void Start() {
        if (volumeSlider)
        {
            volumeSlider.value = 1;
        }
    }

    // Update the volume while sliding the volume bar method
    public void changeVolume() {

        AudioListener.volume = volumeSlider.value;
    }
}
