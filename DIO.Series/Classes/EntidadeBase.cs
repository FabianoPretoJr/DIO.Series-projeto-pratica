namespace DIO.Series.Classes
{
    public abstract class EntidadeBase
    {
        protected EntidadeBase(int id)
        {
            this.Id = id;
        }

        protected int Id { get; set; }
    }
}