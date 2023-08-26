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
    string sql = @"
    SELECT
    k.*,
    COUNT(vk.id) AS kept,
    a.*
    FROM keeps k
    LEFT JOIN vaultkeeps vk ON vk.keepId = k.id
    JOIN accounts a ON a.id = k.creatorId
    GROUP BY k.id
    ;";

    List<Keep> keeps = _db.Query<Keep, Profile, Keep>(
      sql,
      (k, p) => {
        k.Creator = p;
        return k;
      }).ToList();
    return keeps;
  }

  public Keep GetById(int id)
  {
    string sql = @"
    SELECT
    k.*,
    COUNT(vk.id) AS kept,
    a.*
    FROM keeps k
    LEFT JOIN vaultkeeps vk ON vk.keepId = k.id
    JOIN accounts a ON a.id = k.creatorId
    WHERE k.id = @id
    GROUP BY k.id
    ;";

    Keep keep = _db.Query<Keep, Profile, Keep>(
      sql,
      (k, p) => {
        k.Creator = p;
        return k;
      },
      new {id}).FirstOrDefault();
    return keep;
  }

  public List<Keep> GetByVaultId(int id)
  {
    string sql = @"
    SELECT
    k.*,
    COUNT(vk.id) AS kept,
    vk.id AS vaultKeepId,
    a.*
    FROM keeps k
    LEFT JOIN vaultkeeps vk ON vk.keepId = k.id
    JOIN accounts a ON a.id = k.creatorId
    WHERE vk.vaultId = @id
    GROUP BY k.id, vk.id
    ;";

    List<Keep> keeps = _db.Query<Keep, Profile, Keep>(
      sql,
      (k, p) => {
        k.Creator = p;
        return k;
      },
      new {id}).ToList();
    return keeps;
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
