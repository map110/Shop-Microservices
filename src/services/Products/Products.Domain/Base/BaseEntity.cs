namespace Products.Domain.Base;

public abstract class BaseEntity<TKey>
{
    public TKey Id { get; set; }
    public DateTime CreationDateTime { get; set; }
    public DateTime ModificationDateTime { get; set; }
}

public abstract class BaseEntity : BaseEntity<int>
{
    
}