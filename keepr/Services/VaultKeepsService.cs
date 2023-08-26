namespace keepr.Services;

public class VaultKeepsService
{
  private readonly VaultKeepsRepository _vaultKeepsRepository;
  private readonly KeepsService _keepsService;

  public VaultKeepsService(VaultKeepsRepository vaultKeepsRepository, KeepsService keepsService)
  {
    _vaultKeepsRepository = vaultKeepsRepository;
    _keepsService = keepsService;
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

  public List<Keep> GetKeepsByVaultId(int id)
  {
    List<Keep> keeps = _keepsService.GetByVaultId(id);
    return keeps;
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
