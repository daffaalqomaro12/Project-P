using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

public class MazeGenerator : MonoBehaviour
{
    [SerializeField]
    private MzeCell MazeCellPrefab;

    [SerializeField]
    private int mazeWidth;

    [SerializeField]
    private int mazeDepth;

    [SerializeField]
    private Vector2Int entrancePosition = new Vector2Int(0, 0);

    [SerializeField]
    private Vector2Int exitPosition;


    private MzeCell[,] mazeGrid;

    IEnumerator Start()
    {
        mazeGrid =  new MzeCell[mazeWidth, mazeDepth];
        for(int x = 0; x < mazeWidth; x++){
            for(int z = 0; z < mazeDepth; z++) {
                mazeGrid[x, z] = Instantiate(MazeCellPrefab, new Vector3(x, 0, z), Quaternion.identity);
            }
        }

        yield return GenerateMaze(null, mazeGrid[0,0]);
        CreateEntranceAndExit();
    }

    private IEnumerator GenerateMaze(MzeCell previousCell, MzeCell currentCell){
        currentCell.Visit();
        ClearWall(previousCell, currentCell);

        yield return new WaitForSeconds(0.05f);

        MzeCell nextCell;
        do{
            nextCell = GetNextUnvisitedCell(currentCell);
            if(nextCell != null){
                yield return GenerateMaze(currentCell, nextCell);
            }
        }while(nextCell != null);
    }

    void CreateEntranceAndExit()
    {
        var entranceCell = mazeGrid[entrancePosition.x, entrancePosition.y];
        entranceCell.ClearLWall(); 

        var exitCell = mazeGrid[exitPosition.x, exitPosition.y];
        exitCell.ClearRWall(); 
    }


    private MzeCell GetNextUnvisitedCell(MzeCell currentCell){
        var unvisitedCell = GetUnvisitedCell(currentCell);

        return unvisitedCell.OrderBy(_ => Random.Range(1, 10)).FirstOrDefault();
    }

    private IEnumerable<MzeCell> GetUnvisitedCell(MzeCell currentCell){
        int x = (int)currentCell.transform.position.x;
        int z = (int)currentCell.transform.position.z;

        if(x + 1 < mazeWidth){
            var cellToRight = mazeGrid[x + 1, z];

            if(cellToRight.IsVisited == false){
                yield return cellToRight;
            }
        }

        if(x - 1 >= 0){
            var cellToLeft = mazeGrid[x - 1, z];

            if(cellToLeft.IsVisited == false){
                yield return cellToLeft;
            }
        }

        if(z + 1 < mazeDepth){
            var cellToFront = mazeGrid[x, z + 1];

            if(cellToFront.IsVisited == false){
                yield return cellToFront;
            }
        }

        if(z - 1 >= 0){
            var cellToBack = mazeGrid[x, z - 1];

            if(cellToBack.IsVisited == false){
                yield return cellToBack;
            }
        }
    }


    private void ClearWall(MzeCell previousCell, MzeCell currentCell){
        if(previousCell == null){
            return;
        }

        if(previousCell.transform.position.x < currentCell.transform.position.x){
            previousCell.ClearRWall();
            currentCell.ClearLWall();
            return;
        }

        if(previousCell.transform.position.x > currentCell.transform.position.x){
            previousCell.ClearLWall();
            currentCell.ClearRWall();
            return;
        }

        if(previousCell.transform.position.z < currentCell.transform.position.z){
            previousCell.ClearFWall();
            currentCell.ClearBWall();
            return;
        }

        if(previousCell.transform.position.z > currentCell.transform.position.z){
            previousCell.ClearBWall();
            currentCell.ClearFWall();
            return;
        }
    }
    
}
