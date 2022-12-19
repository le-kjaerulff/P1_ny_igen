using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionsAudioPlayer : MonoBehaviour

{
    public AudioSource audioPlayer;      
    AudioClip[] prepositionQuestionSounds = new AudioClip[9];
    AudioClip[] nounQuestionSounds = new AudioClip[3];
    AudioClip[] positivitySounds = new AudioClip[3];
    AudioClip[] animalSounds = new AudioClip[3];

    public void PlayPrepositionQuestionAudio(int positionAsked)
    { 
        audioPlayer.PlayOneShot(prepositionQuestionSounds[positionAsked]);                
    }

    public void PlayNounQuestionAudio(int nounAsked)
    {
        audioPlayer.PlayOneShot(nounQuestionSounds[nounAsked]);
    }
    public void PlayAnswerFeedback(int pickedAnimal)
    {
        audioPlayer.clip = positivitySounds[(int)Random.Range(0, 2)];
        audioPlayer.PlayOneShot(animalSounds[pickedAnimal]);
        audioPlayer.PlayDelayed(animalSounds[pickedAnimal].length);
    }
    private void Awake()
    {
        nounQuestionSounds[0] = Resources.Load<AudioClip>("Audio/Mikkel/edits/VaelgKoen");
        nounQuestionSounds[1] = Resources.Load<AudioClip>("Audio/Mikkel/edits/VaelgGrisen");
        nounQuestionSounds[2] = Resources.Load<AudioClip>("Audio/Mikkel/edits/VaelgFaaret");

        prepositionQuestionSounds[0] = Resources.Load<AudioClip>("Audio/Mikkel/edits/ForanTraeet");
        prepositionQuestionSounds[1] = Resources.Load<AudioClip>("Audio/Mikkel/edits/VedSidenAfTraeet");
        prepositionQuestionSounds[2] = Resources.Load<AudioClip>("Audio/Mikkel/edits/IndenITraeet");
        prepositionQuestionSounds[3] = Resources.Load<AudioClip>("Audio/Mikkel/edits/BagVedTraeet");
        prepositionQuestionSounds[4] = Resources.Load<AudioClip>("Audio/Mikkel/edits/ForanLaden");
        prepositionQuestionSounds[5] = Resources.Load<AudioClip>("Audio/Mikkel/edits/OvenpåLaden");
        prepositionQuestionSounds[6] = Resources.Load<AudioClip>("Audio/Mikkel/edits/IndenILaden");
        prepositionQuestionSounds[7] = Resources.Load<AudioClip>("Audio/BagvedLaden");

        positivitySounds[0] = Resources.Load<AudioClip>("Audio/Mikkel/edits/DuKlarerDetFlot");
        positivitySounds[1] = Resources.Load<AudioClip>("Audio/Mikkel/edits/GodtGaaet");
        positivitySounds[2] = Resources.Load<AudioClip>("Audio/Mikkel/edits/RigtigFlot");

        animalSounds[0] = Resources.Load<AudioClip>("Audio/AnimalSounds/CowSound");
        animalSounds[1] = Resources.Load<AudioClip>("Audio/AnimalSounds/PigSound");
        animalSounds[2] = Resources.Load<AudioClip>("Audio/AnimalSounds/SheepSound");

    }

}




