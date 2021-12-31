**Đồ án Social Network**

**Giới thiệu sơ lược về đồ án của nhóm:**
- Lời đầu tiên, nhóm em xin gửi lời chân thành cảm ơn đến trường Công Nghệ Thông Tin và khoa hệ thống thông tin đã tạo điều kiện cho nhóm em được tìm hiểu và học tập về môn *Xây dựng hệ thống thông tin trên các framework*. Đặc biệt, nhóm em xin gửi lời cảm ơn đến thầy **Vũ Minh Sang** và thầy **Nguyễn Minh Nhựt** đã trực tiếp hướng dẫn, định hướng chuyên môn, chia sẻ cho chúng em những kiến thức, nguồn tài liệu tham khảo cần thiết để chúng em hiểu rõ hơn về môn học và cách triển khai đồ án. Nhóm em đã tìm tòi và phát triển các được các chức năng mà một mạng xã hội cần có như đăng nhập, đăng xuất, đăng ký tài khoản, gửi lời mời kết bạn và xóa lời mời kết bạn (realtime), tìm kiếm người dùng trong hệ thống mạng xã hội, thông báo (realtime), thêm bình luận chỉnh sửa và xóa bình luận (realtime), react status (realtime), trò chuyện như gửi tin nhắn và video call qua lại giữa các người dùng, thêm ảnh xóa và chỉnh sửa ảnh, deploy hệ thống lên Heroku.

**Giới thiệu công nghệ mới mà đồ án đã sử dụng:**

- ReactJs: thư viện JavaScript được sử dụng để xây dựng các thành phần UI có thể tái sử dụng. Nhóm sử dụng để xây dựng giao diện font-end.

- SignalR: thư viện đơn giản hóa quá trình thêm chức năng web real-time trong phát triển ứng dụng. Nhóm sử dụng để tạo chức năng gửi tin nhắn qua lại giữa các người dùng trong hệ thống mạng xã hội. 

- Webrtc: là các API viết bằng javascript giúp giao tiếp theo thời gian thực mà không cần cài plugin hay phần mềm hỗ trợ, có khả năng hỗ trợ trình duyệt giao tiếp thời gian thực. Nhóm sử dụng để tạo một cuộc gọi điện video call giữa các người dùng trong hệ thống mạng xã hội.

- JSON WEB TOKEN: là một phương tiện đại diện cho các yêu cầu chuyển giao giữa hai bên Client – Server , các thông tin trong chuỗi JWT được định dạng bằng JSON. Nhóm sử dụng để thực hiện chức năng đăng nhập, đăng xuất và đăng ký một tài khoản trong hệ thống mạng xã hội.

- Firebase: một nền tảng để phát triển ứng dụng di động và trang web, bao gồm các API đơn giản và mạnh mẽ mà không cần backend hay server. Nhóm sử dụng để upload tất cả hình ảnh được sử dụng trong hệ thống mạng xã hội.

- Heroku: nền tảng đám mây cho phép các lập trình viên xây dựng, triển khai, quản lý và mở rộng ứng dụng. Nhóm sử dụng để triển khai sử dụng hệ thống mạng xã hội **_Social Network_** trong môi trường thực tế. Link heroku app : [social-network-uit](https://social-network-uit.herokuapp.com/)

**Giới thiệu Thành viên nhóm:**

- **Nguyễn Ngọc Khương Duy**, *MSSV*: 19520490, [địa chỉ facebook](https://www.facebook.com/duyastronomer), *số điện thoại*: 0338778642, *nhiệm vụ*: cân all

- **Trần Ngọc Giao**, *MSSV*: 19521451, [địa chỉ facebook](https://www.facebook.com/OumaShu159/), *số điện thoại*: 0963606075, *nhiệm vụ*: code frontend

- **Phó Khánh Hưng**, *MSSV*: 19520102, [địa chỉ facebook](https://www.facebook.com/profile.php?id=100007924638394), *số điện thoại*: 0963023236, *nhiệm vụ*: code frontend

- **Lê Anh Tuấn**, *MSSV*: 19520331, [địa chỉ facebook](https://www.facebook.com/TuanLeIsMe), *số điện thoại*: 0964393056, *nhiệm vụ*: cân all nhưng 50%

**Phần trăm đánh giá từng thành viên**

- *Nguyễn Ngọc Khương Duy*: 35%

- *Trần Ngọc Giao*: 15%

- *Phó Khánh Hưng*: 25%

- *Lê Anh Tuấn*: 25%

**Cài đặt chương trình Web:**

- Cài đặt cơ sở dữ liệu: **_SQL SEVER: MXH_FRAMEWORK.sql_**

- Thư viện kèm theo: 

1. **_ReactJs để xây dựng giao diện Font-end_**

2. **_ASP.NET CORE 5.0 để xây dựng hệ thống Backend_**

- Các bước chạy Front end, Backend: 

1. **_Front end_**

- Đầu tiên, truy cập vào [đường link github này](https://github.com/khuongduy172/framework_IS220.M11_7_FE) để copy link source code.

- Tiếp theo, bật **_Visual Studio Code_** lên và chạy lệnh `git clone https://github.com/khuongduy172/framework_IS220.M11_7_FE` trong *teminal* của visual studio code để *clone source* về máy. 

- Sau đó cd vào thư mục vừa clone về.

- Sau đó, chạy dòng lệnh `npm i` để cài đặt các gói *package* cần thiết để có thể chạy chương trình. 

- Cuối cùng chạy dòng lệnh `npm start` để mở hệ thống lên.

2. **_Backend_**

- Đầu tiên, truy cập vào [đường link github này](https://github.com/khuongduy172/framework_IS220.M11_7) để copy link source code.

- Tiếp theo, bật **_Visual Studio Code_** lên và chạy lệnh `git clone https://github.com/khuongduy172/framework_IS220.M11_7` trong *teminal* của visual studio code để *clone source* về máy. 

- Mở *SQL SEVER* lên và chạy file script **_MXH_framework.sql_** trong thư mục **_framework_IS220.M11_7_**, sau khi tạo database thành công thì kiểm tra kết nối *connection string* ở file **_appsetting.json_** sao cho phù hợp với môi trường trong máy cá nhân.   

- Tiếp đến, chạy câu lệnh `dotnet restore` để tải các thành phần liên quan cần thiết cho project.

- Trong trường hợp nếu có lỗi xảy ra khi thiếu các gói package thì tìm và cài đặt các gói package cần thiết: **_Microsoft.EntityFrameworkCore, Microsoft.Data.SqlClient,Microsoft.AspNetCore.Http,Microsoft.AspNetCore.Mvc_** trên .

- Cuối cùng, để chạy chương trình sử dụng câu lệnh `dotnet watch run`.

# Link deploy FE: https://social-network-is220.vercel.app/

# Quy trình code một tính năng
`git checkout local`

`git pull`

`git checkout -b <đặt tên branch hợp lý>`

ví dụ: authentication-tuanle

sau đó code trên branch vừa tạo

`git add .`

`git commit -m "đặt tên cho message hợp lý"`

`git push -u origin <tên branch mình đang code>`

- code xong nhớ viết docs swager
- đây chỉ là backend viết api cho frontend
- frontend sẽ có 1 repo khác


# Cài package 

`dotnet restore`

# Generate Model

`dotnet ef dbcontext scaffold "Data Source=localhost; Initial Catalog = MXH; Integrated Security=True" Microsoft.EntityFrameworkCore.SqlServer -o Models -c MXHContext`


