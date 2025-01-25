using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Llegada : MonoBehaviour
{
    public Canvas canvas;

    private void OnTriggerEnter(Collider other)
    {
        canvas.gameObject.SetActive(true);
        StartCoroutine(ResetLevel());
    }

    IEnumerator ResetLevel() 
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
