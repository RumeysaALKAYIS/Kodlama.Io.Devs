namespace Core.Persistence.Paging;

public class BasePageableModel
{
    public int Index { get; set; }//Kaçıncı Sayfa
    public int Size { get; set; }//Sayfada kaç data var
    public int Count { get; set; }//Toplamdda kaç data var
    public int Pages { get; set; }//Kaçıncı sayfadayım
    public bool HasPrevious { get; set; }//Once sayfa varmı
    public bool HasNext { get; set; }//Sonraki sayfa var mı
}