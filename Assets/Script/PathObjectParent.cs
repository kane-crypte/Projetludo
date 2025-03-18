using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathObjectParent : MonoBehaviour
{
    public PathPoint[] CommenPathPoints;  // Point de chemin commun (pour tous les joueurs)
    public PathPoint[] RedPathPoints;     // Chemin des pions rouges
    public PathPoint[] GreenPathPoints;   // Chemin des pions verts
    public PathPoint[] YellowPathPoints;  // Chemin des pions jaunes
    public PathPoint[] BluePathPoints;    // Chemin des pions bleus

    // Cette fonction permet de sélectionner le tableau de points de chemin approprié
    // en fonction de la couleur du joueur.
public PathPoint[] GetPlayerPathPoints(Color playerColor)
{
    if (playerColor == Color.red)
        return RedPathPoints;
    if (playerColor == Color.green)
        return GreenPathPoints;
    if (playerColor == Color.yellow)
        return YellowPathPoints;
    if (playerColor == Color.blue)
        return BluePathPoints;
    
    Debug.LogError("Couleur de joueur non valide!");
    return null;
}



    // Start is called before the first frame update
    void Start()
    {
        // Initialisation ou vérification des tableaux de PathPoints
        if (CommenPathPoints == null || CommenPathPoints.Length == 0)
        {
            Debug.LogError("❌ CommenPathPoints n'est pas initialisé correctement.");
        }

        // Tu peux ajouter des vérifications similaires pour les autres tableaux si nécessaire
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
