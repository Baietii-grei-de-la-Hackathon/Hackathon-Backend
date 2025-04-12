namespace QubHq_Repo.GenericEnumFunctions;

public interface IEnumModel<TModel, TModelIdType>
{
    TModelIdType Id { get; set; }
    string Name { get; set; }
}