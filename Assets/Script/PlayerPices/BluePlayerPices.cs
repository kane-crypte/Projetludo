using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePlayerPices : MonoBehaviour
{
    public PathObjectParent pathParent;  // Référence vers le PathObjectParent (comprendre le chemin)
    private int currentIndex = 0; // Indice actuel sur le chemin

    void Start()
    {
        if (pathParent == null) // Si pathParent n'est pas assigné
        {
            pathParent = FindObjectOfType<PathObjectParent>();

            if (pathParent == null)
            {
                Debug.LogError("❌ Impossible de trouver PathObjectParent dans la scène !");
                return;
            }
        }

        // S'assurer que CommenPathPoints est bien initialisé
        if (pathParent.CommenPathPoints == null || pathParent.CommenPathPoints.Length == 0)
        {
            Debug.LogError("❌ CommenPathPoints est null ou vide !");
            return;
        }

        // Initialiser la position du pion à la première case (cela assure que le pion commence à la bonne position)
        transform.position = pathParent.CommenPathPoints[0].transform.position;

        // Démarrer la coroutine de déplacement
        StartCoroutine(MovePlayerCoroutine());
    }

    // Coroutine pour déplacer le pion à travers les cases
    private IEnumerator MovePlayerCoroutine()
    {
        int steps = 5; // Déplacer sur 5 cases

        // Boucle pour parcourir chaque case
        for (int i = 0; i < steps; i++)
        {
            // Vérification de l'indice pour éviter les erreurs
            if (currentIndex + i >= pathParent.CommenPathPoints.Length)
            {
                Debug.LogError("❌ L'indice dépasse la taille des points de chemin !");
                yield break;
            }

            // Déplacement du pion vers la prochaine case
            transform.position = pathParent.CommenPathPoints[currentIndex + i].transform.position;

            // Affichage de la position pour vérifier
            Debug.Log($"Déplacement vers la case {currentIndex + i}: {transform.position}");

            // Attendre avant de passer à la prochaine case
            yield return new WaitForSeconds(0.5f); // Pause de 0.5 seconde entre chaque case
        }
    }
}
