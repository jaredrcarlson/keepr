namespace keepr.Services;

public class KeepsService
{
  private readonly KeepsRepository _keepsRepository;

  public KeepsService(KeepsRepository keepsRepository)
  {
    _keepsRepository = keepsRepository;
  }

  internal Keep Create(Keep data)
  {
    Keep keep = _keepsRepository.Create(data);
    return keep;
  }

  internal List<Keep> Get()
  {
    List<Keep> keeps = _keepsRepository.Get();
    return keeps;
  }

  internal Keep GetById(int id)
  {
    Keep keep = _keepsRepository.GetById(id) ?? throw new Exception("Unable to retrieve requested resource.");
    return keep;
  }

  internal List<Keep> GetByProfileId(string id)
  {
    List<Keep> keeps = _keepsRepository.GetByCreatorId(id);
    return keeps;
  }

  internal List<Keep> GetByVaultId(int id)
  {
    List<Keep> keeps = _keepsRepository.GetByVaultId(id);
    return keeps;
  }

  internal Keep Update(Keep data, Account user)
  {
    Keep keep = GetById(data.Id);
    if(user == null || user.Id != keep.CreatorId)
    {
      data.Name = null;
      data.Description = null;
      data.Img = null;
      data.Kept = null;
    }

    keep.Name = data.Name ?? keep.Name;
    keep.Description = data.Description ?? keep.Description;
    keep.Img = data.Img ?? keep.Img;
    keep.Views = data.Views ?? keep.Views;
    keep.Kept = data.Kept ?? keep.Kept;
    
    keep = _keepsRepository.Update(keep);
    return keep;
  }

  internal void Remove(int id, Account user)
  {
    Keep keep = GetById(id);
    if(user == null || user.Id != keep.CreatorId)
    {
      throw new Exception("Action cannot be performed.");
    }

    _keepsRepository.Remove(id);
  }

}
