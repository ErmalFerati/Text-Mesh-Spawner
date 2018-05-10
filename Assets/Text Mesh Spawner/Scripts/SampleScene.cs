using System.Collections;
using UnityEngine;

public class SampleScene : MonoBehaviour
{
    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            int random = Random.Range(0, transform.childCount);
            TextMeshSpawner.instance.spawnText("Hello", transform.GetChild(random).position, transform.GetChild(random).rotation);
        }
    }
}