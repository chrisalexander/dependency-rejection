using System.Linq;

// The domain object
class BrownBag
{
    public Date Day { get; set;}
    public string Presenter { get; set; }
    public string Topic { get; set; }
}

class BrownBagDto
{
    public BsonData Data { get; }
}

enum Result
{
    Fail,
    Success
}

interface IMapper
{
    BrownBag Map(BrownBagDto dto)
}

interface IValidator
{
    bool Validate(BrownBag brownBag);
}

// Some kind of data store for finding out about brown bags and storing them
interface IBrownBagStore
{
    List<BrownBag> GetBrownBags(Date date);
    Guid TryAccept(BrownBag brownBag);
}

// A mock controller, entry point to the code, to accept new brown bags
public BrownBagController
{
    private IMapper mapper;
    private IValidator validator;
    private IBrownBagStore brownBagStore;

    public BrownBagController(IMapper mapper, IValidator validator, IBrownBagStore brownBagStore)
    {
        this.mapper = mapper;
        this.validator = validator;
        this.brownBagStore = brownBagStore;
    }

    public Result HandleNewBrownBag(BrownBagDto dto)
    {
        var brownBag = mapper.Map(dto);

        var valid = validator.Validate(brownBag);
        if (!valid)
        {
            return Result.Fail;
        }

        var maxBrownBagsPerDay = 1;

        var currentBrownBags = brownBagStore.GetBrownBags(brownBag.Day);
        if (currentBrownBags.Count >= maxBrownBagsPerDay)
        {
            return Result.Fail;
        }

        var id = brownBagStore.TryAccept(brownBag);
        return id != null ? Result.Success : Result.Fail;
    } 
}