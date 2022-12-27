namespace movtrack8_backend.Interfaces
{
    /// <summary>
    /// Additionnal informations added to each entries in the database
    /// Those will be updated automatically when the dev save an object in database
    /// </summary>
    public interface IObjectBase
    {
        long? Id { get; set; }
        DateTime? CreatedAt { get; set; }
        DateTime? UpdatedAt { get; set; }
    }
}
