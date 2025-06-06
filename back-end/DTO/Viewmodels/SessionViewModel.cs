namespace DTO.Viewmodels;

public class SessionViewModel
{
    public int id { get; set; }
    public int table_id { get; set; }
    public Status status { get; set; }
    public bool paid { get; set; }
}