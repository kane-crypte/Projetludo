using UnityEngine;

public class RedPlayerPices : MonoBehaviour
{
    public bool moveNow;
    public int numberOfStepsToMove;
    public PathObjectParent pathParent;
    
    void Start()
    {
        pathParent = FindObjectOfType<PathObjectParent>();
    }

    void Update()
    {
        // Ton code de mise à jour spécifique ici
    }
}
