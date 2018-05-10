public void Start()
{
    //Is very _mildly_ faster in my perf test
    //than using FindGameObjectsWithTag
    //Gets all active game objects in scene. 
    foreach(var go in FindObjectsOfType<GameObject>())
    {

    }
}