using UnityEngine;
using UnityEngine.UI;

public class NextWave : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Button _nextWaveButtom;

    private void OnEnable()
    {
        _spawner.AllEnemySpawned += OnAllEnemySpawned;
        _nextWaveButtom.onClick.AddListener(OnNextWaveButtomClick);
    }

    private void OnDisable()
    {
        _spawner.AllEnemySpawned -= OnAllEnemySpawned;
        _nextWaveButtom.onClick.RemoveListener(OnNextWaveButtomClick);
    }

    public void OnAllEnemySpawned()
    {
        _nextWaveButtom.gameObject.SetActive(true);
    }


    public void OnNextWaveButtomClick()
    {
        _spawner.NextWave();
        _nextWaveButtom.gameObject.SetActive(false);
    }
}
