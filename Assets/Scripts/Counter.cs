using System.Collections;
using UnityEngine;
using TMPro;


public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private int _score;
    private bool isPlay = true;

    public void Reset() =>
        _score = 0;
    
    private void Start() =>
        StartCoroutine(UpdateScore());

    public void Stop() =>
        isPlay = false;

    private IEnumerator UpdateScore()
    {
        WaitForSeconds score = new WaitForSeconds(1);
        
        while (isPlay)
        {
            yield return score;
            _score++;
            _text.text = _score.ToString();
        }
    }
}
