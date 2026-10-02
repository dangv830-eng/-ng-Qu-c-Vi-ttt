Đặng Quốc Việt-24810310611
BÀI KIỂM TRA SỐ 1
PHẦN LÝ THUYẾT

Câu1:
Value Types (Kiểu giá trị)

Vị trí lưu trữ: Giá trị thực sự của biến được lưu trực tiếp trên vùng nhớ Stack (hoặc lưu inline bên trong đối tượng trên Heap nếu biến đó là field của một class).

Cơ chế gán: Khi gán một biến Value Type cho biến khác, C# sẽ sao chép toàn bộ dữ liệu (copy by value). Hai biến hoàn toàn độc lập, thay đổi biến này không làm ảnh hưởng đến biến kia.

Quản lý bộ nhớ: Được quản lý tự động theo mô hình LIFO (Last In, First Out). Bộ nhớ của biến được giải phóng ngay lập tức khi phương thức chứa nó kết thúc hoặc biến đi ra khỏi phạm vi hoạt động (out of scope).

Khả năng chứa null: Mặc định không thể gán null (chỉ gán được khi sử dụng dạng Nullable Types như int?).

Các kiểu dữ liệu phổ biến: int, float, double, bool, char, struct, enum.

Reference Types (Kiểu tham chiếu)

Vị trí lưu trữ: Chia làm 2 phần:

Biến tham chiếu (Reference Pointer): Được lưu trên Stack, chỉ chứa địa chỉ ô nhớ.

Đối tượng thực sự (Data Object): Được cấp phát và lưu trữ trên vùng nhớ Heap.

Cơ chế gán: Khi gán một biến Reference Type cho biến khác, C# chỉ sao chép địa chỉ vùng nhớ (copy by reference). Cả hai biến cùng trỏ đến duy nhất một đối tượng trên Heap, nên thao tác chỉnh sửa dữ liệu qua biến này sẽ làm biến kia thay đổi theo.

Quản lý bộ nhớ: Được thu gom và giải phóng tự động bởi trình dọn rác Garbage Collector (GC) khi không còn biến tham chiếu nào trỏ đến đối tượng đó nữa.

Khả năng chứa null: Có thể chứa giá trị null (trạng thái biến tham chiếu chưa trỏ tới bất kỳ vùng nhớ nào trên Heap).

Các kiểu dữ liệu phổ biến: class, interface, delegate, object, string, array.

Câu2:
Sự khác nhau về cơ chế:

Thuộc tính có set thông thường: Cho phép gán hoặc thay đổi giá trị của thuộc tính bất kỳ lúc nào trong suốt vòng đời của đối tượng (sau khi khởi tạo vẫn có thể sửa giá trị bình thường).

Thuộc tính có init: Chỉ cho phép gán giá trị duy nhất một lần trong quá trình khởi tạo đối tượng (qua Constructor hoặc qua Object Initializer). Sau khi đối tượng hoàn tất khởi tạo, thuộc tính trở thành chỉ đọc (read-only) và không thể thay đổi giá trị.

Trường hợp sử dụng thực tế:

Khởi tạo đối tượng bất biến (Immutable Objects) linh hoạt: Giúp tạo ra các lớp DTO (Data Transfer Object) hoặc Data Models mà dữ liệu không bị thay đổi ngẫu nhiên sau khi khởi tạo, đồng thời vẫn cho phép dùng cú pháp Object Initializer (new Person { Id = 1, Name = "Alice" }) ngắn gọn thay vì phải tạo quá nhiều Constructor overload.

Xử lý dữ liệu định danh: Dùng cho các thuộc tính mang tính định danh hoặc cấu hình chỉ được phép thiết lập một lần lúc tạo object và cố định mãi mãi (ví dụ: Id của người dùng, CreatedAt lưu thời gian tạo, ConnectionString cấu hình hệ thống).

Câu3:
Phương thức virtual (Lớp cha)

Vai trò: Khai báo trên lớp cha để cho phép các lớp con có quyền thay đổi hoặc viết lại nội dung của phương thức này.

Đặc điểm: Bắt buộc phải có phần thân (implementation) chứa logic mặc định. Lớp con có thể chọn sử dụng luôn logic mặc định này (không ghi đè) hoặc viết lại theo nhu cầu.

Mục đích: Đóng vai trò là "chìa khóa" mở ra khả năng đa hình cho một phương thức cụ thể.

Phương thức override (Lớp con)

Vai trò: Khai báo trên lớp con để ghi đè (thay thế hoàn toàn) phần thân của phương thức virtual (hoặc abstract) đã được định nghĩa ở lớp cha.

Đặc điểm: Không thể tự nhiên sử dụng từ khóa override nếu lớp cha không có phương thức tương ứng được đánh dấu là virtual hoặc abstract. Phương thức override phải có cùng tên, cùng kiểu trả về và cùng danh sách tham số với phương thức ở lớp cha.

Mục đích: Cung cấp hành vi cụ thể, đặc trưng riêng cho đối tượng của lớp con.

Cơ chế hoạt động khi triển khai Đa hình (Late Binding / Dynamic Dispatch):
Sự khác biệt rõ nhất thể hiện lúc chạy chương trình (runtime). Khi bạn dùng một biến có kiểu của lớp cha để trỏ tới một đối tượng của lớp con, và gọi phương thức đó:

Chương trình sẽ bỏ qua logic mặc định của phương thức virtual ở lớp cha.

Nó tự động tìm và thực thi phương thức override tương ứng nằm trong lớp con. Điều này giúp các đối tượng khác nhau có thể phản hồi khác nhau với cùng một lời gọi hàm.

Câu4:
1. Quyền sở hữu (Sự khác biệt giữa Class và Instance)
Thành phần static thuộc về chính Lớp (Class) đó, chứ không thuộc về bất kỳ một đối tượng (Instance) cụ thể nào. Đối tượng được tạo ra bằng từ khóa new chỉ mang trong mình các thuộc tính và phương thức thông thường (non-static), đại diện cho trạng thái riêng của chính đối tượng đó.

2. Cơ chế cấp phát bộ nhớ

Với thành phần static: Khi chương trình chạy, hệ thống (CLR) chỉ cấp phát bộ nhớ cho thành phần này duy nhất một lần ngay khi class được nạp vào bộ nhớ, trước cả khi có bất kỳ đối tượng nào được tạo ra. Tất cả các đối tượng của class đó đều dùng chung một bản sao static này.

Với thành phần Instance (không static): Mỗi khi bạn dùng từ khóa new, hệ thống sẽ cấp phát một vùng nhớ hoàn toàn mới và riêng biệt cho đối tượng đó.

3. Thiết kế chặt chẽ của trình biên dịch C#
Mặc dù một số ngôn ngữ khác (như Java) cho phép gọi thành phần static qua object, nhưng C# thì nghiêm cấm hoàn toàn ở cấp độ trình biên dịch. Điều này được thiết kế có chủ đích nhằm:

Tránh gây nhầm lẫn: Nếu cho phép myObject.StaticProperty, lập trình viên có thể hiểu lầm rằng thuộc tính đó là của riêng myObject.

Thể hiện rõ ý nghĩa dòng code: Việc bắt buộc phải gọi qua tên lớp (Ví dụ: Math.PI thay vì myMath.PI) làm rõ ràng ngay lập tức với người đọc code rằng đây là một giá trị hoặc hành vi dùng chung cho toàn cục, thay đổi nó sẽ ảnh hưởng đến mọi đối tượng khác.
PHẦN ||:
