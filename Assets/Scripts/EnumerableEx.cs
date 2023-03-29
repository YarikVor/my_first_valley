using System.Collections;
using System.Collections.Generic;


public static class EnumerableEx
{
    public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, System.Action<T> action)
    {
        foreach (var item in source)
        {
            action(item);
        }
        

        return source;
    }

    public static IEnumerable<TEntity> ForEach<TEntity>(this IEnumerable<TEntity> source,
        System.Action<TEntity, int> action)
    {
        int i = 0;
        foreach (var item in source)
        {
            action(item, i);
            i++;
        }

        return source;
    }

    public static IEnumerable<TEntity> ForEachYield<TEntity>(this IEnumerable<TEntity> source,
        System.Action<TEntity> action)
    {
        foreach (var item in source)
        {
            action(item);
            yield return item;
        }
    }
}