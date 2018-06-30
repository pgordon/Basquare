using UnityEngine;

public class Coin : MonoBehaviour
{
    public void Collected()
    {
        //TODO: trigger disappear animation

        //TODO: SFX

        Destroy(gameObject); //TODO: consider disabling and adding to a pool or something
    }
}