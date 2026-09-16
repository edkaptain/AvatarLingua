using UnityEngine;

public class DropSound : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
<<<<<<< Updated upstream
    {
        
        if (collision.gameObject.CompareTag("Item") && AudioManager.Instance.audioSource.isPlaying == false)
        {
            AudioManager.Instance.DropSound();            
=======
    {        
        if (collision.gameObject.CompareTag("Item") && AudioManager.Instance.audioSource.isPlaying == false)
        {
            AudioManager.Instance.DropSound();
            Debug.LogWarning($"The {collision} has dropped");
>>>>>>> Stashed changes
        }
    }
}
