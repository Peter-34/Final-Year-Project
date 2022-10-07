using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Select : MonoBehaviour
{

    public string heap;
    public string graph;
    public string binaryTree;
    
    public void Heap()
    {
        SceneManager.LoadScene(heap);
    }

    public void Graph()
    {
        SceneManager.LoadScene(graph);
    }

    public void BinaryTree()
    {
        SceneManager.LoadScene(binaryTree);
    }
}
