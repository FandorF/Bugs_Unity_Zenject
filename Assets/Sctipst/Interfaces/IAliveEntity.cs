
public interface IAliveEntity 
{
   int Hp { get; }
   bool Alive { get; }

   void TakeDamage(int damage);
}
