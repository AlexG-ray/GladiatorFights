namespace GladiatorFights.Interfaces
{
    internal interface IDamageable
    {
        bool IsAlive { get; }

        void TakeDamage(int damage);
    }
}
