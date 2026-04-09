using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;
using System.Text;
using vLink.Toon.Format;

namespace vLink.Toon.API.Formatters;

/// <summary>
/// ASP.NET Core output formatter for TOON response bodies.
/// </summary>
public sealed class ToonOutputFormatter : TextOutputFormatter
{
    /// <summary>
    /// The <c>text/toon</c> media type.
    /// </summary>
    public const string MediaTypeText = ToonMediaTypes.Text;

    /// <summary>
    /// The <c>application/toon</c> media type.
    /// </summary>
    public const string MediaTypeApplication = ToonMediaTypes.Application;

    /// <summary>
    /// Creates a TOON output formatter with UTF-8 support.
    /// </summary>
    public ToonOutputFormatter()
    {
        SupportedMediaTypes.Add(MediaTypeText);
        SupportedMediaTypes.Add(MediaTypeApplication);
        SupportedEncodings.Add(Encoding.UTF8);
    }

    /// <inheritdoc />
    protected override bool CanWriteType(Type? type) => type is not null;

    /// <inheritdoc />
    public override bool CanWriteResult(OutputFormatterCanWriteContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        if (!base.CanWriteResult(context))
        {
            return false;
        }

        if (IsToonMediaType(context.HttpContext.Response.ContentType))
        {
            return true;
        }

        if (IsToonMediaType(context.HttpContext.Request.ContentType))
        {
            return true;
        }

        var acceptHeaders = context.HttpContext.Request.GetTypedHeaders().Accept;
        var requestContentType = context.HttpContext.Request.ContentType;

        if (acceptHeaders != null && acceptHeaders.Count > 0)
        {
            return base.CanWriteResult(context);
        }

        // 2. No Accept header → fallback to request Content-Type
        if (!string.IsNullOrWhiteSpace(requestContentType))
        {
            if (requestContentType.StartsWith(MediaTypeText, StringComparison.OrdinalIgnoreCase) ||
                requestContentType.StartsWith(MediaTypeApplication, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }
        if (acceptHeaders is null)
        {
            return true;
        }

        if (acceptHeaders.Any(header => IsToonMediaType(header.MediaType)))
        {
            return true;
        }

        return acceptHeaders.Any(header => header.MediaType == "*/*");
    }

    /// <inheritdoc />
    public override async Task WriteResponseBodyAsync(
        OutputFormatterWriteContext context,
        Encoding selectedEncoding)
    {
        var encodeOptions = ResolveEncodeOptions(context.HttpContext.RequestServices);
        var toon = ToonEncoder.Encode(context.Object!, encodeOptions);
        await context.HttpContext.Response.WriteAsync(toon, selectedEncoding, context.HttpContext.RequestAborted);
    }

    private static bool IsToonMediaType(StringSegment mediaType)
        => mediaType.Equals(MediaTypeText, StringComparison.OrdinalIgnoreCase) || mediaType.Equals(MediaTypeApplication, StringComparison.OrdinalIgnoreCase);

    private static bool IsToonMediaType(string? mediaType)
        => !string.IsNullOrWhiteSpace(mediaType) &&
           (mediaType.StartsWith(MediaTypeText, StringComparison.OrdinalIgnoreCase) ||
            mediaType.StartsWith(MediaTypeApplication, StringComparison.OrdinalIgnoreCase));

    private static ToonEncodeOptions ResolveEncodeOptions(IServiceProvider services)
    {
        var serviceOptions = services.GetService<ToonServiceOptions>();
        if (serviceOptions is null)
        {
            return ToonEncoder.DefaultOptions;
        }

        return serviceOptions.Encode;
    }
}
