# Quy trình code một tính năng
`git checkout local`

`git pull`

`git checkout -b <đặt tên branch hợp lý>`

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
