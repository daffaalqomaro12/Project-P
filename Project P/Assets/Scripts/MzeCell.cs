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

    public bool HasRWall { get; private set; } = true;
    public bool HasLWall { get; private set; } = true;
    public bool HasFWall { get; private set; } = true;
    public bool HasBWall { get; private set; } = true;

    public void Visit(){
        IsVisited = true;
        unvisitedBlock.SetActive(false);
    }
    
    public bool IsVisited { get; private set; } = false;

    public void ClearLWall(){
        lWall.SetActive(false);
        HasLWall = false;
    }

    public void ClearRWall(){
        rWall.SetActive(false);
        HasRWall = false;
    }

    public void ClearFWall(){
        fWall.SetActive(false);
        HasFWall = false;
    }

    public void ClearBWall(){
       bWall.SetActive(false); 
       HasBWall = false;
    }
}
