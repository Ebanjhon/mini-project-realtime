# Base image chính thức của MinIO
FROM quay.io/minio/minio:latest

# Port mặc định
EXPOSE 9000 9001

# Thư mục lưu data
VOLUME ["/data"]

# Command khởi động MinIO
CMD ["server", "/data", "--console-address", ":9001"]

# docker run -d --name minio -p 9000:9000 -p 9001:9001 -e MINIO_ROOT_USER=admin -e MINIO_ROOT_PASSWORD=3B@n12345 -v minio_data:/data minio-storage
