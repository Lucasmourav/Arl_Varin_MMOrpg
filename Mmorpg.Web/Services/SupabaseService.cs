using Supabase;
using Supabase.Gotrue;
using Supabase.Storage;
using Postgrest;
using Postgrest.Models;
using Supabase.Interfaces;
using Supabase.Storage.Interfaces;

namespace Mmorpg.Web.Services;

public class SupabaseService
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<SupabaseService> _logger;
    private readonly Supabase.Client _client;
    private const string SupabaseUrlKey = "Supabase:Url";
    private const string SupabaseKeyKey = "Supabase:Key";
    private const string SupabaseBucket = "alvarin";

    public SupabaseService(IConfiguration configuration, ILogger<SupabaseService> logger)
    {
        _configuration = configuration;
        _logger = logger;

        var url = _configuration[SupabaseUrlKey];
        var key = _configuration[SupabaseKeyKey];

        if (string.IsNullOrEmpty(url) || string.IsNullOrEmpty(key))
        {
            _logger.LogError("Supabase URL ou Key não configurados no appsettings.json");
            throw new InvalidOperationException("Supabase não configurado corretamente.");
        }

        var options = new SupabaseOptions
        {
            AutoConnectRealtime = true
        };

        _client = new Supabase.Client(url, key, options);
    }

    public Supabase.Client GetClient() => _client;
    
    public ISupabaseTable<T, Supabase.Realtime.RealtimeChannel> From<T>() where T : BaseModel, new() => _client.From<T>();
    
    public IStorageFileApi<Supabase.Storage.FileObject> StorageBucket => _client.Storage.From(SupabaseBucket);

    public async Task InitializeAsync()
    {
        try
        {
            await _client.InitializeAsync();
            _logger.LogInformation("Cliente Supabase inicializado com sucesso");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao inicializar o cliente Supabase");
            throw;
        }
    }
}
