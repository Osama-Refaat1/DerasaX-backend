using AutoMapper;
using DerasaX.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Application.Services.Image.GenericResolver
{
    public class GenericPictureUrlResolver<TSource, TDestination> : IValueResolver<TSource, TDestination, string> where TSource : class, IHasImageUrl
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string _imageFolderPath;

        public GenericPictureUrlResolver(IHttpContextAccessor httpContextAccessor, string imageFolderPath)
        {
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
            _imageFolderPath = imageFolderPath ?? throw new ArgumentNullException(nameof(imageFolderPath));
        }

        public string Resolve(TSource source, TDestination destination, string destMember, ResolutionContext context)
        {
            if (source == null || string.IsNullOrEmpty(source.ImageUrl))
            {
                return string.Empty;
            }

            var request = _httpContextAccessor.HttpContext?.Request;
            if (request == null)
            {
                return source.ImageUrl; // Return the original URL if the request is not available
            }

            var baseUrl = $"{request.Scheme}://{request.Host}";
            return $"{baseUrl}/Images/{_imageFolderPath}/{source.ImageUrl}"; // Construct the full URL for the image
        }
    }
}
