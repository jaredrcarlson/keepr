namespace keepr.Services;

public class VaultKeepsService
{
  private readonly VaultKeepsRepository _vaultKeepsRepository;

  public VaultKeepsService(VaultKeepsRepository vaultKeepsRepository)
  {
    _vaultKeepsRepository = vaultKeepsRepository;
  }

  public VaultKeep Create(VaultKeep data)
  {
    VaultKeep vk = _vaultKeepsRepository.Create(data);
    return vk;
  }

  public VaultKeep GetById(int id)
  {
    VaultKeep vk = _vaultKeepsRepository.GetById(id);
    return vk;
  }

  public List<VaultKeep> GetByVaultId(int id)
  {
    List<VaultKeep> vks = _vaultKeepsRepository.GetByVaultId(id);
    return vks;
  }

  public void Remove(int id, Account user)
  {
    VaultKeep vk = GetById(id);
    if(user == null || user.Id != vk.CreatorId)
    {
      throw new Exception("Action cannot be performed.");
    }

    _vaultKeepsRepository.Remove(id);
  }
}
