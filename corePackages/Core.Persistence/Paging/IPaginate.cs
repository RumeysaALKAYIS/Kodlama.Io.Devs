namespace Core.Persistence.Paging;

public interface IPaginate<T>
{
    //Sayfalama 
    int From { get; }//Hangi sayfada
    int Index { get; }//toplam sayfa
    int Size { get; }
    int Count { get; }
    int Pages { get; }
    IList<T> Items { get; }
    bool HasPrevious { get; }
    bool HasNext { get; }
}