# mini-project-realtime

# How to run project

## Backend sử dụng công nghệ ASP.Net, Sql-server, MinIo
tại thư mục gốc có chứa file docker-compose
- dùng lệnh: `docker-compose up -d` để chạy toàn bộ các servcie
### Sql-Server
- có thể sử dụng mySQLServer, Azura data studio...
- sau đó đăng nhập với thông tin sau: localhost,1433, user: sa, password: 3Ban@12345

tiếp đến tạo database, trong project này sử dụng tên là PosDatabase
------------------------------
CREATE DATABASE PosDatabase;
GO
------------------------------
### MinIo
- trong docker bấm truy cập đường dẫn của minIo đang chạy.
- đăng nhập với user: admin, password: 3B@n12345 và tạo bucket với name: pos-storage, và chuyện polify sang public
### ASP.Net web API
- sử dụng IDE Visual code, mở source project và mở package manager console để tiến hành migration
(chú ý) vì migration ở ngoài docker nên hãy chuyển `sqlserver` thành `localhost` ở appsetting.json trước rồi migration, khi migration xong trả lại appsetting.json như cũ
### create migration `dotnet ef migrations add name-migration` 
### run migration `dotnet ef database update`

## Frontend sử dụng công nghệ ReactJS
di chuyển đến thư mục app-pos-realtime
- B1: build dự án chạy lệnh # `npm run build`
- B2: chạy project dùng lệnh # `npm start` hoặc cài yarn chạy và chạy #`yarn start`

## Hình ảnh về sản phẩm

![Sản phẩm 1](/ImageAppPreview/image-preview-1.png)

![Sản phẩm 2](/ImageAppPreview/image-preview-2.png)

![Sản phẩm 3](/ImageAppPreview/image-preview-3.png)
