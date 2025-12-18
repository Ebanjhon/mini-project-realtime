using Amazon.S3;
using Amazon.S3.Model;
using PointOfSale.Api.Models;
using Microsoft.AspNetCore.Http;

namespace PointOfSale.Api.Services
{
    public class S_Minio
    {
        private readonly IAmazonS3 _s3Client;
        private readonly IConfiguration _config;

        public S_Minio(IAmazonS3 s3Client, IConfiguration config)
        {
            _s3Client = s3Client;
            _config = config;
        }

        public async Task<List<M_Image>> UploadImages(List<IFormFile> images)
        {
            var bucket = _config["MinIO:Bucket"];
            var endpoint = "http://localhost:9000";

            var result = new List<M_Image>();

            foreach (var file in images)
            {
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

                using var stream = file.OpenReadStream();

                await _s3Client.PutObjectAsync(new PutObjectRequest
                {
                    BucketName = bucket,
                    Key = fileName,
                    InputStream = stream,
                    ContentType = file.ContentType
                });

                result.Add(new M_Image
                {
                    IsActive = true,
                    ImageUrl = $"{endpoint}/{bucket}/{fileName}"
                });
            }

            return result;
        }

    }
}
