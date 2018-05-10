using System.Collections;
using UnityEngine;

public class TextMeshSpawner : MonoBehaviour
{
    public static TextMeshSpawner instance;
    public TextMesh textPrefab;

    private void Awake()
    {
        instance = this;
    }

    public void spawnText(string text, Vector3 position, Quaternion rotation, float fadeSpeed = 0.5f, float moveSpeed = 3.0f)
    {
        StartCoroutine(spawnTextEnumerator(text, position, rotation, fadeSpeed, moveSpeed));
    }

    private IEnumerator spawnTextEnumerator(string text, Vector3 position, Quaternion rotation, float fadeSpeed = 0.5f, float moveSpeed = 3.0f)
    {
        TextMesh textObject = Instantiate(textPrefab, position, rotation) as TextMesh;
        textObject.text = text;
        while (textObject.color.a > 0f)
        {
            yield return new WaitForEndOfFrame();
            Color c = textObject.color;
            c.a -= Time.deltaTime * 0.5f;
            textObject.color = c;
            textObject.transform.Translate(Vector3.up * 3.0f * Time.deltaTime);
        }
        Destroy(textObject.gameObject);
    }
}