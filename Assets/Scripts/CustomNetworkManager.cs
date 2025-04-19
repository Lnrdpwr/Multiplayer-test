using UnityEngine;
using Mirror;

public class CustomNetworkManager : NetworkManager
{
    [Header("Player colors")]
    [SerializeField] private Color[] _playerColors;

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        Transform spawnPoint = GetStartPosition();
        GameObject player = Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);

        int spawnIndex = GetSpawnPointIndex(spawnPoint);


        if (player.TryGetComponent(out PlayerColorChanger colorChanger))
        {
            colorChanger.ChangePlayerColor(_playerColors[spawnIndex]);
        }

        NetworkServer.AddPlayerForConnection(conn, player);
    }

    private int GetSpawnPointIndex(Transform spawnPoint)
    {
        for (int i = 0; i < startPositions.Count; i++)
        {
            if (startPositions[i] == spawnPoint)
                return i;
        }
        return -1;
    }
}
