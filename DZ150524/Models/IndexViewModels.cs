namespace DZ150524.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Car> Cars { get; }
        
        public IndexViewModel(IEnumerable<Car> cars)
        {
            Cars = cars;           
        }
    }
}
