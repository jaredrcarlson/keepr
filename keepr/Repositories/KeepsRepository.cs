namespace keepr.Repositories;

public class KeepsRepository
{
  private readonly IDbConnection _db;

  public KeepsRepository(IDbConnection db)
  {
    _db = db;
  }

  public Keep Create(Keep data)
  {
    string sql = @"
    INSERT INTO keeps
    (name, description, img, creatorId)
    VALUES
    (@Name, @Description, @Img, @CreatorId)
    ;
    SELECT LAST_INSERT_ID()
    ;";

    int id = _db.ExecuteScalar<int>(sql, data);
    return GetById(id);
  }

  public List<Keep> Get()
  {
    string sql = "SELECT * FROM keeps;";

    List<Keep> keeps = _db.Query<Keep>(sql).ToList();
    return keeps;
  }

  public Keep GetById(int id)
  {
    string sql = @"
    SELECT * FROM keeps
    WHERE id = @id
    ;";

    Keep keep = _db.QueryFirstOrDefault<Keep>(sql, new {id});
    return keep;
  }

  public Keep Update(Keep data)
  {
    string sql = @"
    UPDATE keeps SET
    name = @Name,
    description = @Description,
    img = @Img,
    views = @Views
    WHERE id = @Id
    ;";

    _db.Execute(sql, data);
    Keep keep = GetById(data.Id);
    return keep;
  }

  public void Remove(int id)
  {
    string sql = @"
    DELETE FROM keeps
    WHERE id = @id
    ;";

    _db.Execute(sql, new {id});
  }
}
