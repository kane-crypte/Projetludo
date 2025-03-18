using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPices : MonoBehaviour
{
    public bool moveNow; // Variable pour savoir si le pion doit se déplacer
    public int numberOfStepsToMove = 5; // Nombre de cases à déplacer
    public PathObjectParent pathParent; // Référence à PathObjectParent (contenant les points du chemin)
    private int currentIndex = 0; // Indice du chemin actuel que le pion suit

    void Start()
    {
        // Récupérer la référence à PathObjectParent dans la scène
        pathParent = FindObjectOfType<PathObjectParent>();

        if (pathParent == null)
        {
            Debug.LogError("❌ Impossible de trouver PathObjectParent dans la scène !");
        }

        // Initialiser la position du pion au début du chemin
        if (pathParent != null && pathParent.CommenPathPoints.Length > 0)
        {
            transform.position = pathParent.CommenPathPoints[currentIndex].transform.position;
        }
    }

    void Update()
    {
        // Si moveNow est vrai, démarrer la coroutine de déplacement
        if (moveNow && pathParent != null)
        {
            StartCoroutine(MovePlayerCoroutine());
            moveNow = false; // Désactiver moveNow pour éviter de redémarrer la coroutine à chaque frame
        }
    }

    // Coroutine pour déplacer le joueur
    private IEnumerator MovePlayerCoroutine()
{
    // Vérification du nombre d'étapes à effectuer
    for (int i = 0; i < numberOfStepsToMove; i++)
    {
        // Si l'indice actuel dépasse le nombre de points de chemin, quitter la coroutine
        if (currentIndex >= pathParent.CommenPathPoints.Length - 1)
        {
            Debug.Log("❌ Le pion a atteint la fin du chemin.");
            yield break; // Sortir de la coroutine si on est arrivé à la fin du chemin
        }

        // Déplacer le pion vers la position suivante
        currentIndex++;
        transform.position = pathParent.CommenPathPoints[currentIndex].transform.position;

        // Log supplémentaire pour suivre le déplacement
        Debug.Log($"Déplacement vers la case {currentIndex}: {transform.position}");

        // Attendre avant de continuer le déplacement
        yield return new WaitForSeconds(0.5f); // Attendre 0.5 secondes avant de déplacer à la prochaine position
    }

    // Si on a fini de se déplacer, afficher un message
    Debug.Log("✅ Déplacement terminé.");
}

}
