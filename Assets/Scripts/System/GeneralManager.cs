using UnityEngine;

public class GeneralManager : MonoBehaviour
{
    [SerializeField] int fps = 72;
    // Singlenton
    public static GeneralManager Instance;
<<<<<<< Updated upstream
=======

>>>>>>> Stashed changes
   

    private void Awake()
    {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        // Set to 90 FPS
        Application.targetFrameRate = fps;
<<<<<<< Updated upstream
    }

    private void Start()
    {
    
    }


=======

        DontDestroyOnLoad(gameObject);
    }
>>>>>>> Stashed changes
}
