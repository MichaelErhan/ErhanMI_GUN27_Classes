using System;

public class Unit
{
    public Unit(string name, float health, Helm helm, Shell shell, Boots boots, Weapon weapon)
    {
        Name = name;
        Health = health;
        Helm = helm;
        Shell = shell;
        Boots = boots;
        Weapon = weapon;
    }

    public string Name { get; }
    private float _health;

    public float Health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = value;
            if (_health < 0)
            {
                _health = 0;
            }
        }
    }

    public int HealthInt
    {
        get
        {
            return (int)Math.Floor(Health);
        }
    }

    public float Damage
    {
        get
        {
            return Weapon != null ? Weapon.Damage + BaseDamage : BaseDamage;
        }
    }

    public float Armor
    {
        get
        {
            float HelmArmor = Helm != null ? Helm.ArmorValue : 0;
            float ShellArmor = Shell != null ? Shell.ArmorValue : 0;
            float BootsArmor = Boots != null ? Boots.ArmorValue : 0;

            float TotalArmor = HelmArmor * ShellArmor * BootsArmor;

            if (TotalArmor < 0)
            {
                TotalArmor = 0;
            }
            else if (TotalArmor > 1)
            {
                TotalArmor = 1;
            }

            return TotalArmor;
        }
    }

    public float RealHealth
    {
        get
        {
            return Health * (1f + Armor);
        }
    }

    public bool SetDamage(float value)
    {
        Health -= value * Armor;

        return Health <= 0f;
    }

    private const float BaseDamage = 5;
    public Weapon Weapon { get; set; }
    public Helm Helm { get; set; }
    public Shell Shell { get; set; }
    public Boots Boots { get; set; }

    public Unit() : this("Unknown Unit", 100)
    {
    }

    public Unit(string name) : this(name, 100)
    {
    }

    public Unit(string name, float health)
    {
        Name = name;
        Health = health;
    }

    public void EquipWeapon(Weapon weapon)
    {
        Weapon = weapon;
    }
    public void EquipHelm(Helm helm)
    {
        Helm = helm;
    }

    public void EquipShell(Shell shell)
    {
        Shell = shell;
    }

    public void EquipBoots(Boots boots)
    {
        Boots = boots;
    }
}