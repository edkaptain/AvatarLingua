<<<<<<< Updated upstream
=======
using System.Collections;
>>>>>>> Stashed changes
using UnityEngine;

public class TurnAroundItem : MonoBehaviour
{
    public TutorialTurnAround turnAround;

<<<<<<< Updated upstream
    [Header("Materials")]
    public Material originalMaterial;
    public Material greenMaterial;

    public GameObject sphere;
    public GameObject txt;

   public Camera playerCamera;

    public float lookTimer;
    private bool completed;

    private void Start()
    {
=======
    public GameObject txt;

    public Camera playerCamera;

    private float lookTimer;
    public float transitionDuration = 1.25f;
    private bool completed;

    // Testing
    [SerializeField] private MeshRenderer sphereRenderer;
    [SerializeField] private Color redColor = Color.red;
    [SerializeField] private Color greenColor = Color.green;

    private Material sphereMaterial;
    private Coroutine colorCoroutine;

    private void OnValidate()
    {
        if(sphereRenderer == null)
        {
            sphereRenderer = GetComponentInChildren<MeshRenderer>(true);
        }

>>>>>>> Stashed changes
        if (playerCamera == null)
        {
            playerCamera = Camera.main;
        }

    }

<<<<<<< Updated upstream
=======
    private void Awake()
    {
        if (sphereRenderer == null)
        {
            sphereRenderer = GetComponentInChildren<MeshRenderer>(true);
        }

        if (sphereRenderer == null)
        {
            Debug.LogError("No se encontró un MeshRenderer en los hijos.", this);
            return;
        }

        sphereMaterial = sphereRenderer.material;
        sphereMaterial.color = redColor;
    }


>>>>>>> Stashed changes
    private void Update()
    {
        if (completed || playerCamera == null)
            return;

<<<<<<< Updated upstream
        Ray ray = new Ray(
            playerCamera.transform.position,
            playerCamera.transform.forward
        );

        if (Physics.Raycast(ray, out RaycastHit hit, 10f))
        {

            UpdateColor(true);
            // Comprueba si el objeto golpeado es este objeto
            TurnAroundItem observedItem =
                hit.collider.GetComponentInParent<TurnAroundItem>();

            if (observedItem == this)
            {
                lookTimer += Time.deltaTime;

                if (lookTimer >= 1.25f)
                {
                    completed = true;
                    AudioManager.Instance.SystemNotification(true);

                    transform.gameObject.SetActive(false);

                    turnAround.AddPoints();
                }

                return;
            }
            else
            {
                UpdateColor(false);
                lookTimer = 0f;
            }
        }

        // Se reinicia si deja de mirar el objeto
        lookTimer = 0f;
=======
        bool isLooking = false;

        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, 10f))
        {
            TurnAroundItem observedItem = hit.collider.GetComponentInParent<TurnAroundItem>();
            isLooking = observedItem == this;
        }

        if (isLooking)
        {
            lookTimer += Time.deltaTime;

            if (lookTimer >= transitionDuration)
            {
                lookTimer = transitionDuration;
                completed = true;

                AudioManager.Instance.SystemNotification(true);
                turnAround.AddPoints();
                gameObject.SetActive(false);

            }

        }

        else
        {
            lookTimer -= Time.deltaTime;
            lookTimer = Mathf.Max(lookTimer, 0f);
        }

        float progress = lookTimer / transitionDuration;

        sphereMaterial.color = Color.Lerp(redColor, greenColor, progress);
       
>>>>>>> Stashed changes
    }

    public void UpdateColor(bool status)
    {
<<<<<<< Updated upstream
        
        sphere.GetComponent<MeshRenderer>().material =
            status ? greenMaterial : originalMaterial;
=======
        Color targetColor = status ? greenColor : redColor;

        if (colorCoroutine != null) StopCoroutine(colorCoroutine);

        colorCoroutine = StartCoroutine(ChangeColor(targetColor));
    }

    private IEnumerator ChangeColor(Color targetColor)
    {
        Color initialColor = sphereMaterial.color;
        float elapsedTime = 0f;

        while (elapsedTime < transitionDuration)
        {
            elapsedTime += Time.deltaTime;
            float progress = elapsedTime / transitionDuration;

            sphereMaterial.color = Color.Lerp(initialColor, targetColor, progress);

            yield return null;
        }

        sphereMaterial.color = targetColor;
        yield return null;
>>>>>>> Stashed changes
    }

    public void TurnText(GameObject obj)
    {
        txt.transform.LookAt(obj.transform);
        txt.transform.Rotate(0, 180f, 0);
    }
}