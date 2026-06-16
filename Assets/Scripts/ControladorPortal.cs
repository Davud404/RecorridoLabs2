using UnityEngine;

public class ControladorPortal : MonoBehaviour
{
    public OcclusionPortal portalEntrada; // Arrastra tu portal aquí en el Inspector

    // Cuando el jugador entra al laboratorio
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            portalEntrada.open = false; // Cierra el portal, apaga el exterior
        }
    }

    // Cuando el jugador sale del laboratorio
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            portalEntrada.open = true; // Abre el portal, vuelve a renderizar el campus
        }
    }
}