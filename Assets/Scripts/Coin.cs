using UnityEngine;

public class Coin : MonoBehaviour
{
    public const int COIN_WORTH = 1;
    public void Collected()
    {
        //TODO: trigger disappear animation

        //TODO: SFX

        Destroy(gameObject); //TODO: consider disabling and adding to a pool or something
    }
}