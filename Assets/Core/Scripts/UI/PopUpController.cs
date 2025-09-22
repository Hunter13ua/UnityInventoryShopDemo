using UnityEngine;

public class PopUpController : MonoBehaviour
{
    private float _timer;

    public void SetTimer(float value)
    {
        _timer = value;
        if (_timer > 0)
        {
            gameObject.SetActive(true);
        }
    }

    private void Update()
    {
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
            if (_timer <= 0)
            {
                _timer = 0;
                gameObject.SetActive(false);
            }
        }
    }
}
