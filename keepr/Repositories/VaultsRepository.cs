namespace keepr.Repositories;

public class VaultsRepository
{
  private readonly IDbConnection _db;

  public VaultsRepository(IDbConnection db)
  {
    _db = db;
  }

  public Vault Create(Vault data)
  {
    string sql = @"
    INSERT INTO vaults
    (name, description, img, isPrivate, creatorId)
    VALUES
    (@Name, @Description, @Img, @IsPrivate, @CreatorId)
    ;
    SELECT LAST_INSERT_ID()
    ;";

    int id = _db.ExecuteScalar<int>(sql, data);
    Vault vault = GetById(id);
    return vault;
  }

  public Vault GetById(int id)
  {
    string sql = @"
    SELECT
    v.*,
    a.*
    FROM vaults v
    JOIN accounts a ON a.id = v.creatorId
    WHERE v.id = @id
    ;";

    Vault vault = _db.Query<Vault, Profile, Vault>(
      sql,
      (v, p) => {
        v.Creator = p;
        return v;
      },
      new {id}
    ).FirstOrDefault();

    return vault;
  }

  public Vault Update(Vault data)
  {
    string sql = @"
    UPDATE vaults SET
    name = @Name,
    description = @Description,
    img = @Img,
    isPrivate = @IsPrivate,
    creatorId = @CreatorId
    ;";

    _db.Execute(sql, data);
    Vault vault = GetById(data.Id);
    return vault;
  }

  public void Remove(int id)
  {
    string sql = @"
    DELETE FROM vaults
    WHERE id = @id
    ;";

    _db.Execute(sql, new {id});
  }
}
