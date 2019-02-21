using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeGridController : MonoBehaviour
{
    #region Test
    //TODO: ovo inace preuzimati od igraca
    public int MaxNumOfLives = 3;
    public int NumOfLives;
    #endregion

    public LifeImage LifeImagePrefab;
    public PlayerHealthManager _playerHealth;

    [SerializeField]
    private List<LifeImage> _lifeImages = new List<LifeImage>();

    private void Awake()
    {
        _playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealthManager>();
        NumOfLives = _playerHealth.NumOfLives;
        RefreshLifeImages(_playerHealth.MaxNumOfLives);
    }

    public void AddLifeImage()
    {
        LifeImage lifeImageClone = Instantiate(LifeImagePrefab, transform);
        lifeImageClone.SetActive(true);
        _lifeImages.Add(lifeImageClone);
    }

    public void RefreshLifeImages(int numOfLives)
    {
        int lifeDelta = numOfLives - _lifeImages.Count;

        for (int i = 0; i < lifeDelta; i++)
        {
            AddLifeImage();
        }
        for (int i = 0; i < _lifeImages.Count; i++)
        {
            //TODO: preuzeti NumofLives od igraca
            if (i < numOfLives)
                _lifeImages[i].SetActive(true);
            else
                _lifeImages [i].SetActive(false);
        }
    }
}
