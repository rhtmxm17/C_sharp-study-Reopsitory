namespace HW_30106_abstract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Weapon[] weapons = new Weapon[3];

            weapons[0] = new HeavyMachinegun();
            weapons[1] = new RocketLauncher();
            weapons[2] = new FlameShot();

            for (int i = 0; i < weapons.Length; i++)
            {
                // 똑같이 Weapon.Shoot()을 호출했지만 실제로
                // 작동한건 각 인스턴스의 Shoot()
                weapons[i].Shoot();
                weapons[i].GainAdditionalBullet();
            }
        }
    }
}
