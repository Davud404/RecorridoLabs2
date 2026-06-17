using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CargadorEscena : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(CargarMapa());
    }

    IEnumerator CargarMapa()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1);
        // Esto evita que la escena cambie de golpe al 90%
        asyncLoad.allowSceneActivation = true; 
        
        while (!asyncLoad.isDone)
        {
            // Aquí podrías actualizar una barra de carga
            yield return null;
        }
    }
}