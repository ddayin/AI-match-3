using System;
using System.Collections;
using System.Globalization;

using UnityEngine;
using UnityEngine.Assertions;

using GameVanilla.Core;
using GameVanilla.Game.Popups;

namespace MatchCollect
{
    /// <summary>
    /// This class contains the logic associated to the home scene.
    /// </summary>
    public class IntroScene : BaseScene
    {
        [SerializeField]
        private AnimatedButton soundButton;

        [SerializeField]
        private AnimatedButton musicButton;

        private readonly string dateLastPlayedKey = "date_last_played";
        
        /// <summary>
        /// Unity's Awake method.
        /// </summary>
        private void Awake()
        {
            Application.targetFrameRate = 60;
            
            Assert.IsNotNull(soundButton);
            Assert.IsNotNull(musicButton);
        }

        /// <summary>
        /// Unity's Start method.
        /// </summary>
        private void Start()
        {
            UpdateButtons();
        }

        /// <summary>
        /// Called when the settings button is pressed.
        /// </summary>
        public void OnSettingsButtonPressed()
        {
            OpenPopup<SettingsPopup>("Popups/SettingsPopup");
        }

        /// <summary>
        /// Called when the sound button is pressed.
        /// </summary>
        public void OnSoundButtonPressed()
        {
            SoundManager.instance.ToggleSound();
        }

        /// <summary>
        /// Called when the music button is pressed.
        /// </summary>
        public void OnMusicButtonPressed()
        {
            SoundManager.instance.ToggleMusic();
        }

        /// <summary>
        /// Updates the state of the UI buttons according to the values stored in PlayerPrefs.
        /// </summary>
        public void UpdateButtons()
        {
            var sound = PlayerPrefs.GetInt("sound_enabled");
            soundButton.transform.GetChild(0).GetComponent<SpriteSwapper>().SetEnabled(sound == 1);
            var music = PlayerPrefs.GetInt("music_enabled");
            musicButton.transform.GetChild(0).GetComponent<SpriteSwapper>().SetEnabled(music == 1);
        }
    }
}
