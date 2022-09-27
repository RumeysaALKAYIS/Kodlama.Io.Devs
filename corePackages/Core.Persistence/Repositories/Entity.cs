namespace Core.Persistence.Repositories;

public class Entity
{
    //Bütün nesnelerde id olcağını belirdilmiş
    public int Id { get; set; }

    public Entity()
    {
    }

    public Entity(int id) : this()
    {
        Id = id;
    }
}