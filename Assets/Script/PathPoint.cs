using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathPoint : MonoBehaviour
{
    public GameObject pathPointPrefab; // Le prefab de chaque point de chemin
    public int numberOfPoints = 10; // Nombre de points de chemin
    public float spacing = 2f; // Espacement entre chaque point
    public List<Transform> CommenPathPoints = new List<Transform>(); // Liste des points

    void Start()
    {
        GeneratePathPoints(); // Générer les points de chemin à l'exécution
    }

    // Génère les points de chemin automatiquement
    void GeneratePathPoints()
    {
        for (int i = 0; i < numberOfPoints; i++)
        {
            // Créer un nouveau point de chemin à partir du prefab
            GameObject newPathPoint = Instantiate(pathPointPrefab);
            newPathPoint.transform.SetParent(transform); // Fixe le point sous le parent

            // Calculer la position du point sur l'axe X (tu peux personnaliser l'axe ou la forme du parcours)
            Vector3 newPosition = new Vector3(i * spacing, 0, 0); // Exemple de position sur l'axe X
            newPathPoint.transform.position = newPosition; // Définir la position du point

            // Ajouter le point à la liste
            CommenPathPoints.Add(newPathPoint.transform);

            // Optionnel : Afficher un message pour le débogage
            Debug.Log($"Point {i} créé à la position {newPosition}");
        }
    }
}
