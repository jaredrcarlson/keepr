namespace keepr.Services;

public class KeepsService
{
  private readonly KeepsRepository _keepsRepository;

  public KeepsService(KeepsRepository keepsRepository)
  {
    _keepsRepository = keepsRepository;
  }

  public Keep Create(Keep data)
  {
    Keep keep = _keepsRepository.Create(data);
    return keep;
  }

  public List<Keep> Get()
  {
    List<Keep> keeps = _keepsRepository.Get();
    return keeps;
  }

  public Keep GetById(int id)
  {
    Keep keep = _keepsRepository.GetById(id) ?? throw new Exception("Unable to retrieve requested resource.");
    return keep;
  }

  public Keep Update(Keep data, Account user)
  {
    Keep keep = GetById(data.Id);
    if(user == null || user.Id != keep.CreatorId)
    {
      throw new Exception("Action cannot be performed.");
    }

    keep.Name = data.Name ?? keep.Name;
    keep.Description = data.Description ?? keep.Description;
    keep.Img = data.Img ?? keep.Img;
    // FIXME might need to update Views here
    
    keep = _keepsRepository.Update(keep);
    return keep;
  }

  public void Remove(int id, Account user)
  {
    Keep keep = GetById(id);
    if(user == null || user.Id != keep.CreatorId)
    {
      throw new Exception("Action cannot be performed.");
    }

    _keepsRepository.Remove(id);
  }

}
