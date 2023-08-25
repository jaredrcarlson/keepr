namespace keepr.Services;

public class VaultsService
{
  private readonly VaultsRepository _vaultsRepository;

  public VaultsService(VaultsRepository vaultsRepository)
  {
    _vaultsRepository = vaultsRepository;
  }

  public Vault Create(Vault data)
  {
    Vault vault = _vaultsRepository.Create(data);
    return vault;
  }

  public Vault GetById(int id)
  {
    Vault vault = _vaultsRepository.GetById(id) ?? throw new Exception("Unable to retrieve requested resource.");
    return vault;
  }

  public Vault Update(Vault data, Account user)
  {
    Vault vault = GetById(data.Id);
    if(user == null || user.Id != vault.CreatorId)
    {
      throw new Exception("Action cannot be performed.");
    }

    vault.Name = data.Name ?? vault.Name;
    vault.Description = data.Description ?? vault.Description;
    vault.Img = data.Img ?? vault.Img;
    vault.IsPrivate = data.IsPrivate ?? vault.IsPrivate;

    vault = _vaultsRepository.Update(vault);
    return vault;
  }

  public void Remove(int id, Account user)
  {
    Vault vault = GetById(id);
    if(user == null || user.Id != vault.CreatorId)
    {
      throw new Exception("Action cannot be performed.");
    }

    _vaultsRepository.Remove(id);
  }
}
