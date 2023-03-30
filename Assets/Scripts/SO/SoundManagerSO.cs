using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SoundManager", fileName = "New Sound Manager")]
public class SoundManagerSO : ScriptableObject
{
    [SerializeField] [Range(0f,1f)] private float voiceVolume = 0.7f;
    [SerializeField] [Range(0f, 1f)] private float effectsVolume = 0.7f;
    [SerializeField] private AudioClip tenMovesLeft;
    [SerializeField] private AudioClip twentySecondsLeft;
    [SerializeField] private AudioClip takeThatOffer;
    [SerializeField] private AudioClip tryHarder;
    [SerializeField] private AudioClip puzzleStart;
    [SerializeField] private AudioClip youCanMakeit;
    [SerializeField] private AudioClip outOfMoves;
    [SerializeField] private AudioClip timeEnded;
    [SerializeField] private AudioClip squareMove;
    [SerializeField] private AudioClip ledZap;
    [SerializeField] private AudioClip fireworks;
    [SerializeField] private AudioClip youHaveMyRespect;
    [SerializeField] private AudioClip areYouFriendWithElon;
    [SerializeField] private AudioClip didYouCreateBitcoin;
    [SerializeField] private AudioClip ironMan;

    private float loudSounds;

    public AudioClip IronMan()
    {
        return ironMan;
    }
    public AudioClip DidYouCreate()
    {
        return didYouCreateBitcoin;
    }
    public AudioClip AreYouFriend()
    {
        return areYouFriendWithElon;
    }
    public AudioClip YouhaveMyRespect()
    {
        return youHaveMyRespect;
    }
    public AudioClip GetFireworkSound()
    {
        return fireworks;
    }
    public float GetEffectsVolume()
    {
        return effectsVolume;
    }
    public AudioClip LedZap()
    {
        return ledZap;
    }
    public AudioClip SquareMoveSound()
    {
        return squareMove;
    }
    public AudioClip GetTenMoves()
    {
        return tenMovesLeft;
    }
    public AudioClip GetTwentySeconds()
    {
        return twentySecondsLeft;
    }
    public AudioClip GetTakeThatOffer()
    {
        return takeThatOffer;
    }
    public AudioClip GetTryHarder()
    {
        return tryHarder;
    }
    public AudioClip GetPuzzleStart()
    {
        return puzzleStart;
    }
    public AudioClip GetYouCanMakeIt()
    {
        return youCanMakeit;
    }
    public AudioClip GetTimeEnded()
    {
        return timeEnded;
    }
    public AudioClip GetOutOfMoves()
    {
        return outOfMoves;
    }
    public float GetVoiceVolume()
    {
        return voiceVolume;
    }
    public void SetVoiceVolume(float voiceVol)
    {
        voiceVolume = voiceVol;
    }
    public void SetEffectsVolume(float effectVol)
    {
        effectsVolume = effectVol;
    }
    public float GetLoudSoundsVolume()
    {
        loudSounds = effectsVolume / 2f;
        return loudSounds;
    }

}
