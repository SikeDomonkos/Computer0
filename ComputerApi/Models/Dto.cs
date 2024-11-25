namespace ComputerApi.Models
{
    public record CreatedOsDto(string? Name);
    
    public record UpdateOsDto(string? Name);

    public record CreateComputerDto(Guid? id,string brand,string type,double display,int memory,DateTime CreatedTime,Guid Osld);
}
