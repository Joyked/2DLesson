using System.Collections;
using UnityEngine;
using TMPro;


public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private int _score;
    private bool isWorking = true;

    public void Reset() =>
        _score = 0;
    
    private void Start() =>
        StartCoroutine(UpdateScore());

    public void Stop() =>
        isWorking = false;

    private IEnumerator UpdateScore()
    {
        WaitForSeconds score = new WaitForSeconds(1);
        
        while (isWorking)
        {
            yield return score;
            _score++;
            _text.text = _score.ToString();
        }
    }
}
