using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constant
{
    public const string MAIN_SCENE_NAME = "SampleScene";
    public const float PLAYER_LOOK_DISTANCE_THRESHOLD = 0.9f;

    public const string PLAYER_TAG = "Player";
    public const string BACKGROUND_TAG = "Background";
    public static class MiniGames
    {
        public static class FlappyBird
        {
            public const string SCENE_NAME = "FlappyStyleMiniGame";
            public const string HIGH_SCORE_KEY = "FlappyBirdHighScore";
            public const float SUCCESS_SCORE = 30f;
        }
    }
}
