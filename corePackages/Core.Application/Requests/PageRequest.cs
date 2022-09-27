namespace Core.Application.Requests;

public class PageRequest
{
    public int Page { get; set; }//Kaçıncı sayfayı istiyorsun
    public int PageSize { get; set; }//Bir sayfada kac data olsun
}