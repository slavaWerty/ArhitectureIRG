using UnityEngine;

public class PlayerViewModel
{
    private const string Horizontal = "Horizontal";

    private IPersistantData _persistantData;
    private DataLocalProvider _provider;

    private float _coveredDistance = 0f;

    private PlayerData _playerData => _persistantData.PlayerData;

    public PlayerViewModel(IPersistantData persistantData, PlayerConfig config)
    {
        _persistantData = persistantData;
        _persistantData.PlayerData = new PlayerData(config);
        _provider = new DataLocalProvider(_persistantData);
    }

    public void Move(Transform transform, AudioSource source, GameObject runClip, Transform jumpTransform)
    {
        var horizontal = Input.GetAxis(Horizontal);

        transform.position = new Vector3(transform.position.x + _playerData.Speed * horizontal * Time.deltaTime,
            transform.position.y, transform.position.z);

        if (CheckGround(jumpTransform) == true)
            SetEffect(runClip, true);

        float distance = _playerData.Speed * horizontal * Time.deltaTime;
        _coveredDistance += Mathf.Abs(distance);

        if(distance < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if(distance > 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        if (_coveredDistance >= _playerData.StepsDistance)
        {
            _coveredDistance -= _playerData.StepsDistance;
            source.clip = _playerData.RunClip;
            source.Play();
        }
    }

    public void Jump(Rigidbody2D rb, AudioSource source, GameObject jumpClip)
    {
        rb.AddForce(Vector3.up * _playerData.JumpForce);

        source.clip = _playerData.JumpClip;
        source.Play();
        SetEffect(jumpClip, true);
    }

    public Color GetColor()
    {
        return _playerData.Color;
    }

    public void AddHealth(int count)
    {
        if (count < 0)
        {
            Debug.Log("Count меньше нуля");
            return;
        }

        _playerData.Health += count;
        _provider.Save();
    }

    public void SpendHealth(int count)
    {
        if (count < 0)
        {
            Debug.Log("Count меньше нуля");
            return;
        }

        _playerData.Health -= count;
        _provider.Save();
    }

    public bool CheckGround(Transform transform)
    {
        return Physics2D.OverlapCircle(transform.position, _playerData.Radius, _playerData.LayerMask);
    }

    public void Load()
    {
        _provider.TryLoad();
    }

    public void SetEffect(GameObject effect, bool active)
    {
        effect.SetActive(active);
    }

    public Sprite GetSprite()
    {
        return _playerData.Sprite;
    }
}
