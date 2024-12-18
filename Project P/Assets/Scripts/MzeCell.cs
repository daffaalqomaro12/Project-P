using UnityEngine;

public class MzeCell : MonoBehaviour
{
    [SerializeField]
    private GameObject lWall;

    [SerializeField]
    private GameObject rWall;

    [SerializeField]
    private GameObject fWall;

    [SerializeField]
    private GameObject bWall;

    [SerializeField]
    private GameObject unvisitedBlock;

    public bool IsVisited {get; private set;}

    public void Visit(){
        IsVisited = true;
        unvisitedBlock.SetActive(false);
    }

    public void ClearLWall(){
        lWall.SetActive(false);
    }

    public void ClearRWall(){
        rWall.SetActive(false);
    }

    public void ClearFWall(){
        fWall.SetActive(false);
    }

    public void ClearBWall(){
       bWall.SetActive(false); 
    }
}
