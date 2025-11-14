namespace GladiatorFights.Interfaces
{
    internal interface IDamageable
    {
        void TakeDamage(int damage);
        bool IsAlive {  get; }
    }
}
