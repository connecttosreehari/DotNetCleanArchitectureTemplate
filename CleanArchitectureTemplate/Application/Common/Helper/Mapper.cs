namespace Application.Common.Helper;

public static class Mapper<TSource, TDestination>
{
    public static TDestination Map(TSource source)
    {
        var destination = Activator.CreateInstance<TDestination>();
        foreach (var sourceProp in typeof(TSource).GetProperties())
        {
            var destProp = typeof(TDestination).GetProperty(sourceProp.Name);
            if (destProp != null && destProp.CanWrite)
            {
                destProp.SetValue(destination, sourceProp.GetValue(source));
            }
        }
        return destination;
    }

    public static List<TDestination> Map(List<TSource> sourceList)
    {
        return sourceList.Select(source => Map(source)).ToList();
    }
}

