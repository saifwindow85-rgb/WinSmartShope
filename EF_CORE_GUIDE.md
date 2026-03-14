# دليل مفاهيم Entity Framework Core

---

## 📑 الفهرس

### الجزء الأول: المفاهيم المطبقة حالياً ✅
| # | المفهوم | الرابط |
|---|---------|--------|
| 1 | إعداد DbContext | [انتقل ←](#1-إعداد-dbcontext) |
| 2 | Fluent API Configuration | [انتقل ←](#2-fluent-api-configuration-ientitytypeconfiguration) |
| 3 | علاقات One-to-Many | [انتقل ←](#3-علاقات-one-to-many) |
| 4 | Navigation Properties | [انتقل ←](#4-navigation-properties) |
| 5 | Data Seeding | [انتقل ←](#5-data-seeding-hasdata) |
| 6 | Migrations | [انتقل ←](#6-migrations) |
| 7 | Repository Pattern | [انتقل ←](#7-repository-pattern) |
| 8 | Pagination | [انتقل ←](#8-pagination-الترقيم) |
| 9 | Projection (DTO) | [انتقل ←](#9-projection-select-to-dto) |
| 10 | AsNoTracking | [انتقل ←](#10-asnotracking-للقراءة-فقط) |
| 11 | Index Configuration | [انتقل ←](#11-index-configuration) |
| 12 | Auto-load Configurations | [انتقل ←](#12-auto-load-configurations) |
| 13 | Computed Properties | [انتقل ←](#13-computed-properties) |
| 14 | Enums | [انتقل ←](#14-enums) |

### الجزء الثاني: تمارين المفاهيم الجديدة 🎯
| # | التمرين | الصعوبة | الرابط |
|---|---------|---------|--------|
| 1 | Global Query Filters (Soft Delete) | ⭐⭐ | [انتقل ←](#تمرين-1-global-query-filters-soft-delete) |
| 2 | Include و ThenInclude (Eager Loading) | ⭐⭐ | [انتقل ←](#تمرين-2-include-و-theninclude-eager-loading) |
| 3 | Async Operations | ⭐⭐ | [انتقل ←](#تمرين-3-async-operations) |
| 4 | Transactions | ⭐⭐⭐ | [انتقل ←](#تمرين-4-transactions) |
| 5 | Concurrency (RowVersion) | ⭐⭐⭐ | [انتقل ←](#تمرين-5-concurrency-handling-rowversion) |
| 6 | Value Objects / Owned Types | ⭐⭐⭐ | [انتقل ←](#تمرين-6-value-objects--owned-types) |
| 7 | OnDelete Behaviors | ⭐⭐ | [انتقل ←](#تمرين-7-ondelete-behaviors) |
| 8 | Shadow Properties | ⭐⭐ | [انتقل ←](#تمرين-8-shadow-properties) |
| 9 | Computed Columns | ⭐⭐ | [انتقل ←](#تمرين-9-computed-columns-في-قاعدة-البيانات) |
| 10 | Interceptors | ⭐⭐⭐ | [انتقل ←](#تمرين-10-interceptors) |

### الجزء الثالث: سيناريوهات متقدمة 📊
| السيناريو | الرابط |
|-----------|--------|
| تقرير مبيعات معقد | [انتقل ←](#سيناريو-1-تقرير-مبيعات-معقد) |
| Raw SQL | [انتقل ←](#سيناريو-2-raw-sql-عند-الحاجة) |
| Batch Operations | [انتقل ←](#سيناريو-3-batch-operations) |
| Split Queries | [انتقل ←](#سيناريو-4-split-queries) |

### ملحقات 📚
- [ترتيب التعلم المقترح](#-ترتيب-التعلم-المقترح)
- [مصادر للتعلم](#-مصادر-للتعلم)

---

## 📋 نظرة عامة على المشروع

هذا المشروع يستخدم **Clean Architecture** مع **Entity Framework Core** وقاعدة بيانات **SQL Server**.

---

## ✅ المفاهيم المطبقة حالياً

### 1. إعداد DbContext
```csharp
// ✓ تم تطبيقه في: Infrastructure/DbContext/AppDbContext.cs

public class AppDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<AccountStatement> AccountStatements { get; set; }
    // ...
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connectionString);
    }
}
```

### 2. Fluent API Configuration (IEntityTypeConfiguration)
```csharp
// ✓ تم تطبيقه في: Infrastructure/Configurations/

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.FirstName).HasColumnType("NVARCHAR").HasMaxLength(50).IsRequired();
        // ...
    }
}
```

### 3. علاقات One-to-Many
```csharp
// ✓ Customer -> AccountStatements
builder.HasMany(x => x.AccountStatements)
       .WithOne(x => x.Customer)
       .HasForeignKey(x => x.CustomerId)
       .IsRequired();

// ✓ AccountStatement -> DebtPages
// ✓ DebtPage -> StatementItems
```

### 4. Navigation Properties
```csharp
// ✓ تم تطبيقه في: Domain/Entities/

public class Customer
{
    public ICollection<AccountStatement> AccountStatements { get; set; } = new List<AccountStatement>();
}

public class AccountStatement
{
    public Customer Customer { get; set; } = null!;
}
```

### 5. Data Seeding (HasData)
```csharp
// ✓ تم تطبيقه: بيانات تجريبية للعملاء وكشوف الحسابات
builder.HasData(
    new Customer { Id = 1, FirstName = "John", LastName = "Smith", ... }
);
```

### 6. Migrations
```
// ✓ تم تطبيقه: Infrastructure/Migrations/
// 20260310234350_InitialCreate.cs
```

### 7. Repository Pattern
```csharp
// ✓ تم تطبيقه في: Infrastructure/Repositories/

public class CustomerRepository : ICustomerRepository
{
    private readonly AppDbContext _context;
    
    public CustomerRepository(AppDbContext context)
    {
        _context = context;
    }
}
```

### 8. Pagination (الترقيم)
```csharp
// ✓ تم تطبيقه
query.OrderBy(c => c.Id)
     .Skip((pageNumber - 1) * PageSize)
     .Take(PageSize)
     .ToList();
```

### 9. Projection (Select to DTO)
```csharp
// ✓ تم تطبيقه
Expression<Func<Customer, CustomerDTO>> CustomerToDTO = c => new CustomerDTO
{
    Id = c.Id,
    FullName = c.FirstName + " " + c.LastName,
    // ...
};
```

### 10. AsNoTracking (للقراءة فقط)
```csharp
// ✓ تم تطبيقه
_context.Customers.AsNoTracking();
```

### 11. Index Configuration
```csharp
// ✓ تم تطبيقه
builder.HasIndex(x => x.AccountStatementID);
```

### 12. Auto-load Configurations
```csharp
// ✓ تم تطبيقه
modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
```

### 13. Computed Properties
```csharp
// ✓ تم تطبيقه (في الذاكرة فقط)
public decimal TotalAmount => DebtPages.Sum(x => x.TotalAmount);
```

### 14. Enums
```csharp
// ✓ تم تطبيقه في: Domain/Enums/Units.cs
public Units Unit { get; set; }
```

---

## 🎯 تمارين للمفاهيم الأساسية المتبقية

### تمرين 1: Global Query Filters (Soft Delete)
**الهدف:** تطبيق الحذف الناعم بدلاً من الحذف الفعلي

---

#### 🤔 ما هو Soft Delete؟

في معظم التطبيقات، **لا نحذف البيانات فعلياً** من قاعدة البيانات. بدلاً من ذلك:
- نضع علامة `IsDeleted = true`
- نخفي السجلات المحذوفة من الاستعلامات العادية
- نحتفظ بالبيانات للتدقيق أو الاسترجاع لاحقاً

---

#### ❌ المشكلة بدون Global Query Filter

```csharp
// بدون Filter، يجب إضافة الشرط كل مرة!
var activeCustomers = _context.Customers
    .Where(c => !c.IsDeleted)  // ❌ يجب تكرار هذا في كل استعلام!
    .ToList();

var orders = _context.Orders
    .Where(o => !o.IsDeleted)  // ❌ نسيت هذا؟ ستظهر بيانات محذوفة!
    .ToList();
```

---

#### ✅ الحل: Global Query Filter

**الخطوة 1:** أضف خصائص للكيان

```csharp
// Domain/Entities/DebtPage.cs
public class DebtPage
{
    public int Id { get; set; }
    // ... باقي الخصائص
    
    // ✅ أضف هذه الخصائص
    public bool IsDeleted { get; set; } = false;
    public DateTime? DeletedAt { get; set; }
}
```

---

**الخطوة 2:** أضف Filter في Configuration

```csharp
// Infrastructure/Configurations/DebtPageConfiguration.cs

public void Configure(EntityTypeBuilder<DebtPage> builder)
{
    // ... باقي الإعدادات
    
    // ✅ هذا السطر يخفي السجلات المحذوفة تلقائياً
    builder.HasQueryFilter(x => !x.IsDeleted);
}
```

---

**الخطوة 3:** طريقة الحذف الناعم

```csharp
// في Repository
public async Task SoftDeleteAsync(int id)
{
    var debtPage = await _context.DebtPages.FindAsync(id);
    if (debtPage != null)
    {
        debtPage.IsDeleted = true;
        debtPage.DeletedAt = DateTime.UtcNow;
        await _context.SaveChangesAsync();
    }
}
```

---

**الخطوة 4:** عند الحاجة لرؤية المحذوفات (للمدير مثلاً)

```csharp
// IgnoreQueryFilters يتجاوز الفلتر
var allDebtPages = await _context.DebtPages
    .IgnoreQueryFilters()  // ✅ يُظهر حتى المحذوفة
    .ToListAsync();

// استرجاع سجل محذوف
var deletedPage = await _context.DebtPages
    .IgnoreQueryFilters()
    .FirstOrDefaultAsync(x => x.Id == id);
    
deletedPage.IsDeleted = false;
deletedPage.DeletedAt = null;
await _context.SaveChangesAsync();
```

---

#### 💡 ملاحظة عن مشروعك

في `AppDbContext.cs` يوجد كود معلّق:
```csharp
// modelBuilder.Entity<DebtPage>().HasQueryFilter(x => !x.IsPaid);
```

هذا فلتر مختلف (لإخفاء المدفوعة، ليس المحذوفة). يمكنك تفعيله أو إضافة فلتر `IsDeleted`.

---

**📝 المطلوب منك:**
1. أضف `IsDeleted` و `DeletedAt` لـ `DebtPage`
2. أضف `HasQueryFilter` في `DebtPageConfiguration`
3. أنشئ method `SoftDeleteAsync` في Repository
4. اختبر الفلتر وتأكد أن السجلات المحذوفة لا تظهر

---

### تمرين 2: Include و ThenInclude (Eager Loading)
**الهدف:** جلب البيانات المرتبطة في استعلام واحد

---

#### 🤔 ما هو Eager Loading؟

في EF Core، عندما تجلب كيان (مثل Customer)، **البيانات المرتبطة لا تُجلب تلقائياً**.

---

#### ❌ المشكلة: N+1 Query Problem

```csharp
// ❌ هذا الكود سينتج استعلامات كثيرة جداً!
var customers = _context.Customers.ToList();  // استعلام 1

foreach (var customer in customers)
{
    // لكل عميل، استعلام إضافي! (إذا كان 100 عميل = 100 استعلام!)
    var statements = customer.AccountStatements;  // ستكون فارغة!
}
```

**لماذا فارغة؟** لأن EF Core افتراضياً يستخدم **Lazy Loading = false**

---

#### ✅ الحل: Eager Loading بـ Include

```csharp
// ✅ استعلام واحد يجلب كل شيء!
var customer = _context.Customers
    .Include(c => c.AccountStatements)  // جلب كشوف الحساب
    .FirstOrDefault(c => c.Id == customerId);

// الآن AccountStatements مليئة بالبيانات ✓
console.WriteLine(customer.AccountStatements.Count);
```

---

#### 🔗 جلب بيانات متداخلة بـ ThenInclude

```csharp
// جلب العميل + كشوفه + صفحات الديون + العناصر
var customer = _context.Customers
    .Include(c => c.AccountStatements)              // المستوى 1
        .ThenInclude(a => a.DebtPages)              // المستوى 2
            .ThenInclude(d => d.StatementItems)     // المستوى 3
    .FirstOrDefault(c => c.Id == customerId);

// ✅ الآن كل البيانات موجودة!
foreach (var statement in customer.AccountStatements)
{
    foreach (var page in statement.DebtPages)
    {
        foreach (var item in page.StatementItems)
        {
            Console.WriteLine(item.ItemName);
        }
    }
}
```

---

#### 📊 الفرق في SQL

**بدون Include:**
```sql
SELECT * FROM Customers WHERE Id = 1
-- فقط بيانات العميل
```

**مع Include:**
```sql
SELECT * FROM Customers c
LEFT JOIN AccountStatements a ON c.Id = a.CustomerId
LEFT JOIN DebtPages d ON a.Id = d.AccountStatementID
LEFT JOIN StatementItems s ON d.Id = s.DebtPageId
WHERE c.Id = 1
-- كل البيانات في استعلام واحد!
```

---

#### ⚠️ تحذير: لا تجلب أكثر مما تحتاج!

```csharp
// ❌ سيء - جلب كل شيء للقائمة فقط
var customers = _context.Customers
    .Include(c => c.AccountStatements)
        .ThenInclude(a => a.DebtPages)
            .ThenInclude(d => d.StatementItems)
    .ToList();  // بطيء جداً إذا كان هناك آلاف السجلات!

// ✅ أفضل - استخدم Select لجلب ما تحتاجه فقط
var customerList = _context.Customers
    .Select(c => new CustomerDTO
    {
        Id = c.Id,
        FullName = c.FirstName + " " + c.LastName,
        TotalStatements = c.AccountStatements.Count
    })
    .ToList();
```

---

**📝 المطلوب منك:**

1. أضف هذه الـ method في `CustomerRepository.cs`:

```csharp
public Customer? GetCustomerWithAllDetails(int customerId)
{
    return _context.Customers
        .Include(c => c.AccountStatements)
            .ThenInclude(a => a.DebtPages)
                .ThenInclude(d => d.StatementItems)
        .FirstOrDefault(c => c.Id == customerId);
}
```

2. أضف في `ICustomerRepository.cs`:
```csharp
Customer? GetCustomerWithAllDetails(int customerId);
```

---

### تمرين 3: Async Operations
**الهدف:** تحويل العمليات لتكون غير متزامنة

---

#### 🤔 لماذا Async؟

عند استخدام قاعدة البيانات:
- **Sync (متزامن):** التطبيق **يتوقف وينتظر** الرد من قاعدة البيانات ❌
- **Async (غير متزامن):** التطبيق **يكمل عمله** أثناء الانتظار ✅

**مثال بسيط:**
- Sync = تتصل بشخص وتنتظر على الخط حتى يرد
- Async = ترسل رسالة وتكمل عملك حتى يرد

---

#### 🔑 الكلمات المفتاحية

| الكلمة | المعنى |
|--------|--------|
| `async` | هذه الـ method قد تنتظر شيء |
| `await` | انتظر هنا حتى ينتهي |
| `Task` | وعد بإرجاع نتيجة لاحقاً |
| `Task<T>` | وعد بإرجاع قيمة من نوع T |

---

#### ❌ قبل (Sync)

```csharp
// الكود الحالي في CustomerRepository.cs
public List<CustomerDTO> FilterCustomers(int pageNumber, string value, 
    Expression<Func<Customer,bool>>? filterExpr, out int filterCount, int PageSize)
{
    IQueryable<Customer> query = _context.Customers.AsNoTracking();
    
    if(filterExpr != null)
    {
        query = query.Where(filterExpr);
    }
    filterCount = query.Count();  // ❌ يوقف التطبيق
    return query.OrderBy(c => c.Id)
        .Skip((pageNumber-1) * PageSize)
        .Take(PageSize)
        .Select(CustomerToDTO)
        .ToList();  // ❌ يوقف التطبيق
}
```

---

#### ✅ بعد (Async)

```csharp
// ملاحظة: لا يمكن استخدام out parameter مع async
// لذلك نُرجع tuple أو class جديد

public async Task<(List<CustomerDTO> Customers, int TotalCount)> FilterCustomersAsync(
    int pageNumber, 
    string value, 
    Expression<Func<Customer, bool>>? filterExpr, 
    int pageSize)
{
    IQueryable<Customer> query = _context.Customers.AsNoTracking();
    
    if (filterExpr != null)
    {
        query = query.Where(filterExpr);
    }
    
    // ✅ await يسمح للتطبيق بالاستمرار
    int filterCount = await query.CountAsync();
    
    var customers = await query
        .OrderBy(c => c.Id)
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .Select(CustomerToDTO)
        .ToListAsync();  // ✅ ToListAsync بدلاً من ToList
    
    return (customers, filterCount);
}
```

---

#### 📝 Methods الـ Async الشائعة

| Sync | Async |
|------|-------|
| `ToList()` | `ToListAsync()` |
| `FirstOrDefault()` | `FirstOrDefaultAsync()` |
| `SingleOrDefault()` | `SingleOrDefaultAsync()` |
| `Count()` | `CountAsync()` |
| `Any()` | `AnyAsync()` |
| `SaveChanges()` | `SaveChangesAsync()` |
| `Find()` | `FindAsync()` |

---

#### 🔧 كيف تستدعي Async method؟

```csharp
// في الـ Form أو Controller
private async void btnLoad_Click(object sender, EventArgs e)
{
    // await تنتظر النتيجة
    var result = await _customerRepository.FilterCustomersAsync(1, "", null, 10);
    
    dataGridView1.DataSource = result.Customers;
    lblTotal.Text = $"Total: {result.TotalCount}";
}
```

---

**📝 المطلوب منك:**

1. في `CustomerRepository.cs`، أضف:
```csharp
public async Task<(List<CustomerDTO> Customers, int TotalCount)> FilterCustomersAsync(...)
```

2. في `AccountStatementRepository.cs`، حوّل:
```csharp
public async Task<List<AccountStatmentsDTO>> LoadAccountStatementsAsync(...)
```

3. حدّث الـ Interfaces لتضيف الـ methods الجديدة

---

### تمرين 4: Transactions
**الهدف:** ضمان تنفيذ عدة عمليات كوحدة واحدة

---

#### 🤔 ما هي Transaction؟

**Transaction** = مجموعة عمليات **تنجح كلها أو تفشل كلها**.

**مثال من الحياة:**
- تحويل بنكي: سحب من حسابك + إيداع في حساب آخر
- إذا نجح السحب وفشل الإيداع = **كارثة!** 💀
- الـ Transaction تضمن: إما الاثنين ينجحان أو الاثنين يفشلان

---

#### ❌ المشكلة بدون Transaction

```csharp
// تخيل هذا السيناريو:
public async Task CreateCustomerWithStatementAsync()
{
    var customer = new Customer { FirstName = "أحمد" };
    _context.Customers.Add(customer);
    await _context.SaveChangesAsync();  // ✅ نجح - Id = 5
    
    var statement = new AccountStatement { CustomerId = customer.Id };
    _context.AccountStatements.Add(statement);
    await _context.SaveChangesAsync();  // ❌ فشل! (مثلاً انقطع الاتصال)
    
    // 💀 النتيجة: عميل بدون كشف حساب!
    // البيانات غير متسقة!
}
```

---

#### ✅ الحل: استخدام Transaction

```csharp
public async Task<bool> CreateCustomerWithStatementAsync()
{
    // 1. بدء الـ Transaction
    using var transaction = await _context.Database.BeginTransactionAsync();
    
    try
    {
        // 2. العملية الأولى
        var customer = new Customer 
        { 
            FirstName = "أحمد",
            SecondName = "محمد",
            LastName = "علي",
            Phone = "0501234567",
            Address = "الرياض"
        };
        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();
        // ⏳ البيانات محفوظة مؤقتاً (لم تُثبّت بعد)
        
        // 3. العملية الثانية
        var statement = new AccountStatement 
        { 
            CustomerId = customer.Id,  // الـ Id موجود الآن
            Description = "كشف حساب افتتاحي",
            CreatedAt = DateTime.Now
        };
        _context.AccountStatements.Add(statement);
        await _context.SaveChangesAsync();
        
        // 4. ✅ كل شيء نجح = Commit (تثبيت التغييرات)
        await transaction.CommitAsync();
        return true;
    }
    catch (Exception ex)
    {
        // 5. ❌ حدث خطأ = Rollback (إلغاء كل شيء)
        await transaction.RollbackAsync();
        Console.WriteLine($"خطأ: {ex.Message}");
        return false;
    }
}
```

---

#### 📊 ماذا يحدث داخلياً؟

```
BeginTransaction
    ├── INSERT Customer ──────────┐
    │                             │ معلّقة
    ├── INSERT AccountStatement ──┘
    │
    ├── إذا نجح الكل ── Commit ──→ ✅ البيانات تُحفظ فعلياً
    │
    └── إذا فشل أي شيء ── Rollback ──→ ❌ كأن شيء لم يحدث
```

---

#### 🎯 متى تستخدم Transactions؟

| الحالة | تحتاج Transaction؟ |
|--------|--------------------|
| إضافة عميل واحد | ❌ لا |
| إضافة عميل + كشف حساب | ✅ نعم |
| تحديث بيانات عميل | ❌ لا |
| نقل عنصر من صفحة دين لأخرى | ✅ نعم |
| حذف كشف حساب مع صفحاته | ✅ نعم |

---

#### 💡 نصيحة: SaveChanges تلقائياً Transaction!

```csharp
// هذا الكود آمن بدون Transaction صريح
// لأن SaveChanges يستخدم Transaction داخلياً
var customer = new Customer { FirstName = "أحمد" };
customer.AccountStatements.Add(new AccountStatement { Description = "كشف" });

_context.Customers.Add(customer);
await _context.SaveChangesAsync();  // ✅ Transaction ضمنية
```

**استخدم Transaction صريحة عندما:**
- تحتاج `SaveChanges` أكثر من مرة
- تريد التحقق من قيم (مثل Id) بين العمليات

---

**📝 المطلوب منك:**

1. أنشئ method جديدة في أي Repository:

```csharp
public async Task<bool> CreateCustomerWithStatementAsync(
    string firstName, string lastName, string phone, string address,
    string statementDescription)
{
    using var transaction = await _context.Database.BeginTransactionAsync();
    try
    {
        // أضف الكود هنا...
        await transaction.CommitAsync();
        return true;
    }
    catch
    {
        await transaction.RollbackAsync();
        return false;
    }
}
```

2. اختبرها بإضافة خطأ متعمد (مثل `throw new Exception()`) وتأكد أن البيانات لا تُحفظ

---

### تمرين 5: Concurrency Handling (RowVersion)
**الهدف:** التعامل مع التعديلات المتزامنة

---

#### 🤔 ما هي مشكلة Concurrency؟

**السيناريو:**
1. 👤 موظف (أ) يفتح كشف حساب رقم 5 للتعديل
2. 👤 موظف (ب) يفتح **نفس** كشف الحساب للتعديل
3. 👤 موظف (أ) يحفظ تعديلاته ✅
4. 👤 موظف (ب) يحفظ تعديلاته ✅

**المشكلة:** تعديلات موظف (أ) **ضاعت!** 💀

---

#### 🔑 الحل: RowVersion (أو Timestamp)

كل سجل يحمل "رقم إصدار". عند الحفظ:
- إذا تغير الرقم = شخص آخر عدّل قبلك ❌
- إذا لم يتغير = آمن للحفظ ✅

---

#### 📊 كيف يعمل؟

```
┌──────────────────────────────────────────────────────┐
│ الخطوة 1: موظف (أ) يقرأ السجل                        │
│ AccountStatement Id=5, Description="قديم"            │
│ RowVersion = 0x000001                                │
└──────────────────────────────────────────────────────┘
          ↓
┌──────────────────────────────────────────────────────┐
│ الخطوة 2: موظف (ب) يقرأ نفس السجل                    │
│ AccountStatement Id=5, Description="قديم"            │
│ RowVersion = 0x000001 (نفس الرقم)                    │
└──────────────────────────────────────────────────────┘
          ↓
┌──────────────────────────────────────────────────────┐
│ الخطوة 3: موظف (أ) يحفظ                              │
│ UPDATE ... WHERE Id=5 AND RowVersion=0x000001        │
│ ✅ نجح! RowVersion الآن = 0x000002                   │
└──────────────────────────────────────────────────────┘
          ↓
┌──────────────────────────────────────────────────────┐
│ الخطوة 4: موظف (ب) يحاول الحفظ                       │
│ UPDATE ... WHERE Id=5 AND RowVersion=0x000001        │
│ ❌ فشل! الرقم تغير إلى 0x000002                      │
│ DbUpdateConcurrencyException 🚨                      │
└──────────────────────────────────────────────────────┘
```

---

#### ✅ التطبيق خطوة بخطوة

**الخطوة 1:** أضف الخاصية للكيان

```csharp
// Domain/Entities/AccountStatement.cs

using System.ComponentModel.DataAnnotations;  // ← لا تنس هذا!

public class AccountStatement
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    // ... باقي الخصائص
    
    // ✅ أضف هذا
    [Timestamp]
    public byte[] RowVersion { get; set; } = null!;
}
```

---

**الخطوة 2:** أو بـ Fluent API (أفضل)

```csharp
// Infrastructure/Configurations/AccountStatementConfiguration.cs

public void Configure(EntityTypeBuilder<AccountStatement> builder)
{
    // ... باقي الإعدادات
    
    // ✅ أضف هذا
    builder.Property(x => x.RowVersion)
        .IsRowVersion();  // SQL Server يدير هذا تلقائياً
}
```

---

**الخطوة 3:** أضف Migration

```powershell
cd Infrastructure
dotnet ef migrations add AddRowVersion
dotnet ef database update
```

---

**الخطوة 4:** التعامل مع الخطأ

```csharp
public async Task<bool> UpdateAccountStatementAsync(AccountStatmentsDTO dto)
{
    var statement = await _context.AccountStatements.FindAsync(dto.Id);
    if (statement == null) return false;
    
    statement.Description = dto.Description;
    statement.IsClosed = dto.IsClosed;
    
    try
    {
        await _context.SaveChangesAsync();
        return true;
    }
    catch (DbUpdateConcurrencyException)
    {
        // ❌ شخص آخر عدّل قبلك!
        
        // الخيار 1: أخبر المستخدم
        MessageBox.Show("تم تعديل هذا السجل من شخص آخر. يرجى إعادة تحميل البيانات.");
        
        // الخيار 2: إعادة تحميل وإعادة المحاولة
        // await _context.Entry(statement).ReloadAsync();
        
        return false;
    }
}
```

---

#### 💡 متى تستخدم RowVersion؟

| الحالة | تحتاج RowVersion؟ |
|--------|-------------------|
| تطبيق Desktop لمستخدم واحد | ❌ لا |
| تطبيق Desktop لعدة مستخدمين | ✅ نعم |
| تطبيق Web | ✅ نعم (غالباً) |
| بيانات للقراءة فقط | ❌ لا |

---

**📝 المطلوب منك:**

1. أضف `RowVersion` لـ `AccountStatement`
2. أضف `IsRowVersion()` في Configuration
3. أضف Migration وحدّث قاعدة البيانات
4. أنشئ method تتعامل مع `DbUpdateConcurrencyException`

---

### تمرين 6: Value Objects / Owned Types
**الهدف:** تجميع الخصائص المرتبطة في كائن واحد بدلاً من تفريقها

---

#### 🤔 ما هو Value Object؟

**Value Object** (أو Owned Type في EF Core) هو كائن **ليس له هوية خاصة به** (Id)، 
بل يعتمد على الكيان الأب. مثلاً: العنوان ليس كيان مستقل، بل هو **جزء من العميل**.

---

#### ❌ المشكلة: الطريقة الحالية

حالياً في مشروعك، `Address` عبارة عن `string` واحد:

```csharp
// Domain/Entities/Customer.cs - الوضع الحالي
public class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string Address { get; set; }  // ← string واحد فقط!
}
```

**المشاكل:**
- ❌ لا يمكن البحث عن عملاء حسب المدينة
- ❌ لا يمكن التحقق من صحة أجزاء العنوان بشكل منفصل
- ❌ الكود غير منظم

---

#### ✅ الحل: استخدام Value Object

**الخطوة 1:** أنشئ class جديد للعنوان (في مجلد `Domain/ValueObjects/`)

```csharp
// أنشئ ملف جديد: Domain/ValueObjects/Address.cs

namespace Domain.ValueObjects
{
    public class Address
    {
        // الخصائص - لاحظ: لا يوجد Id!
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        
        // Constructor فارغ (مطلوب لـ EF Core)
        public Address() { }
        
        // Constructor للإنشاء السهل
        public Address(string street, string city, string country)
        {
            Street = street;
            City = city;
            Country = country;
        }
        
        // للعرض الجميل
        public override string ToString() => $"{Street}, {City}, {Country}";
    }
}
```

---

**الخطوة 2:** عدّل كيان Customer

```csharp
// Domain/Entities/Customer.cs

using Domain.ValueObjects;

public class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string SecondName { get; set; } = null!;
    public string? ThirdName { get; set; }
    public string LastName { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string? Email { get; set; }
    
    // ✅ بدلاً من string Address، الآن كائن Address
    public Address Address { get; set; } = new Address();
}
```

---

**الخطوة 3:** عدّل Configuration

```csharp
// Infrastructure/Configurations/CustomerConfiguration.cs

public void Configure(EntityTypeBuilder<Customer> builder)
{
    builder.HasKey(x => x.Id);
    builder.Property(x => x.Id).ValueGeneratedOnAdd();
    
    // باقي الخصائص...
    builder.Property(x => x.FirstName)...
    
    // ❌ احذف هذا السطر القديم:
    // builder.Property(x => x.Address).HasColumnType("NVARCHAR").HasMaxLength(100).IsRequired();
    
    // ✅ استبدله بـ OwnsOne:
    builder.OwnsOne(c => c.Address, addressBuilder =>
    {
        // كل خاصية في Address ستصبح عمود في جدول Customers
        addressBuilder.Property(a => a.Street)
            .HasColumnName("Address_Street")      // اسم العمود في DB
            .HasColumnType("NVARCHAR")
            .HasMaxLength(100)
            .IsRequired();
            
        addressBuilder.Property(a => a.City)
            .HasColumnName("Address_City")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(50)
            .IsRequired();
            
        addressBuilder.Property(a => a.Country)
            .HasColumnName("Address_Country")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(50)
            .IsRequired();
    });
    
    builder.ToTable("Customers");
}
```

---

**الخطوة 4:** أضف Migration

```powershell
# في Terminal
cd Infrastructure
dotnet ef migrations add AddAddressValueObject
dotnet ef database update
```

---

#### 📊 كيف سيبدو الجدول في قاعدة البيانات؟

**قبل (عمود واحد):**
| Id | FirstName | Address |
|----|-----------|---------|
| 1 | John | New York |

**بعد (3 أعمدة):**
| Id | FirstName | Address_Street | Address_City | Address_Country |
|----|-----------|----------------|--------------|-----------------|
| 1 | John | 123 Main St | New York | USA |

---

#### 💡 كيف تستخدمه في الكود؟

```csharp
// إنشاء عميل جديد
var customer = new Customer
{
    FirstName = "أحمد",
    LastName = "محمد",
    Address = new Address("شارع الملك فهد", "الرياض", "السعودية")
};

// البحث عن عملاء في مدينة معينة
var customersInRiyadh = await _context.Customers
    .Where(c => c.Address.City == "الرياض")
    .ToListAsync();

// تعديل العنوان
customer.Address.City = "جدة";
await _context.SaveChangesAsync();
```

---

#### 🎯 متى تستخدم Value Objects؟

| استخدم Value Object | استخدم Entity عادي |
|---------------------|-------------------|
| العنوان (Address) | العميل (Customer) |
| المال (Money: Amount + Currency) | الفاتورة (Invoice) |
| نطاق التاريخ (DateRange: Start + End) | الحجز (Reservation) |
| الإحداثيات (Coordinates: Lat + Long) | الموقع (Location) |

**القاعدة:** إذا الكائن **ليس له معنى لوحده** بدون الكيان الأب = Value Object

---

**📝 المطلوب منك:**
1. أنشئ مجلد `Domain/ValueObjects/`
2. أنشئ ملف `Address.cs` كما في الأعلى
3. عدّل `Customer.cs`
4. عدّل `CustomerConfiguration.cs`
5. أضف Migration وحدّث قاعدة البيانات

---

### تمرين 7: OnDelete Behaviors
**الهدف:** تحديد سلوك الحذف للعلاقات

---

#### 🤔 ماذا يحدث عند حذف الأب؟

عندما تحذف `Customer`، ماذا يحدث لـ `AccountStatements` المرتبطة؟

---

#### 📊 خيارات DeleteBehavior

| السلوك | الوصف | مثال |
|--------|-------|------|
| `Cascade` | حذف الأبناء تلقائياً | حذف العميل → حذف كل كشوفه |
| `Restrict` | منع الحذف إذا كان له أبناء | لا يمكن حذف عميل له كشوف |
| `SetNull` | تعيين Foreign Key = null | حذف العميل → AccountStatement.CustomerId = null |
| `NoAction` | لا شيء (قد يسبب خطأ) | خطر! ⚠️ |

---

#### 💡 أي سلوك أستخدم؟

```csharp
// 🔴 Cascade - حذف كل شيء مرتبط (خطر!)
// استخدمه فقط إذا كنت متأكداً
builder.HasMany(x => x.AccountStatements)
       .WithOne(x => x.Customer)
       .HasForeignKey(x => x.CustomerId)
       .OnDelete(DeleteBehavior.Cascade);

// 🟢 Restrict - الخيار الآمن
// يمنع حذف العميل إذا كان له كشوف حسابات
builder.HasMany(x => x.AccountStatements)
       .WithOne(x => x.Customer)
       .HasForeignKey(x => x.CustomerId)
       .OnDelete(DeleteBehavior.Restrict);
```

---

#### 🎯 توصيات لمشروعك

```csharp
// Customer → AccountStatements
// ✅ Restrict: لا تسمح بحذف عميل له كشوف حسابات
.OnDelete(DeleteBehavior.Restrict);

// AccountStatement → DebtPages
// ⚠️ Cascade أو Restrict حسب متطلباتك
// Cascade: حذف الكشف يحذف كل صفحاته
.OnDelete(DeleteBehavior.Cascade);

// DebtPage → StatementItems
// ✅ Cascade: حذف الصفحة يحذف كل عناصرها
.OnDelete(DeleteBehavior.Cascade);
```

---

**📝 المطلوب منك:**
1. راجع كل العلاقات في ملفات Configuration
2. أضف `OnDelete()` المناسب لكل علاقة
3. أضف Migration وحدّث قاعدة البيانات

---

### تمرين 8: Shadow Properties
**الهدف:** إضافة خصائص للتتبع بدون إضافتها للكيان

---

#### 🤔 ما هي Shadow Properties؟

خصائص **موجودة في قاعدة البيانات** لكن **غير موجودة في الـ Entity class**.

**لماذا تستخدمها؟**
- للتتبع (CreatedAt, ModifiedBy)
- للحفاظ على نظافة الـ Domain Model
- الـ Entity لا يحتاج يعرف عنها

---

#### ✅ التطبيق

**الخطوة 1:** أضف في Configuration

```csharp
// Infrastructure/Configurations/CustomerConfiguration.cs

public void Configure(EntityTypeBuilder<Customer> builder)
{
    // ... باقي الإعدادات
    
    // ✅ Shadow Properties - غير مرئية في Customer class
    builder.Property<DateTime>("CreatedAt")
        .HasDefaultValueSql("GETDATE()");
        
    builder.Property<DateTime?>("LastModifiedAt");
    
    builder.Property<string>("CreatedBy")
        .HasMaxLength(100);
}
```

---

**الخطوة 2:** القراءة والكتابة

```csharp
// 📖 قراءة Shadow Property
var customer = await _context.Customers.FindAsync(1);
var createdAt = _context.Entry(customer).Property<DateTime>("CreatedAt").CurrentValue;

// ✏️ كتابة Shadow Property
_context.Entry(customer).Property("LastModifiedAt").CurrentValue = DateTime.UtcNow;
_context.Entry(customer).Property("CreatedBy").CurrentValue = "Admin";
await _context.SaveChangesAsync();
```

---

**الخطوة 3:** أتمتة في DbContext

```csharp
// Infrastructure/DbContext/AppDbContext.cs

public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
{
    foreach (var entry in ChangeTracker.Entries())
    {
        if (entry.State == EntityState.Added)
        {
            entry.Property("CreatedAt").CurrentValue = DateTime.UtcNow;
            entry.Property("CreatedBy").CurrentValue = "System"; // أو اسم المستخدم
        }
        
        if (entry.State == EntityState.Modified)
        {
            entry.Property("LastModifiedAt").CurrentValue = DateTime.UtcNow;
        }
    }
    
    return await base.SaveChangesAsync(cancellationToken);
}
```

---

**📝 المطلوب منك:**
1. أضف `CreatedAt`, `LastModifiedAt`, `CreatedBy` كـ Shadow Properties
2. أضف Logic في `SaveChangesAsync` لتعبئتها تلقائياً
3. أضف Migration وحدّث قاعدة البيانات

---

### تمرين 9: Computed Columns (في قاعدة البيانات)
**الهدف:** حساب القيم في SQL بدلاً من C#

---

#### 🤔 الفرق بين Computed Property و Computed Column

| | Computed Property (C#) | Computed Column (SQL) |
|--|------------------------|----------------------|
| مكان الحساب | في التطبيق | في قاعدة البيانات |
| أداء | يحسب كل مرة | محسوب مسبقاً |
| يمكن الفلترة عليه | ❌ لا | ✅ نعم |
| مثال | `get => x + y` | `HasComputedColumnSql` |

---

#### ❌ الوضع الحالي (Computed Property)

```csharp
// Domain/Entities/Customer.cs
public class Customer
{
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string? ThirdName { get; set; }
    public string LastName { get; set; }
    
    // ❌ يُحسب في C# - لا يمكن البحث عليه بكفاءة
    public string FullName => $"{FirstName} {SecondName} {ThirdName} {LastName}";
}

// ❌ هذا يجلب كل العملاء ثم يفلتر في الذاكرة!
var customers = _context.Customers
    .Where(c => c.FullName.Contains("أحمد"))  // لن يعمل بشكل صحيح!
    .ToList();
```

---

#### ✅ الحل: Computed Column

**الخطوة 1:** عدّل الكيان

```csharp
// Domain/Entities/Customer.cs
public class Customer
{
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string? ThirdName { get; set; }
    public string LastName { get; set; }
    
    // ✅ خاصية عادية - القيمة تأتي من DB
    public string FullName { get; private set; }  // private set = للقراءة فقط
}
```

---

**الخطوة 2:** أضف في Configuration

```csharp
// Infrastructure/Configurations/CustomerConfiguration.cs

builder.Property(x => x.FullName)
    .HasComputedColumnSql(
        "CONCAT([FirstName], ' ', [SecondName], ' ', COALESCE([ThirdName], ''), ' ', [LastName])",
        stored: true  // يُخزن في DB = أسرع للقراءة
    );
```

---

**الخطوة 3:** الآن يمكنك البحث بكفاءة!

```csharp
// ✅ البحث يحدث في SQL مباشرة
var customers = await _context.Customers
    .Where(c => c.FullName.Contains("أحمد"))
    .ToListAsync();
```

---

**📝 المطلوب منك:**
1. عدّل `Customer.FullName` ليكون `{ get; private set; }`
2. أضف `HasComputedColumnSql` في Configuration
3. أضف Migration (سيحذف العمود ويُنشئه من جديد)
4. اختبر البحث على `FullName`

---

### تمرين 10: Interceptors
**الهدف:** اعتراض العمليات (Logging, Auditing)

---

#### 🤔 ما هو Interceptor؟

**Interceptor** = كود ينفذ **قبل أو بعد** عمليات قاعدة البيانات.

**استخدامات:**
- تسجيل كل العمليات (Logging)
- تتبع التغييرات (Auditing)
- تعديل الاستعلامات قبل تنفيذها
- قياس الأداء

---

#### ✅ التطبيق خطوة بخطوة

**الخطوة 1:** أنشئ ملف Interceptor

```csharp
// Infrastructure/Interceptors/AuditInterceptor.cs

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Infrastructure.Interceptors
{
    public class AuditInterceptor : SaveChangesInterceptor
    {
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
            DbContextEventData eventData,
            InterceptionResult<int> result,
            CancellationToken cancellationToken = default)
        {
            if (eventData.Context == null) 
                return base.SavingChangesAsync(eventData, result, cancellationToken);
            
            var context = eventData.Context;
            
            foreach (var entry in context.ChangeTracker.Entries())
            {
                var entityName = entry.Entity.GetType().Name;
                
                switch (entry.State)
                {
                    case EntityState.Added:
                        Console.WriteLine($"[AUDIT] ➕ إضافة {entityName}");
                        break;
                        
                    case EntityState.Modified:
                        Console.WriteLine($"[AUDIT] ✏️ تعديل {entityName}");
                        
                        // طباعة الخصائص المتغيرة
                        foreach (var prop in entry.Properties
                            .Where(p => p.IsModified))
                        {
                            Console.WriteLine(
                                $"        {prop.Metadata.Name}: " +
                                $"'{prop.OriginalValue}' → '{prop.CurrentValue}'");
                        }
                        break;
                        
                    case EntityState.Deleted:
                        Console.WriteLine($"[AUDIT] 🗑️ حذف {entityName}");
                        break;
                }
            }
            
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}
```

---

**الخطوة 2:** سجّل الـ Interceptor في DbContext

```csharp
// Infrastructure/DbContext/AppDbContext.cs

protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    base.OnConfiguring(optionsBuilder);
    
    var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
    var connectionString = config.GetSection("constr").Value;
    
    optionsBuilder.UseSqlServer(connectionString);
    
    // ✅ أضف هذا السطر
    optionsBuilder.AddInterceptors(new AuditInterceptor());
}
```

---

**الخطوة 3:** اختبره

```csharp
// أي عملية SaveChanges ستطبع في Console
var customer = await _context.Customers.FindAsync(1);
customer.FirstName = "محمد";
await _context.SaveChangesAsync();

// Output:
// [AUDIT] ✏️ تعديل Customer
//         FirstName: 'أحمد' → 'محمد'
```

---

#### 🎯 فكرة متقدمة: حفظ في جدول Audit

```csharp
// أنشئ كيان للتتبع
public class AuditLog
{
    public int Id { get; set; }
    public string EntityName { get; set; }
    public string Action { get; set; }  // Add, Update, Delete
    public string Changes { get; set; }  // JSON
    public DateTime Timestamp { get; set; }
    public string UserName { get; set; }
}
```

---

**📝 المطلوب منك:**
1. أنشئ مجلد `Infrastructure/Interceptors/`
2. أنشئ `AuditInterceptor.cs`
3. سجّله في `AppDbContext`
4. اختبره بإجراء عمليات وتأكد من الطباعة

---

## 📊 سيناريوهات متقدمة للتمرين

### سيناريو 1: تقرير مبيعات معقد
```csharp
// استعلام يجمع المبيعات حسب الشهر والعميل
var report = await _context.StatementItems
    .GroupBy(si => new { 
        si.DebtPage.AccountStatement.Customer.FullName,
        Month = si.DebtPage.CreatedAt.Month 
    })
    .Select(g => new {
        CustomerName = g.Key.FullName,
        Month = g.Key.Month,
        TotalSales = g.Sum(x => x.Total)
    })
    .ToListAsync();
```

### سيناريو 2: Raw SQL عند الحاجة
```csharp
// استعلام SQL مباشر
var customers = await _context.Customers
    .FromSqlRaw("SELECT * FROM Customers WHERE Phone LIKE '%077%'")
    .ToListAsync();

// Stored Procedure
var result = await _context.Database
    .ExecuteSqlRawAsync("EXEC UpdateCustomerStatus @p0, @p1", customerId, status);
```

### سيناريو 3: Batch Operations
```csharp
// EF Core 7+ ExecuteUpdate
await _context.AccountStatements
    .Where(a => a.IsClosed && !a.IsPaid)
    .ExecuteUpdateAsync(s => s.SetProperty(a => a.IsPaid, true));

// EF Core 7+ ExecuteDelete
await _context.StatementItems
    .Where(si => si.DebtPage.IsPaid)
    .ExecuteDeleteAsync();
```

### سيناريو 4: Split Queries
```csharp
// تقسيم الاستعلام لتحسين الأداء
var customers = await _context.Customers
    .Include(c => c.AccountStatements)
    .AsSplitQuery()
    .ToListAsync();
```

---

## 📚 ترتيب التعلم المقترح

| الأولوية | المفهوم | السبب |
|---------|---------|-------|
| 1 | Async Operations | ضروري لأي تطبيق حديث |
| 2 | Include/ThenInclude | أكثر الأخطاء شيوعاً (N+1 Problem) |
| 3 | Transactions | ضروري للعمليات المتعددة |
| 4 | Global Query Filters | مفيد جداً للـ Soft Delete |
| 5 | Concurrency | مهم للتطبيقات متعددة المستخدمين |
| 6 | Value Objects | تحسين تصميم الكيانات |
| 7 | Interceptors | للـ Auditing والـ Logging |
| 8 | Raw SQL | للاستعلامات المعقدة |

---

## 🔗 مصادر للتعلم

- [Microsoft EF Core Docs](https://docs.microsoft.com/ef/core/)
- [EF Core in Action (Book)](https://www.manning.com/books/entity-framework-core-in-action)

---

> **ملاحظة:** كل تمرين يمكن تطبيقه بشكل مستقل. ابدأ بالأولويات العليا ثم انتقل للمتقدمة.
