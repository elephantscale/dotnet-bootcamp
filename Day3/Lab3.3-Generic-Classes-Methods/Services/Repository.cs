// using Lab3._3_Generic_Classes_Methods.Interfaces;
// using Lab3._3_Generic_Classes_Methods.Models;

// namespace Lab3._3_Generic_Classes_Methods.Services;

// public class Repository<T, TKey> : IRepository<T, TKey> 
//     where T : Entity<TKey> 
//     where TKey : IEquatable<TKey>
// {
//     private readonly List<T> _entities = new();

//     public event Action<T>? EntityAdded;
//     public event Action<T>? EntityUpdated;
//     public event Action<T>? EntityDeleted;

//     public void Add(T entity)
//     {
//         if (entity == null)
//             throw new ArgumentNullException(nameof(entity));

//         if (Exists(e => e.Id.Equals(entity.Id)))
//             throw new InvalidOperationException($"Entity with ID {entity.Id} already exists");

//         _entities.Add(entity);
//         EntityAdded?.Invoke(entity);
//     }

//     public void AddRange(IEnumerable<T> entities)
//     {
//         foreach (var entity in entities)
//         {
//             Add(entity);
//         }
//     }

//     public T? GetById(TKey id)
//     {
//         return _entities.FirstOrDefault(e => e.Id.Equals(id) && !e.IsDeleted);
//     }

//     public IEnumerable<T> GetAll()
//     {
//         return _entities.Where(e => !e.IsDeleted).ToList();
//     }

//     public void Update(T entity)
//     {
//         if (entity == null)
//             throw new ArgumentNullException(nameof(entity));

//         var existing = _entities.FirstOrDefault(e => e.Id.Equals(entity.Id));
//         if (existing == null)
//             throw new InvalidOperationException($"Entity with ID {entity.Id} not found");

//         var index = _entities.IndexOf(existing);
//         _entities[index] = entity;
//         entity.MarkAsUpdated();
//         EntityUpdated?.Invoke(entity);
//     }

//     public void Delete(TKey id)
//     {
//         var entity = GetById(id);
//         if (entity != null)
//         {
//             Delete(entity);
//         }
//     }

//     public void Delete(T entity)
//     {
//         if (entity == null)
//             throw new ArgumentNullException(nameof(entity));

//         entity.MarkAsDeleted();
//         EntityDeleted?.Invoke(entity);
//     }

//     public IEnumerable<T> Find(Func<T, bool> predicate)
//     {
//         return _entities.Where(e => !e.IsDeleted && predicate(e)).ToList();
//     }

//     public T? FirstOrDefault(Func<T, bool> predicate)
//     {
//         return _entities.FirstOrDefault(e => !e.IsDeleted && predicate(e));
//     }

//     public bool Exists(Func<T, bool> predicate)
//     {
//         return _entities.Any(e => !e.IsDeleted && predicate(e));
//     }

//     public int Count()
//     {
//         return _entities.Count(e => !e.IsDeleted);
//     }

//     public int Count(Func<T, bool> predicate)
//     {
//         return _entities.Count(e => !e.IsDeleted && predicate(e));
//     }

//     public void DeleteRange(IEnumerable<T> entities)
//     {
//         foreach (var entity in entities)
//         {
//             Delete(entity);
//         }
//     }

//     public void DeleteRange(IEnumerable<TKey> ids)
//     {
//         foreach (var id in ids)
//         {
//             Delete(id);
//         }
//     }
// }

// // Specialized repositories
// public class ProductRepository : Repository<Product, int>
// {
//     public IEnumerable<Product> GetByCategory(string category)
//     {
//         return Find(p => p.Category.Equals(category, StringComparison.OrdinalIgnoreCase));
//     }

//     public IEnumerable<Product> GetInPriceRange(decimal minPrice, decimal maxPrice)
//     {
//         return Find(p => p.Price >= minPrice && p.Price <= maxPrice);
//     }

//     public IEnumerable<Product> GetInStock()
//     {
//         return Find(p => p.InStock && p.StockQuantity > 0);
//     }

//     public IEnumerable<Product> GetLowStock(int threshold = 10)
//     {
//         return Find(p => p.InStock && p.StockQuantity <= threshold);
//     }
// }

// public class CustomerRepository : Repository<Customer, int>
// {
//     public Customer? GetByEmail(string email)
//     {
//         return FirstOrDefault(c => c.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
//     }

//     public IEnumerable<Customer> GetByType(CustomerType type)
//     {
//         return Find(c => c.Type == type);
//     }

//     public IEnumerable<Customer> GetByAgeRange(int minAge, int maxAge)
//     {
//         return Find(c => c.Age >= minAge && c.Age <= maxAge);
//     }

//     public IEnumerable<Customer> GetWithOrders()
//     {
//         return Find(c => c.OrderIds.Count > 0);
//     }
// }

// public class OrderRepository : Repository<Order, int>
// {
//     public IEnumerable<Order> GetByCustomer(int customerId)
//     {
//         return Find(o => o.CustomerId == customerId);
//     }

//     public IEnumerable<Order> GetByStatus(OrderStatus status)
//     {
//         return Find(o => o.Status == status);
//     }

//     public IEnumerable<Order> GetByDateRange(DateTime startDate, DateTime endDate)
//     {
//         return Find(o => o.OrderDate >= startDate && o.OrderDate <= endDate);
//     }

//     public IEnumerable<Order> GetLargeOrders(decimal minimumAmount)
//     {
//         return Find(o => o.TotalAmount >= minimumAmount);
//     }
// }

using Lab3._3_Generic_Classes_Methods.Interfaces;
using Lab3._3_Generic_Classes_Methods.Models;

namespace Lab3._3_Generic_Classes_Methods.Services;

public class Repository<T> : IRepository<T> where T : Entity
{
    private readonly List<T> _items = new();

    public int Count => _items.Count;

    public T Add(T entity)
    {
        if (entity.Id == 0) entity.Id = IdCounter<T>.Next();
        _items.Add(entity);
        return entity;
    }

    public T? GetById(int id) => _items.FirstOrDefault(e => e.Id == id);
    public IReadOnlyList<T> GetAll() => _items.AsReadOnly();
    public IReadOnlyList<T> Find(Func<T, bool> predicate) => _items.Where(predicate).ToList();

    public bool Remove(int id)
    {
        var e = GetById(id);
        return e is not null && _items.Remove(e);
    }

    public bool Update(T entity)
    {
        var idx = _items.FindIndex(e => e.Id == entity.Id);
        if (idx < 0) return false;
        _items[idx] = entity;
        return true;
    }
}