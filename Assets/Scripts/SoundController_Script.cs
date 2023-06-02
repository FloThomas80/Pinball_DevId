using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController_Script : MonoBehaviour
{

    private static SoundController_Script instance;
    //methode Bobo :​
    /*
     * Créer le gameobject avec l'audiosource intégré
     */
    [SerializeField]
    private GameObject mBumperSound;
    [SerializeField]
    private GameObject mLauncherSound;
    [SerializeField]
    private GameObject mFlipperSound;

    public static SoundController_Script Instance //instance called
    {
        get

        {
            if (instance == null)
            {
                instance = FindObjectOfType<SoundController_Script>();

                if (instance == null)
                {
                    GameObject SoundController_Script = new GameObject("SoundController");
                    instance = SoundController_Script.AddComponent<SoundController_Script>();
                }
            }

            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this) //singleton, only one instance exist ?
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        DontDestroyOnLoad(gameObject);//don't destroy me, i'm THE SOUND Controller ! (what would be a sailor without a good song ?)
    }

    public void LaunchBumperSound1()
    {
        // Indiquer le destroy avec un temps de delete
        Destroy(Instantiate(mBumperSound), 2);
    }
    public void LaunchLauncherSound2()
    {
        Destroy(Instantiate(mLauncherSound), 3);
    }
    public void LaunchFlipperSound()
    {
        Destroy(Instantiate(mFlipperSound), 3);
    }
}
