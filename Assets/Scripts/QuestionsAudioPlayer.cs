using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionsAudioPlayer : MonoBehaviour

{
    public AudioSource audioPlayer;       // Audiosource og arrays til lydfiler
    AudioClip[] prepositionQuestionSounds = new AudioClip[9];
    AudioClip[] nounQuestionSounds = new AudioClip[3];
    AudioClip[] positiveReinforcementSounds = new AudioClip[3];
    AudioClip[] animalSounds = new AudioClip[3];



    public void PlayPrepositionQuestionAudio(int positionAsked)
    {
        //audioPlayer.clip = prepositionQuestionSounds[positionAsked];         // lydklip der passer til den udtrukne position afspilles gemmes i audioplayerens standard "clip" variabel. 
        audioPlayer.PlayOneShot(prepositionQuestionSounds[positionAsked]);                // "Hvilket dyr er..." - PlayOneShot afspiller lyd der refereres i parentesen een gang og stopper når lyden slutter. 
        //audioPlayer.PlayDelayed(prepositionQuestionSounds[7].length);           // "[forholdsord] [navneord]"? - Playdelayed gør så lyden afspilles med en forsinkelse der svarer til længden af lydklippet i parentesen.  
                                                                     // Playdelayed afspiller den lyd der som ligger i audioplayeres standard "clip" variabel
    }

    public void PlayNounQuestionAudio(int nounAsked)
    {
        //audioPlayer.clip = nounQuestionSounds[nounAsked];
        audioPlayer.PlayOneShot(nounQuestionSounds[nounAsked]);
        //audioPlayer.PlayDelayed(nounQuestionSounds[3].length);

    }

    public void PlayAnswerFeedback(int pickedAnimal)
    {
        audioPlayer.clip = positiveReinforcementSounds[(int)Random.Range(0, 2)];
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
        prepositionQuestionSounds[7] = Resources.Load<AudioClip>("Audio/Level2/BagvedLaden");

        positiveReinforcementSounds[0] = Resources.Load<AudioClip>("Audio/Mikkel/edits/DuKlarerDetFlot");
        positiveReinforcementSounds[1] = Resources.Load<AudioClip>("Audio/Mikkel/edits/GodtGaaet");
        positiveReinforcementSounds[2] = Resources.Load<AudioClip>("Audio/Mikkel/edits/RigtigFlot");

        animalSounds[0] = Resources.Load<AudioClip>("Audio/AnimalSounds/CowSound");
        animalSounds[1] = Resources.Load<AudioClip>("Audio/AnimalSounds/PigSound");
        animalSounds[2] = Resources.Load<AudioClip>("Audio/AnimalSounds/SheepSound");

    }

}




