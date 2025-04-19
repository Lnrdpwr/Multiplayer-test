using Mirror;
using UnityEngine;

public class PlayerColorChanger : NetworkBehaviour
{
    [SyncVar(hook = nameof(OnChangedColor))]
    private Color _playerColor = Color.white;

    private SpriteRenderer _renderer;

    private void OnChangedColor(Color oldColor, Color newColor)
    {
        _renderer = GetComponent<SpriteRenderer>();
        if (_renderer != null)
            _renderer.color = newColor;
    }

    [Server]
    public void ChangePlayerColor(Color color)
    {
        _playerColor = color;
    }
}
