using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public GameObject[] weapons;
    private int currentWeaponIndex = 0;

    void Start()
    {
        SelectWeapon();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            currentWeaponIndex = (currentWeaponIndex + 1) % weapons.Length;
            SelectWeapon();
        }
    }

    void SelectWeapon()
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(i == currentWeaponIndex);
        }
    }
}
